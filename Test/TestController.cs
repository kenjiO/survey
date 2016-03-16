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

        public String stageName(int stageId)
        {
            switch (stageId)
            {
                case 1:
                    return "Stage 1";
                case 2:
                    return "Stage 2";
                case 3:
                    return "Stage 3";
                case 4:
                    return "Stage 4";
                case 5:
                    return "Stage 5";
                default:
                    throw new KeyNotFoundException("Invalid stage, " + stageId);
            }
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

        public string getTypeName(int typeId)
        {
            switch (typeId)
            {
                case 1:
                    return "Type 1";
                case 2:
                    return "Type 2";
                default:
                    throw new KeyNotFoundException("Invalid type, " + typeId);
            }
        }
        #endregion

        #region Cohorts
        public String getCohortName(int cohortId)
        {
            switch (cohortId) {
                case 1:
                    return "Cohort 1";
                case 2:
                    return "Cohort 2";
                default:
                    throw new KeyNotFoundException("Invalid cohort id, " + cohortId);
            }
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
                    results.Add(new EvaluationSchedule(1, 1, 1, DateTime.Now, DateTime.Parse("2016-06-10")));
                    results.Add(new EvaluationSchedule(1, 2, 1, DateTime.Now, DateTime.Parse("2016-06-10")));
                    break;
                case 2:
                    results.Add(new EvaluationSchedule(2, 1, 1, DateTime.Now, DateTime.Parse("2016-06-10")));
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

        #endregion

        #region Employees
        public List<EmployeeName> getEmployeeNameList()
        {
            List<EmployeeName> results = new List<EmployeeName>();

            results.Add(new EmployeeName(1, "Ann Smith"));
            results.Add(new EmployeeName(2, "Bob Jones"));
            results.Add(new EmployeeName(3, "John Doe"));
            results.Add(new EmployeeName(4, "Steve Anderson"));
            results.Add(new EmployeeName(5, "Zoe Doe"));
            return results;
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
        #endregion

    }
}
