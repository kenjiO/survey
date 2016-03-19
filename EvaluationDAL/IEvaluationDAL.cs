using Evaluation.Model;
using System;
using System.Collections.Generic;

namespace Evaluation.DAL
{
    /// <summary>
    /// Interface to database access layer
    /// </summary>
    public interface IEvaluationDAL
    {
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

        #region Types
        /// <summary>
        /// Get type name from typeId
        /// </summary>
        /// <param name="typeId">the id of the type</param>
        /// <returns>the name of the type with the given id</returns>
        string getTypeName(int typeId);

        #endregion

        
    }

}
