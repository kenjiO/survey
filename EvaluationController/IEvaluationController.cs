using Evaluation.DAL;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Controller
{
    /// <summary>
    /// Interface for Evaluations View Controller
    /// </summary>
    public interface IEvaluationController
    {
        Employee currentUser { get; }
        Boolean idAdminSession { get; }

        /// <summary>
        /// Get a list of stages and their ids
        /// </summary>
        /// <returns>Stage list</returns>
        List<Stage> getStageList();

        /// <summary>
        /// Get a list of types and their ids
        /// </summary>
        /// <returns>List of types</returns>
        List<EvalType> getTypeList();

        /// <summary>
        /// Look up cohort name for a given cohort
        /// </summary>
        /// <param name="cohortId">Id of cohort to look up</param>
        /// <returns>Cohort name</returns>
        string getCohortName(int cohortId);

        /// <summary>
        /// Login with username and password
        /// </summary>
        /// <param name="username">Username (email address)</param>
        /// <param name="password">Password</param>
        /// <returns>Employee if successful login. Null for invalid username/password</returns>
        Employee login(String username, String password);


        /// <summary>
        /// Return User Report data for a given stage and evaluation type
        /// </summary>
        /// <param name="stageId"></param>
        /// <param name="typeId"></param>
        /// <returns>Report details as a DataTable</returns>
        DataTable getUserReport(int stageId, int typeId);

        /// <summary>
        /// Add a new cohort
        /// </summary>
        /// <returns>The newly created Cohort instance or null if it could not create a cohort</returns>
        Cohort addCohort(String name);
    }
}
