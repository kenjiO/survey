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
        private bool _editing;
        private String _cohortName;
        private List<Stage> _stages;
        private List<EvalType> _types;
        private List<CohortScheduleData> _scheduleDataList;
        private EvaluationSchedule _schedule;
        private IRefreshable _parent;
        private DateRange _range;

        private bool Editing { get { return _editing; } }

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
        public static AddOrEditCohortScheduleForm CreateEditForm(IEvaluationController controller, int cohortId, EvaluationSchedule originalSchedule, IRefreshable parent)
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
            _editing = false;
        }

        private AddOrEditCohortScheduleForm(IEvaluationController controller, int cohortId, EvaluationSchedule originalSchedule, IRefreshable parent)
        {
            InitializeComponent();
            _controller = controller;
            _parent = parent;
            _cohortId = cohortId;
            _cohortName = null;
            _schedule = originalSchedule;
            _editing = true;
        }

        private void AddCohortScheduleForm_Load(object sender, EventArgs e)
        {
            if (Editing)
            {
                lblAction.Text = "Edit";
                btnAdd.Text = "Save";
                if (_schedule == null)
                {
                    MessageBox.Show("Invalid schedule selected");
                    this.DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
            }
            else
            {
                lblAction.Text = "Add";
                btnAdd.Text = "Add";
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
                _stages = _controller.GetStageList();
                _types = _controller.GetTypeList();
                if (Editing)
                {
                    _range = _controller.GetScheduleDateRange(_schedule.ScheduleId, _schedule.CohortId, _schedule.TypeId, _schedule.StageId);
                }
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
            _cohortName = _controller.GetCohortName(_cohortId);
            if (_cohortName.Length == 0)
            {
                MessageBox.Show("Invalid cohort selected");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            lblCohortName.Text = _cohortName;
            ResetMinAndMaxDates();
            // setup stage list to list all stages
            cboStage.DataSource = _stages;
            cboStage.DisplayMember = "name";
            cboStage.ValueMember = "id";
            cboStage.SelectedIndex = -1;
            cboStage.Enabled = false;

            if (Editing)
            {
                // initialize type list to list all types
                cboType.DataSource = _types;
                cboType.DisplayMember = "name";
                cboType.ValueMember = "id";
                cboType.SelectedIndex = -1;
                cboType.Enabled = false;

                cboType.SelectedValue = _schedule.TypeId;
                cboStage.SelectedValue = _schedule.StageId;
                dateStart.MinDate = _range.StartDate;
                dateStart.MaxDate = _range.EndDate;
                dateStart.Value = _schedule.StartDate;
                dateEnd.MinDate = _range.StartDate;
                dateEnd.MaxDate = _range.EndDate;
                dateEnd.Value = _schedule.EndDate;
            }
            else
            {
                try
                {
                    _scheduleDataList = _controller.GetCohortAddScheduleInfo(_cohortId);
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
            if (_editing || cboType.SelectedIndex < 0)
            {
                return;
            }
            CohortScheduleData data = _scheduleDataList[cboType.SelectedIndex];

            if (data.NextStageId != null)
            {
                cboStage.SelectedValue = data.NextStageId;
                SetupControls(true, "");
            }
            else
            {
                cboStage.SelectedIndex = -1;
                SetupControls(false, "All stages scheduled");
            }

            ResetMinAndMaxDates();
            if (data.LastStageEndDate != null)
            {
                DateTime minStartDate = data.LastStageEndDate ?? DateTime.Now;
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

        private void ResetMinAndMaxDates()
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
        private void SetupControls(bool canAdd, string msg)
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
                if (Editing)
                {
                    _controller.UpdateEvaluationSchedule(_schedule.ScheduleId, startDate, endDate);
                }
                else
                {
                    _controller.AddEvaluationSchedule(_cohortId, typeId, stageId, startDate, endDate);
                }
                this.DialogResult = DialogResult.OK;
                if (_parent != null)
                {
                    _parent.RefreshViews();
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
