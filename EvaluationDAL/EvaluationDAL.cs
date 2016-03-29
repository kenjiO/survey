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
        public bool isSelfEvaluationStarted(int employeeId, int typeId, int stageId)
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

        public List<OpenEvaluation> getOpenSelfEvaluations(int employeeId)
        {
            List<OpenEvaluation> results = new List<OpenEvaluation>();

            // TODO: get scheduled evaluations that are complete or in progress and open
            return results;
        }

        public List<OpenEvaluation> getOpenOtherEvaluations(int employeeId)
        {
            List<OpenEvaluation> results = new List<OpenEvaluation>();

            // TODO: get evaluations we need to do for others that are still open
            return results;
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
        public void createEvaluations(int empId, int typeId, int stageId, int coworkerId)
        {
            int supervisorId;
            if (empId == coworkerId)
                throw new ArgumentException("Co-worker must be different than employee");
            SqlConnection connection = EvaluationDB.GetConnection();
            connection.Open();

            // Check employee is in DB and has a supervisor
            string selectStatement =
                "SELECT employeeId, supervisorId " +
                "FROM employee " +
                "WHERE EmployeeId = @employeeId";
            SqlCommand command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@EmployeeId", empId);
            SqlDataReader reader = command.ExecuteReader();
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
            reader.Close();

            //Check co-worker is not same as supervisor
            if (coworkerId == supervisorId)
            {
                throw new CreateEvaluationException("Co-worker cannot be the supervisor");
            }

            //Check co-worker is a valid non-admin employee
            selectStatement =
                "SELECT employeeId, isAdmin " +
                "FROM employee " +
                "WHERE EmployeeId = @employeeId";
            command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@EmployeeId", coworkerId);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                if ((bool)(reader["isAdmin"]))
                    throw new CreateEvaluationException("Co-worker must not be an admin");
            }
            else
            {
                throw new CreateEvaluationException("Coworker Id not found in the database");
            }
            reader.Close();

            // Check if any evals for type and stage already exist
            selectStatement =
                "SELECT evaluationId " +
                "FROM evaluations " +
                "WHERE EmployeeId = @employeeId AND typeId = @typeId AND stageId = @stageId";
            command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@EmployeeId", empId);
            command.Parameters.AddWithValue("@typeId", typeId);
            command.Parameters.AddWithValue("@stageId", stageId);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                throw new CreateEvaluationException("An evaluation for this employee, type, stage already exists");
            }
            reader.Close();

            // Use a transaction to add self, supervisor and co-worker evaluations
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                string insertStatement =
                    "INSERT INTO evaluations " +
                    "(employeeId, stageId, typeId, evaluator, roleId) " +
                    "VALUES (@employeeId, @stageId, @typeId, @evaluator, @roleId)";
                command = new SqlCommand(insertStatement, connection, transaction);
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
