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
        public List<Stage> GetStageList()
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

        public int AddNewStage(String name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name is null");
            }
            if (name.Trim() == "")
            {
                throw new ArgumentException("Name cannot be blank");
            }
            string insertStatement =
                "IF NOT EXISTS (Select 1 From stage WHERE stageName = @name)" +
                "INSERT INTO stage (stageName) " +
                "VALUES (@name)";
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertStatement, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected < 1)
                    {
                        throw new ArgumentException("A stage with that name exists");
                    }
                    //Get the stageID of the newly created stage
                    command.CommandText = "SELECT IDENT_CURRENT('Stage') FROM Stage";
                    int stageId = Convert.ToInt32(command.ExecuteScalar());
                    return stageId;
                }
            }
        }

        public bool RenameStage(int stageId, string oldName, string newName)
        {
            string updateStatement =
                "UPDATE stage " +
                "SET stageName = @newName " +
                "WHERE stageId = @stageId AND stageName = @oldName " +
                "   AND NOT EXISTS (SELECT stageName FROM stage WHERE stageName = @newName)";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand updateCommand = new SqlCommand(updateStatement, connection))
                {
                    updateCommand.Parameters.AddWithValue("@stageId", stageId);
                    updateCommand.Parameters.AddWithValue("@oldName", oldName);
                    updateCommand.Parameters.AddWithValue("@newName", newName);

                    int count = updateCommand.ExecuteNonQuery();
                    if (count < 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
    }


}
