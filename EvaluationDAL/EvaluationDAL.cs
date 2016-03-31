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

        /// <summary>
        /// Check if a self-evaluation for an employee, type and stage has been started
        /// </summary>
        /// <param name="employeeId">employeeId for the self-evaluation</param>
        /// <param name="typeId">The evaluation typeId</param>
        /// <param name="stageId">The evaluation stageId</param>
        public bool IsSelfEvaluationStarted(int employeeId, int typeId, int stageId)
        {
            string selectStatement =
                "SELECT evaluationId " +
                "FROM evaluations " +
                "WHERE typeId = @typeId " +
                "  AND stageId = @stageId " +
                "  AND employeeId = @employeeId " +
                "  AND evaluator = @employeeId";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@employeeId", employeeId);
                    selectCommand.Parameters.AddWithValue("@typeId", typeId);
                    selectCommand.Parameters.AddWithValue("@stageId", stageId);
                    return (selectCommand.ExecuteScalar() != null);
                }
            }
        }

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
                            results.Add(CreateOpenEvaluation(reader, employeeId, SELF_EVALUATION_ROLE_ID));
                        }
                    }
                }
            }
            return results;
        }

        private OpenEvaluation CreateOpenEvaluation(SqlDataReader reader, int employeeId, int roleId)
        {
            return new OpenEvaluation( (int)reader["scheduleId"], GetEmployeeName(employeeId).FullName, roleId, GetRoleName(roleId),
                            reader["typeName"].ToString(), reader["stageName"].ToString(), (DateTime)reader["startDate"], 
                            (DateTime)reader["endDate"]);                                    
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
                            results.Add(createOpenEvaluation(reader, (int)reader["employeeId"], (int)reader["roleId"]));
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
        private OpenEvaluation createOpenEvaluation(SqlDataReader reader, int employeeId, int roleId)
        {
            return new OpenEvaluation((int)reader["evaluationId"], (int)reader["scheduleId"], getEmployeeName(employeeId).fullName, 
                            roleId, getRoleName(roleId), reader["typeName"].ToString(), reader["stageName"].ToString(), 
                            (DateTime)reader["startDate"],  (DateTime)reader["endDate"]);                                    
        }

        /// <summary>
        /// Create the self, supervisor and co-worker evaluations in the database
        /// Precondition: Supervisor is set for employee
        /// Precondition: Co-worker is not the supervisor
        /// Precondition: Co-worker is different then employee
        /// Precondition: Evaluations for type and stage are not created yet for this employee
        /// Precondition: Type and Stage are valid 
        /// </summary>
        /// <param name="empId">Employee who the evaluations are for</param>
        /// <param name="typeId">Type Id of evaluation to create</param>
        /// <param name="stageId">StageId of evaluation to create</param>
        /// <param name="coworkerId">Co-worker's employeeId</param>
        public void CreateEvaluations(int empId, int typeId, int stageId, int coworkerId)
        {
            int supervisorId;
            if (empId == coworkerId)
                throw new ArgumentException("Co-worker must be different than employee");

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                // Check employee is in DB and has a supervisor
                string selectStatement =
                    "SELECT employeeId, supervisorId " +
                    "FROM employee " +
                    "WHERE EmployeeId = @employeeId";
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", empId);
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
                    command.Parameters.AddWithValue("@EmployeeId", empId);
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
                            command.Parameters.AddWithValue("@employeeId", empId);
                            command.Parameters.AddWithValue("@typeId", typeId);
                            command.Parameters.AddWithValue("@stageId", stageId);
                            command.Parameters.AddWithValue("@evaluator", empId);
                            command.Parameters.AddWithValue("@roleId", SELF_EVALUATION_ROLE_ID);
                            int result1 = command.ExecuteNonQuery();
                            if (result1 < 1)
                            {
                                transaction.Rollback();
                                throw new CreateEvaluationException("Problem creating self evaluation. No evaluations created");
                            }

                            // Reset paramaters to run again for supervisor evaluation
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@employeeId", empId);
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
                            command.Parameters.AddWithValue("@employeeId", empId);
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

                        if (ex.Errors[0].Number == 547) // Assume the interesting stuff is in the first error
                        {
                            //Error 547 is a foreign key violation. Since emp, supervisor and co-worker
                            //have been checked they are not causing it. So it must be stage or type.
                            if (ex.Errors[0].Number == 547)
                            {
                                throw new CreateEvaluationException("Invalid type or stage");
                            }
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                } // end using transaction
            } //end using connection
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
}
