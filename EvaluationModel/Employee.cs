using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class Employee
    {
        public int EmployeeId { get { return _id; } }
        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }
        public string FullName { get { return new EmployeeName(_id, _firstName, _lastName).FullName; } }
        public string Email { get { return _email; } }
        public Boolean IsAdmin { get { return _isAdmin; } }
        public int? CohortId { get; set; }
        public int? SupervisorId { get; set; }

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
