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
        public DataTable GetUserReport(int stage, int evalType)
        {
            // TODO: Use DAL to acquire report details
            throw new NotSupportedException();
        }
        #endregion


        public List<OpenEvaluation> GetOpenSelfEvaluations(int employeeId)
        {
            return _dal.GetOpenSelfEvaluations(employeeId);
        }

        public List<OpenEvaluation> GetOpenPeerEvaluations(int employeeId)
        {
            return _dal.GetOpenPeerEvaluations(employeeId);
        }

        public int IsSelfEvaluationStarted(int scheduleId)
        {
            return _dal.IsSelfEvaluationStarted(_currentUser.EmployeeId, scheduleId);
        }

        public int InitializeSelfEvaluation(int scheduleId, int coworkerId)
        {
            if (_currentUser.SupervisorId == null)
            {
                throw new CreateEvaluationException("Supervisor must be selected");
            }
            if (_currentUser.SupervisorId == coworkerId)
            {
                throw new CreateEvaluationException("Co-worker must not be the supervisor");
            }
            if (_currentUser.EmployeeId == coworkerId)
            {
                throw new CreateEvaluationException("Co-worker must be different than self");
            }
            return _dal.InitializeSelfEvaluation(_currentUser.EmployeeId, scheduleId, coworkerId);
        }

    }
}
