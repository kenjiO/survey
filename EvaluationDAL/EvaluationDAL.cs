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
                    Object result = selectCommand.ExecuteScalar();
                    return (selectCommand.ExecuteScalar() != null);
                }
            }
        }

        public List<Evaluations> getOpenSelfEvaluations(int employeeId)
        {
            List<Evaluations> results = new List<Evaluations>();

            // TODO: Finish
            return results;
        }

        public List<Evaluations> getOpenOtherEvaluations(int employeeId)
        {
            List<Evaluations> results = new List<Evaluations>();

            // TODO: Finish
            return results;
        }

        public DateTime getEndDateForSchedule(int typeId, int stageId, int? cohortId)
        {
            // TODO: Finish
            return DateTime.Now;
        }

        public List<OpenEvaluation> getOpenSelfEvaluations_New(int employeeId)
        {
            List<OpenEvaluation> results = new List<OpenEvaluation>();

            // TODO: Finish
            return results;
        }

        public List<OpenEvaluation> getOpenOtherEvaluations_New(int employeeId)
        {
            List<OpenEvaluation> results = new List<OpenEvaluation>();

            // TODO: Finish
            return results;
        }

    }
}
