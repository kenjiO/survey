using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evaluation.Controller;
using System.Data.SqlClient;

namespace CS6232_G1.View
{
    public partial class AddCohortForm : Form
    {
        IEvaluationController _controller;

        public AddCohortForm(IEvaluationController controller)
        {
            InitializeComponent();
            _controller = controller;
            if (_controller == null)
            {
                throw new ArgumentNullException("Null controller on Add Cohort form");
            }
        }

        private void CreateCohortButton_Click(object sender, EventArgs e)
        {
            String name = cohortNameTextBox.Text;
            if (name.Trim() == "")
            {
                errorMsgLabel.Text = "Cohort name cannot be blank";
                return;
            }
            try
            {
                _controller.addCohort(name);
                MessageBox.Show("Cohort " + name + " created.");
                Close();
            }
            catch (SqlException ex) 
            {
                MessageBox.Show("Database error\n" + ex.Message);
                return;
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
