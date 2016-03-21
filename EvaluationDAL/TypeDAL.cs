using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.DAL
{
    public partial class EvaluationDAL
    {
        public List<EvalType> getTypeList()
        {
            List<EvalType> results = new List<EvalType>();

            string selectStatement =
                "SELECT  typeId, typeName, answerRange " +
                "FROM type " +
                "ORDER BY typeId;";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EvalType type = new EvalType((int)reader["typeId"], reader["typeName"].ToString(), (int)reader["answerRange"]);
                            results.Add(type);
                        }
                    }
                }
            }
            return results;
        }
                
    }
}
