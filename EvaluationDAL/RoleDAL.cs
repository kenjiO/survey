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
        List<Role> _roles;

        public String getRoleName(int roleId)
        {
            getRoleList();
            Role result = _roles.Find(r => r.id == roleId);
            if (result == null || result.id != roleId)
            {
                return "";
            }
            return result.name;
        }

        public List<Role> GetRoleList()
        {
            _roles = new List<Role>();

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
                            _roles.Add(Role);
                        }
                    }
                }
            }
            return _roles;
        }

    }
}
