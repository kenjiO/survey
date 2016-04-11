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
            List<UserReport> reportData = new List<UserReport>();

            string testStatement =
                "SELECT evaluationId " +
                "  FROM evaluations  " +
                " WHERE typeId = @typeId " +
                "   AND stageId = @stageId " +
                "   AND completionDate IS NOT NULL " +
                "   AND employeeId = @employeeId " +
                "   AND roleId = 1";

            string selectStatement =
                "SELECT c.categoryName, q.questionNo, COALESCE(a_s.answer,'0') AS 'self', COALESCE(a_sup.answer,'0') AS supervisor, COALESCE(a_cw.answer,'0') AS coworker " +
                "  FROM question q                                                                                              " +
                "  LEFT JOIN category c ON (c.categoryId = q.categoryId)                                                        " +
                "  LEFT JOIN evaluations ev_s ON (ev_s.typeId = @typeId AND ev_s.stageId = @stageId                             " +
                "              AND ev_s.completionDate IS NOT NULL AND ev_s.employeeId = @employeeId AND ev_s.roleId = 1)       " +
                "  LEFT JOIN evaluations ev_sup ON (ev_sup.typeId = @typeId AND ev_sup.stageId = @stageId                       " +
                "              AND ev_sup.completionDate IS NOT NULL AND ev_sup.employeeId = @employeeId AND ev_sup.roleId = 2) " +
                "  LEFT JOIN evaluations ev_cw ON (ev_cw.typeId = @typeId AND ev_cw.stageId = @stageId                          " +
                "              AND ev_cw.completionDate IS NOT NULL AND ev_cw.employeeId = @employeeId AND ev_cw.roleId = 3)    " +
                "  LEFT JOIN answer a_s ON (a_s.evaluationId = ev_s.evaluationId AND a_s.questionId = q.questionId)             " +
                "  LEFT JOIN answer a_sup ON (a_sup.evaluationId = ev_sup.evaluationId AND a_sup.questionId = q.questionId)     " +
                "  LEFT JOIN answer a_cw ON (a_cw.evaluationId = ev_cw.evaluationId AND a_cw.questionId = q.questionId)         " +
                " WHERE q.typeId = @typeId                                                                                      " +
                " ORDER BY q.questionNo                                                                                         ";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(testStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@employeeId", employeeId);
                    selectCommand.Parameters.AddWithValue("@typeId", typeId);
                    selectCommand.Parameters.AddWithValue("@stageId", stageId);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return reportData;
                        }
                    }
                }

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@employeeId", employeeId);
                    selectCommand.Parameters.AddWithValue("@typeId", typeId);
                    selectCommand.Parameters.AddWithValue("@stageId", stageId);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string category = reader["categoryName"].ToString();
                            int question = (int)reader["questionNo"];
                            int self = (int)reader["self"];
                            int supervisor = (int)reader["supervisor"];
                            int coworker = (int)reader["coworker"];
                            reportData.Add(new UserReport(category, question, self, supervisor, coworker));
                        }
                    }
                }
            }
            return reportData;
        }

        public List<CohortReport> GetCohortReport(int cohortId, int typeId)
        {
            string cohort = this.GetCohortName(cohortId);
            string type = this.GetTypeName(typeId);

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
                "    ) as percentProficient                                                    " +
                "FROM answer a                                                                 " +
                "JOIN evaluations ev ON a.evaluationId = ev.evaluationId                       " +
                "JOIN employee em ON em.employeeId = ev.employeeId                             " +
                "JOIN question q ON q.questionId = a.questionId                                " +
                "JOIN category c ON c.categoryId = q.categoryId                                " +
                "JOIN stage s On s.stageId = ev.stageId                                        " +
                "WHERE em.cohortId = @cohortId AND q.typeId = @typeId                         " +
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
                            CohortReport report = new CohortReport(cohort, type, stage, category, percentProficient);
                            reportDataPoints.Add(report);
                        }
                    }
                }
            }
            return reportDataPoints;
        }
    }

}
