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
        public List<Stage> getStageList()
        {
            List<Stage> results = new List<Stage>();

            string selectStatement =
                "SELECT  stageId, stageName " +
                "FROM stage " +
                "ORDER BY stageId;";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Stage stage = new Stage((int)reader["stageId"], reader["stageName"].ToString());
                            results.Add(stage);
                        }
                    }
                }
            }
            return results;
        }
    }
}
