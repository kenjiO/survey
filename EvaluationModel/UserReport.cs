using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class UserReport
    {
        /*
         * TODO: User Report Details 
         * 
          by employeeid
          should show
               employee name
               stage
               type
               for each category,
                    for each question, show
                         self evaluation result
                         coworker's evaluation result
                         direct supervisor's evaluation result
                         average of all three
        */


        /// <summary>
        /// User Report Columns
        /// </summary>
        public enum Columns { EmployeeId, Stage, Type, Category, Question, Self, Coworker, Supervisor, Average };

        /// <summary>
        /// Create User Report Data Table
        /// </summary>
        /// <returns>Data Table with User Report columns defined</returns>
        public static DataTable createDataTable()
        {
            DataTable table = new DataTable();

            table.Locale = CultureInfo.InvariantCulture;
            table.Columns.Add(Columns.EmployeeId.ToString(), typeof(int));
            table.Columns.Add(Columns.Stage.ToString(), typeof(string));
            table.Columns.Add(Columns.Type.ToString(), typeof(string));
            table.Columns.Add(Columns.Category.ToString(), typeof(string));
            table.Columns.Add(Columns.Question.ToString(), typeof(int));
            table.Columns.Add(Columns.Self.ToString(), typeof(int));
            table.Columns.Add(Columns.Coworker.ToString(), typeof(int));
            table.Columns.Add(Columns.Supervisor.ToString(), typeof(int));
            table.Columns.Add(Columns.Average.ToString(), typeof(int));
            return table;
        }


    }
}
