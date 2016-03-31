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

        #region Admin Reports
        public DataTable getUserReport(int stage, int evalType)
        {
            // TODO: Use DAL to acquire report details
            throw new NotSupportedException();
        }
        #endregion


        public bool isSelfEvaluationStarted(int empId, int typeId, int stageId)
        {
            return _dal.isSelfEvaluationStarted(empId, typeId, stageId);
        }

        public void initializeSelfEvaluation(int typeId, int stageId, int coworkerId)
        {
            if (_currentUser.SupervisorId == null)
                throw new CreateEvaluationException("Supervisor must be selected");
            if (_currentUser.SupervisorId == coworkerId)
                throw new CreateEvaluationException("Co-worker must not be the supervisor");
            if (_currentUser.EmployeeId == coworkerId)
                throw new CreateEvaluationException("Co-worker must be different than self");
            _dal.createEvaluations(_currentUser.EmployeeId, typeId, stageId, coworkerId);
        }

        public List<OpenEvaluation> getOpenSelfEvaluations(int employeeId)
        {
            return _dal.getOpenSelfEvaluations(employeeId);
        }

        public List<OpenEvaluation> getOpenPeerEvaluations(int employeeId)
        {
            return _dal.getOpenPeerEvaluations(employeeId);
        }

    }
}
