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
    public partial class SelectCohortForm : Form
    {
        private Cohort _selectedCohort;
        private IEvaluationController _controller;

        public SelectCohortForm(IEvaluationController controller)
        {
            InitializeComponent();
            if (controller == null)
            {
                throw new ArgumentNullException("Null controller on Select Cohort Form");
            }
            _controller = controller;
            _selectedCohort = null;
        }

        public Cohort selectedCohort { get { return _selectedCohort; } }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void SelectCohortForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Cohort> cohortList = _controller.getCohorts();
                CohortComboBox.DataSource = cohortList;
                CohortComboBox.DisplayMember = "cohortName";
                CohortComboBox.ValueMember = "cohortId";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A Database error occured fetching cohorts: " + ex.Message);
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            CohortComboBox.SelectedIndex = -1;
        }

        private void CohortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCohort = (Cohort) CohortComboBox.SelectedItem;
        }

    }
}
