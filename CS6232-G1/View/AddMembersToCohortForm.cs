using Evaluation.Controller;
using Evaluation.Model;
using EvaluationModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CS6232_G1.View
{
    public partial class AddMembersToCohortForm : Form
    {
        private IEvaluationController _controller;
        private int _cohortId;
        private String _cohortName;
        private IRefreshable _parentForm;

        /// <summary>
        /// Run Add Members to Cohort dialog
        /// </summary>
        /// <param name="controller">Controller to use</param>
        /// <param name="cohortId">Id of cohort to add members to</param>
        /// <param name="parentForm">the form that calls this form</param>
        public AddMembersToCohortForm(IEvaluationController controller, int cohortId, IRefreshable parentForm)
        {
            InitializeComponent();
            _controller = controller;
            _cohortId = cohortId;
            _parentForm = parentForm;
            if (_controller == null)
            {
                throw new ArgumentNullException("controller", "Controller cannot be null");
            }
            if (_cohortId <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid cohort", "Cohort Id must be greater than 0");
            }
        }

        private void AddMembersToCohortForm_Load(object sender, EventArgs e)
        {
            try
            {
                _cohortName = _controller.GetCohortName(_cohortId);

                lblAddMember.Text = "Add Members to " + _cohortName;

                LoadEmployeeListView();
                btnAddMembers.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred acquiring data from database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }



        // Loads the Listview with the employees that are not assigned to any cohort
        private void LoadEmployeeListView()
        {
            lvEmployeeList.Items.Clear();
            SetListViewColumnWidth(lvEmployeeList);
            try
            {
                List<Employee> memberList;
                memberList = _controller.GetMembersNotInCohort();
                if (memberList.Count > 0)
                {
                    foreach (Employee member in memberList)
                    {
                        ListViewItem item = lvEmployeeList.Items.Add(member.EmployeeId.ToString());
                        item.SubItems.Add(member.FirstName);
                        item.SubItems.Add(member.LastName);
                        item.SubItems.Add(member.Email);
                    }
                }
                else
                {
                    MessageBox.Show("All employees have been assigned to a cohort.");
                }
            }
            catch(SqlException ex)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvEmployeeList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            btnAddMembers.Enabled = lvEmployeeList.CheckedItems.Count > 0;
        }

        private void btnAddMembers_Click(object sender, EventArgs e)
        {
            try
            {
                // get selected employee ids
                List<int> empIdList = new List<int>();
                foreach (ListViewItem item in lvEmployeeList.CheckedItems)
                {
                    empIdList.Add(int.Parse(item.SubItems[0].Text));
                }

                // update cohortid of selected employees
                List<int> notUpdated = _controller.AddMembersToCohort(_cohortId, empIdList);
                if (notUpdated.Count > 0)
                {
                    // get ids from list and show
                    String failedIdList = "";
                    foreach (int id in notUpdated)
                    {
                        failedIdList += id + ", ";
                    }
                    failedIdList = failedIdList.Trim().TrimEnd(',');
                    MessageBox.Show("The following empIds were not added to the cohort because they have been updated by another user.\n"
                        + failedIdList , "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("All selected employees have been added to the cohort!", "Operation Successful");
                }
                //loadEmployeeListView();
                Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("An error occurred updating data in database. \n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }

        private void AddMembersToCohortForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_parentForm != null)
            {
                _parentForm.RefreshViews();
            }
        }
    }
}
