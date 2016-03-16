﻿using System.Collections.Generic;
using Evaluation.Model;
using System;

namespace Evaluation.Controller
{
    /// <summary>
    /// Evaluation Schedule View-Controller
    /// </summary>
    public partial class EvaluationController : IEvaluationController
    {
        public List<EvaluationSchedule> getEvaluationScheduleList(int cohortId)
        {
            return _dal.getEvaluationScheduleList(cohortId);
        }

        public Cohort addCohort(String name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name is null");
            }
            return _dal.addNewCohort(name);
        }

        public List<Employee> getMembersOfCohort(int cohortId)
        {
            //return _dal.getMembersOfCohort(cohortId);
            return null;
        }
    }
}
