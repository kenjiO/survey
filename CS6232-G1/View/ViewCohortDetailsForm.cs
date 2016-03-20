using Evaluation.Controller;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CS6232_G1.View
{
    public partial class ViewCohortDetailsForm : Form
    {
        private IEvaluationController _controller;
        private int _cohortId;
        private String _cohortName;
        private EvaluationSchedule selectedSchedule;

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
                //_cohortName = "Cohort 1"; 
                lblCohortName.Text = "Details for " + _cohortName;

                dgvEvaluationSchedule.CellBorderStyle = DataGridViewCellBorderStyle.None;
                dgvEvaluationSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEvaluationSchedule.BackgroundColor = Color.White;

                loadMemberListView();
                loadEvaluationScheduleGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void loadEvaluationScheduleGridView()
        {
            //Get list of evaluation schedule objects and bind the datagrid to the list
            List<EvaluationSchedule> scheduleList = _controller.getEvaluationScheduleList(_cohortId);
            dgvEvaluationSchedule.DataSource = scheduleList;

            // Display type name and stage name
            foreach (DataGridViewRow row in dgvEvaluationSchedule.Rows)
            {
                int typeId = (int)row.Cells["TypeId"].Value;
                row.Cells["TypeName"].Value = _controller.getTypeName(typeId);

                int stageId = (int)row.Cells["StageId"].Value;
                row.Cells["StageName"].Value = _controller.getStageName(stageId);
            }
            dgvEvaluationSchedule.AutoResizeColumns();
            dgvEvaluationSchedule.ClearSelection();
        }

        // Loads the Listbox with the members in the given cohort
        private void loadMemberListView()
        {
            lvMembers.Items.Clear();
            setListViewColumnWidth(lvMembers);
            List<Employee> memberList;
            try
            {
                memberList = _controller.getMembersOfCohort(_cohortId);
                if (memberList.Count > 0)
                {
                    foreach (Employee member in memberList)
                    {
                        ListViewItem item = lvMembers.Items.Add(member.employeeId.ToString());
                        item.SubItems.Add(member.firstName);
                        item.SubItems.Add(member.lastName);
                        item.SubItems.Add(member.email);
                    }
                }
                else
                {
                    MessageBox.Show("No members have been added to this cohort.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Calculates the width of listView columns dynamically by getting fillWeight from Tag property of columns. 
        /// To use this method, set fillWeight in the Tag property of each column.
        /// </summary>
        /// <param name="listView">the listview whose columns are to be sized</param>
        private void setListViewColumnWidth(ListView listView)
        {
            float totalColumnWidth = 0;

            // Get the sum of all column tags
            for (int i = 0; i < listView.Columns.Count; i++)
                totalColumnWidth += Convert.ToInt32(listView.Columns[i].Tag);

            // Calculate the percentage of space each column should 
            // occupy in reference to the other columns and then set the 
            // width of the column to that percentage of the visible space.
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                float colPercentage = (Convert.ToInt32(listView.Columns[i].Tag) / totalColumnWidth);
                listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
            }
        }

        private void btnAddEvaluation_Click(object sender, EventArgs e)
        {
            AddOrEditCohortScheduleForm addCohortScheduleForm = AddOrEditCohortScheduleForm.createAddForm(_controller, _cohortId, null);
            addCohortScheduleForm.Show();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            AddMembersToCohortForm form = new AddMembersToCohortForm(_controller, _cohortId, this);
            form.Show();
        }

        public void refreshViews()
        {
            loadMemberListView();
            lvMembers.Items[lvMembers.Items.Count - 1].EnsureVisible();
            loadEvaluationScheduleGridView();
            dgvEvaluationSchedule.FirstDisplayedScrollingRowIndex = dgvEvaluationSchedule.RowCount - 1;
        }

        private void dgvEvaluationSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == senderGrid.Columns["EditButton"].Index && e.RowIndex >= 0)
            {
                MessageBox.Show("Edit  Button,  scheduleid: " + senderGrid.SelectedRows[0].Cells["ScheduleId"].Value);
                // TODO: open the Edit form with data for the selected schedule
            }

            if (e.ColumnIndex == senderGrid.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {
                MessageBox.Show("Delete button, scheduleid: " + senderGrid.SelectedRows[0].Cells["ScheduleId"].Value);
                // Delete the selected schedule
                selectedSchedule = this.PutDataInScheduleObject(senderGrid);
                if (!_controller.DeleteSchedule(selectedSchedule))
                {
                    MessageBox.Show("Operation unsuccessful! Schedule has evaluations, or another user has deleted the schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else 
                {
                    MessageBox.Show("Schedule has been deleted!", "Operation Successful");
                }   
            }
            this.refreshViews();
        }

        private EvaluationSchedule PutDataInScheduleObject(DataGridView senderGrid)
        {
            int scheduleId = (int)senderGrid.SelectedRows[0].Cells["ScheduleId"].Value;
            int typeId = (int)senderGrid.SelectedRows[0].Cells["TypeId"].Value;
            int stageId = (int)senderGrid.SelectedRows[0].Cells["StageId"].Value;
            DateTime startDate = (DateTime)senderGrid.SelectedRows[0].Cells["StartDate"].Value;
            DateTime endDate = (DateTime)senderGrid.SelectedRows[0].Cells["EndDate"].Value;
            selectedSchedule = new EvaluationSchedule(scheduleId, _cohortId, typeId, stageId, startDate, endDate);
            return selectedSchedule;
        }

        private void DeleteCohortButton_Click(object sender, EventArgs e)
        {
            _controller.deleteCohort(_cohortId);
        }

    }
}