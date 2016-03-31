using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class EmployeeName
    {
        public int EmployeeId { get { return _id; } }
        public string Name { get { return _name; } }
        public string FullName { get { return _name; } }

        public EmployeeName(int id, string firstName, string lastName)
        {
            _id = id;
            _name = fullNameString(id, firstName, lastName);
        }

        /// <summary>
        /// Convert first and last name and employee id to full name string (e.g. "last, first (###)")
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <param name="first">First name</param>
        /// <param name="last">Last name</param>
        /// <returns>Full name string</returns>
        public static string fullNameString(int id, string first, string last)
        {
            string result;

            if (first == null)
            {
                first = "";
            }
            if (last == null)
            {
                last = "";
            }
            result = last;
            if (result.Length > 0 && first.Length > 0)
            {
                result += ", ";
            }
            result += first + " (" + id + ")";
            return result;
        }

        private int _id;
        private string _name;

    }
}
