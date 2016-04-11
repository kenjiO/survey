using Evaluation.Controller;
using Evaluation.Model;
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
        private List<UserReport> reportData;
        private List<UserReportTitleData> titleData = new List<UserReportTitleData>();

        public UserReportForm(IEvaluationController controller)
        {
            _controller = controller;
            InitializeComponent();
            if ((_stages = GetStageList()) == null)
            {
                return;
            }
            stageComboBox.ComboBox.DataSource = _stages;
            stageComboBox.ComboBox.DisplayMember = "name";
            stageComboBox.ComboBox.ValueMember = "id";
            stageComboBox.ComboBox.SelectedIndex = -1;

            if ((_types = GetTypeList()) == null)
            {
                return;
            }
            typeComboBox.ComboBox.DataSource = _types;
            typeComboBox.ComboBox.DisplayMember = "name";
            typeComboBox.ComboBox.ValueMember = "id";
            typeComboBox.ComboBox.SelectedIndex = -1;

        }

        private void UserReportForm_Load(object sender, EventArgs e)
        {
            reportViewer.RefreshReport();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            int employeeId = ParseEmployeeId(employeeTextBox.Text);
            if (employeeId < 1)
            {
                MessageBox.Show("Please enter a valid numeric employee id", "Notice");
                return;
            }
            if (typeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an evaluation type", "Notice");
                return;
            }
            if (stageComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select evaluation stage and type", "Notice");
                return;
            }
            titleData.Clear();
            titleData.Add(new UserReportTitleData(_controller.GetEmployeeNameFL(employeeId), typeComboBox.Text, stageComboBox.Text));
            int evaltype = (int)typeComboBox.ComboBox.SelectedValue;
            int stage = (int)stageComboBox.ComboBox.SelectedValue;
            GenerateUserReport(employeeId, evaltype, stage);
            if (reportData.Count == 0)
            {
                string text = "No report found for employee " + employeeId + " for " + typeComboBox.Text + " and " + stageComboBox.Text;
                MessageBox.Show(text, "Notice");
            }
        }

        /// <summary>
        /// Generate a User Report
        /// </summary>
        /// <param name="employeeId">Employee to generate report for</param>
        /// <param name="stage">Stage selected</param>
        /// <param name="evalType">Evaluation Type selected</param>
        private void GenerateUserReport(int employeeId, int evalType, int stage)
        {
            try
            {
                // TODO: set header label to: titleData

                reportData = _controller.GetUserReport(employeeId, evalType, stage);
                UserReportBindingSource.DataSource = reportData;
                reportViewer.RefreshReport();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from the database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }


        // 
        // Utility functions
        // 
        private int ParseEmployeeId(string text)
        {
            try
            {
                int empId = Int32.Parse(text);
                return empId;
            }
            catch(FormatException)
            {
                return -1;
            }
        }

        private List<Stage> GetStageList()
        {
            List<Stage> list = null;

            try
            {
                list = _controller.GetStageList();
                if (list.Count == 0)
                {
                    MessageBox.Show("No stages available", "Notice");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            return list;
        }

        private List<EvalType> GetTypeList()
        {
            List<EvalType> list = null;

            try
            {
                list = _controller.GetTypeList();
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


        /// <summary>
        /// Launch UserReport Form
        /// </summary>
        /// <param name="_controller">Controller to use</param>
        public static void Run(IEvaluationController _controller)
        {
            UserReportForm form = new UserReportForm(_controller);
            form.MdiParent = Program.mainForm; 
            form.Show();
        }
    }
}
