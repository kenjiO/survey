using Evaluation.Controller;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS6232_G1.View
{
    public partial class SelectCoworkerForm : Form
    {
        private IEvaluationController _controller;
        private EmployeeName _selectedCoworker;

        public EmployeeName SelectedCoworker { get { return _selectedCoworker; } }

        public SelectCoworkerForm(IEvaluationController controller)
        {
            InitializeComponent();
            _controller = controller;
            _selectedCoworker = null;
        }

        private void SelectCoworkerForm_Load(object sender, EventArgs e)
        {
            if (_controller == null)
            {
                MessageBox.Show("Invalid controller to Select Coworker Form.");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            LoadCoworkerList();
        }

        private void LoadCoworkerList()
        {
            List<EmployeeName> EmployeeListExceptSelfAndSupervisor = null;
            try
            {
                if (_controller.CurrentUser.SupervisorId == null) {
                    throw new ArgumentException("Supervisor has not been set.");
                }
                int[] ids = {_controller.CurrentUser.EmployeeId, (int) _controller.CurrentUser.SupervisorId};
                EmployeeListExceptSelfAndSupervisor = _controller.GetListOfNonAdminEmployees(ids);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A Database error occured fetching employee list\n\n" +
                    "Details: " + ex.Message, "Notice");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            if (EmployeeListExceptSelfAndSupervisor == null || EmployeeListExceptSelfAndSupervisor.Count < 1)
            {
                MessageBox.Show("There are no other employees in the DB. Please add employees before coworker can be selected.");
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
            cboCoworkers.DataSource = EmployeeListExceptSelfAndSupervisor;
            cboCoworkers.DisplayMember = "Name";
            cboCoworkers.ValueMember = "EmployeeId";
            cboCoworkers.SelectedIndex = -1;
        }

        private void cboCoworkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCoworker = (EmployeeName)cboCoworkers.SelectedItem;
            btnSelectCoworker.Enabled = (_selectedCoworker != null);
        }

        private void btnSelectCoworker_Click(object sender, EventArgs e)
        {
            _selectedCoworker = (EmployeeName)cboCoworkers.SelectedItem;
            if (_selectedCoworker == null)
            {
                MessageBox.Show("Please select a coworker first");
                return;
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        public static int Run(IEvaluationController controller)
        {
            SelectCoworkerForm form = new SelectCoworkerForm(controller);
            DialogResult result = form.ShowDialog(Program.mainForm);
            if (result == DialogResult.OK && form.SelectedCoworker != null)
            {
                return form.SelectedCoworker.EmployeeId;
            }
            return -1;
        }
        
    }
}
