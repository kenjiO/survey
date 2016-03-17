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
        public List<EvalType> getTypeList()
        {
            // TODO: Use DAL to acquire type list
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get type name from typeId
        /// </summary>
        /// <param name="typeId">the id of the type</param>
        /// <returns>the name of the type with the given id</returns>
        public string getTypeName(int typeId)
        {
            return _dal.getTypeName(typeId);
        }
    }
}
