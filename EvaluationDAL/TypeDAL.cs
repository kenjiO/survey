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

            try
            {
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
            catch (SqlException ex)
            {
                //exceptions are thrown to the controller, then to the view
                //throw is used instead of throw ex because the former preserves the stack trace
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
