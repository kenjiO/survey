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
        public List<QAndA> GetQuestionsAndAnswers(int evaluationId)
        {
            return _dal.GetQuestionsAndAnswers(evaluationId);
        }

        /// <summary>
        /// Creates a new answer record in the database
        /// </summary>
        /// <param name="_evaluationId">id of the evaluation</param>
        /// <param name="questionId">id of the question</param>
        /// <param name="answer">id of the answer</param>
        /// <returns>answerId of the newly created row, else 0</returns>
        public int CreateNewAnswerRecord(int evaluationId, int questionId, int answer)
        {
            return _dal.CreateNewAnswerRecord(evaluationId, questionId, answer);
        }

        /// <summary>
        /// Saves an answer in the database
        /// </summary>
        /// <param name="answerId">id of record to update</param>
        public void SaveAnswer(int answerId, int newAnswer)
        {
            _dal.SaveAnswer(answerId, newAnswer);
        }
    }
}
