using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationModel
{
    public class EvaluationSchedule
    {
        public int cohortId { get; set; }
        public string cohortName { get; set; }
        public int typeId { get; set; }
        public string typeName { get; set; }
        public int stageId { get; set; }
        public string stageName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
