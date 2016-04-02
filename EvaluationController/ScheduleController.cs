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

        public List<EvaluationSchedule> GetEvaluationScheduleList(int cohortId, int? typeId, int? stageId)
        {
            return _dal.GetEvaluationScheduleList(cohortId, typeId, stageId);
        }

        public int AddEvaluationSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate)
        {
            return _dal.AddEvaluationSchedule(cohortId, typeId, stageId, startDate, endDate);
        }

        public DateRange GetScheduleDateRange(int cohortId, int typeId, int stageId)
        {
            DateRange result = new DateRange(DateTime.Parse("1/1/2000"), DateTime.Parse("12/31/2100"));
            List<EvaluationSchedule> list = _dal.GetEvaluationScheduleList(cohortId, typeId, null);
            foreach (EvaluationSchedule sched in list)
            {
                // if less than selected schedule, update start of range to end of this schedule + 1 day
                if (sched.StageId < stageId)
                {
                    result.StartDate = sched.EndDate.AddDays(1);
                    continue;
                }
                // the selected schedule does not affect allowed range
                if (sched.StageId == stageId)
                {
                    continue;
                }
                // if higher than selected schedule, set range end to start date - 1 day and exit
                result.EndDate = sched.StartDate.AddDays(-1);
                break;
            }
            return result;
        }

        public void UpdateEvaluationSchedule(int scheduleId, DateTime startDate, DateTime endDate)
        {
            _dal.UpdateEvaluationSchedule(scheduleId, startDate, endDate);
        }

    }
}
