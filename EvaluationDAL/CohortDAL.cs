using Evaluation.Model;
using EvaluationModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Evaluation.DAL
{
    public partial class EvaluationDAL
    {
        public Cohort addNewCohort(String name) {
            return null;
        }

        /// <summary>
        /// Get a list of evaluation schedules for a given cohort
        /// </summary>
        /// /// <param name="cohortId">the cohortId</param>
        /// <returns>Evaluation Schedule list</returns>
        public static List<EvaluationSchedule> getEvaluationScheduleList(int cohortId)
        {
            List<EvaluationSchedule> results = new List<EvaluationSchedule>();

            string selectStatement =
                "SELECT  c.cohortName, e.typeid, t.typeName, e.stageId, s.stageName, " +
                "e.startDate, e.endDate " +
                "FROM evaluation_schedule e " +
                "JOIN cohort c on e.cohortId = c.cohortId " +
                "JOIN type t on e.typeId = t.typeId " +
                "JOIN stage s on e.stageId = s.stageId " +
                "WHERE cohortId = @cohortId";

            try
            {
                using (SqlConnection connection = EvaluationDB.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@cohortId", cohortId);

                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            int cohortNameOrd = reader.GetOrdinal("cohortName");
                            int typeIDOrd = reader.GetOrdinal("typeId");
                            int typeNameOrd = reader.GetOrdinal("typeName");
                            int stageIDOrd = reader.GetOrdinal("stageId");
                            int stageNameOrd = reader.GetOrdinal("stageName");
                            int startDateOrd = reader.GetOrdinal("startDate");
                            int endDateOrd = reader.GetOrdinal("endDate");

                            while (reader.Read())
                            {
                                EvaluationSchedule schedule = new EvaluationSchedule();
                                schedule.cohortId = cohortId;
                                schedule.cohortName = reader.GetString(cohortNameOrd);
                                schedule.typeId = reader.GetInt32(typeIDOrd);
                                schedule.typeName = reader.GetString(typeNameOrd);
                                schedule.stageId = reader.GetInt32(stageIDOrd);
                                schedule.stageName = reader.GetString(stageNameOrd);
                                schedule.startDate = reader.GetDateTime(startDateOrd);
                                schedule.endDate = reader.GetDateTime(endDateOrd);
                                results.Add(schedule);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //exceptions are thrown to the controller, then to the view
                //throw is used instead of throw ex because the former preserves the stack trace
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return results;
        }
    }
}
