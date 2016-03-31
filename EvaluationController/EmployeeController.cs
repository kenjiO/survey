using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Controller
{
    public partial class EvaluationController : IEvaluationController
    {
        public List<EmployeeName> getEmployeeNameList()
        {
            // TODO: get employee name list from database (all names?  We have non-admin below.  Is this function needed?)
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get a list of non-admin employees with possible exclusions
        /// </summary>
        /// <param name="exclude">List of employee Id's to exclude</param>
        /// <returns>A list of non admin employees excluding given Id's</returns>
        public List<EmployeeName> getListOfNonAdminEmployees(int[] exclude)
        {
            if (exclude == null)
            {
                throw new ArgumentNullException("exclude cannot be null");
            }
            List<EmployeeName> employees = _dal.getListOfNonAdminEmployees();
            foreach (int id in exclude)
            {
                employees.RemoveAll(emp => emp.EmployeeId == id);
            }
            return employees;
        }

        /// <summary>
        /// Check if the currentUser has selected a supervisor
        /// </summary>
        /// <returns>Whether or not a supervisor has been selected</returns>
        public bool isSupervisorSelectedForCurrentUser()
        {
            return (_currentUser.SupervisorId != null);
        }

        /// <summary>
        /// Set a supervisor for the logged in employee
        /// Precondition: isSupervisorSelectedForCurrentUser() is false
        /// Precondition: supervisor is not the same as currentUser
        /// </summary>
        /// <param name="supervisorId">Id to set as the supervisor</param>
        public void setSupervisor(int supervisorId)
        {
            if (supervisorId == _currentUser.EmployeeId) {
                throw new ArgumentException("supervisorId cannot be the same as the current user");
            }
            if (this.isSupervisorSelectedForCurrentUser())
            {
                throw new InvalidOperationException("Supervisor is already set");
            }
            if (_dal.setSupervisor(_currentUser.EmployeeId, supervisorId))
            {
                _currentUser.SupervisorId = supervisorId;
            }
        }

        /// <summary>
        /// Get employee name from id
        /// </summary>
        /// <param name="employeeId">employee id</param>
        /// <returns>Employee name</returns>
        public String getEmployeeName(int employeeId)
        {
            // TODO Get employee name for employee id - needed? 
            throw new NotSupportedException("EvaluationController.getEmployeeName not implemented");
        }

    }
}
