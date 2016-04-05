using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Evaluation.DAL
{
    /// <summary>
    /// Interface to database access layer
    /// </summary>
    public interface IEvaluationDAL
    {
        #region Types
        /// <summary>
        /// Get a list of all types
        /// </summary>
        /// <returns>Type list</returns>
        List<EvalType> GetTypeList();
        #endregion

        #region Stages
        /// <summary>
        /// Get a list of stages and their ids
        /// </summary>
        /// <returns>Stage list</returns>
        List<Stage> GetStageList();
        #endregion

        #region Roles
        /// <summary>
        /// Get a list of Roles and their ids
        /// </summary>
        /// <returns>Role list</returns>
        List<Role> GetRoleList();
        #endregion

        #region Cohorts
        /// <summary>
        /// Get a list of cohorts
        /// </summary>
        /// <returns>A list of Cohort objects corresponding to the cohorts in the DB</returns>
        List<Cohort> GetCohorts();

        /// <summary>
        /// Create a new cohort with the given name
        /// </summary>
        /// <returns>The new cohort created. Null if it could not be created</returns>
        Cohort AddNewCohort(String name);

        /// <summary>
        /// Get a list of members for a given cohort
        /// </summary>
        /// <param name="_cohortId">cohort id of the specific cohort</param>
        /// <returns>Member list</returns>
        List<Employee> GetMembersOfCohort(int cohortId);

        /// <summary>
        /// Get a list of members that are not assigned to any cohort
        /// </summary>
        /// <returns>Member list</returns>
        List<Employee> GetMembersNotInCohort();

        /// <summary>
        /// Updates the cohortid of employees with specified ids
        /// </summary>
        /// <param name="_cohortId">id of cohort to add members to</param>
        /// <param name="empIdList">list of employee ids to be added to the cohort</param>
        /// <returns>list of employee ids that were not updated</returns>
        List<int> AddMembersToCohort(int cohortId, List<int> empIdList);

        /// <summary>
        /// Get a list of cohort scheduling info
        /// </summary>
        /// <param name="_cohortId">Cohort id to get list for</param>
        /// <returns>List of cohort scheduling info</returns>
        DataTable GetCohortAddScheduleInfo(int cohortId);

        /// <summary>
        /// Get a list of cohorts that have no members or schedules
        /// </summary>
        /// <returns>A list of cohorts with no members or schedules</returns>
        List<Cohort> GetCohortsWithNoMembersOrEvals();

        /// <summary>
        /// Delete a cohort with the given Id.  Cohort must not have any members or schedules.
        /// </summary>
        /// <param name="cohortId">Id of the cohort to delete</param>
        bool DeleteCohort(int cohortId);

        /// <summary>
        /// Rename a cohort if cohortId with oldName is in the database
        /// </summary>
        /// <param name="cohortId">cohortId to rename</param>
        /// <param name="oldName">the old name of the cohort</param>
        /// <param name="newName">the new name of the cohort</param>
        /// <returns>True if rename successful. False otherwise</returns>
        bool RenameCohort(int cohortId, string oldName, string newName);
        
        #endregion

        #region Employees

        /// <summary>
        /// Get employee matching given login and password
        /// </summary>
        /// <returns>Employee if valid login/password. Otherwise null</returns>
        Employee GetLogin(String username, String password);

        /// <summary>
        /// Look up employee cohort id
        /// </summary>
        /// <param name="employeeId">Employee to look up</param>
        /// <returns>Cohort Id of employee (0 if none assigned)</returns>
        int GetEmployeeCohortId(int employeeId);

        /// <summary>
        /// Look up employee name
        /// </summary>
        /// <param name="employeeId">Employee to look up</param>
        /// <returns>EmployeeName record</returns>
        /// <throws>ArgumentException if employeeId not found</throws>
        EmployeeName GetEmployeeName(int employeeId);

        /// <summary>
        /// Get employees that are not admins
        /// </summary>
        /// <returns>List of non-admin employees</returns>
        List<EmployeeName> GetListOfNonAdminEmployees();

        /// <summary>
        /// Check if the given employee has selected a supervisor
        /// </summary>
        /// <param name="employeeId">the employee id</param>
        /// <returns>True if a supervisor has been selected, else false</returns>
        bool IsSupervisorSelected(int employeeId);

        /// <summary>
        /// Set a supervisor for an employee
        /// Precondition: employeeId != supervisorId
        /// </summary>
        /// <param name="employeeId">The Employee Id</param>
        /// <param name="supervisorId">The SupervisorId to set for the employee</param>
        /// <returns>True if successful, false if supervisor is already set to another supervisor</returns>
        bool SetSupervisor(int employeeId, int supervisorId);

        #endregion

        #region Admin Reports
        /// <summary>
        /// Return User Report data for a given employee, evaluation type, and stage
        /// </summary>
        /// <param name="employeeId">Employee to generate report for</param>
        /// <param name="typeId">Evaluation type</param>
        /// <param name="stageId">Evaluation stage</param>
        /// <returns>Report details list</returns>
        List<UserReport> GetUserReport(int employeeId, int typeId, int stageId);
        #endregion

        #region Schedules

        /// <summary>
        /// Deletes a schedule if it has no evaluations
        /// </summary>
        /// <param name="selectedSchedule"></param>
        /// <returns>true if delete is successful, else false</returns>
        bool DeleteSchedule(EvaluationSchedule selectedSchedule);

        /// <summary>
        /// Get a list of evaluation schedules for a given cohort
        /// </summary>
        /// <param name="cohortId">cohort id of the specific cohort</param>
        /// <param name="typeId">Optional type id to filter list by</param>
        /// <param name="stageId">Optional stage id to filter list by</param>
        /// <returns>Evaluation schedule list</returns>
        List<EvaluationSchedule> GetEvaluationScheduleList(int cohortId, int? typeId, int? stageId);

        /// <summary>
        /// Attempt to add a new cohort evaluation schedule
        /// </summary>
        /// <param name="cohortId">Cohort to add schedule for</param>
        /// <param name="typeId">Evaluation type</param>
        /// <param name="stageId">Evaluation Stage</param>
        /// <param name="StartDate">Start date</param>
        /// <param name="EndDate">End date</param>
        /// <returns>scheduleId for schedule item added</returns>
        /// <exception cref="ArgumentException">Parameters given were invalid</exception>
        int AddEvaluationSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Update the dates for a cohort schedule
        /// </summary>
        /// <param name="scheduleId">Schedule to update</param>
        /// <param name="startDate">New start date</param>
        /// <param name="endDate">New end date</param>
        /// <param name="originalStartDate">Original start date</param>
        /// <param name="originalEndDate">Original end date</param>
        void UpdateEvaluationSchedule(int scheduleId, DateTime startDate, DateTime endDate, DateTime originalStartDate, DateTime originalEndDate);

        #endregion

        #region Evaluations
        
        /// <summary>
        /// Returns list of all open self evaluations for given employee id
        /// </summary>
        /// <param name="employeeId">id of the given employee</param>
        /// <returns>List of Open Self Evaluations</returns>
        List<OpenEvaluation> GetOpenSelfEvaluations(int employeeId);

        /// <summary>
        /// Returns list of all open evaluations to rate others, for given employee id
        /// </summary>
        /// <param name="employeeId">id of the given employee</param>
        /// <returns>List of Open Evaluations that are not Self Evaluations</returns>
        List<OpenEvaluation> GetOpenPeerEvaluations(int employeeId);

        /// <summary>
        /// Check to see if the current employee has started an evaluation for a given schedule
        /// </summary>
        /// <param name="employeeId">Employee to initialize evaluation for</param>
        /// <param name="scheduleId">The scheduleID for the evaluation</param>
        /// <returns>EvaluationId of self evaluation, or 0 if not started</returns>
        int IsSelfEvaluationStarted(int employeeId, int scheduleId);

        /// <summary>
        /// Creates a self-evaluation, supervisor evaluation and co-worker evaluation 
        ///  for a given employee and schedule
        /// THROWS custom exception 'CreateEvaluationsException' for errors when preconditions not met
        /// Precondition: SupervisorId is set for currentEmployee
        /// Precondition: coworkerId is in the DB and not the supervisor or admin
        /// Precondition: Evaluations for currentEmployee for given schedule does not exist
        /// Precondition: Schedule exist in the DB
        /// </summary>
        /// <param name="employeeId">Employee to initialize evaluation for</param>
        /// <param name="scheduleId">The scheduleID for the evaluation</param>
        /// <param name="coworkerId">Co-worker selected to evaluate this employee</param>
        /// <returns>Evaluation id of self evaluation created</returns>
        int InitializeSelfEvaluation(int employeeId, int scheduleId, int coworkerId);

        #endregion

    }

}
