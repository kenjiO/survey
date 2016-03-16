using Evaluation.Controller;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CS6232_G1.View
{
    public partial class ViewCohortDetailsForm : Form
    {
        private IEvaluationController _controller;
        private int _cohortId;
        private String _cohortName;

        /// <summary>
        /// Run View Cohort Details dialog
        /// </summary>
        /// <param name="controller">Controller to use</param>
        /// <param name="cohortId">Id of cohort to view details of</param>
        public ViewCohortDetailsForm(IEvaluationController controller, int cohortId)
        {
            InitializeComponent();
            _controller = controller;
            _cohortId = cohortId;
        }

        private void ViewCohortDetailsForm_Load(object sender, EventArgs e)
        {
            if (_controller == null)
            {
                MessageBox.Show("Invalid arguments to cohort scheduler");
                Close();
                return;
            }
            if (_cohortId <= 0)
            {
                MessageBox.Show("Invalid cohort selected");
                Close();
                return;
            }
            try
            {
                _cohortName = _controller.getCohortName(_cohortId);

                lblCohortName.Text = "Details for " + _cohortName;

                loadListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void loadListView()
        {
            List<EvaluationSchedule> scheduleList;
            scheduleList = _controller.getEvaluationScheduleList(_cohortId);
            lvEvaluationSchedule.Items.Clear();
            setListViewColumnWidth();

            if (scheduleList.Count > 0)
            {
                foreach (EvaluationSchedule schedule in scheduleList)
                {
                    String typeName = _controller.getTypeName(schedule.TypeId);
                    ListViewItem item = lvEvaluationSchedule.Items.Add(typeName);
                    String stageName = _controller.stageName(schedule.StageId);
                    item.SubItems.Add(stageName);
                    item.SubItems.Add(schedule.StartDate.ToShortDateString());
                    item.SubItems.Add(schedule.EndDate.ToShortDateString());
                }
            }
            else
            {
                MessageBox.Show("No evaluations have been set up for this cohort.");
            }
        }

        private void setListViewColumnWidth()
        {
            for (int i = 0; i < lvEvaluationSchedule.Columns.Count; i++)
            {
                lvEvaluationSchedule.Columns[i].Width = (int)(0.25 * lvEvaluationSchedule.ClientRectangle.Width);
            }
        }

        private void btnAddEvaluation_Click(object sender, EventArgs e)
        {
            AddCohortScheduleForm addCohortScheduleForm = new AddCohortScheduleForm(_controller, _cohortId, _cohortName);
            addCohortScheduleForm.Show();
        }
    }
}