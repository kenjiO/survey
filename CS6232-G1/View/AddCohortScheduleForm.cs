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
    public partial class AddCohortScheduleForm : Form
    {
        private IEvaluationController _controller;
        private int _cohortId;
        private String _cohortName;
        private List<Stage> _stages;
        private List<CohortScheduleData> _scheduleDataList;

        /// <summary>
        /// Run Add Cohort Schedule dialog
        /// </summary>
        /// <param name="controller">Controller to use</param>
        /// <param name="cohortId">Id of cohort to add schedule for</param>
        /// <param name="cohortName">Name of cohort (optional)</param>
        public AddCohortScheduleForm(IEvaluationController controller, int cohortId, String cohortName)
        {
            InitializeComponent();
            _controller = controller;
            _cohortId = cohortId;
            _cohortName = cohortName;
        }

        private void AddCohortScheduleForm_Load(object sender, EventArgs e)
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
                _stages = _controller.getStageList();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A database error occurred looking up the cohort name.  Please" +
                      " check your SQL configuration.\n\n" +
                     "Details: " + ex.Message, "Notice");
                Close();
                return;
            }
            if (_cohortName.Length <= 0) 
            {
                _cohortName = _controller.getCohortName(_cohortId);
                if (_cohortName.Length == 0)
                {
                    MessageBox.Show("Invalid cohort selected");
                    Close();
                    return;
                }
            }
            lblCohortName.Text = _cohortName;
            try
            {
                _scheduleDataList = _controller.getCohortAddScheduleInfo(_cohortId);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A database error occurred looking up the cohort name.  Please" +
                      " check your SQL configuration.\n\n" +
                     "Details: " + ex.Message, "Notice");
                Close();
                return;
            }
            if (_scheduleDataList.Count == 0)
            {
                MessageBox.Show("No schedulable evaluation types for this cohort", "Notice");
                Close();
                return;
            }

            // setup stage list to list all stages
            cboStage.DataSource = _stages;
            cboStage.DisplayMember = "name";
            cboStage.ValueMember = "id";
            cboStage.SelectedIndex = -1;

            cboType.DataSource = _scheduleDataList;
            cboType.DisplayMember = "typeName";
            cboType.ValueMember = "typeId";
            cboType.SelectedIndex = 0;
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CohortScheduleData data = _scheduleDataList[cboType.SelectedIndex];

            if (data.nextStageId != null)
            {
                cboStage.SelectedValue = data.nextStageId;
                setupControls(true, "");
            }
            else
            {
                cboStage.SelectedIndex = -1;
                setupControls(false, "All stages scheduled");
            }
            DateTime minStartDate = data.lastStageEndDate ?? DateTime.Now;
            minStartDate = minStartDate.Date.AddDays(1);
            dateStart.MinDate = minStartDate;
            dateStart.Value = minStartDate;
            dateEnd.MinDate = minStartDate;
            dateEnd.Value = minStartDate;
        }

        /// <summary>
        /// Setup controls based on whether add can occur
        /// </summary>
        /// <param name="canAdd">User can add schedule item</param>
        /// <param name="msg">Display message, if any</param>
        private void setupControls(bool canAdd, string msg)
        {
            btnAdd.Enabled = canAdd;
            dateStart.Enabled = canAdd;
            dateEnd.Enabled = canAdd;
            // TODO: Set message
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO: Finish
            // fail if dateStart > dateEnd
            // if successful, close
            // calling form will need to refresh list
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }



        
    }
}
