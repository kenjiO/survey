﻿using Evaluation.Model;
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
        /// <param name="selectedSchedule">The schedule object to delete</param>
        /// <returns>true if delete is successful, else throws InvalidOperationException</returns>
        public bool DeleteSchedule(EvaluationSchedule selectedSchedule)
        {
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                // check if schedule exists
                string selectStatement =
                    "SELECT * from evaluation_schedule " +
                    "WHERE scheduleId = @scheduleId ";

                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    command.Parameters.AddWithValue("@scheduleId", selectedSchedule.ScheduleId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            throw new InvalidOperationException("Another user has deleted this schedule.");
                        }
                    }
                }

                //check if a schedule with higher stage exists
                string higherStageExistsForType =
                "SELECT es2.stageid " +
                "FROM evaluation_schedule es1, evaluation_schedule es2 " +
                "WHERE es2.stageid > es1.stageid " +
                "AND es2.typeid = es1.typeid AND es1.cohortid = es2.cohortid AND es1.scheduleid = @scheduleId ";
                using (SqlCommand command = new SqlCommand(higherStageExistsForType, connection))
                {
                    command.Parameters.AddWithValue("@scheduleId", selectedSchedule.ScheduleId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            throw new InvalidOperationException("Schedule with higher stage exists for the same type.");
                        }
                    }
                }

                string deleteStatement =
                "DELETE FROM evaluation_schedule " +
                "WHERE scheduleId = @scheduleId " +
                "AND NOT EXISTS(SELECT * FROM evaluations ev " +
                "JOIN employee e ON ev.employeeId = e.employeeId " +
                "WHERE ev.typeId = @typeId AND ev.stageId = @stageId and e.cohortId = @cohortId)";

                using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection)) 
                { 
                    deleteCommand.Parameters.AddWithValue("@scheduleId", selectedSchedule.ScheduleId);
                    deleteCommand.Parameters.AddWithValue("@cohortId", selectedSchedule.CohortId);
                    deleteCommand.Parameters.AddWithValue("@typeId", selectedSchedule.TypeId);
                    deleteCommand.Parameters.AddWithValue("@stageId", selectedSchedule.StageId);

                    int count = deleteCommand.ExecuteNonQuery();
                    if (count < 1)
                    {
                        throw new InvalidOperationException("Evaluations exist for schedule.");
                    }
                    else
                    {
                        return true;
                    }
                }
            }            
        }

        public List<EvaluationSchedule> GetEvaluationScheduleList(int cohortId, int? typeId, int? stageId)
        {
            List<EvaluationSchedule> results = new List<EvaluationSchedule>();

            string selectStatement =
                "SELECT  scheduleid, typeid, stageId, " +
                "startDate, endDate " +
                "FROM evaluation_schedule " +
                "WHERE cohortId = @cohortId ";

            if (typeId != null)
            {
                selectStatement += "  AND typeId = @typeId ";
            }
            if (stageId != null)
            {
                selectStatement += "  AND stageId = @stageId ";
            }
            selectStatement += ";";
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@cohortId", cohortId);
                    if (typeId != null)
                    {
                        selectCommand.Parameters.AddWithValue("@typeId", typeId);
                    }
                    if (stageId != null)
                    {
                        selectCommand.Parameters.AddWithValue("@stageId", stageId);
                    }
 
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
                            int _typeId = reader.GetInt32(typeIDOrd);
                            int _stageId = reader.GetInt32(stageIDOrd);
                            DateTime startDate = reader.GetDateTime(startDateOrd);
                            DateTime endDate = reader.GetDateTime(endDateOrd);
                            EvaluationSchedule schedule = new EvaluationSchedule(scheduleId, cohortId, _typeId, _stageId, startDate, endDate);
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

        public void UpdateEvaluationSchedule(int scheduleId, DateTime startDate, DateTime endDate, DateTime originalStartDate, DateTime originalEndDate)
        {
            string updateStatement = "UPDATE evaluation_schedule " +
                                     "   SET startDate = @startDate, " +
                                     "       endDate = @endDate " +
                                     "WHERE scheduleId = @scheduleId " +
                                     "  AND startDate = @originalStartDate " +
                                     "  AND endDate = @originalEndDate";

            if (startDate > endDate)
            {
                throw new ArgumentException("End date must be on or after start date");
            }
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                int count;
                using (SqlCommand command = new SqlCommand(updateStatement, connection))
                {
                    command.Parameters.AddWithValue("@scheduleId", scheduleId);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);
                    command.Parameters.AddWithValue("@originalStartDate", originalStartDate);
                    command.Parameters.AddWithValue("@originalEndDate", originalEndDate);
                    count = command.ExecuteNonQuery();
                }
                if (count < 1)
                {
                    string selectStatement =
                        "SELECT * from evaluation_schedule " +
                        "WHERE scheduleId = @scheduleId ";

                    using (SqlCommand command = new SqlCommand(selectStatement, connection))
                    {
                        command.Parameters.AddWithValue("@scheduleId", scheduleId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                throw new InvalidOperationException("Another user has deleted this schedule");
                            }
                            else
                            {
                                throw new InvalidOperationException("Another user has modified the schedule");
                            }
                        }
                    }                    
                }
            }
        }
    }
}
