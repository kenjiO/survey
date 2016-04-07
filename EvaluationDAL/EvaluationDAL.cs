using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.DAL
{
    /// <summary>
    /// Database Access Layer for evaluations database
    /// </summary>
    public partial class EvaluationDAL : IEvaluationDAL
    {
        const int SELF_EVALUATION_ROLE_ID = 1;
        const int SUPERVISOR_ROLE_ID = 2;
        const int COWORKER_ROLE_ID = 3;

        public List<OpenEvaluation> GetOpenSelfEvaluations(int employeeId)
        {
            List<OpenEvaluation> results = new List<OpenEvaluation>();

            int cohortId = GetEmployeeCohortId(employeeId);
            // if no cohort, no self-evaluations
            if (cohortId == 0)
            {
                return results;
            }
            String selectStatement =   
                        "SELECT * FROM EvaluationScheduleView this " +
                        "WHERE startDate <= GETDATE() " +
                        "  AND endDate >= GETDATE() " +
                        "  AND cohortId = @cohortId " +
                        "  AND NOT EXISTS(SELECT * FROM evaluations " +
                        "                  WHERE employeeId = @employeeId " +
                        "                    AND typeId = this.typeId " +
                        "                    AND stageId = this.stageId " +
                        "                    AND completionDate IS NOT NULL)";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@cohortId", cohortId);
                    selectCommand.Parameters.AddWithValue("@employeeId", employeeId);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(CreateOpenEvaluation(reader, null, employeeId, SELF_EVALUATION_ROLE_ID));
                        }
                    }
                }
            }
            return results;
        }

        public List<OpenEvaluation> GetOpenPeerEvaluations(int employeeId)
        {
            List<OpenEvaluation> results = new List<OpenEvaluation>();

            String selectStatement =
                    "SELECT ev.evaluationId, es.scheduleId, ev.employeeId, ev.roleId, ty.typeName, st.stageName, es.startDate, es.endDate " +
                    "  FROM evaluations ev " +
                    "  LEFT JOIN employee em ON (em.employeeId = ev.employeeId) " +
                    "  LEFT JOIN evaluation_schedule es ON (es.cohortId = em.cohortId AND es.typeId = ev.typeId AND es.stageId = ev.stageId) " +
                    "  LEFT JOIN type ty ON (ty.typeId = ev.typeId) " +
                    "  LEFT JOIN stage st ON (st.stageId = ev.stageId) " +
                    "  WHERE ev.evaluator = @employeeId " +
                    "    AND ev.roleId != 1 " +
                    "    AND ev.completionDate IS NULL " +
                    "    AND es.startDate <= GETDATE() " +
                    "    AND es.endDate >= GETDATE()";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@employeeId", employeeId);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(CreateOpenEvaluation(reader, (int)reader["evaluationId"], (int)reader["employeeId"], (int)reader["roleId"]));
                        }
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Create an OpenEvaluation record from a reader record
        /// </summary>
        /// <param name="reader">SQL reader</param>
        /// <param name="employeeId">employee being evaluated</param>
        /// <param name="roleId">Role of evaluator</param>
        /// <returns>OpenEvaluation record</returns>
        private OpenEvaluation CreateOpenEvaluation(SqlDataReader reader, int? evaluationId, int employeeId, int roleId)
        {
            return new OpenEvaluation(evaluationId, (int)reader["scheduleId"], GetEmployeeName(employeeId).FullName, 
                            roleId, GetRoleName(roleId), reader["typeName"].ToString(), reader["stageName"].ToString(), 
                            (DateTime)reader["startDate"],  (DateTime)reader["endDate"]);                                    
        }

        /// <summary>
        /// Check to see if the current employee has started an evaluation for a given schedule
        /// </summary>
        /// <param name="employeeId">Employee to initialize evaluation for</param>
        /// <param name="scheduleId">The scheduleID for the evaluation</param>
        /// <returns>EvaluationId of self evaluation, or 0 if not started</returns>
        public int IsSelfEvaluationStarted(int employeeId, int scheduleId)
        {
            string selectStatement =
                "SELECT ev.evaluationId " +
                "FROM evaluation_schedule es " +
                " JOIN evaluations ev ON (ev.typeId = es.typeId AND ev.stageId = es.stageId) " +
                "WHERE es.scheduleId = @scheduleId " +
                "  AND ev.employeeId = @employeeId " +
                "  AND ev.evaluator = @employeeId";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@employeeId", employeeId);
                    selectCommand.Parameters.AddWithValue("@scheduleId", scheduleId);
                    Object result = selectCommand.ExecuteScalar();
                    if (result == null)
                    {
                        return 0;
                    }
                    return (int)result; 
                }
            }
        }

        /// <summary>
        /// Creates a self-evaluation, supervisor evaluation and co-worker evaluation 
        ///  for a given employee and schedule
        /// THROWS custom exception 'CreateEvaluationsException' for errors when preconditions not met
        /// Precondition: SupervisorId is set for currentEmployee
        /// Precondition: coworkerId is in the DB and not the supervisor or admin
        /// Precondition: Evaluations for currentEmployee for given schedule does not exist
        /// Precondition: Schedule exist in the DB
        /// </summary>
        /// <param name="employeeId">Employee to initialize evaluation for</param>
        /// <param name="scheduleId">The scheduleID for the evaluation</param>
        /// <param name="coworkerId">Co-worker selected to evaluate this employee</param>
        /// <returns>Evaluation id of self evaluation created</returns>
        public int InitializeSelfEvaluation(int employeeId, int scheduleId, int coworkerId)
        {
            int supervisorId;
            int typeId;
            int stageId;
            int evaluationId;

            if (employeeId == coworkerId)
            {
                throw new ArgumentException("Co-worker must be different than employee");
            }

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();
                //
                // Get typeId and stageId for these evaluations
                //
                String selectTypeAndStageCommand = "SELECT typeId, stageId FROM evaluation_schedule WHERE scheduleId = @scheduleId";
                using (SqlCommand command = new SqlCommand(selectTypeAndStageCommand, connection))
                {
                    command.Parameters.AddWithValue("@scheduleId", scheduleId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            throw new CreateEvaluationException("Evaluation schedule, " + scheduleId + ", not found");
                        }
                        typeId = (int)reader["typeId"];
                        stageId = (int)reader["stageId"];
                    }
                }


                // Check employee is in DB and has a supervisor
                string selectStatement =
                    "SELECT employeeId, supervisorId " +
                    "FROM employee " +
                    "WHERE EmployeeId = @employeeId";
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (DBNull.Value.Equals(reader["supervisorId"]))
                                throw new CreateEvaluationException("Supervisor not set for employee");
                            else
                                supervisorId = (int)reader["supervisorId"];
                        }
                        else
                        {
                            throw new CreateEvaluationException("EmployeeId not found in the database");
                        }
                    }

                    //Check co-worker is not same as supervisor
                    if (coworkerId == supervisorId)
                    {
                        throw new CreateEvaluationException("Co-worker cannot be the supervisor");
                    }
                }

                //Check co-worker is a valid non-admin employee
                selectStatement =
                    "SELECT employeeId, isAdmin " +
                    "FROM employee " +
                    "WHERE EmployeeId = @employeeId";
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", coworkerId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if ((bool)(reader["isAdmin"]))
                                throw new CreateEvaluationException("Co-worker must not be an admin");
                        }
                        else
                        {
                            throw new CreateEvaluationException("Coworker Id not found in the database");
                        }
                    }
                }

                // Check if any evals for type and stage already exist
                selectStatement =
                    "SELECT evaluationId " +
                    "FROM evaluations " +
                    "WHERE EmployeeId = @employeeId AND typeId = @typeId AND stageId = @stageId";
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@typeId", typeId);
                    command.Parameters.AddWithValue("@stageId", stageId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            throw new CreateEvaluationException("An evaluation for this employee, type, stage already exists");
                        }
                    }
                }

                // Use a transaction to add self, supervisor and co-worker evaluations
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertStatement =
                            "INSERT INTO evaluations " +
                            "(employeeId, stageId, typeId, evaluator, roleId) " +
                            "VALUES (@employeeId, @stageId, @typeId, @evaluator, @roleId)";
                        using (SqlCommand command = new SqlCommand(insertStatement, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@employeeId", employeeId);
                            command.Parameters.AddWithValue("@typeId", typeId);
                            command.Parameters.AddWithValue("@stageId", stageId);
                            command.Parameters.AddWithValue("@evaluator", employeeId);
                            command.Parameters.AddWithValue("@roleId", SELF_EVALUATION_ROLE_ID);
                            int result1 = command.ExecuteNonQuery();
                            if (result1 < 1)
                            {
                                transaction.Rollback();
                                throw new CreateEvaluationException("Problem creating self evaluation. No evaluations created");
                            }

                            // get ident and set evaluationid
                            command.Parameters.Clear();
                            command.CommandText = "SELECT IDENT_CURRENT('evaluations');";
                            evaluationId = Convert.ToInt32(command.ExecuteScalar());

                            // Reset paramaters to run again for supervisor evaluation
                            command.Parameters.Clear();
                            command.CommandText = insertStatement;
                            command.Parameters.AddWithValue("@employeeId", employeeId);
                            command.Parameters.AddWithValue("@typeId", typeId);
                            command.Parameters.AddWithValue("@stageId", stageId);
                            command.Parameters.AddWithValue("@evaluator", supervisorId);
                            command.Parameters.AddWithValue("@roleId", SUPERVISOR_ROLE_ID);
                            int result2 = command.ExecuteNonQuery();
                            if (result2 < 1)
                            {
                                transaction.Rollback();
                                throw new CreateEvaluationException("Problem adding supervisor evaluation. No evaluations created");
                            }

                            // Reset paramaters to run again for co-worker evaluation
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@employeeId", employeeId);
                            command.Parameters.AddWithValue("@typeId", typeId);
                            command.Parameters.AddWithValue("@stageId", stageId);
                            command.Parameters.AddWithValue("@evaluator", coworkerId);
                            command.Parameters.AddWithValue("@roleId", COWORKER_ROLE_ID);
                            int result3 = command.ExecuteNonQuery();
                            if (result3 < 1)
                            {
                                transaction.Rollback();
                                throw new CreateEvaluationException("Problem adding co-worker evaluation. No evaluations created");
                            }

                            transaction.Commit();
                        }
                    } // end try
                    catch (SqlException ex)
                    {
                        if (transaction != null)
                            transaction.Rollback();

                        //Error 547 is a foreign key violation. Since emp, supervisor and co-worker
                        //have been checked they are not causing it. So it must be stage or type.
                        if (ex.Errors[0].Number == 547)
                        {
                            throw new CreateEvaluationException("Invalid type or stage");
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                } // end using transaction
            } //end using connection
            return evaluationId;
        }

        /// <summary>
        /// Get Details required to show an evaluation form
        /// </summary>
        /// <param name="_evaluationId">the id of the evaluation</param>
        /// <returns>EvaluationDetails object</returns>
        public EvaluationDetails getEvaluationDetails(int evaluationId)
        {
            EvaluationDetails evaluationDetails;
            int employeeId = 0;
            int typeId = 0;
            string typeName = null;
            int categoryCount = 0;
            int answerRange = 0;
            
            string selectStatement = "SELECT e.employeeId, ev.typeId, t.typeName, t.answerRange " +
                                     "FROM evaluations ev " +
                                     "JOIN employee e ON e.employeeId = ev.employeeId " +
                                     "JOIN type t ON t.typeId = ev.typeId " +
                                     "WHERE evaluationId = @evaluationId ";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@evaluationId", evaluationId);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            throw new NoRecordsFoundException("This evaluation does not exist.");
                        }
                        else
                        {
                            employeeId = (int)reader["employeeId"];
                            typeId = (int)reader["typeId"];
                            typeName = (string)reader["typeName"];
                            answerRange = (int)reader["answerRange"];                            
                        }
                    }
                }

                string getCategoryCountStatement = "SELECT count(c.categoryId) as categoriesPerType " +
                                     "FROM category c " +
                                     "WHERE c.typeId = @typeId ";

                using (SqlCommand selectCommand = new SqlCommand(getCategoryCountStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@typeId", typeId);

                    Object result = selectCommand.ExecuteScalar();
                    if (result == null)
                    {
                        throw new NoRecordsFoundException("There are no categories for this type.");
                    }
                    categoryCount = (int)result;
                }

                evaluationDetails = new EvaluationDetails(employeeId, typeId, typeName, answerRange, categoryCount);

            }
            return evaluationDetails;
        }

        /// <summary>
        /// Gets a list of questions and answers for an evaluation record
        /// </summary>
        /// <param name="evaluationId">id of the evaluation</param>
        /// <returns>list of QAndA objects</returns>
        public List<QAndA> GetQuestionsAndAnswers(int evaluationId)
        {
            List<QAndA> list = new List<QAndA>();
            int typeId = 0;            

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                string getTypeIdStatement = "SELECT typeId " +
                                     "FROM evaluations " +
                                     "WHERE evaluationId = @evaluationId ";

                using (SqlCommand selectCommand = new SqlCommand(getTypeIdStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@evaluationId", evaluationId);

                    Object result = selectCommand.ExecuteScalar();
                    if (result == null)
                    {
                        throw new NoRecordsFoundException("This evaluation does not exist.");
                    }
                    typeId = (int)result;
                }

                String selectStatement =
                    "SELECT q.questionId, c.categoryName,  q.question, a.answerId, a.answer " +
                    "  FROM question q " +
                    "  JOIN category c on q.categoryId = c.categoryId " +
                    "  LEFT JOIN answer a on a.questionId = q.questionId and a.evaluationId = @evaluationId " +
                    "  WHERE q.typeid =  @typeId";

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@evaluationId", evaluationId);
                    selectCommand.Parameters.AddWithValue("@typeId", typeId);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int answerId;
                            int answer;
                            if (reader["answerId"] == DBNull.Value) 
                            { 
                                answerId = 0; 
                            }
                            else
                            {
                                answerId = (int)reader["answerId"];
                            }
                            if (reader["answer"] == DBNull.Value)
                            {
                                answer = 0;
                            }
                            else
                            {
                                answer = (int)reader["answer"];                               
                            }
                            
                            list.Add(new QAndA(evaluationId, (int)reader["questionId"], (string)reader["categoryName"], (string)reader["Question"], answerId, answer));
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Creates a new answer record in the database
        /// </summary>
        /// <param name="_evaluationId">id of the evaluation</param>
        /// <param name="questionId">id of the question</param>
        /// <param name="answer">id of the answer</param>
        /// <returns>answerId of the newly created row, else throws exception</returns>
        public int CreateNewAnswerRecord(int evaluationId, int questionId, int answer)
        {
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                string insertStatement =
                            "INSERT INTO answer " +
                            "(evaluationId, questionId, answer) " +
                            "VALUES (@evaluationId, @questionId, @answer)";

                using (SqlCommand command = new SqlCommand(insertStatement, connection))
                {
                    command.Parameters.AddWithValue("@evaluationId", evaluationId);
                    command.Parameters.AddWithValue("@questionId", questionId);
                    command.Parameters.AddWithValue("@answer", answer);
                    int count = command.ExecuteNonQuery();
                    if (count < 1)
                    {
                        throw new InsertException("Answer could not be saved to the database.");
                    }
                    else
                    {
                        // get ident and set answerId
                        command.Parameters.Clear();
                        command.CommandText = "SELECT IDENT_CURRENT('answer');";
                        int answerId = Convert.ToInt32(command.ExecuteScalar());
                        return answerId;
                    }
                    
                }
                
            }

        }

        /// <summary>
        /// Saves an answer in the database
        /// </summary>
        /// <param name="answerId">id of record to update</param>
        /// <param name="newAnswer">the new answer</param>
        public void SaveAnswer(int answerId, int newAnswer)
        {
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                string updateStatement =
                            "UPDATE answer " +
                            "SET answer = @newAnswer " +
                            "WHERE answerId = @answerId";

                using (SqlCommand command = new SqlCommand(updateStatement, connection))
                {
                    command.Parameters.AddWithValue("@answerId", answerId);
                    command.Parameters.AddWithValue("@newAnswer", newAnswer);
                    int count = command.ExecuteNonQuery();
                    if (count < 1)
                    {
                        throw new NoRecordsFoundException("The answer could not be updated.");
                    }
                }
            }
        }

        /// <summary>
        /// Updates completionDate of an evaluation in the database.
        /// </summary>
        /// <throws>Exception if not successful</throws>
        /// <param name="_evaluationId">evaluationId of the evaluation to close</param>
        public void CloseEvaluation(int evaluationId)
        {
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                string updateStatement =
                            "UPDATE evaluations " +
                            "SET completionDate = GETDATE() " +
                            "WHERE evaluationId = @evaluationId";

                using (SqlCommand command = new SqlCommand(updateStatement, connection))
                {
                    command.Parameters.AddWithValue("@evaluationId", evaluationId);
                    int count = command.ExecuteNonQuery();
                    if (count < 1)
                    {
                        throw new NoRecordsFoundException("The completion date/time could not be updated.");
                    }
                }
            }
        }
 
    }

    /// <summary>
    /// Exception used for when errors occur in createEvaluations()
    /// </summary>
    [Serializable]
    public class CreateEvaluationException : Exception
    {
        public CreateEvaluationException() { }
        public CreateEvaluationException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception used for when errors occur in inserting db records
    /// </summary>
    [Serializable]
    public class InsertException : Exception
    {
        public InsertException() { }
        public InsertException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception used for when errors occur in accessing db records
    /// </summary>
    [Serializable]
    public class NoRecordsFoundException : Exception
    {
        public NoRecordsFoundException() { }
        public NoRecordsFoundException(string message) : base(message) { }
    }
}
