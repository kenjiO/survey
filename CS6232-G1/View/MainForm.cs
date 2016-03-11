﻿using CS6232_G1.View;
using Evaluation.Controller;
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
            //testToolStripMenuItem.Visible = true;

            // initialize these to both invisible until we know which to use, default menu will be visible
            menuStripAdmin.Visible = false;
            menuStripEmployee.Visible = false;
            if (_controller == null)
            {
                throw new ArgumentNullException("Null controller on main form");
            }
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

        // TODO: Remove test link from default menu when done testing
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AddCohortScheduleForm(_controller, 1, "");
            form.MdiParent = this;
            form.Show();
        }

    }
}
