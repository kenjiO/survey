using Evaluation.Controller;
using EvaluationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS6232_G1.View
{
    public partial class UserReportForm : Form
    {
        IEvaluationController _controller;
        private List<Stage> _stages;
        private List<EvalType> _types;

        public UserReportForm(IEvaluationController controller)
        {
            _controller = controller;
            InitializeComponent();
            if ((_stages = getStageList()) == null)
            {
                return;
            }
            cmboStage.DataSource = _stages;
            cmboStage.DisplayMember = "name";
            cmboStage.ValueMember = "id";
            cmboStage.SelectedIndex = -1;

            if ((_types = getTypeList()) == null)
            {
                return;
            }
            cmboType.DataSource = _types;
            cmboType.DisplayMember = "name";
            cmboType.ValueMember = "id";
            cmboType.SelectedIndex = -1;
        }

        private List<Stage> getStageList()
        {
            List<Stage> list = null;

            try
            {
                list = _controller.getStageList();
                if (list.Count == 0)
                {
                    MessageBox.Show("No stages available", "Notice");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from database.  Please check your SQL configuration. (Details: "
                                    + ex.Message + ")", "Notice");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            return list;
        }

        private List<EvalType> getTypeList()
        {
            List<EvalType> list = null;

            try
            {
                list = _controller.getTypeList();
                if (list.Count == 0)
                {
                    MessageBox.Show("No Evaluation Types available", "Notice");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from database.  Please check your SQL configuration. (Details: "
                                    + ex.Message + ")", "Notice");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            return list;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (cmboStage.SelectedIndex == -1)
            {
                MessageBox.Show("Please select evaluation stage and type", "Notice");
                return;
            }
            if (cmboType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an evaluation type", "Notice");
                return;
            }
            int stage = (int)cmboStage.SelectedValue;
            int evaltype = (int)cmboType.SelectedValue;
            generateUserReport(stage, evaltype);
        }

        /// <summary>
        /// Generate a User Report
        /// </summary>
        /// <param name="stage">Stage selected</param>
        /// <param name="evalType">Evaluation Type selected</param>
        private void generateUserReport(int stage, int evalType)
        {
            try
            {
                statusLabel.Text = "Generating Report...";
                Application.UseWaitCursor = true;
                Application.DoEvents();
                DataTable reportTable = _controller.getUserReport(stage, evalType);
                setupUserReport(reportTable);
            }
            finally
            {
                Application.UseWaitCursor = false;
                statusLabel.Text = "";
            }
        }

        /// <summary>
        /// Display user report for a given dataset
        /// </summary>
        /// <param name="reportTable">Report table to display</param>
        private void setupUserReport(DataTable reportTable)
        {            
            // reset table
            dataGridView.DataSource = null;
            dataGridView.Columns.Clear();
            dataGridView.DataSource = reportTable;
            dataGridView.RowHeadersWidth = 20;

            // set column properties by column index or column title string
            // hide a column
            //dataGridView.Columns[columnIdx].Visible = false;
            // set a minimum width
            //dataGridView.Columns[columnIdx].MinimumWidth = 115;
            // set fixed width
            //dataGridView.Columns[columnIdx].Width = 320;
            // set column to autosize based on all data rows
            //dataGridView.Columns[columnIdx].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            // enable word wrap
            //dataGridView.Columns[columnIdx].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // setup table
            // right justify employee id and size based on header text
            dataGridView.Columns[(int)UserReport.Columns.EmployeeId].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns[(int)UserReport.Columns.EmployeeId].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            // stage, type, category - autosize by all cells
            for (int column = (int)UserReport.Columns.Stage; column <= (int)UserReport.Columns.Category; column++)
            {
                dataGridView.Columns[column].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            // make answer columns same width
            for (int column = (int)UserReport.Columns.Question; column <= (int)UserReport.Columns.Average; column++)
            {
                dataGridView.Columns[column].Width = 58;
                dataGridView.Columns[column].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // TODO: either move stage/type prompt off this page and dock ALL, or find a way to keep top same distance from 
            //      form top on resize
        }
    }
}
