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

        public int NewCohortId { get { return _cohortId; } }

        public AddCohortForm(IEvaluationController controller)
        {
            InitializeComponent();
            _controller = controller;
            _cohortId = 0;
        }

        private void AddCohortForm_Load(object sender, EventArgs e)
        {
            if (_controller == null)
            {
                MessageBox.Show("Error: AddCohortFrom created with a null controller.");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
        }

        private void CreateCohortButton_Click(object sender, EventArgs e)
        {
            String name = cohortNameTextBox.Text;
            try
            {
                _cohortId = _controller.AddCohort(name).CohortId;
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
                MessageBox.Show("An error occurred updating the database.  Please check your SQL configuration.\n\n" +
                                "Details: " + ex.Message, "Notice");
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
            DialogResult result = form.ShowDialog(Program.mainForm);
            if (result == DialogResult.OK)
            {
                return form.NewCohortId;
            }
            return -1;
        }

    }
}
