using Evaluation.Controller;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Test
{
    public class TestController : IEvaluationController
    {
        private Employee _currentUser;
        private bool _isAdminSession;

        public Employee CurrentUser { get { return _currentUser; } }
        public bool IsAdminSession { get { return _isAdminSession; } }

        #region Stages
        public List<Stage> GetStageList()
        {
            List<Stage> results = new List<Stage>();

            results.Add(new Stage(1, "Stage 1"));
            results.Add(new Stage(2, "Stage 2"));
            results.Add(new Stage(3, "Stage 3"));
            results.Add(new Stage(4, "Stage 4"));
            results.Add(new Stage(5, "Stage 5"));
            return results;
        }

        public bool StageExists(string name)
        {
            List<Stage> _stages = GetStageList();
            return _stages.Exists(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public string GetStageName(int stageId)
        {
            List<Stage> _stages = GetStageList();
            Stage result = _stages.Find(s => s.Id == stageId);
            if (result == null || result.Id != stageId)
            {
                throw new KeyNotFoundException("Stage Id " + stageId + " not found");
            }
            return result.Name;
        }


        public int? GetNextStageId(int? stageId)
        {
            if (stageId == null)
            {
                return 1;
            }
            if (stageId < 5)
            {
                return stageId + 1;
            }
            return null;
        }

        public int AddStage(string name)
        {
            return 5;
        }

        #endregion

        #region Types
        public List<EvalType> GetTypeList()
        {
            List<EvalType> results = new List<EvalType>();

            results.Add(new EvalType(1, "Type 1", 5));
            results.Add(new EvalType(2, "Type 2", 10));
            return results;
        }

        public bool TypeExists(string name)
        {
            List<EvalType> _types = GetTypeList();
            return _types.Exists(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public string GetTypeName(int typeId)
        {
            List<EvalType> _types = GetTypeList();
            EvalType result = _types.Find(s => s.Id == typeId);
            if (result == null || result.Id != typeId)
            {
                throw new KeyNotFoundException("Type Id " + typeId + " not found");
            }
            return result.Name;
        }

        public int AddType(string name)
        {
            return 3;
        }

        #endregion

        #region Roles
        public List<Role> GetRoleList()
        {
            List<Role> results = new List<Role>();

            results.Add(new Role(1, "Self"));
            results.Add(new Role(2, "Coworker"));
            results.Add(new Role(3, "Supervisor"));
            return results;
        }

        public bool RoleExists(string name)
        {
            List<Role> _roles = GetRoleList();
            return _roles.Exists(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public string GetRoleName(int roleId)
        {
            List<Role> _roles = GetRoleList();
            Role result = _roles.Find(r => r.Id == roleId);
            if (result == null || result.Id != roleId)
            {
                throw new KeyNotFoundException("Role Id " + roleId + " not found");
            }
            return result.Name;
        }


        #endregion

        #region Cohorts
        public String GetCohortName(int cohortId)
        {
            List<Cohort> _cohorts = GetCohorts();
            Cohort result = _cohorts.Find(c => c.CohortId == cohortId);
            if (result == null || result.CohortId != cohortId)
            {
                throw new KeyNotFoundException("Cohort " + cohortId + " not found");
            }
            return result.CohortName;
        }

        public List<Cohort> GetCohorts()
        {
            List<Cohort> cohorts = new List<Cohort>();
            cohorts.Add(new Cohort(1, "Cohort 1"));
            cohorts.Add(new Cohort(2, "Cohort 2"));
            return cohorts;
        }

        public Cohort AddCohort(String name)
        {
            return null;
        }

        public List<Employee> GetMembersOfCohort(int cohortId)
        {
            List<Employee> results = new List<Employee>();
            switch (cohortId)
            {
                case 1:
                    results.Add(new Employee(1, "John", "Smith", "johnsmith@gmail.com", false));
                    results.Add(new Employee(2, "Sam", "Black", "samblack@gmail.com", false));
                    break;
                case 2:
                    results.Add(new Employee(3, "Sandy", "William", "sandywilliam@gmail.com", false));
                    break;
                default:
                    throw new KeyNotFoundException("Invalid cohort id, " + cohortId);
            }
            return results;
        }

        public List<Employee> GetMembersNotInCohort()
        {
            List<Employee> results = new List<Employee>();
            results.Add(new Employee(4, "John", "Smith", "john_smith@gmail.com", false));
            results.Add(new Employee(5, "Sam", "Black", "sam_black@gmail.com", false));

            return results;
        }

        public List<int> AddMembersToCohort(int _cohortId, List<int> empIdList)
        {
            return new List<int>();
        }

        public List<CohortScheduleData> GetCohortAddScheduleInfo(int cohortId)
        {
            List<CohortScheduleData> list = new List<CohortScheduleData>();

            if (cohortId == 1)
            {
                list.Add(new CohortScheduleData(1, "Type 1", null, 1)); // type 1 has no current schedules for this cohort
                list.Add(new CohortScheduleData(2, "Type 2", DateTime.Parse("6/5/2016"), 3)); // type 2 has stages 1 and 2 for this cohort
            }
            else
            {
                list.Add(new CohortScheduleData(1, "Type 1", DateTime.Parse("4/15/2016"), 5)); // type 1 has stages 1-4 for this cohort
                list.Add(new CohortScheduleData(2, "Type 2", DateTime.Parse("5/25/2016"), null)); // type 2 all 5 stages scheduled for this cohort
            }
            return list;
        }

        public bool DeleteCohort(int _cohortId)
        {
            return false ;
        }

        public bool RenameCohort(int cohortId, string oldName, string newName)
        {
            return false;
        }

        public List<Cohort> GetCohortsWithNoMembersOrEvals()
        {
            List<Cohort> cohorts = new List<Cohort>();
            cohorts.Add(new Cohort(1, "cohort1"));
            cohorts.Add(new Cohort(2, "cohort2"));
            return cohorts;
        }

        #endregion

        #region Employees

        public EmployeeName GetEmployeeName(int employeeId)
        {
            return new EmployeeName(1, "Tom", "Ryser");
        }

        public String GetEmployeeNameFL(int employeeId)
        {
            return "Cindy Who (" + employeeId + ")";
        }

        public bool IsSupervisorSelected(int employeeId)
        {
            return false;
        }

        public List<EmployeeName> GetListOfNonAdminEmployees(int[] exclude)
        {
            List<EmployeeName> names = new List<EmployeeName>();
            names.Add(new EmployeeName(1, "Tom", "Ryser"));
            names.Add(new EmployeeName(2, "Dora", "Ado"));
            return names;
        }

        public bool IsSupervisorSelectedForCurrentUser()
        {
            return _currentUser.SupervisorId == null;
        }

        public void SetSupervisor(int supervisorId)
        {
            _currentUser.SupervisorId = supervisorId;
        }

        #endregion

        #region Schedules
        public bool DeleteSchedule(EvaluationSchedule selectedSchedule)
        {
            return true;
        }

        public List<EvaluationSchedule> GetEvaluationScheduleList(int cohortId)
        {
            return GetEvaluationScheduleList(cohortId, null, null);
        }

        public List<EvaluationSchedule> GetEvaluationScheduleList(int cohortId, int? typeId, int? stageId)
        {
            List<EvaluationSchedule> results = new List<EvaluationSchedule>();
            switch (cohortId)
            {
                case 1:
                    if (typeId == null || typeId == 1)
                    {
                        if (stageId == null || stageId == 1)
                        {
                            results.Add(new EvaluationSchedule(1, 1, 1, 1, DateTime.Parse("2016-01-01"), DateTime.Parse("2016-01-20")));
                        }
                        if (stageId == null || stageId == 2)
                        {
                            results.Add(new EvaluationSchedule(2, 1, 1, 2, DateTime.Parse("2016-03-01"), DateTime.Parse("2016-03-10")));
                        }
                        if (stageId == null || stageId == 3)
                        {
                            results.Add(new EvaluationSchedule(3, 1, 1, 3, DateTime.Parse("2016-06-01"), DateTime.Parse("2016-06-10")));
                        }
                    }
                    if (typeId == null || typeId == 2)
                    {
                        if (stageId == null || stageId == 1)
                        {
                            results.Add(new EvaluationSchedule(4, 1, 2, 1, DateTime.Parse("2016-06-01"), DateTime.Parse("2016-06-10")));
                        }
                    }
                    break;
                case 2:
                    if (typeId == null || typeId == 1)
                    {
                        if (stageId == null || stageId == 1)
                        {
                            results.Add(new EvaluationSchedule(5, 2, 1, 1, DateTime.Parse("2016-06-10"), DateTime.Parse("2016-06-10")));
                        }
                    }
                    break;
                default:
                    throw new KeyNotFoundException("Invalid cohort id, " + cohortId);
            }
            return results;
        }

        public int AddEvaluationSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate)
        {
            if (cohortId == 1)
            {
                return 5;
            }
            throw new ArgumentException("Invalid configuration (test)");
        }

        public DateRange GetScheduleDateRange(int cohortId, int typeId, int stageId)
        {
            return new DateRange(DateTime.Parse("1/1/2000"), DateTime.Parse("12/31/2100"));
        }

        public void UpdateEvaluationSchedule(int scheduleId, DateTime startDate, DateTime endDate, DateTime originalStartDate, DateTime originalEndDate)
        {
        }
        #endregion

        #region Login
        public Employee Login(string email, string password)
        {
            _isAdminSession = false;
            if (password == null || password.Length == 0)
            {
                return null;
            }
            if (email.IndexOf("admin") >= 0)
            {
                _currentUser = new Employee(1, "Jane", "Admin", email, true);
                _isAdminSession = true;
            }
            else
            {
                _currentUser = new Employee(1, "John", "Smith", email, false);
            }
            return _currentUser;
        }
        #endregion

        #region Admin Reports
        public List<UserReport> GetUserReport(int employeeId, int typeId, int stageId)
        {
            List<UserReport> results = new List<UserReport>();

            results.Add(new UserReport("Category 1",  1, 3, 4, 5));
            results.Add(new UserReport("Category 1",  2, 5, 4, 5));
            results.Add(new UserReport("Category 1",  3, 3, 4, 3));
            results.Add(new UserReport("Category 1",  4, 4, 4, 5));
            results.Add(new UserReport("Category 1",  5, 3, 2, 2));
            results.Add(new UserReport("Category 2",  6, 3, 3, 3));
            results.Add(new UserReport("Category 2",  7, 3, 3, 5));
            results.Add(new UserReport("Category 2",  8, 3, 4, 4));
            results.Add(new UserReport("Category 2",  9, 1, 4, 1));
            results.Add(new UserReport("Category 2", 10, 2, 2, 5));
            results.Add(new UserReport("Category 3", 11, 3, 4, 5));
            results.Add(new UserReport("Category 3", 12, 5, 4, 5));
            results.Add(new UserReport("Category 3", 13, 3, 4, 3));
            results.Add(new UserReport("Category 3", 14, 4, 4, 5));
            results.Add(new UserReport("Category 3", 15, 3, 2, 2));
            results.Add(new UserReport("Category 4", 16, 3, 3, 3));
            results.Add(new UserReport("Category 4", 17, 3, 3, 5));
            results.Add(new UserReport("Category 4", 18, 3, 4, 4));
            results.Add(new UserReport("Category 4", 19, 1, 4, 1));
            results.Add(new UserReport("Category 4", 10, 2, 2, 5));
            results.Add(new UserReport("Category 5", 11, 3, 4, 5));
            results.Add(new UserReport("Category 5", 12, 5, 4, 5));
            results.Add(new UserReport("Category 5", 13, 3, 4, 3));
            results.Add(new UserReport("Category 5", 14, 4, 4, 5));
            results.Add(new UserReport("Category 5", 15, 3, 2, 2));

            return results;
        }

        public List<CohortReport> GetCohortReport(int typeId, int cohortId)
        {
            List<CohortReport> results = new List<CohortReport>();
            results.Add(new CohortReport("Stag 1", "Cat1", 5));
            results.Add(new CohortReport("Stag 1", "Cat2", 15));
            results.Add(new CohortReport("Stag 1", "Cat3", 20));
            results.Add(new CohortReport("Stag 2", "Cat1", 55));
            results.Add(new CohortReport("Stag 2", "Cat2", 65));
            results.Add(new CohortReport("Stag 2", "Cat3", 75));
            results.Add(new CohortReport("Stag 3", "Cat1", 95));
            results.Add(new CohortReport("Stag 3", "Cat2", 90));
            results.Add(new CohortReport("Stag 3", "Cat3", 80));

            return results;
        }


        public List<UserReport2> GetUserReport2(int employeeId, int typeId, int stageId)
        {
            List<UserReport2> results = new List<UserReport2>();
            string _name = GetEmployeeNameFL(employeeId);
            string _type = GetTypeName(typeId);
            string _stage = GetStageName(stageId);

            results.Add(new UserReport2(_name, _type, _stage, "Category 1", 1, 3, 4, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 1", 2, 5, 4, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 1", 3, 3, 4, 3));
            results.Add(new UserReport2(_name, _type, _stage, "Category 1", 4, 4, 4, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 1", 5, 3, 2, 2));
            results.Add(new UserReport2(_name, _type, _stage, "Category 2", 6, 3, 3, 3));
            results.Add(new UserReport2(_name, _type, _stage, "Category 2", 7, 3, 3, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 2", 8, 3, 4, 4));
            results.Add(new UserReport2(_name, _type, _stage, "Category 2", 9, 1, 4, 1));
            results.Add(new UserReport2(_name, _type, _stage, "Category 2", 10, 2, 2, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 3", 11, 3, 4, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 3", 12, 5, 4, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 3", 13, 3, 4, 3));
            results.Add(new UserReport2(_name, _type, _stage, "Category 3", 14, 4, 4, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 3", 15, 3, 2, 2));
            results.Add(new UserReport2(_name, _type, _stage, "Category 4", 16, 3, 3, 3));
            results.Add(new UserReport2(_name, _type, _stage, "Category 4", 17, 3, 3, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 4", 18, 3, 4, 4));
            results.Add(new UserReport2(_name, _type, _stage, "Category 4", 19, 1, 4, 1));
            results.Add(new UserReport2(_name, _type, _stage, "Category 4", 10, 2, 2, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 5", 11, 3, 4, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 5", 12, 5, 4, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 5", 13, 3, 4, 3));
            results.Add(new UserReport2(_name, _type, _stage, "Category 5", 14, 4, 4, 5));
            results.Add(new UserReport2(_name, _type, _stage, "Category 5", 15, 3, 2, 2));

            return results;
        }

        #endregion

        #region Evaluation

        public List<OpenEvaluation> GetOpenSelfEvaluations(int employeeId)
        {
            List<OpenEvaluation> results = new List<OpenEvaluation>();

            results.Add(new OpenEvaluation(null, 1, "Jones, Jim (1234)", 1, "Self", "Type 1", "Stage 1", DateTime.Parse("3/5/2016"), DateTime.Parse("6/5/2016")));
            results.Add(new OpenEvaluation(null, 2, "Jones, Jim (1234)", 1, "Self", "Type 2", "Stage 3", DateTime.Parse("2/5/2016"), DateTime.Parse("5/5/2016")));

            return results;
        }

        public List<OpenEvaluation> GetOpenPeerEvaluations(int employeeId)
        {
            List<OpenEvaluation> results = new List<OpenEvaluation>();

            results.Add(new OpenEvaluation(1, 1, "Duke, Daisy (5678)", 2, "Co-worker", "Type 1", "Stage 1", DateTime.Parse("3/5/2016"), DateTime.Parse("6/5/2016")));
            results.Add(new OpenEvaluation(2, 2, "Simpson, Bart (12)", 2, "Co-worker", "Type 2", "Stage 3", DateTime.Parse("2/5/2016"), DateTime.Parse("5/5/2016")));
            results.Add(new OpenEvaluation(3, 1, "Groot, Iam (0)", 3, "Supervisor", "Type 1", "Stage 1", DateTime.Parse("3/5/2016"), DateTime.Parse("6/5/2016")));

            return results;
        }

        public int IsSelfEvaluationStarted(int scheduleId)
        {
            return 0;
        }

        public int InitializeSelfEvaluation(int scheduleId, int coworkerId)
        {
            return 1;
        }

        public EvaluationDetails getEvaluationDetails(int evaluationId)
        {
            return new EvaluationDetails(1, 1, "Type-1", 5, 5, 3);
        }

        #endregion
    }
}
