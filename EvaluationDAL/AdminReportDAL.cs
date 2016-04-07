using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Evaluation.DAL
{
    public partial class EvaluationDAL : IEvaluationDAL
    {
        public List<UserReport> GetUserReport(int employeeId, int typeId, int stageId)
        {
            // TODO: Query user report data from SQL
            return null;
        }

        public List<CohortReport> GetCohortReport(int cohortId, int typeId)
        {
            List<CohortReport> reportDataPoints = new List<CohortReport>();

            string selectStatement =
                "SELECT s.stageName, c.categoryName,                                           " +
                "    COUNT(CASE WHEN a.answer >= 3 THEN 1 ELSE NULL END) as proficientAnswers, " +
                "    COUNT(a.answerId) as totalAnswers,                                        " +
                "    ROUND(                                                                    " +
                "           (                                                                  " +
                "             COUNT(CASE WHEN a.answer >= 3 THEN 1 ELSE NULL END)              " +
                "             * 100.0                                                          " +
                "             /                                                                " +
                "             COUNT(a.answerId)                                                " +
                "           )                                                                  " +
                "           , 0                                                                " +
                "    ) as percentProficient                                                     " +
                "FROM answer a                                                                 " +
                "JOIN evaluations ev ON a.evaluationId = ev.evaluationId                       " +
                "JOIN employee em ON em.employeeId = ev.employeeId                             " +
                "JOIN question q ON q.questionId = a.questionId                                " +
                "JOIN category c ON c.categoryId = q.categoryId                                " + 
                "JOIN stage s On s.stageId = ev.stageId                                        " +
                "WHERE ev.employeeId = ev.evaluator                                            " +
                "    AND em.cohortId = @cohortId AND ev.typeId = @typeId                       " +
                "GROUP BY s.stageName, c.categoryName                                          ";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@cohortId", cohortId);
                    selectCommand.Parameters.AddWithValue("@typeId", typeId);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string stage = reader["stageName"].ToString();
                            string category = reader["categoryName"].ToString();
                            int proficientAnswers = (int) reader["proficientAnswers"];
                            int totalAnswers = (int) reader["totalAnswers"];
                            decimal percentProficient = (decimal) reader["percentProficient"];
                            CohortReport report = new CohortReport(stage, category, percentProficient);
                            reportDataPoints.Add(report);
                        }
                    }
                }
            }
            return reportDataPoints;
        }
    }

}
