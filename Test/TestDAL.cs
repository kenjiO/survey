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
        public List<EvalType> getTypeList()
        {
            return _controller.getTypeList();
        }

        #endregion

        #region Stages
        public List<Stage> getStageList()
        {
            return _controller.getStageList();
        }
        #endregion

        #region Cohorts
        public List<Cohort> getCohorts()
        {
            return _controller.getCohorts();
        }

        public List<Cohort> getCohortsWithNoMembersOrEvals()
        {
            throw new NotSupportedException();
        }

        public Cohort addNewCohort(String name)
        {
            throw new NotSupportedException();
        }

        public List<EvaluationSchedule> getEvaluationScheduleList(int cohortId)
        {
            throw new NotSupportedException();
        }

        public List<Employee> getMembersOfCohort(int cohortId)
        {
            throw new NotSupportedException();
        }

        public List<Employee> getMembersNotInCohort()
        {
            throw new NotSupportedException();
        }

        public List<int> addMembersToCohort(int cohortId, List<int> empIdList)
        {
            throw new NotSupportedException();
        }

        public DataTable getCohortAddScheduleInfo(int cohortId)
        {
            DataTable table = EvaluationDAL.createCohortAddScheduleInfoDataTable();

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

        public int addCohortSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate)
        {
            return 5;
        }

        public bool deleteCohort(int cohortId)
        {
            throw new NotImplementedException();

        }

        public bool renameCohort(int cohortId, string oldName, string newName)
        {
            throw new NotImplementedException("TestDal.renameCohort() not implemented");
        }

        #endregion

        #region Employees
        public Employee getLogin(String username, String password)
        {
            throw new NotSupportedException();
        }

        public int getEmployeeCohortId(int employeeId)
        {
            return 1;
        }

        public List<EmployeeName> getListOfNonAdminEmployees()
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Schedules
        public bool DeleteSchedule(EvaluationSchedule selectedSchedule)
        {
            return true;
        }

        #endregion

        #region Evaluations
        public bool isSelfEvaluationStarted(int empId, int typeId, int stageId)
        {
            throw new NotSupportedException();
        }

        public bool setSupervisor(int employeeId, int supervisorId)
        {
            throw new NotSupportedException();
        }

        public List<OpenEvaluation> getOpenSelfEvaluations(int employeeId)
        {
            return _controller.getOpenSelfEvaluations(employeeId);
        }

        public List<OpenEvaluation> getOpenOtherEvaluations(int employeeId)
        {
            return _controller.getOpenOtherEvaluations(employeeId);
        }

        public void createEvaluations(int empId, int typeId, int stageId, int coworkerId)
        {
            return;
        }

        #endregion

    }
}
