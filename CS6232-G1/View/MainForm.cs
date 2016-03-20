﻿using CS6232_G1.View;
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
            _controller = controller;
            InitializeComponent();

            // TODO: Remove - test code
            // *********** Begin test code **************
            //testToolStripMenuItem.Visible = true;
            testAdminToolStripMenuItem.Visible = true;
            //testEmployeeMenuToolStripMenuItem.Visible = true;
            // ************ End test code ***************

            // initialize these to both invisible until we know which to use, default menu will be visible
            menuStripAdmin.Visible = false;
            menuStripEmployee.Visible = false;
            if (_controller == null)
            {
                throw new ArgumentNullException("Null controller on main form");
            }
        }

        // TODO: Remove test link from default menu when done testing
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AddCohortScheduleForm(_controller, 1, "");
            form.MdiParent = this;
            form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Enable/Disable admin mode
        /// </summary>
        /// <param name="on"></param>
        public void setAdminMode(bool on)
        {
            menuStripDefault.Visible = false;
            menuStripAdmin.Visible = on;
            menuStripEmployee.Visible = !on;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String username = UsernameTextBox.Text;
            String password = PasswordTextBox.Text;
            if (!Validate(username, password))
                return;

            try
            {
                if (_controller.login(username, password) == null)
                {
                    ErrorMsgLabel.Text = "Invalid username/password";
                    return;
                }

                LoginPanel.Visible = false;

                if (_controller.idAdminSession)
                {
                    setAdminMode(true);
                }
                else
                {
                    setAdminMode(false);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("There was a database error tying to login:\n" + ex.Message);
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

        private void createNewCohortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AddCohortForm(_controller);
            form.MdiParent = this;
            form.Show();
        }

        // This opens a dialog form that will prompt the user to select a cohort
        // It will return the cohort selected or null if cancelled or an error occurs
        private Cohort selectCohort()
        {
            SelectCohortForm selectForm = new SelectCohortForm(_controller);
            selectForm.ShowDialog();
            if (selectForm.DialogResult == DialogResult.OK)
            {
                return selectForm.selectedCohort;
            }
            else
            {
                return null;
            }
        }

    }
}
