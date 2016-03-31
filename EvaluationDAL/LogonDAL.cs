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
        /// <summary>
        /// Get employee matching given email address and password
        /// </summary>
        /// <returns>Employee if valid email/password combination. Otherwise null</returns>
        public Employee getLogin(String emailAddress, String password)
        {
            if (emailAddress == null || password == null)
            {
                throw new ArgumentNullException("emailAddress and password must not be null");
            }
            Employee employee = null;
            string selectStatement =
                "SELECT  employeeID, firstName, lastName, emailAddress, isAdmin, cohortId, supervisorId " +
                "FROM employee " +
                "WHERE emailAddress = @emailAddress AND password = @password";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();
                using(SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@emailAddress", emailAddress);
                    selectCommand.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int employeeId = (int) reader["employeeId"];
                            String firstName = reader["firstName"].ToString();
                            String lastName = reader["lastName"].ToString();
                            String email = reader["emailAddress"].ToString();
                            Boolean isAdmin = Convert.ToBoolean(reader["isAdmin"]); 
                            employee = new Employee(employeeId, firstName, lastName, email, isAdmin);

                            if (!DBNull.Value.Equals(reader["cohortId"]))
                                employee.CohortId = (int) reader["cohortId"];
                            else
                                employee.CohortId = null;

                            if (!DBNull.Value.Equals(reader["supervisorId"]))
                                employee.SupervisorId = (int) reader["supervisorId"];
                            else
                                employee.SupervisorId = null;
                        }
                    }
                }
            }
            return employee;
        }
    }
}