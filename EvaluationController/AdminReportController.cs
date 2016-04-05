using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Controller
{
    /// <summary>
    /// Admin Reports View-Controller
    /// </summary>
    public partial class EvaluationController : IEvaluationController
    {
        public List<UserReport> GetUserReport(int employeeId, int typeId, int stageId)
        {
            return _dal.GetUserReport(employeeId, typeId, stageId);
        }

        public List<CohortReport> GetCohortReport(int typeId, int cohortId)
        {
            return null;
        }

    }


}
