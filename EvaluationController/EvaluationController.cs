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

        /// <summary>
        /// Get Details required to show an evaluation form
        /// </summary>
        /// <param name="_evaluationId">the id of the evaluation</param>
        /// <returns>EvaluationDetails object</returns>
        public EvaluationDetails getEvaluationDetails(int evaluationId)
        {
            return _dal.getEvaluationDetails(evaluationId);
        }

        /// <summary>
        /// Gets a list of questions and answers for an evaluation record
        /// </summary>
        /// <param name="evaluationId">id of the evaluation</param>
        /// <returns>list of QAndA objects</returns>
        public List<QAndA> getQuestionsAndAnswers(int evaluationId)
        {
            return _dal.getQuestionsAndAnswers(evaluationId);
        }
    }
}
