using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class EmployeeName
    {
        public int EmployeeId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string FullName { get { return FullNameString(); } }
        public string FullNameFL { get { return FullNameFLString(); } }

        public EmployeeName(int id, string firstName, string lastName)
        {
            EmployeeId = id;
            FirstName = firstName ?? "";
            LastName = lastName ?? "";
        }

        /// <summary>
        /// Convert first and last name and employee id to full name string
        /// </summary>
        /// <returns>Full name string in "last, first (####)" format</returns>
        public string FullNameString()
        {
            string result;

            result = LastName;
            if (result.Length > 0 && FirstName.Length > 0)
            {
                result += ", ";
            }
            result += FirstName + " (" + EmployeeId + ")";
            return result;
        }

        /// <summary>
        /// Convert first and last name and employee id to full name string
        /// </summary>
        /// <returns>Full name string in "first last (####)" format</returns>
        public string FullNameFLString()
        {
            string result;

            result = FirstName;
            if (result.Length > 0 && LastName.Length > 0)
            {
                result += " ";
            }
            result += LastName + " (" + EmployeeId + ")";
            return result;
        }

    }
}
