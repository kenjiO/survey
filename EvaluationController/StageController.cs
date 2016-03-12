using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Controller
{
    /// <summary>
    /// Stage portion of Evaluation View-Controller
    /// </summary>
    public partial class EvaluationController : IEvaluationController
    {
        private List<Stage> _stages;

        public List<Stage> getStageList()
        {
            if (_stages != null)
            {
                _stages = _dal.getStageList();
            }
            return _stages;
        }

        public string stageName(int stageId)
        {
            // assure stage list exists
            getStageList();
            // TODO: look up stage name in list
            throw new NotSupportedException();
        }

    }
}
