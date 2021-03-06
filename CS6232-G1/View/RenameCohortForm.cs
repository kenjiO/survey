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
    public partial class RenameCohortForm : Form
    {
        IEvaluationController _controller;

        public RenameCohortForm(IEvaluationController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void RenameCohortForm_Load(object sender, EventArgs e)
        {
            if (_controller == null)
            {
                MessageBox.Show("Error: RenameCohortFrom created with a null controller.");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            LoadComboBoxItems();
        }

        private void LoadComboBoxItems()
        {
            List<Cohort> cohortList = null;
            try
            {
                cohortList = _controller.GetCohorts();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A Database error occured fetching cohorts\n\n" +
                    "Details: " + ex.Message, "Notice");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            if (cohortList == null || cohortList.Count < 1)
            {
                MessageBox.Show("There are no cohorts");
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
            cohortsComboBox.DataSource = cohortList;
            cohortsComboBox.DisplayMember = "cohortName";
            cohortsComboBox.ValueMember = "cohortId";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {
            Cohort selectedCohort = (Cohort) cohortsComboBox.SelectedItem;
            if (selectedCohort == null)
            {
                MessageBox.Show("Please select a cohort first");
                return;
            }
            int cohortId = selectedCohort.CohortId;
            string oldName = selectedCohort.CohortName;
            string newName = newNameBox.Text.Trim();
            if (newName == "")
            {
                MessageBox.Show("New name must not be blank");
                return;
            }

            List<Cohort> cohorts = _controller.GetCohorts();
            bool nameExists = cohorts.Exists((Cohort c) => { return c.CohortName == newName; });
            if (nameExists)
            {
                MessageBox.Show("A cohort with that name already exists");
                return;
            }

            bool result = false;
            try
            {
                result = _controller.RenameCohort(cohortId, oldName, newName);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A Database error occured renaming the cohort\n\n" +
                     "Details: " + ex.Message);
                LoadComboBoxItems();
                return;
            }

            if (result)
            {
                MessageBox.Show("Cohort " + oldName + " renamed to " + newName);
                this.DialogResult = DialogResult.OK;
                Close();
                return;
            }
            else
            {
                MessageBox.Show(selectedCohort.CohortName + " was unable to be renamed");
            }
            LoadComboBoxItems();
        }

        public static void Run(IEvaluationController controller)
        {
            RenameCohortForm form = new RenameCohortForm(controller);
            form.ShowDialog(Program.mainForm);
        }


    }
}
