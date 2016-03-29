using Evaluation.Model;
﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Evaluation.DAL
{
    public partial class EvaluationDAL : IEvaluationDAL
    {
        /// <summary>
        /// Deletes a schedule if it has no evaluations
        /// </summary>
        /// <param name="selectedSchedule"></param>
        /// <returns>true if delete is successful, else false</returns>
        public bool DeleteSchedule(EvaluationSchedule selectedSchedule)
        {
            string deleteStatement =
                "DELETE FROM evaluation_schedule " +
                "WHERE scheduleId = @scheduleId " +
                "AND NOT EXISTS(SELECT * FROM evaluations " +
                "WHERE employeeId IN (SELECT employeeId FROM employee WHERE cohortId = @cohortId) " +
                "AND typeId = @typeId AND stageId = @stageId)";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@scheduleId", selectedSchedule.ScheduleId);
                    deleteCommand.Parameters.AddWithValue("@cohortId", selectedSchedule.CohortId);
                    deleteCommand.Parameters.AddWithValue("@typeId", selectedSchedule.TypeId);
                    deleteCommand.Parameters.AddWithValue("@stageId", selectedSchedule.StageId);

                    int count = deleteCommand.ExecuteNonQuery();
                    if (count < 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }            
        }

        public List<Evaluations> getOpenSelfEvaluations(int employeeId)
        {
            List<Evaluations> results = new List<Evaluations>();

            // TODO: Finish
            return results;
        }

        public List<Evaluations> getOpenOtherEvaluations(int employeeId)
        {
            List<Evaluations> results = new List<Evaluations>();

            // TODO: Finish
            return results;
        }

        public DateTime getEndDateForSchedule(int typeId, int stageId, int? cohortId)
        {
            // TODO: Finish
            return DateTime.Now;
        }

    }
}
