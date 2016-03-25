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

        public List<Evaluations> getOpenSelfEvaluations(int employeeId)
        {
            throw new NotSupportedException();
        }

        public List<Evaluations> getOpenOtherEvaluations(int employeeId)
        {
            throw new NotSupportedException();
        }

        public DateTime getEndDateForSchedule(int typeId, int stageId, int? cohortId)
        {
            throw new NotSupportedException();
        }
    }
}
