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

        public List<Stage> GetStageList()
        {
            _stages = _dal.GetStageList();
            return _stages;
        }

        private bool TryLoadStageList()
        {
            if (_stages == null)
            {
                try
                {
                    GetStageList();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public bool StageExists(string name)
        {
            if (!TryLoadStageList())
            {
                return false;
            }
            return _stages.Exists(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public string GetStageName(int stageId)
        {
            if (!TryLoadStageList())
            {
                return "";
            }
            Stage result = _stages.Find(s => s.Id == stageId);
            if (result == null || result.Id != stageId)
            {
                _stages = null;
                return "";
            }
            return result.Name;
        }

        public int? GetNextStageId(int? stageId)
        {
            if (!TryLoadStageList())
            {
                return null;
            }
            if (stageId == null)
            {
                return _stages[0].Id;
            }
            foreach (Stage stage in _stages)
            {
                if (stage.Id > stageId)
                {
                    return stage.Id;
                }
            }
            return null;
        }

        public int AddStage(string name)
        {
            return _dal.AddNewStage(name);
        }

        public bool RenameStage(int stageId, string oldName, string newName)
        {
            return _dal.RenameStage(stageId, oldName, newName);
        }

    }
}
