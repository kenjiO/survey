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
            return _dal.GetEvaluationScheduleList(cohortId, null, null);
        }

        public int AddEvaluationSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate)
        {
            return _dal.AddEvaluationSchedule(cohortId, typeId, stageId, startDate, endDate);
        }

        public DateRange GetScheduleDateRange(int scheduleId, int cohortId, int typeId, int stageId)
        {
            DateRange result = new DateRange(DateTime.Parse("1/1/2000"), DateTime.Parse("12/31/2100"));
            List<EvaluationSchedule> list = _dal.GetEvaluationScheduleList(cohortId, typeId, null);
            // TODO: Get list of schedules for given cohort and type
            // scan list for previous end and next start
            return result;
        }

        public void UpdateEvaluationSchedule(int scheduleId, DateTime startDate, DateTime endDate)
        {
            _dal.UpdateEvaluationSchedule(scheduleId, startDate, endDate);
        }

    }
}
