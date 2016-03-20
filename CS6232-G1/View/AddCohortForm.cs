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
        private int _cohortId;

        public int newCohortId { get { return _cohortId; } }

        public AddCohortForm(IEvaluationController controller)
        {
            InitializeComponent();
            _controller = controller;
            _cohortId = 0;
            if (_controller == null)
            {
                throw new ArgumentNullException("Null controller on Add Cohort form");
            }
        }

        private void CreateCohortButton_Click(object sender, EventArgs e)
        {
            String name = cohortNameTextBox.Text;
            try
            {
                _cohortId = _controller.addCohort(name).cohortId;
                MessageBox.Show("Cohort " + name + " created.");
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                errorMsgLabel.Text = ex.Message;
                return;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error\n" + ex.Message);
                return;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        public static int Run(IEvaluationController controller)
        {
            AddCohortForm form = new AddCohortForm(controller);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                return form.newCohortId;
            }
            return -1;
        }

    }
}
