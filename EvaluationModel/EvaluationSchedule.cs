using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationModel
{
    public class EvaluationSchedule
    {
        public int CohortId { get; set; }
        //public string cohortName { get; set; }
        public int TypeId { get; set; }
        //public string typeName { get; set; }
        public int StageId { get; set; }
        //public string stageName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public EvaluationSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate) 
        {
            CohortId = cohortId;
            TypeId = typeId;
            StageId = stageId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }

    
}
