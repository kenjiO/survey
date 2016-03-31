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

            menuStripAdmin.Visible = false;
            menuStripEmployee.Visible = false;
            showLoginPanel();
        }

        private void showLoginPanel() {
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
            int cohortId = SelectCohortForm.Run(_controller);
            if (cohortId <= 0)
            {
                return;
            }
            ViewCohortDetails(cohortId);
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
            Form form = new ViewCohortDetailsForm(_controller, cohortId);
            form.MdiParent = this;
            form.Show();
        }

        #endregion

        #region User Menu Item Handlers

        ViewEvaluationsForm frmViewEvaluations;

        private void employeeMenuEvaluationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prevent duplicates
            if (frmViewEvaluations != null)
            {
                frmViewEvaluations.Close();
            }
            //open ViewEvaluationDetailsForm
            frmViewEvaluations = new ViewEvaluationsForm(_controller, _controller.CurrentUser);
            frmViewEvaluations.MdiParent = this;
            frmViewEvaluations.Show();
            frmViewEvaluations.FormClosed += viewEvaluationsForm_FormClosed;
            // The next 2 lines fix position of child form within the parent
            frmViewEvaluations.StartPosition = FormStartPosition.Manual;
            frmViewEvaluations.Location = new System.Drawing.Point(15, 15);
        }


        void viewEvaluationsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmViewEvaluations = null;
        }

        #endregion

        #region Login

        private void login()
        {
            String username = UsernameTextBox.Text;
            String password = PasswordTextBox.Text;
            if (!Validate(username, password))
            {
                return;
            }

            try
            {
                if (_controller.Login(username, password) == null)
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
            menuStripEmployee.Visible = !_controller.IsAdminSession;
            if (!_controller.IsAdminSession)
            {
                // Open this on login for user sessions
                employeeMenuEvaluationsToolStripMenuItem_Click(null, null);
            }
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

        private void LoginButton_Click(object sender, EventArgs e)
        {
            login();
        }
        
        //Login using enter key instead of clicking on the button
        private void LoginTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
       
        #endregion

    }
}
