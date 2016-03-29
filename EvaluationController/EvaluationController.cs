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

        /// <summary>
        /// Check to see if the employee has started an evaluation for type and stage
        /// </summary>
        /// <param name="empId">The employee</param>
        /// <param name="typeId">The typeID for the evaluation</param>
        /// <param name="stageId">The stageId for the evaluation</param>
        /// <returns>Whether or not a self-evaluation for this type and stage exists yet</returns>
        public bool isSelfEvaluationStarted(int empId, int typeId, int stageId)
        {
            return _dal.isSelfEvaluationStarted(empId, typeId, stageId);
        }

        /// <summary>
        /// Creates a self-evaluation, supervisor evaluation and co-worker evaluation 
        /// for currentUser for stage and type
        /// THROWS custom exception CreateEvaluationsException for certain errors when creating the evaluations
        /// Precondition: SupervisorId is set for currentEmployee
        /// Precondition: coworkerId is in the DB and not the supervisor or admin
        /// Precondition: Evaluations for currentEmployee at given type and stage does not exist
        /// Precondition: TypeId and StageId exist in the DB
        /// </summary>
        /// <param name="typeId">Evaluation type to create</param>
        /// <param name="stageId">Evaluation stage to create</param>
        /// <param name="coworkerId">Co-worker selected to evaluate this employee</param>
        public void initializeSelfEvaluation(int typeId, int stageId, int coworkerId)
        {
            if (_currentUser.supervisorId == null)
                throw new CreateEvaluationException("Supervisor must be selected");
            if (_currentUser.supervisorId == coworkerId)
                throw new CreateEvaluationException("Co-worker must not be the supervisor");
            if (_currentUser.employeeId == coworkerId)
                throw new CreateEvaluationException("Co-worker must be different than self");
            _dal.createEvaluations(_currentUser.employeeId, typeId, stageId, coworkerId);
        }

        public List<Evaluations> getOpenSelfEvaluations(int employeeId)
        {
            return _dal.getOpenSelfEvaluations(employeeId);
        }

        public List<Evaluations> getOpenOtherEvaluations(int employeeId)
        {
            return _dal.getOpenOtherEvaluations(employeeId);
        }

        public DateTime getEndDateForSchedule(int typeId, int stageId, int? cohortId)
        {
            return _dal.getEndDateForSchedule(typeId, stageId, cohortId);
        }

        public List<OpenEvaluation> getOpenSelfEvaluations_New(int employeeId)
        {
            return _dal.getOpenSelfEvaluations_New(employeeId);
        }

        public List<OpenEvaluation> getOpenOtherEvaluations_New(int employeeId)
        {
            return _dal.getOpenOtherEvaluations_New(employeeId);
        }

    }
}
