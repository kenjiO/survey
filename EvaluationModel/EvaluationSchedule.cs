using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class EvaluationSchedule
    {
        public int ScheduleId { get; set; }
        public int CohortId { get; set; }
        public int TypeId { get; set; }
        public int StageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public EvaluationSchedule(int scheduleId, int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate) 
        {
            ScheduleId = scheduleId;
            CohortId = cohortId;
            TypeId = typeId;
            StageId = stageId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }

    
}
