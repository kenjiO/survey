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
        List<Stage> getStageList();

        List<EvalType> getTypeList();

        DataTable getUserReport(int stage, int evalType);

        /// <summary>
        /// Login with username and password
        /// </summary>
        /// <param name="stage">Stage to report</param>
        /// <param name="evalType">Type to report</param>
        /// <returns>Employee if successful login. Null for invalid username/password</returns>
        Employee login(String username, String password);
    }
}
