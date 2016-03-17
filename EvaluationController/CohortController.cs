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
        public string getCohortName(int cohortId)
        {
            // TODO: Finish
            throw new NotSupportedException();
        }

        public List<Cohort> getCohorts()
        {
            //TODO get real list from the DB

            List<Cohort> cohorts = new List<Cohort>();
            cohorts.Add(new Cohort(1, "cohort 1"));
            cohorts.Add(new Cohort(2, "cohort 2"));
            return cohorts;
        }
        public Cohort addCohort(String name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name is null");
            }
            return _dal.addNewCohort(name);
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

    }
}
