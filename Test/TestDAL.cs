using Evaluation.Controller;
using Evaluation.DAL;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestDAL : IEvaluationDAL
    {
        private IEvaluationController _controller = new TestController();

        #region Types
        public List<EvalType> GetTypeList()
        {
            return _controller.GetTypeList();
        }

        #endregion

        #region Stages
        public List<Stage> GetStageList()
        {
            return _controller.GetStageList();
        }
        #endregion

        #region Roles
        public List<Role> GetRoleList()
        {
            return _controller.GetRoleList();
        }
        #endregion

        #region Cohorts
        public List<Cohort> GetCohorts()
        {
            return _controller.GetCohorts();
        }

        public List<Cohort> GetCohortsWithNoMembersOrEvals()
        {
            throw new NotSupportedException();
        }

        public Cohort AddNewCohort(String name)
        {
            throw new NotSupportedException();
        }

        public List<Employee> GetMembersOfCohort(int cohortId)
        {
            throw new NotSupportedException();
        }

        public List<Employee> GetMembersNotInCohort()
        {
            throw new NotSupportedException();
        }

        public List<int> AddMembersToCohort(int cohortId, List<int> empIdList)
        {
            throw new NotSupportedException();
        }

        public DataTable GetCohortAddScheduleInfo(int cohortId)
        {
            DataTable table = EvaluationDAL.CreateCohortAddScheduleInfoDataTable();

            if (cohortId == 1) 
            {
                Object[] row1 = { 1, null, null };
                Object[] row2 = { 2, 2, DateTime.Parse("6/5/2016") };

                table.Rows.Add(row1);
                table.Rows.Add(row2);
            }
            else
            {
                Object[] row1 = { 1, 4, DateTime.Parse("4/15/2016") };
                Object[] row2 = { 2, 5, DateTime.Parse("5/25/2016") };

                table.Rows.Add(row1);
                table.Rows.Add(row2);
            }
            return table;
        }

        private DataTable createCohortAddScheduleInfoDataTable()
        {
            throw new NotImplementedException();
        }

        public bool DeleteCohort(int cohortId)
        {
            throw new NotImplementedException();

        }

        public bool RenameCohort(int cohortId, string oldName, string newName)
        {
            throw new NotImplementedException("TestDal.renameCohort() not implemented");
        }

        #endregion

        #region Employees
        public Employee GetLogin(String username, String password)
        {
            throw new NotSupportedException();
        }

        public int GetEmployeeCohortId(int employeeId)
        {
            return 1;
        }

        public EmployeeName GetEmployeeName(int employeeId)
        {
            return new EmployeeName(employeeId, "John", "Silver");
        }

        public List<EmployeeName> GetListOfNonAdminEmployees()
        {
            throw new NotSupportedException();
        }

        public bool IsSupervisorSelected(int employeeId)
        {
            return false;
        }

        #endregion

        #region Schedules
        public bool DeleteSchedule(EvaluationSchedule selectedSchedule)
        {
            return true;
        }

        public List<EvaluationSchedule> GetEvaluationScheduleList(int cohortId, int? typeId, int? stageId)
        {
            return _controller.GetEvaluationScheduleList(cohortId, typeId, stageId);
        }

        public int AddEvaluationSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate)
        {
            return 5;
        }

        public void UpdateEvaluationSchedule(int scheduleId, DateTime startDate, DateTime endDate, DateTime originalStartDate, DateTime originalEndDate)
        {            
        }
        #endregion

        #region Admin Reports
        public List<UserReport> GetUserReport(int employeeId, int typeId, int stageId)
        {
            return _controller.GetUserReport(employeeId, typeId, stageId);
        }

        public List<CohortReport> GetCohortReport(int cohortId, int typeId)
        {
            List<CohortReport> reportDataPoints = new List<CohortReport>();
            reportDataPoints.Add(new CohortReport("stage1", "category1", 50.0m));
            reportDataPoints.Add(new CohortReport("stage1", "category2", 60.0m));
            reportDataPoints.Add(new CohortReport("stage2", "category1", 70.0m));
            reportDataPoints.Add(new CohortReport("stage2", "category2", 80.0m));
            return reportDataPoints;
        }

        #endregion

        #region Evaluations
        public bool SetSupervisor(int employeeId, int supervisorId)
        {
            throw new NotSupportedException();
        }

        public EvaluationDetails getEvaluationDetails(int evaluationId)
        {
            return _controller.getEvaluationDetails(evaluationId);
        }

        public List<OpenEvaluation> GetOpenSelfEvaluations(int employeeId)
        {
            return _controller.GetOpenSelfEvaluations(employeeId);
        }

        public List<OpenEvaluation> GetOpenPeerEvaluations(int employeeId)
        {
            return _controller.GetOpenPeerEvaluations(employeeId);
        }

        public int IsSelfEvaluationStarted(int employeeId, int scheduleId)
        {
            return 0;
        }

        public int InitializeSelfEvaluation(int employeeId, int scheduleId, int coworkerId)
        {
            return 1;
        }

        public List<QAndA> GetQuestionsAndAnswers(int evaluationId)
        {
            return _controller.GetQuestionsAndAnswers(evaluationId);
        }

        public int CreateNewAnswerRecord(int evaluationId, int questionId, int answer)
        {
            throw new NotSupportedException();
        }

        public void SaveAnswer(int answerId, int newAnswer)
        {
            throw new NotSupportedException();
        }

        public void CloseEvaluation(int evaluationId)
        {
            throw new NotSupportedException();
        }
        #endregion

    }
}
