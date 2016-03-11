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
            String name = CohortNameTextBox.Text;
            if (name.Trim() == "")
            {
                ErrorMsgLabel.Text = "Cohort name cannot be blank";
                return;
            }
            MessageBox.Show("TODO: implement add cohort in controller");
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
