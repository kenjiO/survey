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
            // TODO: Finish
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
                employees.RemoveAll(emp => emp.employeeId == id);
            }
            return employees;
        }

        /// <summary>
        /// Check if the currentUser has selected a supervisor
        /// </summary>
        /// <returns>Whether or not a supervisor has been selected</returns>
        public bool isSupervisorSelectedForCurrentUser()
        {
            //TODO Implement.
            throw new NotSupportedException("EvaluationController.isSupervisorSelectedForCurrentUser() not implemented");
        }

        /// <summary>
        /// Set a supervisor for the logged in employee
        /// Precondition: isSupervisorSelectedForCurrentUser() is false
        /// Precondition: supervisor is not the same as currentUser
        /// Throws an exception if supervisor is already set
        /// </summary>
        /// <param name="supervisorId">Id to set as the supervisor</param>
        /// <returns>True if supervisor was set successfully. False if the supervisor was already set</returns>
        public void setSupervisor(int supervisorId)
        {
            //TODO Implement.  Remember to update currentUser!!
            throw new NotSupportedException("EvaluationController.setSupervisor() not implemented");
        }

        /// <summary>
        /// Get employee name from id
        /// </summary>
        /// <param name="employeeId">employee id</param>
        /// <returns>Employee name</returns>
        public String getEmployeeName(int employeeId)
        {
            //TODO Implement.  
            throw new NotSupportedException("EvaluationController.getEmployeeName not implemented");
        }

    }
}
