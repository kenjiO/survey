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

        #region Stages
        List<Stage> getStageList()
        {
            return _controller.getStageList();
        }
        #endregion

        #region Cohorts
        List<Cohort> getCohorts()
        {
            throw new NotSupportedException();
        }

        Cohort addNewCohort(String name)
        {
            throw new NotSupportedException();
        }

        List<EvaluationSchedule> getEvaluationScheduleList(int cohortId)
        {
            throw new NotSupportedException();
        }

        List<Employee> getMembersOfCohort(int cohortId)
        {
            throw new NotSupportedException();
        }

        List<Employee> getMembersNotInCohort()
        {
            throw new NotSupportedException();
        }

        List<int> addMembersToCohort(int cohortId, List<int> empIdList)
        {
            throw new NotSupportedException();
        }

        #endregion

        List<EmployeeName> getEmployeeNameList()
        {
            throw new NotSupportedException();
        }

        Employee getLogin(String username, String password)
        {
            throw new NotSupportedException();
        }

        #region Types
        string getTypeName(int typeId)
        {
            throw new NotSupportedException();
        }

        #endregion

        
    }
}
