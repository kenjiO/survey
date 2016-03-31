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

        /// <summary>
        /// Get a list of evaluation schedules for a given cohort
        /// </summary>
        /// /// <param name="cohortId">the cohortId</param>
        /// <returns>Evaluation Schedule list</returns>
        public List<EvaluationSchedule> GetEvaluationScheduleList(int cohortId)
        {
            List<EvaluationSchedule> results = new List<EvaluationSchedule>();

            string selectStatement =
                "SELECT  scheduleid, typeid, stageId, " +
                "startDate, endDate " +
                "FROM evaluation_schedule " +
                "WHERE cohortId = @cohortId";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@cohortId", cohortId);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        int scheduleIDOrd = reader.GetOrdinal("scheduleId");
                        int typeIDOrd = reader.GetOrdinal("typeId");
                        int stageIDOrd = reader.GetOrdinal("stageId");
                        int startDateOrd = reader.GetOrdinal("startDate");
                        int endDateOrd = reader.GetOrdinal("endDate");

                        while (reader.Read())
                        {
                            int scheduleId = reader.GetInt32(scheduleIDOrd);
                            int typeId = reader.GetInt32(typeIDOrd);
                            int stageId = reader.GetInt32(stageIDOrd);
                            DateTime startDate = reader.GetDateTime(startDateOrd);
                            DateTime endDate = reader.GetDateTime(endDateOrd);
                            EvaluationSchedule schedule = new EvaluationSchedule(scheduleId, cohortId, typeId, stageId, startDate, endDate);
                            results.Add(schedule);
                        }
                    }
                }
            }
            return results;
        }

        public int AddEvaluationSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate)
        {
            string insertStatement = "INSERT INTO evaluation_schedule " +
                                     "(cohortId, typeId, stageId, startDate, endDate) " +
                                     "VALUES (@cohortId, @typeId, @stageId, @startDate, @endDate)";

            if (startDate > endDate)
            {
                throw new ArgumentException("End date must be on or after start date");
            }
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertStatement, connection))
                {
                    command.Parameters.AddWithValue("@cohortId", cohortId);
                    command.Parameters.AddWithValue("@typeId", typeId);
                    command.Parameters.AddWithValue("@stageId", stageId);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand("SELECT IDENT_CURRENT('evaluation_schedule') AS scheduleId", connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

    }
}
