using Evaluation.Controller;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestController : IEvaluationController
    {
        private Employee _currentUser;
        private Boolean _isAdminSession;
        public Employee currentUser { get { return _currentUser; } }
        public Boolean idAdminSession { get { return _isAdminSession; } }

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

        public List<EvalType> getTypeList()
        {
            List<EvalType> results = new List<EvalType>();

            results.Add(new EvalType(1, "Type 1", 5));
            results.Add(new EvalType(2, "Type 2", 10));
            return results;
        }

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

        public Employee login(string email, string password)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get details for a User Report (See IEvaluationController.UserReportColumns enum for column list)
        /// </summary>
        /// <param name="stage">Stage to report</param>
        /// <param name="evalType">Type to report</param>
        /// <returns></returns>
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

    }
}
