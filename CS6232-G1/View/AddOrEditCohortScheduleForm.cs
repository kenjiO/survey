using Evaluation.Controller;
using Evaluation.Model;
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
    public partial class AddOrEditCohortScheduleForm : Form
    {
        private IEvaluationController _controller;
        private int _cohortId;
        private bool _editExisting;
        private String _cohortName;
        private List<Stage> _stages;
        private List<EvalType> _types;
        private List<CohortScheduleData> _scheduleDataList;
        private EvaluationSchedule _schedule;
        private IRefreshable _parent;

        /// <summary>
        /// Create form for Add Cohort Schedule dialog
        /// </summary>
        /// <param name="controller">Controller to use</param>
        /// <param name="cohortId">Id of cohort to add schedule for</param>
        /// <param name="parent">Refreshable parent form</param>
        public static AddOrEditCohortScheduleForm createAddForm(IEvaluationController controller, int cohortId, IRefreshable parent)
        {
            return new AddOrEditCohortScheduleForm(controller, cohortId, parent);
        }

        /// <summary>
        /// Create form for Edit Cohort Schedule dialog
        /// </summary>
        /// <param name="controller">Controller to use</param>
        /// <param name="cohortId">Id of cohort to add schedule for</param>
        /// <param name="originalSchedule">Schedule to be edited</param>
        /// <param name="parent">Refreshable parent form</param>
        public static AddOrEditCohortScheduleForm createEditForm(IEvaluationController controller, int cohortId, EvaluationSchedule originalSchedule, IRefreshable parent)
        {
            return new AddOrEditCohortScheduleForm(controller, cohortId, originalSchedule, parent);
        }

        private AddOrEditCohortScheduleForm(IEvaluationController controller, int cohortId, IRefreshable parent)
        {
            InitializeComponent();
            _controller = controller;
            _parent = parent;
            _cohortId = cohortId;
            _cohortName = null;
            _schedule = null;
            _editExisting = false;
        }

        private AddOrEditCohortScheduleForm(IEvaluationController controller, int cohortId, EvaluationSchedule originalSchedule, IRefreshable parent)
        {
            InitializeComponent();
            _controller = controller;
            _parent = parent;
            _cohortId = cohortId;
            _cohortName = null;
            _schedule = originalSchedule;
            _editExisting = true;
        }

        private void AddCohortScheduleForm_Load(object sender, EventArgs e)
        {
            if (_editExisting)
            {
                lblAction.Text = "Edit";
            }
            else
            {
                lblAction.Text = "Add";
            }
            if (_controller == null)
            {
                MessageBox.Show("Invalid arguments to cohort scheduler");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            if (_cohortId <= 0)
            {
                MessageBox.Show("Invalid cohort selected");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            try
            {
                _stages = _controller.getStageList();
                _types = _controller.getTypeList();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A database error occurred looking up the cohort name.  Please" +
                      " check your SQL configuration.\n\n" +
                     "Details: " + ex.Message, "Notice");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            _cohortName = _controller.getCohortName(_cohortId);
            if (_cohortName.Length == 0)
            {
                MessageBox.Show("Invalid cohort selected");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            lblCohortName.Text = _cohortName;
            resetMinAndMaxDates();
            // setup stage list to list all stages
            cboStage.DataSource = _stages;
            cboStage.DisplayMember = "name";
            cboStage.ValueMember = "id";
            cboStage.SelectedIndex = -1;
            cboStage.Enabled = false;

            if (_editExisting)
            {
                // initialize type list to list all types
                cboType.DataSource = _types;
                cboType.DisplayMember = "name";
                cboType.ValueMember = "id";
                cboType.SelectedIndex = -1;
                cboType.Enabled = false;

                if (_schedule == null)
                {
                    MessageBox.Show("Invalid schedule selected");
                    this.DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
                cboType.SelectedValue = _schedule.TypeId;
                cboStage.SelectedValue = _schedule.StageId;
                // TODO: Need min and max dates - prev stage end + 1 and next stage start - 1
                //dateStart.MinDate = minStartDate;
                //dateStart.Value = minStartDate;
                //dateEnd.MinDate = minStartDate;
                //dateEnd.Value = minStartDate;
            }
            else
            {
                try
                {
                    _scheduleDataList = _controller.getCohortAddScheduleInfo(_cohortId);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("A database error occurred looking up the cohort name.  Please" +
                          " check your SQL configuration.\n\n" +
                         "Details: " + ex.Message, "Notice");
                    this.DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
                if (_scheduleDataList.Count == 0)
                {
                    MessageBox.Show("No schedulable evaluation types for this cohort", "Notice");
                    this.DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                // for add, change type list to show available types
                cboType.DataSource = _scheduleDataList;
                cboType.DisplayMember = "typeName";
                cboType.ValueMember = "typeId";
                cboType.SelectedIndex = 0;
                cboType.Enabled = true;
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_editExisting || cboType.SelectedIndex < 0)
            {
                return;
            }
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

            resetMinAndMaxDates();
            if (data.lastStageEndDate != null)
            {
                DateTime minStartDate = data.lastStageEndDate ?? DateTime.Now;
                minStartDate = minStartDate.Date.AddDays(1);
                dateStart.MinDate = minStartDate;
                dateStart.Value = minStartDate;
                dateEnd.MinDate = minStartDate;
                dateEnd.Value = minStartDate;
            }
            else
            {
                dateStart.Value = DateTime.Now;
                dateEnd.Value = DateTime.Now;
            }
        }

        private void resetMinAndMaxDates()
        {
            dateStart.MinDate = DateTime.Parse("1/1/2000");
            dateStart.MaxDate = DateTime.Parse("12/31/2100");
            dateEnd.MinDate = dateStart.MinDate;
            dateEnd.MaxDate = dateStart.MaxDate;
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
            lblNotice.Text = msg;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int typeId = (int)cboType.SelectedValue;
            int stageId = (int)cboStage.SelectedValue;
            DateTime startDate = dateStart.Value;
            DateTime endDate = dateEnd.Value;

            if (endDate < startDate)
            {
                MessageBox.Show("End Date must be on or after start date", "Notice");
                return;
            }

            try
            {
                _controller.addCohortSchedule(_cohortId, typeId, stageId, startDate, endDate);
                this.DialogResult = DialogResult.OK;
                if (_parent != null)
                {
                    _parent.refreshViews();
                }
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error occurred creating the evaluation schedule\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred creating the evaluation schedule\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            if (dateEnd.Value < dateStart.Value)
            {
                dateEnd.Value = dateStart.Value;
            }
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            /*
             * When calendar is dropping down, value changes twice, first to the minDate, then to the current value.  So I can't
             *    adjust start date based on end date changed unless a solution is found to this bug.
             *            
            if (dateEnd.Value < dateStart.Value)
            {
                dateStart.Value = dateEnd.Value;
            }
             */ 
        }
       
    }
}
