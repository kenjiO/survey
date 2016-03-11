using Evaluation.DAL;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Controller
{
    /// <summary>
    /// Evaluation view controller
    /// </summary>
    public partial class EvaluationController : IEvaluationController
    {
        IEvaluationDAL _dal;

        public EvaluationController(IEvaluationDAL dal) 
        {
            _dal = dal;
            if (_dal == null)
            {
                throw new ArgumentNullException("DAL is null");
            }
        }

        public List<Stage> getStageList()
        {
            // TODO: Use DAL to acquire stage list
            throw new NotSupportedException();
        }

        public List<EvalType> getTypeList()
        {
            // TODO: Use DAL to acquire type list
            throw new NotSupportedException();
        }

        public string getCohortName(int cohortId)
        {
            // TODO: Finish
            throw new NotSupportedException();
        }

        public DataTable getUserReport(int stage, int evalType)
        {
            // TODO: Use DAL to acquire report details
            throw new NotSupportedException();
        }

    }
}
