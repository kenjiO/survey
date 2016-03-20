﻿using Evaluation.Controller;
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

            Object[] row1 = { 1, null, null };
            Object[] row2 = { 2, 2, DateTime.Parse("6/5/2016") };
            Object[] row3 = { 1, 4, DateTime.Parse("4/15/2016") };
            Object[] row4 = { 2, 5, DateTime.Parse("5/25/2016") };

            table.Rows.Add(row1);
            table.Rows.Add(row2);
            table.Rows.Add(row3);
            table.Rows.Add(row4);
            return table;
        }

        private DataTable createCohortAddScheduleInfoDataTable()
        {
            throw new NotImplementedException();
        }

        public void addCohortSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate)
        {
            return;
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

        public bool DeleteSchedule(EvaluationSchedule selectedSchedule)
        {
            throw new NotSupportedException();
        }
        
    }
}
