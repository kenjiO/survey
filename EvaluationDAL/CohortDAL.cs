using Evaluation.Model;
﻿using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvaluationModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Evaluation.DAL
{
    public partial class EvaluationDAL : IEvaluationDAL
    {
        public Cohort addNewCohort(String name) {
            if (name == null)
            {
                throw new ArgumentNullException("name is null");
            }

            SqlConnection connection = EvaluationDB.GetConnection();
            string insertStatement =
                "INSERT INTO cohort " +
                "(cohortName) " +
                "VALUES (@CohortName)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@CohortName", name);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('Incidents') FROM Incidents";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int cohortId = Convert.ToInt32(selectCommand.ExecuteScalar());
                return new Cohort(cohortId, name);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        /// <summary>
        /// Get a list of evaluation schedules for a given cohort
        /// </summary>
        /// /// <param name="cohortId">the cohortId</param>
        /// <returns>Evaluation Schedule list</returns>
        public List<EvaluationSchedule> getEvaluationScheduleList(int cohortId)
        {
            List<EvaluationSchedule> results = new List<EvaluationSchedule>();

            string selectStatement =
                "SELECT  e.typeid, e.stageId, " +
                "e.startDate, e.endDate " +
                "FROM evaluation_schedule e " +
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
                            int typeIDOrd = reader.GetOrdinal("typeId");
                            int stageIDOrd = reader.GetOrdinal("stageId");
                            int startDateOrd = reader.GetOrdinal("startDate");
                            int endDateOrd = reader.GetOrdinal("endDate");

                            while (reader.Read())
                            {
                                int typeId = reader.GetInt32(typeIDOrd);
                                int stageId = reader.GetInt32(stageIDOrd);
                                DateTime startDate = reader.GetDateTime(startDateOrd);
                                DateTime endDate = reader.GetDateTime(endDateOrd);
                                EvaluationSchedule schedule = new EvaluationSchedule(cohortId, typeId, stageId, startDate, endDate);
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
