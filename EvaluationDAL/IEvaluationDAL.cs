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

        #endregion

        #region Employees

        /// <summary>
        /// Deletes a schedule if it has no evaluations
        /// </summary>
        /// <param name="selectedSchedule"></param>
        /// <returns>true if delete is successful, else false</returns>
        bool DeleteSchedule(EvaluationSchedule selectedSchedule);

        #endregion
    }

}
