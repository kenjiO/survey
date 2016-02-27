using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationModel
{
    public class EmployeeName
    {
        public int employeeId { get { return _id; } }
        // name - first last
        public string name { get { return _name; } }

        public EmployeeName(int id, string firstName, string lastName)
        {
            _id = id;
            if (firstName.Length > 0)
            {
                _name = firstName + " " + lastName;
            }
            else
            {
                _name = lastName;
            }
        }

        public EmployeeName(int id, string name)
        {
            _id = id;
            _name = name;
        }

        private int _id;
        private string _name;
    }
}
