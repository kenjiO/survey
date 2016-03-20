using Evaluation.Controller;
using Evaluation.DAL;
using Evaluation.Model;
using System;
using System.Collections.Generic;
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

        #endregion

        public List<EmployeeName> getEmployeeNameList()
        {
            return _controller.getEmployeeNameList();
        }

        public Employee getLogin(String username, String password)
        {
            throw new NotSupportedException();
        }

        
    }
}
