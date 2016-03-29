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
            return _dal.getOpenSelfEvaluations(employeeId);
        }

        public List<Evaluations> getOpenOtherEvaluations(int employeeId)
        {
            return _dal.getOpenOtherEvaluations(employeeId);
        }

        public DateTime getEndDateForSchedule(int typeId, int stageId, int? cohortId)
        {
            return _dal.getEndDateForSchedule(typeId, stageId, cohortId);
        }
    }
}
