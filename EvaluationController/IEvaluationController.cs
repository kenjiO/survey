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
        Employee currentUser { get; }
        Boolean idAdminSession { get; }

        #region Stages
        /// <summary>
        /// Get a list of stages and their ids
        /// </summary>
        /// <returns>Stage list</returns>
        List<Stage> getStageList();

        /// <summary>
        /// Look up the name for a stage
        /// </summary>
        /// <param name="stageId">Stage id to look up</param>
        /// <returns>Stage name if found, else an empty string</returns>
        string getStageName(int stageId);

        /// <summary>
        /// See if a stage already exists
        /// </summary>
        /// <param name="name">Stage name to check</param>
        /// <returns>True if the stage name already exists</returns>
        bool stageExists(string name);

        /// <summary>
        /// Get stageId for the stage that comes after the one given
        /// </summary>
        /// <param name="stageId">Previous stage id, null if none</param>
        /// <returns>Next stage id, null if none</returns>
        int? getNextStageId(int? stageId);

        /// <summary>
        /// Add a new stage
        /// </summary>
        /// <param name="name">Stage name to add</param>
        /// <returns>Stage id of new stage</returns>
        int addStage(string name);

        #endregion 

        #region Types
        /// <summary>
        /// Get a list of types and their ids
        /// </summary>
        /// <returns>List of types</returns>
        List<EvalType> getTypeList();

        /// <summary>
        /// See whether a type exists by type name
        /// </summary>
        /// <param name="name">Type name to check</param>
        /// <returns>True if type exists</returns>
        bool typeExists(string name);

        /// <summary>
        /// Get type name from typeId
        /// </summary>
        /// <param name="typeId">the id of the type</param>
        /// <returns>the name of the type with the given id</returns>
        string getTypeName(int typeId);

        /// <summary>
        /// Add a new type
        /// </summary>
        /// <param name="name">Type name to add</param>
        /// <returns>Type id for new type</returns>
        int addType(string name);

        #endregion

        #region Cohorts
        /// <summary>
        /// Look up cohort name for a given cohort
        /// </summary>
        /// <param name="cohortId">Id of cohort to look up</param>
        /// <returns>Cohort name</returns>
        string getCohortName(int cohortId);

        /// <summary>
        /// Get a list of Cohorts
        /// </summary>
        /// <returns>A list of Corhort objects representing each cohort in the DB</returns>
        List<Cohort> getCohorts();

        /// <summary>
        /// Add a new cohort
        /// </summary>
        /// <returns>The newly created Cohort instance or null if it could not create a cohort</returns>
        Cohort addCohort(String name);

        /// <summary>
        /// Get a list of evaluation schedules for a given cohort
        /// </summary>
        /// <param name="cohortId">cohort id of the specific cohort</param>
        /// <returns>Evaluation schedule list</returns>
        List<EvaluationSchedule> getEvaluationScheduleList(int cohortId);

        /// <summary>
        /// Get a list of members for a given cohort
        /// </summary>
        /// <param name="_cohortId">cohort id of the specific cohort</param>
        /// <returns>Member list</returns>
        List<Employee> getMembersOfCohort(int cohortId);

        /// <summary>
        /// Get a list of members that are not assigned to any cohort
        /// </summary>
        /// <returns>Member list</returns>
        List<Employee> getMembersNotInCohort();

        /// <summary>
        /// Updates the cohortid of employees with specified ids
        /// </summary>
        /// <param name="_cohortId">id of cohort to add members to</param>
        /// <param name="empIdList">list of employee ids to be added to the cohort</param>
        /// <returns>list of employee ids that were not updated</returns>
        List<int> addMembersToCohort(int _cohortId, List<int> empIdList);

        /// <summary>
        /// Get a list of cohort scheduling info
        /// </summary>
        /// <param name="_cohortId">Cohort id to get list for</param>
        /// <returns>List of cohort scheduling info</returns>
        List<CohortScheduleData> getCohortAddScheduleInfo(int cohortId);

        /// <summary>
        /// Attempt to add a new cohort evaluation schedule
        /// </summary>
        /// <param name="cohortId">Cohort to add schedule for</param>
        /// <param name="typeId">Evaluation type</param>
        /// <param name="stageId">Evaluation Stage</param>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>scheduleId for schedule item added</returns>
        /// <exception cref="ArgumentException">Parameters given were invalid</exception>
        int addCohortSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Deletes the specified cohort
        /// </summary>
        /// <param name="_cohortId">id of cohort to delete</param>
        void deleteCohort(int _cohortId);

        #endregion

        #region Employees
        /// <summary>
        /// Get a list of employee names and ids
        /// </summary>
        /// <returns>Employee name list</returns>
        List<EmployeeName> getEmployeeNameList();

        /// <summary>
        /// Get a list of non-admin employees with possible exclusions
        /// </summary>
        /// <param name="exclude">List of employee Id's to exclude</param>
        /// <returns>A list of non admin employees excluding given Id's</returns>
        List<EmployeeName> getListOfNonAdminEmployees(int[] exclude);

        /// <summary>
        /// Check if the currentUser has selected a supervisor
        /// </summary>
        /// <returns>Whether or not a supervisor has been selected</returns>
        bool isSupervisorSelectedForCurrentUser();

        /// <summary>
        /// Set a supervisor for the logged in employee
        /// Precondition: isSupervisorSelectedForCurrentUser() is false
        /// Precondition: supervisor is not the same as currentUser
        /// Throws an exception if supervisor is already set
        /// </summary>
        /// <param name="supervisorId">Id to set as the supervisor</param>
        /// <returns>True if supervisor was set successfully. False if the supervisor was already set</returns>
        void setSupervisor(int supervisorId);

        #endregion

        #region Login
        /// <summary>
        /// Login with username and password
        /// </summary>
        /// <param name="username">Username (email address)</param>
        /// <param name="password">Password</param>
        /// <returns>Employee if successful login. Null for invalid username/password</returns>
        Employee login(String username, String password);
        #endregion

        #region Admin Reports
        /// <summary>
        /// Return User Report data for a given stage and evaluation type
        /// </summary>
        /// <param name="stageId"></param>
        /// <param name="typeId"></param>
        /// <returns>Report details as a DataTable</returns>
        DataTable getUserReport(int stageId, int typeId);
        #endregion

        #region Schedule
        /// <summary>
        /// Deletes a schedule if it has no evaluations
        /// </summary>
        /// <param name="selectedSchedule"></param>
        /// <returns>true if delete is successful, else false</returns>
        bool DeleteSchedule(EvaluationSchedule selectedSchedule);
        #endregion

        #region Evaluation

        /// <summary>
        /// Check to see if the employee has started an evaluation for type and stage
        /// </summary>
        /// <param name="empId">The employee</param>
        /// <param name="typeId">The typeID for the evaluation</param>
        /// <param name="stageId">The stageId for the evaluation</param>
        /// <returns>Whether or not a self-evaluation for this type and stage exists yet</returns>
        bool isSelfEvaluationStarted(int empId, int typeId, int stageId);

        /// <summary>
        /// Creates a self-evaluation, supervisor evaluation and co-worker evaluation 
        /// for currentUser for stage and type
        /// Precondition: SupervisorId is set for currentEmployee
        /// Precondition: co-worker is not the supervisor
        /// Precondition: Evaluation for currentEmployee at given type and stage does not exist
        /// Precondition: EvaluationSchedule is open for currentUser's cohort
        /// </summary>
        /// <param name="typeId">Evaluation type to create</param>
        /// <param name="stageId">Evaluation stage to create</param>
        /// <param name="coworkerId">Co-worker selected to evaluate this employee</param>
        void initializeSelfEvaluation(int typeId, int stageId, int coworkerId);

        #endregion

    }
}
