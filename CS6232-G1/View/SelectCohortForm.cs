using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evaluation.Controller;
using Evaluation.Model;
using System.Data.SqlClient;

namespace CS6232_G1.View
{
    public partial class SelectCohortForm : Form
    {
        private Cohort _selectedCohort;
        private IEvaluationController _controller;

        public SelectCohortForm(IEvaluationController controller)
        {
            InitializeComponent();
            if (controller == null)
            {
                throw new ArgumentNullException("controller", "Controller cannot be null");
            }
            _controller = controller;
            _selectedCohort = null;
        }

        public Cohort SelectedCohort { get { return _selectedCohort; } }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (_selectedCohort == null)
            {
                MessageBox.Show("No Cohort Selected");
                return;
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SelectCohortForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Cohort> cohortList = _controller.GetCohorts();
                CloseFormIfNoCohorts(cohortList);
                CohortComboBox.DataSource = cohortList;
                CohortComboBox.DisplayMember = "cohortName";
                CohortComboBox.ValueMember = "cohortId";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from the database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
            CohortComboBox.SelectedIndex = -1;
        }

        private void CohortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCohort = (Cohort) CohortComboBox.SelectedItem;
            SelectButton.Enabled = (_selectedCohort != null);
        }

        private void CloseFormIfNoCohorts(List<Cohort> cohorts) {
            if (cohorts.Count < 1)
            {
                MessageBox.Show("There are no cohorts. Please add a cohort first");
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        public static int Run(IEvaluationController controller)
        {
            SelectCohortForm form = new SelectCohortForm(controller);
            DialogResult result = form.ShowDialog(Program.mainForm);
            if (result == DialogResult.OK && form.SelectedCohort != null)
            {
                return form.SelectedCohort.CohortId;
            }
            return -1;
        }

    }
}
