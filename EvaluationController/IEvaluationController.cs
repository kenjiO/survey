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
        /// <returns>Stage name if found, else null</returns>
        string getStageName(int stageId);

        /// <summary>
        /// See if a stage already exists
        /// </summary>
        /// <param name="name">Stage name to check</param>
        /// <returns>True if the stage name already exists</returns>
        bool stageExists(string name);

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
        /// Get type name from typeId
        /// </summary>
        /// <param name="typeId">the id of the type</param>
        /// <returns>the name of the type with the given id</returns>
        string getTypeName(int typeId);
        #endregion

        #region Cohorts
        /// <summary>
        /// Look up cohort name for a given cohort
        /// </summary>
        /// <param name="cohortId">Id of cohort to look up</param>
        /// <returns>Cohort name</returns>
        string getCohortName(int cohortId);

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
        /// Get a list of Cohorts
        /// </summary>
        /// <returns>A list of Corhort objects representing each cohort in the DB</returns>
        List<Cohort> getCohorts();

        /// <summary>
        /// Get a list of cohort scheduling info
        /// </summary>
        /// <param name="_cohortId">Cohort id to get list for</param>
        /// <returns>List of cohort scheduling info</returns>
        List<CohortScheduleData> getCohortAddScheduleInfo(int _cohortId);

        #endregion

        #region Employees
        /// <summary>
        /// Get a list of employee names and ids
        /// </summary>
        /// <returns>Employee name list</returns>
        List<EmployeeName> getEmployeeNameList();
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


    }
}
