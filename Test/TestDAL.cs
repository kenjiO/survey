using Evaluation.DAL;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestDAL : IEvaluationDAL
    {
        /// <summary>
        /// Get a list of employee names and ids
        /// </summary>
        /// <returns>Employee name list</returns>
        public List<EmployeeName> getEmployeeNameList()
        {
            List<EmployeeName> results = new List<EmployeeName>();

            results.Add(new EmployeeName(1, "Ann Smith"));
            results.Add(new EmployeeName(2, "Bob Jones"));
            results.Add(new EmployeeName(3, "John Doe"));
            results.Add(new EmployeeName(4, "Steve Anderson"));
            results.Add(new EmployeeName(5, "Zoe Doe"));
            return results;
        }

        /// <summary>
        /// Get employee matching given email address and password
        /// </summary>
        /// <returns>Employee if valid email/password combination. Otherwise null</returns>
        public Employee getLogin(String emailAddress, String password)
        {
            throw new NotSupportedException();
        }
    }
}
