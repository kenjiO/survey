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

        public List<Stage> getStageList()
        {
            // TODO: Finish
            throw new NotSupportedException();
        }
    }
}
