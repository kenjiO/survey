using Evaluation.DAL;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Evaluation.Controller
{
    /// <summary>
    /// Evaluation View-Controller
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

        #region Types
        public List<EvalType> getTypeList()
        {
            // TODO: Use DAL to acquire type list
            throw new NotSupportedException();
        }
        #endregion

        #region Admin Reports
        public DataTable getUserReport(int stage, int evalType)
        {
            // TODO: Use DAL to acquire report details
            throw new NotSupportedException();
        }
        #endregion

    }
}
