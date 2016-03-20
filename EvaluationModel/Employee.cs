using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class Employee
    {
        public int employeeId { get { return _id; } }
        public string firstName { get { return _firstName; } }
        public string lastName { get { return _lastName; } }
        public string fullName { get { return EmployeeName.fullNameString(_id, _firstName, _lastName); } }
        public string email { get { return _email; } }
        public Boolean isAdmin { get { return _isAdmin; } }
        public int? cohortId { get; set; }
        public int? supervisorId { get; set; }

        public Employee(int id, string firstName, string lastName, string email, Boolean isAdmin)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _isAdmin = isAdmin;
        }

        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private Boolean _isAdmin;
    }
}
