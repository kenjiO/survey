using System.Collections.Generic;
using Evaluation.Model;
using System;

namespace Evaluation.Controller
{
    /// <summary>
    /// Evaluation Schedule Controller
    /// </summary>
    public partial class EvaluationController : IEvaluationController
    {
        public bool DeleteSchedule(EvaluationSchedule selectedSchedule)
        {
            return _dal.DeleteSchedule(selectedSchedule);
        }
    }
}
