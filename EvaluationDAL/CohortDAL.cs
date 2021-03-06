﻿using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Evaluation.DAL
{
    public partial class EvaluationDAL : IEvaluationDAL
    {

        /// <summary>
        /// Get a list of cohorts
        /// </summary>
        /// <returns>A list of Cohort objects corresponding to the cohorts in the DB</returns>
        public List<Cohort> GetCohorts()
        {
            List<Cohort> cohorts = new List<Cohort>();

            string selectStatement =
                "SELECT cohortId, cohortName " +
                "FROM cohort " +
                "ORDER BY cohortName";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int) reader["cohortId"];
                            String name = reader["cohortName"].ToString();
                            cohorts.Add(new Cohort(id, name));
                        }
                    }
                }
            }
            return cohorts;
        }

        /// <summary>
        /// Get a list of cohorts that have no members or schedules
        /// </summary>
        /// <returns>A list of cohorts with no members or schedules</returns>
        public List<Cohort> GetCohortsWithNoMembersOrEvals()
        {
            List<Cohort> cohorts = new List<Cohort>();

            string selectStatement =
                "SELECT cohortId, cohortName " +
                "FROM cohort " +
                "WHERE NOT EXISTS(SELECT NULL FROM employee e WHERE cohort.cohortId = e.cohortId) " +
                "  AND NOT EXISTS(SELECT NULL FROM evaluation_schedule s WHERE cohort.cohortId = s.cohortId) " +
                "ORDER BY cohortName";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["cohortId"];
                            String name = reader["cohortName"].ToString();
                            cohorts.Add(new Cohort(id, name));
                        }
                    }
                }
            }
            return cohorts;
        }

        /// <summary>
        /// Get the name of a cohort
        /// </summary>
        /// <param name="cohortId">The id of the cohort</param>
        /// <returns>The cohort name</returns>
        public string GetCohortName(int cohortId)
        {
            string selectStatement = "SELECT cohortName " +
                                     "FROM cohort " +
                                     "WHERE cohortId = @cohortId";
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@cohortId", cohortId);
                    return selectCommand.ExecuteScalar().ToString();
                }
            }
        }

        /// <summary>
        /// Add a new cohort
        /// Precondition: name != null and a cohort with that name does not exist alreay
        /// </summary>
        /// <param name="name">The name of the new cohort</param>
        /// <returns>A Cohort object reflecting the cohort added to the DB</returns>
        public Cohort AddNewCohort(String name) {
            if (name == null)
            {
                throw new ArgumentNullException("name is null");
            }
            if (name.Trim() == "")
            {
                throw new ArgumentException("Name cannot be blank");
            }
            string insertStatement =
                "IF NOT EXISTS (Select 1 From cohort WHERE cohortName = @CohortName)" +
                "INSERT INTO cohort (CohortName) " +
                "VALUES (@CohortName)";
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertStatement, connection))
                {
                    command.Parameters.AddWithValue("@CohortName", name);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected < 1)
                    {
                        throw new ArgumentException("A cohort with that name exists");
                    }
                    //Get the cohortID of the newly created cohort
                    command.CommandText =  "SELECT IDENT_CURRENT('Cohort') FROM Cohort";
                    int cohortId = Convert.ToInt32(command.ExecuteScalar());
                
                    return new Cohort(cohortId, name);
                }
            }
        }

        /// <summary>
        /// Delete a cohort that has no members or schedules
        /// Precondition: cohortId must refer to a cohort with no members or schedules. If not
        ///               a sql foreign key contraint exception will be thrown
        /// </summary>
        /// <param name="cohortId">cohortId of the cohort to delete</param>
        /// <returns>True if deleted. False if cohort doen't exist, has members or has schedules</returns>
        public bool DeleteCohort(int cohortId)
        {
            string deleteStatement =
                "DELETE FROM cohort " +
                "WHERE cohortId = @cohortId";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@cohortId", cohortId);

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
        /// Rename a cohort if cohortId with oldName is in the database
        /// </summary>
        /// <param name="cohortId">cohortId to rename</param>
        /// <param name="oldName">the old name of the cohort</param>
        /// <param name="newName">the new name of the cohort</param>
        /// <returns>True if rename successful. False otherwise</returns>
        public bool RenameCohort(int cohortId, string oldName, string newName)
        {
            string updateStatement =
                "UPDATE cohort " +
                "SET cohortName = @newName " +
                "WHERE cohortId = @cohortId AND cohortName = @oldName " +
                "   AND NOT EXISTS (SELECT cohortName FROM cohort WHERE cohortName = @newName)";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();

                using (SqlCommand updateCommand = new SqlCommand(updateStatement, connection))
                {
                    updateCommand.Parameters.AddWithValue("@cohortId", cohortId);
                    updateCommand.Parameters.AddWithValue("@oldName", oldName);
                    updateCommand.Parameters.AddWithValue("@newName", newName);

                    int count = updateCommand.ExecuteNonQuery();
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
        /// Get a list of members for a given cohort
        /// </summary>
        /// <param name="_cohortId">cohort id of the specific cohort</param>
        /// <returns>Member list</returns>
        public List<Employee> GetMembersOfCohort(int cohortId)
        {
            List<Employee> results = new List<Employee>();

            string selectStatement =
                "SELECT  employeeId, firstName, lastName, emailAddress " +
                "FROM employee " +
                "WHERE isAdmin = 0 AND cohortId = @cohortId";

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
            return results;
        }

        /// <summary>
        /// Get a list of members that are not assigned to any cohort
        /// </summary>
        /// <returns>Member list</returns>
        public List<Employee> GetMembersNotInCohort()
        {
            List<Employee> results = new List<Employee>();

            string selectStatement =
                "SELECT  employeeId, firstName, lastName, emailAddress " +
                "FROM employee " +
                "WHERE isAdmin = 0 AND cohortId is null";

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
            return results;
        }

        /// <summary>
        /// Updates the cohortid of employees with specified ids
        /// </summary>
        /// <param name="_cohortId">id of cohort to add members to</param>
        /// <param name="empIdList">list of employee ids to be added to the cohort</param>
        /// <returns>list of employee ids that were not updated</returns>
        public List<int> AddMembersToCohort(int cohortId, List<int> empIdList)
        {
            List<int> failedIds = new List<int>();
            string updateStatement =
                "UPDATE employee " +
                "SET cohortId = @cohortId " +
                "WHERE employeeId = @employeeId AND cohortId is null";

            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();
                foreach (int id in empIdList)
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
            }
            return failedIds;
        }

        /// <summary>
        /// Create table for returning cohort schedule information
        /// </summary>
        /// <returns>Data Table with columns defined</returns>
        public static DataTable CreateCohortAddScheduleInfoDataTable()
        {
            DataTable table = new DataTable();

            table.Locale = CultureInfo.InvariantCulture;
            table.Columns.Add("typeId", typeof(int));
            table.Columns.Add("lastStageId", typeof(int));
            table.Columns.Add("lastStageEndDate", typeof(DateTime));
            return table;
        }


        public DataTable GetCohortAddScheduleInfo(int cohortId)
        {
            DataTable table = CreateCohortAddScheduleInfoDataTable();

            string selectStatement ="SELECT stageId, endDate " +
                                      "FROM evaluation_schedule " +
                                     "WHERE cohortId = @cohortId " +
                                       "AND typeId = @typeId " +
                                       "AND stageId = (SELECT MAX(stageId) " +
                                                        "FROM evaluation_schedule " +
                                                       "WHERE cohortId = @cohortId " +
                                                         "AND typeId = @typeId)";

            List<EvalType> typeList = GetTypeList();
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();
                foreach (EvalType type in typeList) 
                {
                    int typeId = type.Id;
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@cohortId", cohortId);
                        selectCommand.Parameters.AddWithValue("@typeId", typeId);
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                int lastStageId = (int)reader["stageId"];
                                DateTime lastStageEndDate = (DateTime)reader["endDate"];
                                Object[] row = { typeId, lastStageId, lastStageEndDate };

                                table.Rows.Add(row);
                            }
                            else
                            {
                                Object[] row = { typeId, null, null };
                                table.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            return table;
        }

    }
}
