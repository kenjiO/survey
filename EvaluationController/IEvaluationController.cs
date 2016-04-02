using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Evaluation.Controller
{
    /// <summary>
    /// Interface for Evaluations View Controller
    /// </summary>
    public interface IEvaluationController
    {
        Employee CurrentUser { get; }
        Boolean IsAdminSession { get; }


        #region Stages
        /// <summary>
        /// Get a list of stages and their ids
        /// </summary>
        /// <returns>Stage list</returns>
        List<Stage> GetStageList();

        /// <summary>
        /// Look up the name for a stage
        /// </summary>
        /// <param name="stageId">Stage id to look up</param>
        /// <returns>Stage name if found, else an empty string</returns>
        string GetStageName(int stageId);

        /// <summary>
        /// See if a stage already exists
        /// </summary>
        /// <param name="name">Stage name to check</param>
        /// <returns>True if the stage name already exists</returns>
        bool StageExists(string name);

        /// <summary>
        /// Get stageId for the stage that comes after the one given
        /// </summary>
        /// <param name="stageId">Previous stage id, null if none</param>
        /// <returns>Next stage id, null if none</returns>
        int? GetNextStageId(int? stageId);

        /// <summary>
        /// Add a new stage
        /// </summary>
        /// <param name="name">Stage name to add</param>
        /// <returns>Stage id of new stage</returns>
        int AddStage(string name);

        #endregion 

        #region Types
        /// <summary>
        /// Get a list of types and their ids
        /// </summary>
        /// <returns>List of types</returns>
        List<EvalType> GetTypeList();

        /// <summary>
        /// See whether a type exists by type name
        /// </summary>
        /// <param name="name">Type name to check</param>
        /// <returns>True if type exists</returns>
        bool TypeExists(string name);

        /// <summary>
        /// Get type name from typeId
        /// </summary>
        /// <param name="typeId">the id of the type</param>
        /// <returns>the name of the type with the given id</returns>
        string GetTypeName(int typeId);

        /// <summary>
        /// Add a new type
        /// </summary>
        /// <param name="name">Type name to add</param>
        /// <returns>Type id for new type</returns>
        int AddType(string name);

        #endregion

        #region Roles
        /// <summary>
        /// Get a list of Roles and their ids
        /// </summary>
        /// <returns>Role list</returns>
        List<Role> GetRoleList();

        /// <summary>
        /// Look up the name for a role
        /// </summary>
        /// <param name="roleId">role id to look up</param>
        /// <returns>role name if found, else an empty string</returns>
        string GetRoleName(int roleId);

        /// <summary>
        /// See if a role already exists
        /// </summary>
        /// <param name="name">role name to check</param>
        /// <returns>True if the role name already exists</returns>
        bool RoleExists(string name);
        #endregion

        #region Cohorts
        /// <summary>
        /// Look up cohort name for a given cohort
        /// </summary>
        /// <param name="cohortId">Id of cohort to look up</param>
        /// <returns>Cohort name</returns>
        string GetCohortName(int cohortId);

        /// <summary>
        /// Get a list of Cohorts
        /// </summary>
        /// <returns>A list of Corhort objects representing each cohort in the DB</returns>
        List<Cohort> GetCohorts();

        /// <summary>
        /// Get a list of Cohorts with no members or schedules
        /// </summary>
        /// <returns>A list of Corhort that have no members or schedules</returns>
        List<Cohort> GetCohortsWithNoMembersOrEvals();

        /// <summary>
        /// Add a new cohort
        /// </summary>
        /// <returns>The newly created Cohort instance or null if it could not create a cohort</returns>
        Cohort AddCohort(String name);

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
        List<int> AddMembersToCohort(int _cohortId, List<int> empIdList);

        /// <summary>
        /// Get a list of cohort scheduling info
        /// </summary>
        /// <param name="_cohortId">Cohort id to get list for</param>
        /// <returns>List of cohort scheduling info</returns>
        List<CohortScheduleData> GetCohortAddScheduleInfo(int cohortId);

        /// <summary>
        /// Deletes the specified cohort
        /// </summary>
        /// <param name="cohortId">id of cohort to delete</param>
        /// <returns>True if cohort deleted. False otherwise.</returns>
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
        /// Get a list of employee names and ids
        /// </summary>
        /// <returns>Employee name list</returns>
        List<EmployeeName> GetEmployeeNameList();

        /// <summary>
        /// Get a list of non-admin employees with possible exclusions
        /// </summary>
        /// <param name="exclude">List of employee Id's to exclude</param>
        /// <returns>A list of non admin employees excluding given Id's</returns>
        List<EmployeeName> GetListOfNonAdminEmployees(int[] exclude);

        /// <summary>
        /// Check if the given employee has selected a supervisor
        /// </summary>
        /// <param name="employeeId">the employee id</param>
        /// <returns>True if a supervisor has been selected, else false</returns>
        bool IsSupervisorSelected(int employeeId);

        /// <summary>
        /// Set a supervisor for the logged in employee
        /// Precondition: isSupervisorSelectedForCurrentUser() is false
        /// Precondition: supervisor is not the same as currentUser
        /// Throws an exception if supervisor is already set
        /// </summary>
        /// <param name="supervisorId">Id to set as the supervisor</param>
        /// <returns>True if supervisor was set successfully. False if the supervisor was already set</returns>
        void SetSupervisor(int supervisorId);

        /// <summary>
        /// Get employee name from id
        /// </summary>
        /// <param name="employeeId">employee id</param>
        /// <returns>Employee name</returns>
        String GetEmployeeName(int employeeId);

        #endregion

        #region Login
        /// <summary>
        /// Login with username and password
        /// </summary>
        /// <param name="username">Username (email address)</param>
        /// <param name="password">Password</param>
        /// <returns>Employee if successful login. Null for invalid username/password</returns>
        Employee Login(String username, String password);
        #endregion

        #region Admin Reports
        /// <summary>
        /// Return User Report data for a given stage and evaluation type
        /// </summary>
        /// <param name="stageId"></param>
        /// <param name="typeId"></param>
        /// <returns>Report details as a DataTable</returns>
        DataTable GetUserReport(int stageId, int typeId);
        #endregion

        #region Schedule
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
        /// <returns>Evaluation schedule list</returns>
        List<EvaluationSchedule> GetEvaluationScheduleList(int cohortId);

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
        /// Get the allowed date range for an existing evaluation schedule
        /// </summary>
        /// <param name="scheduleId">Schedule to get date range for</param>
        /// <param name="cohortId">Selected schedule's cohort id</param>
        /// <param name="typeId">Selected schedule's type id</param>
        /// <param name="stageId">Selected schedule's stage id</param>
        /// <returns>Maximum date range for this schedule</returns>
        DateRange GetScheduleDateRange(int cohortId, int typeId, int stageId);

        /// <summary>
        /// Update the dates for a cohort schedule
        /// </summary>
        /// <param name="scheduleId">Schedule to update</param>
        /// <param name="startDate">New start date</param>
        /// <param name="endDate">New end date</param>
        void UpdateEvaluationSchedule(int scheduleId, DateTime startDate, DateTime endDate);

        #endregion

        #region Evaluation

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
        /// <param name="scheduleId">The scheduleID for the evaluation</param>
        /// <returns>EvaluationId of self evaluation, or 0 if not started</returns>
        int IsSelfEvaluationStarted(int scheduleId);

        /// <summary>
        /// Creates a self-evaluation, supervisor evaluation and co-worker evaluation 
        /// for currentUser for a given schedule
        /// THROWS custom exception 'CreateEvaluationsException' for errors when preconditions not met
        /// Precondition: SupervisorId is set for currentEmployee
        /// Precondition: coworkerId is in the DB and not the supervisor or admin
        /// Precondition: Evaluations for currentEmployee for given schedule does not exist
        /// Precondition: Schedule exist in the DB
        /// </summary>
        /// <param name="scheduleId">The scheduleID for the evaluation</param>
        /// <param name="coworkerId">Co-worker selected to evaluate this employee</param>
        /// <returns>Evaluation id of self evaluation created</returns>
        int InitializeSelfEvaluation(int scheduleId, int coworkerId);

        #endregion


    }
}
