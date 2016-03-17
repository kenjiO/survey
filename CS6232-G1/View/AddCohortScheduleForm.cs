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
        private List<CohortScheduleData> _typeList;

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
                _typeList = _controller.getCohortAddScheduleInfo(_cohortId);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A database error occurred looking up the cohort name.  Please" +
                      " check your SQL configuration.\n\n" +
                     "Details: " + ex.Message, "Notice");
                Close();
                return;
            }
            if (_typeList.Count == 0)
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

            cboType.DataSource = _typeList;
            cboType.DisplayMember = "typeName";
            cboType.ValueMember = "typeId";
            cboType.SelectedIndex = 0;
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Setup for selected item
            // if nextStageId is not null,
            //      set cboStage.SelectedValue to nextStageId
            //      enable other controls and add button
            // else
            //      set cboStage.SelectedIndex = -1 and display message that no more stages are available for this stage
            //      disable other controls and add button
            // get min start date (use today if lastStageEndDate is null, else use lastStageEndDate + 1)
            // set start.mindate, startdate, and enddate to min start date
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO: Finish
            // if successful, close
            // calling form will need to refresh list
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }



        
    }
}
