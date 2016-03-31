using System.Collections.Generic;
using Evaluation.Model;
using System;
using System.Data;

namespace Evaluation.Controller
{
    /// <summary>
    /// Evaluation Schedule View-Controller
    /// </summary>
    public partial class EvaluationController : IEvaluationController
    {
        private List<Cohort> _cohorts;

        public List<Cohort> GetCohorts()
        {
            _cohorts = _dal.GetCohorts();
            return _cohorts;
        }

        private bool TryLoadCohortList()
        {
            if (_cohorts == null)
            {
                try
                {
                    GetCohorts();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public string GetCohortName(int cohortId)
        {
            if (!TryLoadCohortList())
            {
                return "";
            }
            Cohort result = _cohorts.Find(c => c.CohortId == cohortId);
            if (result == null || result.CohortId != cohortId)
            {
                _cohorts = null;
                return "";
            }
            return result.CohortName;
        }


        public Cohort AddCohort(String name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name is null");
            }
            Cohort result = _dal.AddNewCohort(name);
            _cohorts = null;
            return result;
        }

        public List<EvaluationSchedule> GetEvaluationScheduleList(int cohortId)
        {
            return _dal.GetEvaluationScheduleList(cohortId);
        }

        public List<Employee> GetMembersOfCohort(int cohortId)
        {
            return _dal.GetMembersOfCohort(cohortId);
        }

        public List<Employee> GetMembersNotInCohort()
        {
            return _dal.GetMembersNotInCohort();
        }

        public List<int> AddMembersToCohort(int cohortId, List<int> empIdList)
        {
            return _dal.AddMembersToCohort(cohortId, empIdList);
        }

        public List<CohortScheduleData> GetCohortAddScheduleInfo(int cohortId)
        {
            List<CohortScheduleData> results = new List<CohortScheduleData>();
            DataTable table = _dal.GetCohortAddScheduleInfo(cohortId);
            
            foreach (DataRow row in table.Rows)
            {
                int typeId = (int)row["typeId"];
                int? lastStageId = null;
                if (!DBNull.Value.Equals(row["lastStageId"]))
                {
                    lastStageId = (int)row["lastStageId"];
                }
                DateTime? lastStageEndDate = null;
                if (!DBNull.Value.Equals(row["lastStageEndDate"]))
                {
                    lastStageEndDate = (DateTime)row["lastStageEndDate"];
                }

                results.Add(new CohortScheduleData(typeId, GetTypeName(typeId), lastStageEndDate, GetNextStageId(lastStageId)));
            }
            return results;
        }

        public int AddCohortSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate)
        {
            return _dal.AddCohortSchedule(cohortId, typeId, stageId, startDate, endDate);
        }

        public bool DeleteCohort(int cohortId)
        {
            return _dal.DeleteCohort(cohortId);
        }

        public bool RenameCohort(int cohortId, string oldName, string newName)
        {
            return _dal.RenameCohort(cohortId, oldName, newName);
        }

        public List<Cohort> GetCohortsWithNoMembersOrEvals()
        {
            return _dal.GetCohortsWithNoMembersOrEvals();
        }

    }
}
