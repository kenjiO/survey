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
            this.reportViewer1.RefreshReport();
        }

        private void UserReportForm_Resize(object sender, EventArgs e)
        {
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            int employeeId=1;

            // TODO: Parse employee number
            if (stageComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select evaluation stage and type", "Notice");
                return;
            }
            if (typeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an evaluation type", "Notice");
                return;
            }
            int stage = (int)stageComboBox.ComboBox.SelectedValue;
            int evaltype = (int)typeComboBox.ComboBox.SelectedValue;
            GenerateUserReport(employeeId, stage, evaltype);
        }

        /// <summary>
        /// Generate a User Report
        /// </summary>
        /// <param name="employeeId">Employee to generate report for</param>
        /// <param name="stage">Stage selected</param>
        /// <param name="evalType">Evaluation Type selected</param>
        private void GenerateUserReport(int employeeId, int stage, int evalType)
        {
            try
            {
                //statusLabel.Text = "Generating Report...";
                //Application.UseWaitCursor = true;
                //Application.DoEvents();
                // TODO: Get UserReport list and set report binding
                //DataTable reportTable = _controller.GetUserReport(employeeId, stage, evalType);
                // this.reportViewer1.Controls.
                // set header label to:
                //  String text = "Employee " + nameFirstLastId + " Evaluation Report (Evaluation " + typeName + " at " + stageName + 
                //                  ") (generated " + DateTime.Now.AsDD/MM/YYYY + ")"
                //SetupUserReport(reportTable);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from the database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
            finally
            {
                //Application.UseWaitCursor = false;
                //statusLabel.Text = "";
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
