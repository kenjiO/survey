﻿using Evaluation.Controller;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CS6232_G1.View
{
    public partial class AddMembersToCohortForm : Form
    {
        private IEvaluationController _controller;
        private int _cohortId;
        private String _cohortName;

        /// <summary>
        /// Run Add Members to Cohort dialog
        /// </summary>
        /// <param name="controller">Controller to use</param>
        /// <param name="cohortId">Id of cohort to add members to</param>
        public AddMembersToCohortForm(IEvaluationController controller, int cohortId)
        {
            InitializeComponent();
            _controller = controller;
            _cohortId = cohortId;
        }

        private void AddMembersToCohortForm_Load(object sender, EventArgs e)
        {
            if (_controller == null)
            {
                MessageBox.Show("Invalid controller");
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

                lblAddMember.Text = "Add Members to " + _cohortName;

                loadMemberListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        // Loads the Listbox with the members in the given cohort
        private void loadMemberListView()
        {
            lvMembers.Items.Clear();
            lvMembers.CheckBoxes = true;
            setListViewColumnWidth(lvMembers);
            try
            {
                List<Employee> memberList;
                memberList = _controller.getMembersNotInCohort();
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
                    MessageBox.Show("All members have been assigned to a cohort.");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
