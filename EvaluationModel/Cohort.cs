using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class Cohort
    {
        public int CohortId { get { return _id; } }
        public string CohortName { get { return _cohortName; } }

        public Cohort(int id, string name)
        {
            _id = id;
            _cohortName = name;
        }

        private int _id;
        private string _cohortName;
    }
}
