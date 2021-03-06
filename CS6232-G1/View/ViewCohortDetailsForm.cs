﻿using Evaluation.Controller;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CS6232_G1.View
{
    public partial class ViewCohortDetailsForm : Form, IRefreshable
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
            if (_controller == null)
            {
                throw new ArgumentNullException("controller", "Controller cannot be null");
            }
            if (_cohortId <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid cohort","Cohort Id must be greater than 0");
            }
        }

        private void ViewCohortDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                _cohortName = _controller.GetCohortName(_cohortId);
                lblCohortName.Text = "Details for " + _cohortName;

                dgvEvaluationSchedule.BackgroundColor = Color.White;

                dgvEvaluationSchedule.CellFormatting += dgvEvaluationSchedule_CellFormatting;

                LoadMemberListView();
                LoadEvaluationScheduleGridView();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from the database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }

        // show values of unbound columns on form load
        void dgvEvaluationSchedule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvEvaluationSchedule.Columns["StageName"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewRow row = dgvEvaluationSchedule.Rows[e.RowIndex];
                e.Value = _controller.GetStageName((int)row.Cells["StageId"].Value);
            }
            if (e.ColumnIndex == dgvEvaluationSchedule.Columns["TypeName"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewRow row = dgvEvaluationSchedule.Rows[e.RowIndex];
                e.Value = _controller.GetTypeName((int)row.Cells["TypeId"].Value);
            }
        }

        private void LoadEvaluationScheduleGridView()
        {
            //Get list of evaluation schedule objects and bind the datagrid to the list
            try
            {
                List<EvaluationSchedule> scheduleList = _controller.GetEvaluationScheduleList(_cohortId);
                dgvEvaluationSchedule.DataSource = scheduleList;
                dgvEvaluationSchedule.AutoResizeColumns();
                dgvEvaluationSchedule.ClearSelection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from the database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        // Loads the Listbox with the members in the given cohort
        private void LoadMemberListView()
        {
            lvMembers.Items.Clear();
            SetListViewColumnWidth(lvMembers);
            List<Employee> memberList;
            try
            {
                memberList = _controller.GetMembersOfCohort(_cohortId);
                if (memberList.Count > 0)
                {
                    foreach (Employee member in memberList)
                    {
                        ListViewItem item = lvMembers.Items.Add(member.EmployeeId.ToString());
                        item.SubItems.Add(member.FirstName);
                        item.SubItems.Add(member.LastName);
                        item.SubItems.Add(member.Email);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from the database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
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
        private void SetListViewColumnWidth(ListView listView)
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
            AddOrEditCohortScheduleForm addCohortScheduleForm = AddOrEditCohortScheduleForm.createAddForm(_controller, _cohortId, this);
            addCohortScheduleForm.StartPosition = FormStartPosition.CenterScreen;
            addCohortScheduleForm.Show();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            try
            {
                AddMembersToCohortForm form = new AddMembersToCohortForm(_controller, _cohortId, this);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred on opening add member form.\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }

        public void RefreshViews()
        {
            LoadMemberListView();
            if (lvMembers.Items.Count != 0) {
                lvMembers.Items[lvMembers.Items.Count - 1].EnsureVisible();
            }
            LoadEvaluationScheduleGridView();
            if (dgvEvaluationSchedule.Rows.Count != 0)
            {
                dgvEvaluationSchedule.FirstDisplayedScrollingRowIndex = dgvEvaluationSchedule.RowCount - 1;
            }
        }

        private void dgvEvaluationSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == senderGrid.Columns["EditButton"].Index && e.RowIndex >= 0)
            {
                // Edit the selected schedule
                selectedSchedule = this.PutDataInScheduleObject(senderGrid);
                AddOrEditCohortScheduleForm editCohortScheduleForm = AddOrEditCohortScheduleForm.CreateEditForm(_controller, _cohortId, selectedSchedule, this);
                editCohortScheduleForm.StartPosition = FormStartPosition.CenterScreen;
                editCohortScheduleForm.Show();
                this.RefreshViews();
            }

            if (e.ColumnIndex == senderGrid.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {
                // Delete the selected schedule
                selectedSchedule = this.PutDataInScheduleObject(senderGrid);
                try
                {
                    if (_controller.DeleteSchedule(selectedSchedule))
                    {
                        MessageBox.Show("Schedule has been deleted!", "Operation Successful");
                    }
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Cannot delete the schedule.\n\n" +
                                    "Details: " + ex.Message, "Notice");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A Database error occured.\n\n" +
                            "Details: " + ex.Message);
                }
                this.RefreshViews();
            }

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
            bool result = false;
            try
            {
                result = _controller.DeleteCohort(_cohortId);
            }
            catch (SqlException ex)
            {
                //Error 547 is a foreign key violation caused by existing members or schedules
                if (ex.Errors[0].Number == 547)
                {
                    MessageBox.Show("Cannot delete a Cohort with existing members or schedules");
                }
                else
                {
                    MessageBox.Show("A Database error occured deleting the cohort\n\n" +
                            "Details: " + ex.Message);
                }
                return;
            }

            if (result)
            {
                MessageBox.Show("Cohort deleted");
                Close();
                return;
            }
            else
            {
                //Cohort was not deleted even though no SqlException thrown
                MessageBox.Show("Unable to delete cohort");
            }
        }

    }
}
