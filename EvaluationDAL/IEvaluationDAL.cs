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
        List<EvalType> getTypeList();
        #endregion

        #region Stages
        /// <summary>
        /// Get a list of stages and their ids
        /// </summary>
        /// <returns>Stage list</returns>
        List<Stage> getStageList();
        #endregion

        #region Cohorts
        /// <summary>
        /// Get a list of cohorts
        /// </summary>
        /// <returns>A list of Cohort objects corresponding to the cohorts in the DB</returns>
        List<Cohort> getCohorts();

        /// <summary>
        /// Create a new cohort with the given name
        /// </summary>
        /// <returns>The new cohort created. Null if it could not be created</returns>
        Cohort addNewCohort(String name);

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
        List<int> addMembersToCohort(int cohortId, List<int> empIdList);

        /// <summary>
        /// Get a list of cohort scheduling info
        /// </summary>
        /// <param name="_cohortId">Cohort id to get list for</param>
        /// <returns>List of cohort scheduling info</returns>
        DataTable getCohortAddScheduleInfo(int cohortId);

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
        /// Get a list of cohorts that have no members or schedules
        /// </summary>
        /// <returns>A list of cohorts with no members or schedules</returns>
        List<Cohort> getCohortsWithNoMembersOrEvals();

        /// <summary>
        /// Delete a cohort with the given Id.  Cohort must not have any members or schedules.
        /// </summary>
        /// <param name="cohortId">Id of the cohort to delete</param>
        bool deleteCohort(int cohortId);

        /// <summary>
        /// Rename a cohort if cohortId with oldName is in the database
        /// </summary>
        /// <param name="cohortId">cohortId to rename</param>
        /// <param name="oldName">the old name of the cohort</param>
        /// <param name="newName">the new name of the cohort</param>
        /// <returns>True if rename successful. False otherwise</returns>
        bool renameCohort(int cohortId, string oldName, string newName);
        
        #endregion

        #region Employees

        /// <summary>
        /// Get a list of employee names and ids
        /// </summary>
        /// <returns>Employee name list</returns>
        List<EmployeeName> getEmployeeNameList();

        /// <summary>
        /// Get employee matching given login and password
        /// </summary>
        /// <returns>Employee if valid login/password. Otherwise null</returns>
        Employee getLogin(String username, String password);

        /// <summary>
        /// Get employees that are not admins
        /// </summary>
        /// <returns>List of non-admin employees</returns>
        List<EmployeeName> getListOfNonAdminEmployees();

        /// <summary>
        /// Set a supervisor for an employee
        /// Precondition: employeeId != supervisorId
        /// </summary>
        /// <param name="employeeId">The Employee Id</param>
        /// <param name="supervisorId">The SupervisorId to set for the employee</param>
        /// <returns>True if successful, false if supervisor is already set to another supervisor</returns>
        bool setSupervisor(int employeeId, int supervisorId);

        /// <summary>
        /// Check if a self-evaluation for an employee, type and stage has been started
        /// </summary>
        /// <param name="employeeId">employeeId for the self-evaluation</param>
        /// <param name="typeId">The evaluation typeId</param>
        /// <param name="stageId">The evaluation stageId</param>
        bool isSelfEvaluationStarted(int employeeId, int typeId, int stageId);

        #endregion

        #region Schedules

        /// <summary>
        /// Deletes a schedule if it has no evaluations
        /// </summary>
        /// <param name="selectedSchedule"></param>
        /// <returns>true if delete is successful, else false</returns>
        bool DeleteSchedule(EvaluationSchedule selectedSchedule);
        #endregion

        #region Evaluations
        /// <summary>
        /// Returns list of all open self evaluations for given employee id
        /// </summary>
        /// <param name="employeeId">id of the given employee</param>
        /// <returns>List of Open Self Evaluations</returns>
        List<Evaluations> getOpenSelfEvaluations(int employeeId);

        /// <summary>
        /// Returns list of all open evaluations to rate others, for given employee id
        /// </summary>
        /// <param name="employeeId">id of the given employee</param>
        /// <returns>List of Open Evaluations that are not Self Evaluations</returns>
        List<Evaluations> getOpenOtherEvaluations(int employeeId);

        /// <summary>
        /// Returns the endDate of the schedule
        /// </summary>
        /// <param name="typeId">id of the type of evaluation</param>
        /// <param name="stageId">id of the stage of evaluation</param>
        /// <param name="cohortId">id of the cohort (optional)</param>
        /// <returns>The end date of the schedule</returns>
        DateTime getEndDateForSchedule(int typeId, int stageId, int? cohortId);

        /// <summary>
        /// Returns list of all open self evaluations for given employee id
        /// </summary>
        /// <param name="employeeId">id of the given employee</param>
        /// <returns>List of Open Self Evaluations</returns>
        List<OpenEvaluation> getOpenSelfEvaluations_New(int employeeId);

        /// <summary>
        /// Returns list of all open evaluations to rate others, for given employee id
        /// </summary>
        /// <param name="employeeId">id of the given employee</param>
        /// <returns>List of Open Evaluations that are not Self Evaluations</returns>
        List<OpenEvaluation> getOpenOtherEvaluations_New(int employeeId);

        #endregion

        #region Evaluations

        /// <summary>
        /// Create the self, supervisor and co-worker evaluations in the database
        /// Precondition: Supervisor is set for employee
        /// Precondition: Co-worker is not the supervisor
        /// Precondition: Co-worker is different then employee
        /// Precondition: Evaluations for type and stage are not created yet for this employee
        /// </summary>
        /// <param name="empId">Employee who the evaluations are for</param>
        /// <param name="typeId">Type Id of evaluation to create</param>
        /// <param name="stageId">StageId of evaluation to create</param>
        /// <param name="coworkerId">Co-worker's employeeId</param>
        void createEvaluations(int empId, int typeId, int stageId, int coworkerId);

        #endregion
    }

}
