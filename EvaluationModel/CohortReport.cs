using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class CohortReport
    {
        public string Stage { get; private set; }
        public string Category { get; private set; }
        public decimal PercentProficient { get; private set; }

        public CohortReport(string _stage, string _category, decimal _percentProficient)
        {
            Stage = _stage;
            Category = _category;
            PercentProficient = _percentProficient;
        }
    }
}
