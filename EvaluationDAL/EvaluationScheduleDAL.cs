using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvaluationModel;

namespace Evaluation.DAL
{
    /// <summary>
    /// Database Access Layer for evaluation schedule database
    /// </summary>
    public partial class EvaluationDAL : IEvaluationDAL
    {
        /// <summary>
        /// Get a list of evaluation schedules for a given cohort
        /// </summary>
        /// <returns>Evaluation Schedule list</returns>
        public static List<EvaluationSchedule> getEvaluationScheduleList()
        {
            List<EvaluationSchedule> results = new List<EvaluationSchedule>();

            string selectStatement =
                "SELECT  e.cohortId, c.cohortName, e.typeid, t.typeName, e.stageId, s.stageName, " +
                "e.startDate, e.endDate " +
                "FROM evaluation_schedule e " +
                "JOIN cohort c on e.cohortId = c.cohortId " +
                "JOIN type t on e.typeId = t.typeId " +
                "JOIN stage s on e.stageId = s.stageId";

            try
            {
                using (SqlConnection connection = EvaluationDB.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            int cohortIDOrd = reader.GetOrdinal("cohortId");
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
                                schedule.cohortId = reader.GetInt32(cohortIDOrd);
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
