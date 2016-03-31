using Evaluation.Controller;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CS6232_G1.View
{
    public partial class ViewEvaluationsForm : Form
    {
        private IEvaluationController _controller;
        private Employee _currentUser;

        public ViewEvaluationsForm(IEvaluationController controller, Employee currentUser)
        {
            InitializeComponent();
            _controller = controller;
            _currentUser = currentUser;
        }

        private void ViewEvaluationDetailsForm_Load(object sender, EventArgs e)
        {
            if (_controller == null)
            {
                MessageBox.Show("Invalid arguments to view evaluations form");
                Close();
                return;
            }
            if (_currentUser == null)
            {
                MessageBox.Show("Invalid user.");
                Close();
                return;
            }
            try
            {
                loadSelfEvaluations();
                loadPeerEvaluations();               
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred acquiring data from database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }        

        private void loadSelfEvaluations()
        {
            //Get list of evaluation schedule objects and bind the datagrid to the list
            List<OpenEvaluation> evaluationList = _controller.getOpenSelfEvaluations(_currentUser.EmployeeId);
            dgvSelfEvaluations.DataSource = evaluationList;            
            dgvSelfEvaluations.ClearSelection();
        }

        private void loadPeerEvaluations()
        {
            //Get list of evaluation schedule objects and bind the datagrid to the list
            List<OpenEvaluation> evaluationList = _controller.getOpenPeerEvaluations(_currentUser.EmployeeId);
            dgvPeerEvaluations.DataSource = evaluationList;            
            dgvPeerEvaluations.ClearSelection();
        }

        public void refreshViews()
        {
            loadSelfEvaluations();
            loadPeerEvaluations();
        }

        private void ViewEvaluationsForm_Shown(object sender, EventArgs e)
        {
            if (dgvSelfEvaluations.DisplayedRowCount(true) == 0 && dgvPeerEvaluations.DisplayedRowCount(true) == 0)
            {
                MessageBox.Show("There are no evaluations at this time.");
            }
            else if (dgvSelfEvaluations.DisplayedRowCount(true) == 0)
            {
                MessageBox.Show("There are no self evaluations at this time.");
            }
            else if (dgvPeerEvaluations.DisplayedRowCount(true) == 0)
            {
                MessageBox.Show("There are no peer evaluations at this time.");
            } 
        }
                    
    }
}
