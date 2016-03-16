using Evaluation.Model;
﻿using System;
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
                    "SELECT IDENT_CURRENT('Cohort') FROM Cohort";
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
                "SELECT  typeid, stageId, " +
                "startDate, endDate " +
                "FROM evaluation_schedule " +
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

        /// <summary>
        /// Get a list of members for a given cohort
        /// </summary>
        /// <param name="_cohortId">cohort id of the specific cohort</param>
        /// <returns>Member list</returns>
        public List<Employee> getMembersOfCohort(int cohortId)
        {
            List<Employee> results = new List<Employee>();

            string selectStatement =
                "SELECT  employeeId, firstName, lastName, emailAddress " +
                "FROM employee " +
                "WHERE isAdmin = 0 AND cohortId = @cohortId";

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
                            int employeeIdOrd = reader.GetOrdinal("employeeId");
                            int firstNameOrd = reader.GetOrdinal("firstName");
                            int lastNameOrd = reader.GetOrdinal("lastName");
                            int emailOrd = reader.GetOrdinal("emailAddress");

                            while (reader.Read())
                            {
                                int employeeId = reader.GetInt32(employeeIdOrd);
                                string firstName = reader.GetString(firstNameOrd);
                                string lastName = reader.GetString(lastNameOrd);
                                string email = reader.GetString(emailOrd);
                                Employee member = new Employee(employeeId, firstName, lastName, email, false);
                                results.Add(member);
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
