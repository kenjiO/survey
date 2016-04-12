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

        public List<EvalType> GetTypeList()
        {
            _types = _dal.GetTypeList();
            return _types;
        }

        private bool TryLoadTypeList()
        {
            if (_types == null)
            {
                try
                {
                    GetTypeList();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public bool TypeExists(string name)
        {
            if (!TryLoadTypeList())
            {
                return false;
            }
            return _types.Exists(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public string GetTypeName(int typeId)
        {
            if (!TryLoadTypeList())
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

        public int AddType(string name)
        {
            // If add type is needed, flesh out this function
            //  - add type, return identity column
            //  - name should be non-null, non-empty string
            //  - name should not already exist (can you have a WHERE statement in an INSERT command?)
            //  - second query to get identity value
            //  - set _types = null;
            //  - return ident
            throw new NotSupportedException();
        }

    }
}
