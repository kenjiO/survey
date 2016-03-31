using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class DateRange
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public DateRange(DateTime start, DateTime end)
        {
            startDate = start;
            endDate = end;
        }
    }
}
