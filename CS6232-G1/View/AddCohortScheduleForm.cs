using Evaluation.Controller;
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
    public partial class AddCohortScheduleForm : Form
    {
        private IEvaluationController _controller;
        private int _cohortId;
        private String _cohortName;

        /// <summary>
        /// Run Add Cohort Schedule dialog
        /// </summary>
        /// <param name="controller">Controller to use</param>
        /// <param name="cohortId">Id of cohort to add schedule for</param>
        /// <param name="cohortName">Name of cohort (optional)</param>
        public AddCohortScheduleForm(IEvaluationController controller, int cohortId, String cohortName)
        {
            InitializeComponent();
            _controller = controller;
            _cohortId = cohortId;
            _cohortName = cohortName;
        }

        private void AddCohortScheduleForm_Load(object sender, EventArgs e)
        {
            if (_controller == null)
            {
                MessageBox.Show("Invalid arguments to cohort scheduler");
                Close();
                return;
            }
            if (_cohortId <= 0)
            {
                MessageBox.Show("Invalid cohort selected");
                Close();
                return;
            }
            if (_cohortName.Length <= 0) 
            {
                try
                {
                    _cohortName = _controller.getCohortName(_cohortId);
                }
                catch (SqlException ex) 
                {
                    MessageBox.Show("A database error occurred looking up the cohort name.  Please" +
                          " check your SQL configuration.\n\n" +
                         "Details: " + ex.Message, "Notice");
                    Close();
                    return;
                }
                catch (KeyNotFoundException)
                {
                    MessageBox.Show("Invalid cohort selected");
                    Close();
                    return;
                }
            }
            lblCohortName.Text = _cohortName;
            cboType.SelectedIndex = -1;
            cboStage.SelectedIndex = -1;
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Setup for selected item
            // set stage
            // get min start date
            // set start.mindate, startdate, and enddate to min start date
            // enable btnAdd
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO: Finish
            // if successful, close
            // calling form will need to refresh list
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }



        
    }
}
