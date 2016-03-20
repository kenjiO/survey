using System.Collections.Generic;
using Evaluation.Model;
using System;

namespace Evaluation.Controller
{
    /// <summary>
    /// Evaluation Schedule View-Controller
    /// </summary>
    public partial class EvaluationController : IEvaluationController
    {
        private List<Cohort> _cohorts;

        public List<Cohort> getCohorts()
        {
            _cohorts = _dal.getCohorts();
            return _cohorts;
        }

        private bool tryLoadCohortList()
        {
            if (_cohorts == null)
            {
                try
                {
                    getCohorts();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public string getCohortName(int cohortId)
        {
            if (!tryLoadCohortList())
            {
                return "";
            }
            Cohort result = _cohorts.Find(c => c.cohortId == cohortId);
            if (result == null || result.cohortId != cohortId)
            {
                _cohorts = null;
                return "";
            }
            return result.cohortName;
        }


        public Cohort addCohort(String name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name is null");
            }
            Cohort result = _dal.addNewCohort(name);
            _cohorts = null;
            return result;
        }

        public List<EvaluationSchedule> getEvaluationScheduleList(int cohortId)
        {
            return _dal.getEvaluationScheduleList(cohortId);
        }

        public List<Employee> getMembersOfCohort(int cohortId)
        {
            return _dal.getMembersOfCohort(cohortId);
        }

        public List<Employee> getMembersNotInCohort()
        {
            return _dal.getMembersNotInCohort();
        }

        public List<int> addMembersToCohort(int cohortId, List<int> empIdList)
        {
            return _dal.addMembersToCohort(cohortId, empIdList);
        }

        public List<CohortScheduleData> getCohortAddScheduleInfo(int cohortId)
        {
            return _dal.getCohortAddScheduleInfo(cohortId);
        }

        public void addCohortSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate)
        {
            _dal.addCohortSchedule(cohortId, typeId, stageId, startDate, endDate);
        }

    }
}
