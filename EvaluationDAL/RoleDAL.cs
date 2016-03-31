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

        public String GetRoleName(int roleId)
        {
            GetRoleList();
            Role result = _roles.Find(r => r.Id == roleId);
            if (result == null || result.Id != roleId)
            {
                return "";
            }
            return result.Name;
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
