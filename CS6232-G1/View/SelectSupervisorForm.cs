using Evaluation.Controller;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS6232_G1.View
{
    public partial class SelectSupervisorForm : Form
    {
        private IEvaluationController _controller;
        private EmployeeName _selectedSupervisor;

        public EmployeeName SelectedSupervisor { get { return _selectedSupervisor; } }

        public SelectSupervisorForm(IEvaluationController controller)
        {
            InitializeComponent();
            _controller = controller;
            _selectedSupervisor = null;
        }

        private void SelectSupervisorForm_Load(object sender, EventArgs e)
        {
            if (_controller == null)
            {
                MessageBox.Show("Invalid controller to Select Supervisor Form.");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            LoadSupervisorList();
        }

        private void LoadSupervisorList()
        {
            List<EmployeeName> EmployeeListExceptSelf = null;
            try
            {
                int[] ids = {_controller.CurrentUser.EmployeeId};
                EmployeeListExceptSelf = _controller.GetListOfNonAdminEmployees(ids);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A Database error occured fetching employee list\n\n" +
                    "Details: " + ex.Message, "Notice");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            if (EmployeeListExceptSelf == null || EmployeeListExceptSelf.Count < 1)
            {
                MessageBox.Show("There are no other employees in the DB. Please add employees before supervisor can be selected.");
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
            cboSupervisors.DataSource = EmployeeListExceptSelf;
            cboSupervisors.DisplayMember = "FullName";
            cboSupervisors.ValueMember = "EmployeeId";
            cboSupervisors.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSelectSupervisor_Click(object sender, EventArgs e)
        {
            _selectedSupervisor = (EmployeeName)cboSupervisors.SelectedItem;
            if (_selectedSupervisor == null)
            {
                MessageBox.Show("Please select a supervisor first");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("You have selected " + _selectedSupervisor.FullName + " as your supervisor. Once set, the supervisor cannot be changed."
                            + Environment.NewLine + "Click OK to confirm supervisor selection."
                            + Environment.NewLine
                            + "Click Cancel to return to the form to select another supervisor.", "Confirm Supervisor", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                cboSupervisors.Focus();                
            }
        }

        private void cboSupervisors_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedSupervisor = (EmployeeName)cboSupervisors.SelectedItem;
            btnSelectSupervisor.Enabled = (_selectedSupervisor != null);
        }

        public static int Run(IEvaluationController controller)
        {
            SelectSupervisorForm form = new SelectSupervisorForm(controller);
            DialogResult result = form.ShowDialog(Program.mainForm);
            if (result == DialogResult.OK && form.SelectedSupervisor != null)
            {
                return form.SelectedSupervisor.EmployeeId;
            }
            return -1;
        }
    }
}
