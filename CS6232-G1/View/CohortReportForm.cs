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
    public partial class CohortReportForm : Form
    {
        IEvaluationController _controller;
        private List<Cohort> _cohorts;
        private List<EvalType> _types;
        private List<CohortReport> reportData;

        public CohortReportForm(IEvaluationController controller)
        {
            _controller = controller;
            InitializeComponent();
            if ((_cohorts = GetCohortList()) == null)
            {
                return;
            }
            cohortComboBox.ComboBox.DataSource = _cohorts;
            cohortComboBox.ComboBox.DisplayMember = "cohortName";
            cohortComboBox.ComboBox.ValueMember = "cohortId";
            cohortComboBox.ComboBox.SelectedIndex = -1;

            if ((_types = GetTypeList()) == null)
            {
                return;
            }
            typeComboBox.ComboBox.DataSource = _types;
            typeComboBox.ComboBox.DisplayMember = "name";
            typeComboBox.ComboBox.ValueMember = "id";
            typeComboBox.ComboBox.SelectedIndex = -1;
            GenerateUserReport(1, 1);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (cohortComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a cohort", "Notice");
                return;
            } 
            if (typeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an evaluation type", "Notice");
                return;
            }

            int type = (int)typeComboBox.ComboBox.SelectedValue;
            int cohort = (int)cohortComboBox.ComboBox.SelectedValue;
            GenerateUserReport(type, cohort);
            if (reportData.Count == 0)
            {
                string text = "No report found for selected cohort and type";
                MessageBox.Show(text, "Notice");
            }
        }

        /// <summary>
        /// Generate a User Report
        /// </summary>
        /// <param name="employeeId">Employee to generate report for</param>
        /// <param name="stage">Stage selected</param>
        /// <param name="evalType">Evaluation Type selected</param>
        private void GenerateUserReport(int typeId, int cohortId)
        {
            try
            {
                
                // TODO: set header label to:
                // string text = "Employee " + nameFirstLastId + " Evaluation Report (Evaluation " + typeName + " at " + stageName + 
                //                  ") (generated " + DateTime.Now.AsDD/MM/YYYY + ")"
                reportData = _controller.GetCohortReport(typeId, cohortId);
                CohortReportBindingSource.DataSource = reportData;
                reportViewer.RefreshReport();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from the database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }


        private List<Cohort> GetCohortList()
        {
            List<Cohort> cohorts = null;
            try
            {
                cohorts = _controller.GetCohorts();
                if (cohorts == null || cohorts.Count == 0)
                {
                    MessageBox.Show("No cohorts available", "Notice");
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
            return cohorts;
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
        /// Launch CohortReport Form
        /// </summary>
        /// <param name="_controller">Controller to use</param>
        public static void Run(IEvaluationController _controller)
        {
            CohortReportForm form = new CohortReportForm(_controller);
            form.MdiParent = Program.mainForm; 
            form.Show();
        }
    }
}
