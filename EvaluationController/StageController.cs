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
            _stages = _dal.getStageList();
            return _stages;
        }

        private bool tryLoadStageList()
        {
            if (_stages == null)
            {
                try
                {
                    getStageList();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public bool stageExists(string name)
        {
            if (!tryLoadStageList())
            {
                return false;
            }
            return _stages.Exists(s => s.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public string stageName(int stageId)
        {
            if (!tryLoadStageList())
            {
                return "";
            }
            Stage result = _stages.Find(s => s.id == stageId);
            if (result == null || result.id != stageId)
            {
                _stages = null;
                return "";
            }
            return result.name;
        }

        public int addStage(string name)
        {
            // TODO: add stage, return identity column
            //  - name should be non-null, non-empty string
            //  - name should not already exist (can you have a WHERE statement in an INSERT command?)
            //  - second query to get identity value
            //  - set _stages = null;
            //  - return ident
            throw new NotSupportedException();
        }

    }
}
