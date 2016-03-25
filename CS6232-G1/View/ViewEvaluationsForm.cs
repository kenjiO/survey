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
                MessageBox.Show("Invalid arguments to cohort scheduler");
                Close();
                return;
            }
            try
            {
                dgvSelfEvaluations.CellFormatting += dgvSelfEvaluations_CellFormatting;
                dgvOtherEvaluations.CellFormatting += dgvOtherEvaluations_CellFormatting;

                loadSelfEvaluations();
                loadOtherEvaluations();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        void dgvOtherEvaluations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == senderGrid.Columns["StageName1"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewRow row = senderGrid.Rows[e.RowIndex];
                e.Value = _controller.getStageName((int)row.Cells["StageId1"].Value);
            }
            if (e.ColumnIndex == senderGrid.Columns["TypeName1"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewRow row = senderGrid.Rows[e.RowIndex];
                e.Value = _controller.getTypeName((int)row.Cells["TypeId1"].Value);
            }
            if (e.ColumnIndex == senderGrid.Columns["EmployeeName"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewRow row = senderGrid.Rows[e.RowIndex];
                e.Value = _controller.getEmployeeName(((int)row.Cells["EmployeeId"].Value));
            }
            if (e.ColumnIndex == senderGrid.Columns["EvaluateAs"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewRow row = senderGrid.Rows[e.RowIndex];
                e.Value = _controller.getRoleName((int)row.Cells["RoleId"].Value);
            }
            if (e.ColumnIndex == senderGrid.Columns["CloseDate1"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewRow row = senderGrid.Rows[e.RowIndex];
                e.Value = _controller.getEndDateForSchedule((int)row.Cells["TypeId1"].Value, (int)row.Cells["StageId1"].Value, _currentUser.cohortId).ToShortDateString();
            }
            
            senderGrid.ClearSelection();            
        }

        private void loadSelfEvaluations()
        {
            //Get list of evaluation schedule objects and bind the datagrid to the list
            List<Evaluations> evaluationList = _controller.getOpenSelfEvaluations(_currentUser.employeeId);
            dgvSelfEvaluations.DataSource = evaluationList;            
            dgvSelfEvaluations.ClearSelection();
        }

        private void loadOtherEvaluations()
        {
            //Get list of evaluation schedule objects and bind the datagrid to the list
            List<Evaluations> evaluationList = _controller.getOpenOtherEvaluations(_currentUser.employeeId);
            dgvOtherEvaluations.DataSource = evaluationList;            
            dgvOtherEvaluations.ClearSelection();
        }

        public void refreshViews()
        {
            loadSelfEvaluations();
            loadOtherEvaluations();
        }
            

        void dgvSelfEvaluations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == senderGrid.Columns["StageName"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewRow row = senderGrid.Rows[e.RowIndex];
                e.Value = _controller.getStageName((int)row.Cells["StageId"].Value);
            }
            if (e.ColumnIndex == senderGrid.Columns["TypeName"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewRow row = senderGrid.Rows[e.RowIndex];
                e.Value = _controller.getTypeName((int)row.Cells["TypeId"].Value);
            }
            if (e.ColumnIndex == senderGrid.Columns["CloseDate"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewRow row = senderGrid.Rows[e.RowIndex];
                e.Value = _controller.getEndDateForSchedule((int)row.Cells["TypeId"].Value, (int)row.Cells["StageId"].Value, _currentUser.cohortId).ToShortDateString();
            }
            senderGrid.ClearSelection();
        }
    }
}
