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
        public int getEmployeeCohortId(int employeeId)
        {
            string selectStatement = "SELECT cohortId " +
                                     "FROM employee " +
                                     "WHERE employeeId = @employeeId ";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@employeeId", employeeId);

                    Object result = selectCommand.ExecuteScalar();
                    if (result == null) {
                        return 0;
                    }
                    return (int)result; 
                }
            }
        }


        public List<EmployeeName> getListOfNonAdminEmployees()
        {
            List<EmployeeName> results = new List<EmployeeName>();

            string selectStatement =
                "SELECT  employeeID, firstName, lastName " +
                "FROM employee " +
                "WHERE isAdmin = 0 " +
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
        /// Set a supervisor for an employee
        /// Precondition: employeeId != supervisorId
        /// </summary>
        /// <param name="employeeId">The Employee Id</param>
        /// <param name="supervisorId">The SupervisorId to set for the employee</param>
        /// <returns>True if successful, false if supervisor is already set to another supervisor</returns>
        public bool setSupervisor(int employeeId, int supervisorId)
        {
            if (employeeId == supervisorId)
            {
                throw new ArgumentException("supervisorId cannot equal employeeId");
            }
            string updateStatement =
                "UPDATE employee " +
                "SET supervisorId = @supervisorId " +
                "WHERE employeeId = @employeeId " +
                "AND (supervisorId IS NULL OR supervisorId = @supervisorId)";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand updateCommand = new SqlCommand(updateStatement, connection))
                {
                    updateCommand.Parameters.AddWithValue("@employeeId", employeeId);
                    updateCommand.Parameters.AddWithValue("@supervisorId", supervisorId);

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