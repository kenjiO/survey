using Evaluation.Model;
﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Evaluation.DAL
{
    public partial class EvaluationDAL : IEvaluationDAL
    {

        /// <summary>
        /// Add a new cohort
        /// Precondition: name != null and a cohort with that name does not exist alreay
        /// </summary>
        /// <param name="name">The name of the new cohort</param>
        /// <returns>A Cohort object reflecting the cohort added to the DB</returns>
        public Cohort addNewCohort(String name) {
            if (name == null)
            {
                throw new ArgumentNullException("name is null");
            }
            if (name.Trim() == "")
            {
                throw new ArgumentException("Name cannot be blank");
            }

            SqlConnection connection = EvaluationDB.GetConnection();

            string selectStatement =
                "SELECT CohortName " +
                "FROM cohort " +
                "WHERE CohortName = @CohortName" ;
            string insertStatement =
                "INSERT INTO cohort " +
                "(CohortName) " +
                "VALUES (@CohortName)";

            SqlCommand command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@CohortName", name);
            try
            {
                connection.Open();

                // Check if cohort with that name exists
                SqlDataReader reader =  command.ExecuteReader();
                if (reader.HasRows)
                {
                    throw new ArgumentException("A cohort with that name exists");
                }
                reader.Close();

                command.CommandText = insertStatement;
                command.ExecuteNonQuery();

                //Get the cohortID of the newly created cohort
                command.CommandText =  "SELECT IDENT_CURRENT('Cohort') FROM Cohort";
                int cohortId = Convert.ToInt32(command.ExecuteScalar());
                
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
            catch (SqlException)
            {
                //exceptions are thrown to the controller, then to the view
                //throw is used instead of throw ex because the former preserves the stack trace
                throw;
            }
            catch (Exception)
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
            catch (SqlException)
            {
                //exceptions are thrown to the controller, then to the view
                //throw is used instead of throw ex because the former preserves the stack trace
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return results;
        }

        /// <summary>
        /// Get a list of members that are not assigned to any cohort
        /// </summary>
        /// <returns>Member list</returns>
        public List<Employee> getMembersNotInCohort()
        {
            List<Employee> results = new List<Employee>();

            string selectStatement =
                "SELECT  employeeId, firstName, lastName, emailAddress " +
                "FROM employee " +
                "WHERE isAdmin = 0 AND cohortId is null";

            try
            {
                using (SqlConnection connection = EvaluationDB.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
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
            catch (SqlException)
            {
                //exceptions are thrown to the controller, then to the view
                //throw is used instead of throw ex because the former preserves the stack trace
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return results;
        }

        /// <summary>
        /// Updates the cohortid of employees with specified ids
        /// </summary>
        /// <param name="_cohortId">id of cohort to add members to</param>
        /// <param name="empIdList">list of employee ids to be added to the cohort</param>
        /// <returns>list of employee ids that were not updated</returns>
        public List<int> addMembersToCohort(int cohortId, List<int> empIdList)
        {
            List<int> failedIds = new List<int>();
            string updateStatement =
                "UPDATE employee " +
                "SET cohortId = @cohortId " +
                "WHERE employeeId = @employeeId AND cohortId is null";

            try
            {
                using (SqlConnection connection = EvaluationDB.GetConnection())
                {
                    connection.Open();
                    foreach (int id in empIdList)
                    {
                        try
                        {
                            using (SqlCommand updateCommand = new SqlCommand(updateStatement, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@cohortId", cohortId);
                                updateCommand.Parameters.AddWithValue("@employeeId", id);
                                int count = updateCommand.ExecuteNonQuery();
                                if (count < 1)
                                {
                                    failedIds.Add(id);
                                }  
                            }
                        }
                        catch {}
                    }
                }
            }
            catch (SqlException)
            {
                //exceptions are thrown to the controller, then to the view
                //throw is used instead of throw ex because the former preserves the stack trace
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return failedIds;
        }
    }
}
