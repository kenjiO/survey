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
        private List<EvalType> _types;

        public List<EvalType> getTypeList()
        {
            _types = _dal.getTypeList();
            return _types;
        }

        private bool tryLoadTypeList()
        {
            if (_types == null)
            {
                try
                {
                    getTypeList();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public bool typeExists(string name)
        {
            if (!tryLoadTypeList())
            {
                return false;
            }
            return _types.Exists(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public string getTypeName(int typeId)
        {
            if (!tryLoadTypeList())
            {
                return "";
            }
            EvalType result = _types.Find(t => t.Id == typeId);
            if (result == null || result.Id != typeId)
            {
                _types = null;
                return "";
            }
            return result.Name;
        }

        public int addType(string name)
        {
            // TODO: add type, return identity column
            //  - name should be non-null, non-empty string
            //  - name should not already exist (can you have a WHERE statement in an INSERT command?)
            //  - second query to get identity value
            //  - set _types = null;
            //  - return ident
            throw new NotSupportedException();
        }

    }
}
