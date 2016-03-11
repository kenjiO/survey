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
        /// Get a list of employee names and ids
        /// </summary>
        /// <returns>Employee name list</returns>
        public List<EmployeeName> getEmployeeNameList()
        {
            List<EmployeeName> results = new List<EmployeeName>();

            string selectStatement =
                "SELECT  employeeID, firstName, lastName " +
                "FROM employee " +
                "ORDER BY firstName, lastName;";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeeName employee = new EmployeeName((int)reader["employeeId"], reader["firstName"].ToString(), reader["lastName"].ToString());
                            results.Add(employee);
                        }
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Get employee matching given email address and password
        /// </summary>
        /// <returns>Employee if valid email/password combination. Otherwise null</returns>
        public Employee getLogin(String emailAddress, String password)
        {
            Employee employee = null;
            string selectStatement =
                "SELECT  employeeID, firstName, lastName, emailAddress, isAdmin, cohortId, supervisorId " +
                "FROM employee " +
                "WHERE emailAddress = @emailAddress AND password = @password";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue("@emailAddress", emailAddress);
                selectCommand.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = null;
                try
                {
                    connection.Open();
                    reader = selectCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        int employeeId = (int) reader["employeeId"];
                        String firstName = reader["firstName"].ToString();
                        String lastName = reader["lastName"].ToString();
                        String email = reader["emailAddress"].ToString();
                        Boolean isAdmin = Convert.ToBoolean(reader["isAdmin"]); 
                        employee = new Employee(employeeId, firstName, lastName, email, isAdmin);

                        if (!DBNull.Value.Equals(reader["cohortId"]))
                            employee.cohortId = (int) reader["cohortId"];
                        else
                            employee.cohortId = null;

                        if (!DBNull.Value.Equals(reader["supervisorId"]))
                            employee.supervisorId = (int) reader["supervisorId"];
                        else
                            employee.supervisorId = null;
                    }
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (reader != null)
                        reader.Close();
                }
            }
            return employee;
        }
    }
}
