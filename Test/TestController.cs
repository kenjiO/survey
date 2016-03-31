﻿using Evaluation.Controller;
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

        public Employee currentUser { get { return _currentUser; } }
        public bool idAdminSession { get { return _isAdminSession; } }
        
        #region Stages
        public List<Stage> getStageList()
        {
            List<Stage> results = new List<Stage>();

            results.Add(new Stage(1, "Stage 1"));
            results.Add(new Stage(2, "Stage 2"));
            results.Add(new Stage(3, "Stage 3"));
            results.Add(new Stage(4, "Stage 4"));
            results.Add(new Stage(5, "Stage 5"));
            return results;
        }

        public bool stageExists(string name)
        {
            List<Stage> _stages = getStageList();
            return _stages.Exists(s => s.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public string getStageName(int stageId)
        {
            List<Stage> _stages = getStageList();
            Stage result = _stages.Find(s => s.id == stageId);
            if (result == null || result.id != stageId)
            {
                throw new KeyNotFoundException("Stage Id " + stageId + " not found");
            }
            return result.name;
        }


        public int? getNextStageId(int? stageId)
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

        public int addStage(string name)
        {
            return 5;
        }

        #endregion

        #region Types
        public List<EvalType> getTypeList()
        {
            List<EvalType> results = new List<EvalType>();

            results.Add(new EvalType(1, "Type 1", 5));
            results.Add(new EvalType(2, "Type 2", 10));
            return results;
        }

        public bool typeExists(string name)
        {
            List<EvalType> _types = getTypeList();
            return _types.Exists(s => s.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public string getTypeName(int typeId)
        {
            List<EvalType> _types = getTypeList();
            EvalType result = _types.Find(s => s.id == typeId);
            if (result == null || result.id != typeId)
            {
                throw new KeyNotFoundException("Type Id " + typeId + " not found");
            }
            return result.name;
        }

        public int addType(string name)
        {
            return 3;
        }

        #endregion

        #region Roles
        public List<Role> getRoleList()
        {
            List<Role> results = new List<Role>();

            results.Add(new Role(1, "Self"));
            results.Add(new Role(2, "Coworker"));
            results.Add(new Role(3, "Supervisor"));
            return results;
        }

        public bool roleExists(string name)
        {
            List<Role> _roles = getRoleList();
            return _roles.Exists(r => r.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public string getRoleName(int roleId)
        {
            List<Role> _roles = getRoleList();
            Role result = _roles.Find(r => r.id == roleId);
            if (result == null || result.id != roleId)
            {
                throw new KeyNotFoundException("Role Id " + roleId + " not found");
            }
            return result.name;
        }


        #endregion

        #region Cohorts
        public String getCohortName(int cohortId)
        {
            List<Cohort> _cohorts = getCohorts();
            Cohort result = _cohorts.Find(c => c.cohortId == cohortId);
            if (result == null || result.cohortId != cohortId)
            {
                throw new KeyNotFoundException("Cohort " + cohortId + " not found");
            }
            return result.cohortName;
        }

        public List<Cohort> getCohorts()
        {
            List<Cohort> cohorts = new List<Cohort>();
            cohorts.Add(new Cohort(1, "Cohort 1"));
            cohorts.Add(new Cohort(2, "Cohort 2"));
            return cohorts;
        }

        public Cohort addCohort(String name)
        {
            return null;
        }

        public List<EvaluationSchedule> getEvaluationScheduleList(int cohortId)
        {
            List<EvaluationSchedule> results = new List<EvaluationSchedule>();
            switch (cohortId)
            {
                case 1:
                    results.Add(new EvaluationSchedule(1, 1, 1, 1, DateTime.Now, DateTime.Parse("2016-06-10")));
                    results.Add(new EvaluationSchedule(2, 1, 2, 1, DateTime.Now, DateTime.Parse("2016-06-10")));
                    break;
                case 2:
                    results.Add(new EvaluationSchedule(3, 2, 1, 1, DateTime.Now, DateTime.Parse("2016-06-10")));
                    break;
                default:
                    throw new KeyNotFoundException("Invalid cohort id, " + cohortId);
            }
            return results;
        }

        public List<Employee> getMembersOfCohort(int cohortId)
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

        public List<Employee> getMembersNotInCohort()
        {
            List<Employee> results = new List<Employee>();
            results.Add(new Employee(4, "John", "Smith", "john_smith@gmail.com", false));
            results.Add(new Employee(5, "Sam", "Black", "sam_black@gmail.com", false));
            
            return results;
        }

        public List<int> addMembersToCohort(int _cohortId, List<int> empIdList)
        {
            return new List<int>();
        }

        public List<CohortScheduleData> getCohortAddScheduleInfo(int cohortId)
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

        public int addCohortSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate)
        {
            if (cohortId == 1)
            {
                return 5;
            }
            throw new ArgumentException("Invalid configuration (test)");
        }

        public bool deleteCohort(int _cohortId)
        {
            return false ;
        }

        public bool renameCohort(int cohortId, string oldName, string newName)
        {
            return false;
        }

        public List<Cohort> getCohortsWithNoMembersOrEvals()
        {
            List<Cohort> cohorts = new List<Cohort>();
            cohorts.Add(new Cohort(1, "cohort1"));
            cohorts.Add(new Cohort(2, "cohort2"));
            return cohorts;
        }

        #endregion

        #region Employees
        public List<EmployeeName> getEmployeeNameList()
        {
            List<EmployeeName> results = new List<EmployeeName>();

            results.Add(new EmployeeName( 54, "Steve", "Anderson"));
            results.Add(new EmployeeName(  3, "John", "Doe"));
            results.Add(new EmployeeName(105, "Zoe", "Doe"));
            results.Add(new EmployeeName( 22, "Bob", "Jones"));
            results.Add(new EmployeeName(141, "Ann", "Smith"));
            return results;
        }

        public List<EmployeeName> getListOfNonAdminEmployees(int[] exclude)
        {
            List<EmployeeName> names = new List<EmployeeName>();
            names.Add(new EmployeeName(1, "Tom", "Ryser"));
            names.Add(new EmployeeName(2, "Dora", "Ado"));
            return names;
        }

        public bool isSupervisorSelectedForCurrentUser()
        {
            return _currentUser.supervisorId == null;
        }

        public void setSupervisor(int supervisorId)
        {
            _currentUser.supervisorId = supervisorId;
        }

        public String getEmployeeName(int employeeId)
        {
            return "Employee Name";
        }

        #endregion

        #region Login
        public Employee login(string email, string password)
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
        public DataTable getUserReport(int stage, int evalType)
        {
            DataTable table = UserReport.createDataTable();
            // EmployeeId, Stage, Type, Category, Question, Self, Coworker, Supervisor, Average
            Object[] row1 = {    1, "Stage 1", "Type 1", null, null, null, null, null, null };
            Object[] row2 = { null, null, null, "Category 1", 1, 3, 4, 5, 4 };
            Object[] row3 = { null, null, null, "Category 1", 2, 3, 2, 3, 3 };
            Object[] row4 = {    2, "Stage 1", "Type 1", null, null, null, null, null, null };
            Object[] row5 = { null, null, null, "Category 1", 1, 3, 4, 5, 4 };
            Object[] row6 = { null, null, null, "Category 1", 2, 3, 2, 3, 3 };
             
            table.Rows.Add(row1);
            table.Rows.Add(row2);
            table.Rows.Add(row3);
            table.Rows.Add(row4);
            table.Rows.Add(row5);
            table.Rows.Add(row6);
            return table;
        }

        public bool DeleteSchedule(EvaluationSchedule selectedSchedule)
        {
            return true;
        }
        #endregion

        #region Evaluation

        public bool isSelfEvaluationStarted(int empId, int typeId, int stageId)
        {
            return false;
        }

        public void initializeSelfEvaluation(int typeId, int stageId, int coworkerId)
        {
            return;
        }

        public List<OpenEvaluation> getOpenSelfEvaluations(int employeeId)
        {
            List<OpenEvaluation> results = new List<OpenEvaluation>();

            results.Add(new OpenEvaluation(1, "Jones, Jim (1234)", 1, "Self", "Type 1", "Stage 1", DateTime.Parse("3/5/2016"), DateTime.Parse("6/5/2016")));
            results.Add(new OpenEvaluation(2, "Jones, Jim (1234)", 1, "Self", "Type 2", "Stage 3", DateTime.Parse("2/5/2016"), DateTime.Parse("5/5/2016")));

            return results;
        }

        public List<OpenEvaluation> getOpenPeerEvaluations(int employeeId)
        {
            List<OpenEvaluation> results = new List<OpenEvaluation>();

            results.Add(new OpenEvaluation(1, "Duke, Daisy (5678)", 2, "Co-worker", "Type 1", "Stage 1", DateTime.Parse("3/5/2016"), DateTime.Parse("6/5/2016")));
            results.Add(new OpenEvaluation(2, "Simpson, Bart (12)", 2, "Co-worker", "Type 2", "Stage 3", DateTime.Parse("2/5/2016"), DateTime.Parse("5/5/2016")));
            results.Add(new OpenEvaluation(1, "Groot, Iam (0)", 3, "Supervisor", "Type 1", "Stage 1", DateTime.Parse("3/5/2016"), DateTime.Parse("6/5/2016")));

            return results;
        }

        #endregion
    }
}
