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
        /// <summary>
        /// Get type name from typeId
        /// </summary>
        /// <param name="typeId">the id of the type</param>
        /// <returns>the name of the type with the given id</returns>
        public string getTypeName(int typeId)
        {

            String typeName;

            string selectStatement =
                "SELECT typeName " +
                "FROM type " +
                "WHERE typeId = @typeId";
            
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@typeId", typeId);
                    typeName = selectCommand.ExecuteScalar().ToString();
                    return typeName;
                }
            }            
        }
    }
}
