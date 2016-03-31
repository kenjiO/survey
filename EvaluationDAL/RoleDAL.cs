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
    /// Database Access Layer for roles
    /// </summary>
    public partial class EvaluationDAL : IEvaluationDAL
    {
        public String GetRoleName(int roleId)
        {
            string selectStatement = "SELECT roleName " +
                                     "FROM role " +
                                     "WHERE roleId = @roleId ";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@roleId", roleId);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            throw new ArgumentException("Role " + roleId + " not found");
                        }
                        return reader["roleName"].ToString();
                    }
                }
            }
        }

        public List<Role> GetRoleList()
        {
            List<Role> results = new List<Role>();

            string selectStatement =
                "SELECT  RoleId, RoleName " +
                "FROM Role " +
                "ORDER BY RoleId;";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Role Role = new Role((int)reader["RoleId"], reader["RoleName"].ToString());
                            results.Add(Role);
                        }
                    }
                }
            }
            return results;
        }

    }
}
