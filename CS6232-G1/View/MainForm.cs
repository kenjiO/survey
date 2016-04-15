using CS6232_G1.View;
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
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace CS6232_G1.View
{
    public partial class MainForm : Form
    {
        IEvaluationController _controller;

        /// <summary>
        /// Main form constructor
        /// </summary>
        /// <param name="controller">View controller</param>
        public MainForm(IEvaluationController controller)
        {
            if (controller == null)
            {
                throw new ArgumentNullException("Null controller on main form");
            }
            _controller = controller;
            InitializeComponent();
            showLoginPanel();
        }

        private void showLoginPanel() {
            menuStripDefault.Visible = true;
            menuStripAdmin.Visible = false;
            menuStripEmployee.Visible = false;
            LoginPanel.Visible = true;
            LoginPanel.Location = new Point(
                this.ClientSize.Width / 2 - LoginPanel.Size.Width / 2,
                this.ClientSize.Height / 2 - LoginPanel.Size.Height / 2);
            LoginPanel.Anchor = AnchorStyles.None;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Admin Menu Item Handlers

        private void createNewCohortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cohortId = AddCohortForm.Run(_controller);
            if (cohortId <= 0)
            {
                return;
            }
            ViewCohortDetails(cohortId);
        }

        private void deleteACohortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCohortForm.Run(_controller);
        }

        private void renameACohortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameCohortForm.Run(_controller);
        }

        private void modifyACohortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int cohortId = SelectCohortForm.Run(_controller);
                if (cohortId <= 0)
                {
                    return;
                }
                ViewCohortDetails(cohortId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred on selecting a cohort. \n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }

        private void createStageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStageForm.Run(_controller);
        }

        private void renameStageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameStageForm.Run(_controller);
        }

        // This opens a dialog form that will prompt the user to select a cohort
        // It will return the cohort selected or null if cancelled or an error occurs
        private Cohort SelectCohort()
        {
            SelectCohortForm selectForm = new SelectCohortForm(_controller);
            selectForm.ShowDialog();
            if (selectForm.DialogResult == DialogResult.OK)
            {
                return selectForm.SelectedCohort;
            }
            else
            {
                return null;
            }
        }

        private void ViewCohortDetails(int cohortId)
        {
            try
            {
                Form form = new ViewCohortDetailsForm(_controller, cohortId);
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred on opening cohort details. \n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }

        private void userReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserReportForm.Run(_controller);
        }

        private void cohortReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CohortReportForm.Run(_controller);
        }

        #endregion

        #region User Menu Item Handlers

        private void employeeMenuEvaluationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prevent duplicates
            Form openEvaluationsForm = Application.OpenForms["ViewEvaluationsForm"];
            if (Application.OpenForms["ViewEvaluationsForm"] != null)
            {
                openEvaluationsForm.Focus();
                if (openEvaluationsForm.WindowState == FormWindowState.Minimized)
                {
                    openEvaluationsForm.WindowState = FormWindowState.Normal;
                }
                return;
            }

            //open ViewEvaluationDetailsForm
            try
            {
                ViewEvaluationsForm frmViewEvaluations = new ViewEvaluationsForm(_controller, _controller.CurrentUser);
                frmViewEvaluations.MdiParent = this;
                frmViewEvaluations.Show();
                // The next 2 lines fix position of child form within the parent
                frmViewEvaluations.StartPosition = FormStartPosition.Manual;
                frmViewEvaluations.Location = new System.Drawing.Point(15, 15);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred on opening evaluation list. \n\n" +
                                "Details: " + ex.Message, "Notice");
            }
        }

        #endregion

        #region Login

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String username = UsernameTextBox.Text;
            String password = PasswordTextBox.Text;
            if (!Validate(username, password))
            {
                return;
            }
            try
            {
                if (_controller.Login(username, hashPassword(password)) == null)
                {
                    ErrorMsgLabel.Text = "Invalid username/password";
                    return;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("There was a database error tying to login:\n" + ex.Message);
                return;
            }

            LoginPanel.Visible = false;
            menuStripDefault.Visible = false;
            menuStripAdmin.Visible = _controller.IsAdminSession;
            nameTextAdminMenu.Text = _controller.CurrentUser.FullNameFL;
            menuStripEmployee.Visible = !_controller.IsAdminSession;
            nameTextEmployeeMenu.Text = _controller.CurrentUser.FullNameFL;
            if (!_controller.IsAdminSession)
            {
                // Open this on login for user sessions
                employeeMenuEvaluationsToolStripMenuItem_Click(null, null);
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.Logout();
            foreach (Form form in MdiChildren)
            {
                form.Close();
            }
            showLoginPanel();
        }

        private string hashPassword(string password)
        {
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
            String hashedPassword = "";
            foreach (byte b in hash)
            {
                hashedPassword = hashedPassword + b.ToString("X2");
            }
            return hashedPassword;
        }

        private Boolean Validate(String username, String password)
        {
            if (username != null && username != "" && password != null && password != "")
            {
                return true;
            }
            else
            {
                ErrorMsgLabel.Text = "Username and Password required";
                return false;
            }
        }

        private void clearLoginErrorMessage(object sender, EventArgs e)
        {
            ErrorMsgLabel.Text = "";
        }

        #endregion


    }
}
