using Evaluation.Controller;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CS6232_G1.View;

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
                LoadSelfEvaluations();
                LoadPeerEvaluations();               
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred acquiring data from database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }        

        private void LoadSelfEvaluations()
        {
            //Get list of evaluation schedule objects and bind the datagrid to the list
            List<OpenEvaluation> evaluationList = _controller.GetOpenSelfEvaluations(_currentUser.EmployeeId);
            dgvSelfEvaluations.DataSource = evaluationList;            
            dgvSelfEvaluations.ClearSelection();
        }

        private void LoadPeerEvaluations()
        {
            //Get list of evaluation schedule objects and bind the datagrid to the list
            List<OpenEvaluation> evaluationList = _controller.GetOpenPeerEvaluations(_currentUser.EmployeeId);
            dgvPeerEvaluations.DataSource = evaluationList;            
            dgvPeerEvaluations.ClearSelection();
        }

        public void RefreshViews()
        {
            LoadSelfEvaluations();
            LoadPeerEvaluations();
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

        private void dgvSelfEvaluations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int scheduleId = (int)senderGrid.Rows[e.RowIndex].Cells["ScheduleId"].Value;
                if (!_controller.IsSupervisorSelected(_currentUser.EmployeeId))
                {
                    int supervisorId = SelectSupervisorForm.Run(_controller);
                    if (supervisorId <= 0)
                    {
                        return;
                    }
                    try
                    {
                        _controller.SetSupervisor(supervisorId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Supervisor cannot be updated. \n\n" +
                                        "Details: " + ex.Message, "Notice");
                    }
                }
                // TODO: If evaluation not started (evaluationId = IsSelfEvaluationStarted(employeeId, scheduleId))
                //      - ask for coworker - cannot be supervisor
                //      - call function to create self, supervisor, and coworker evaluations (how does this scale if she adds a second 
                //          coworker?)
                //      - function returns self eval evaluationId
                // TODO: Open self evaluation
            }
        }
                    
    }
}
