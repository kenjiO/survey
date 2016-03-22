using Evaluation.Model;
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
        public List<Cohort> getCohorts()
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
        public List<Cohort> getCohortsWithNoMembersOrEvals()
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
        public List<Employee> getMembersNotInCohort()
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
        public List<int> addMembersToCohort(int cohortId, List<int> empIdList)
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
            return failedIds;
        }

        /// <summary>
        /// Create table for returning cohort schedule information
        /// </summary>
        /// <returns>Data Table with columns defined</returns>
        public static DataTable createCohortAddScheduleInfoDataTable()
        {
            DataTable table = new DataTable();

            table.Locale = CultureInfo.InvariantCulture;
            table.Columns.Add("typeId", typeof(int));
            table.Columns.Add("lastStageId", typeof(int));
            table.Columns.Add("lastStageEndDate", typeof(DateTime));
            return table;
        }


        public DataTable getCohortAddScheduleInfo(int cohortId)
        {
            DataTable table = createCohortAddScheduleInfoDataTable();

            string selectStatement ="SELECT stageId, endDate " +
                                      "FROM evaluation_schedule " +
                                     "WHERE cohortId = @cohortId " +
                                       "AND typeId = @typeId " +
                                       "AND stageId = (SELECT MAX(stageId) " +
                                                        "FROM evaluation_schedule " +
                                                       "WHERE cohortId = @cohortId " +
                                                         "AND typeId = @typeId)";

            List<EvalType> typeList = getTypeList();
            using (SqlConnection connection = EvaluationDB.GetConnection())
            {
                connection.Open();
                foreach (EvalType type in typeList) 
                {
                    int typeId = type.id;
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

        public int addCohortSchedule(int cohortId, int typeId, int stageId, DateTime startDate, DateTime endDate)
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
