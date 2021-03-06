﻿using Evaluation.Controller;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CS6232_G1.View;
using System.Data.SqlClient;

namespace CS6232_G1.View
{
    public partial class ViewEvaluationsForm : Form, IRefreshable
    {
        private IEvaluationController _controller;
        private Employee _currentUser;
        
        public ViewEvaluationsForm(IEvaluationController controller, Employee currentUser)
        {
            InitializeComponent();
            _controller = controller;
            _currentUser = currentUser;
            if (_controller == null)
            {
                throw new ArgumentNullException("controller", "Controller cannot be null");
            }
            if (_currentUser == null)
            {
                throw new ArgumentNullException("currentUser", "Current user cannot be null");
            }
        }

        private void ViewEvaluationDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSelfEvaluations();
                LoadPeerEvaluations();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }

        private void LoadSelfEvaluations()
        {
            try
            {
                //Get list of evaluation schedule objects and bind the datagrid to the list
                List<OpenEvaluation> evaluationList = _controller.GetOpenSelfEvaluations(_currentUser.EmployeeId);
                dgvSelfEvaluations.DataSource = evaluationList;
                dgvSelfEvaluations.ClearSelection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from the database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }

        private void LoadPeerEvaluations()
        {
            try
            {
                //Get list of evaluation schedule objects and bind the datagrid to the list
                List<OpenEvaluation> evaluationList = _controller.GetOpenPeerEvaluations(_currentUser.EmployeeId);
                dgvPeerEvaluations.DataSource = evaluationList;
                dgvPeerEvaluations.ClearSelection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from the database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }

        public void RefreshViews()
        {
            LoadSelfEvaluations();
            LoadPeerEvaluations();
        }

        private void dgvSelfEvaluations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                int scheduleId = (int)senderGrid.Rows[e.RowIndex].Cells["ScheduleId"].Value;
                int evaluationId = _controller.IsSelfEvaluationStarted(scheduleId);

                // if self evaluation not started
                if (evaluationId == 0)
                {
                    int supervisorId = ShowSupervisorForm();
                    if (supervisorId < 1)
                    {
                        return;
                    }
                    int coworkerId = ShowCoworkerForm();

                    if (coworkerId > 0)
                    {
                        evaluationId = _controller.InitializeSelfEvaluation(scheduleId, coworkerId);
                    }
                } // end if self evaluation not started

                if (evaluationId > 0 && !isAnotherFormOpen()) {
                    // Open self evaluation
                    try
                    {
                        QuestionnaireForm form = new QuestionnaireForm(_controller, EvalType.Evaluator.Self, evaluationId, this);
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unexpected error occurred on opening evaluation form.\n\n" +
                                        "Details: " + ex.Message, "Notice");
                    }
                }
            }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred acquiring data from the database.  Please check your SQL configuration.\n\n" +
                                    "Details: " + ex.Message, "Notice");
                }
            }
        }

       private int ShowCoworkerForm()
        {
            int coworkerId = 0;
            if (!isAnotherFormOpen()) {
                try
                {
                    coworkerId = SelectCoworkerForm.Run(_controller);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Coworker cannot be selected. \n\n" +
                                    "Details: " + ex.Message, "Notice");
                }
            }
            return coworkerId;
        }

        private int ShowSupervisorForm()
        {
            int supervisorId = 0;
            if (!isAnotherFormOpen())
            {
                try
                {
                    supervisorId = SelectSupervisorForm.Run(_controller);
                    _controller.SetSupervisor(supervisorId);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred accessing the database.  Please check your SQL configuration.\n\n" +
                                    "Details: " + ex.Message, "Notice");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Supervisor cannot be updated. \n\n" +
                                    "Details: " + ex.Message, "Notice");
                }
            }
            return supervisorId;
        }

        private void dgvPeerEvaluations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && !isAnotherFormOpen())
            {
                int evaluationId = (int)senderGrid.Rows[e.RowIndex].Cells["evaluationId1"].Value;

                // Open peer evaluation
                try
                {
                    QuestionnaireForm form = new QuestionnaireForm(_controller, EvalType.Evaluator.Peer, evaluationId, this);                    
                    form.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred on opening evaluation form.\n\n" +
                                    "Details: " + ex.Message, "Notice");
                }

            }
        }

        private bool isAnotherFormOpen()
        {
            Form openQuestionnaireForm = Application.OpenForms["QuestionnaireForm"];
            if (openQuestionnaireForm != null)
            {
                MessageBox.Show("Another questionnaire is open and must be closed before opening another one.");
                Application.OpenForms["QuestionnaireForm"].Focus();
                if (openQuestionnaireForm.WindowState == FormWindowState.Minimized)
                {
                    openQuestionnaireForm.WindowState = FormWindowState.Normal;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    
}
