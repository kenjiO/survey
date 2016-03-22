﻿using System;
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
    public partial class DeleteCohortForm : Form
    {
        IEvaluationController _controller;

        public DeleteCohortForm(IEvaluationController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void DeleteCohortForm_Load(object sender, EventArgs e)
        {
            if (_controller == null)
            {
                MessageBox.Show("Error: DeleteCohortFrom created with a null controller.");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            loadComboBoxItems();
        }

        private void loadComboBoxItems()
        {
            List<Cohort> deletableCohortList = null;
            try
            {
                deletableCohortList = _controller.getCohortsWithNoMembersOrEvals();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A Database error occured fetching cohorts\n" + ex.Message);
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            if (deletableCohortList == null || deletableCohortList.Count < 1)
            {
                MessageBox.Show("There are no cohorts that can be deleted");
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
            cohortsComboBox.DataSource = deletableCohortList;
            cohortsComboBox.DisplayMember = "cohortName";
            cohortsComboBox.ValueMember = "cohortId";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Cohort selectedCohort = (Cohort) cohortsComboBox.SelectedItem;
            if (selectedCohort == null)
            {
                MessageBox.Show("Please select a cohort first");
                return;
            }
            bool result = false;
            try
            {
                result = _controller.deleteCohort(selectedCohort.cohortId);
            }
            catch (SqlException ex)
            {
                if (ex.Errors.Count > 0) // Assume the interesting stuff is in the first error
                {
                    int SQL_FOREIGN_KEY_EXCEPTION_CODE = 547;
                    if (ex.Errors[0].Number == SQL_FOREIGN_KEY_EXCEPTION_CODE)
                    {
                        //Another process added a member or schedule to this cohort
                        MessageBox.Show("The cohort was updated by another process and can no longer be deleted");
                    }
                    else {
                        MessageBox.Show("A Database error occured deleting the cohort\n" + ex.Message);
                    }
                }
                loadComboBoxItems();
                return;
            }

            if (result) 
            {
                MessageBox.Show(selectedCohort.cohortName + " deleted");
                this.DialogResult = DialogResult.OK;
                Close();
                return;
            }
            else
            {
                MessageBox.Show(selectedCohort.cohortName + " was unable to be deleted");
            }
            loadComboBoxItems();
        }

        public static void Run(IEvaluationController controller)
        {
            DeleteCohortForm form = new DeleteCohortForm(controller);
            form.ShowDialog(Program.mainForm);
        }

    }
}
