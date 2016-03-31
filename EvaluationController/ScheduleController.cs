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

        public List<EvaluationSchedule> GetEvaluationScheduleList(int cohortId)
        {
            return _dal.GetEvaluationScheduleList(cohortId);
        }

        public int AddEvaluationSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate)
        {
            return _dal.AddEvaluationSchedule(cohortId, typeId, stageId, startDate, endDate);
        }

    }
}
