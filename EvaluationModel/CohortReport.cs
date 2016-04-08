using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class CohortReport
    {
        public string Cohort { get; private set; }
        public string Type { get; private set;}        
        public string Stage { get; private set; }
        public string Category { get; private set; }
        public decimal PercentProficient { get; private set; }

        public CohortReport(string cohort, string type, string stage, string category, decimal percentProficient)
        {
            Cohort = cohort;
            Type = type;
            Stage = stage;
            Category = category;
            PercentProficient = percentProficient;
        }
    }
}
