﻿using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Controller
{
    public partial class EvaluationController : IEvaluationController
    {
        /// <summary>
        /// Get a list of non-admin employees with possible exclusions
        /// </summary>
        /// <param name="exclude">List of employee Id's to exclude</param>
        /// <returns>A list of non admin employees excluding given Id's</returns>
        public List<EmployeeName> GetListOfNonAdminEmployees(int[] exclude)
        {
            if (exclude == null)
            {
                throw new ArgumentNullException("exclude cannot be null");
            }
            List<EmployeeName> employees = _dal.GetListOfNonAdminEmployees();
            foreach (int id in exclude)
            {
                employees.RemoveAll(emp => emp.EmployeeId == id);
            }
            return employees;
        }

        /// <summary>
        /// Check if the given employee has selected a supervisor
        /// </summary>
        /// <param name="employeeId">the employee id</param>
        /// <returns>True if a supervisor has been selected, else false</returns>
        public bool IsSupervisorSelected(int employeeId)
        {
            return _dal.IsSupervisorSelected(employeeId);
        }

        /// <summary>
        /// Set a supervisor for the logged in employee
        /// Precondition: isSupervisorSelectedForCurrentUser() is false
        /// Precondition: supervisor is not the same as currentUser
        /// </summary>
        /// <param name="supervisorId">Id to set as the supervisor</param>
        public void SetSupervisor(int supervisorId)
        {
            if (supervisorId == _currentUser.EmployeeId) {
                throw new ArgumentException("supervisorId cannot be the same as the current user");
            }
            if (this.IsSupervisorSelected(_currentUser.EmployeeId))
            {
                throw new InvalidOperationException("Supervisor is already set");
            }
            if (_dal.SetSupervisor(_currentUser.EmployeeId, supervisorId))
            {
                _currentUser.SupervisorId = supervisorId;
            }
        }

    }
}
