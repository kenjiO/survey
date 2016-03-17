using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    /// <summary>
    /// Data to guide adding a new cohort schedule
    /// </summary>
    public class CohortScheduleData
    {
        /// <summary>
        /// Schedulable type for selected cohort
        /// </summary>
        public int typeId { get; set; }
        public string typeName { get; set; }
        /// <summary>
        /// End date for the last stage scheduled for this cohort+type, if any, else null
        /// </summary>
        public DateTime lastStageEndDate { get; set; }
        /// <summary>
        /// Schedulable stage for this cohort+type (if null, no more stages exist)
        /// </summary>
        public int? nextStageId { get; set; }
    }
}
