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
using Evaluation.Model;
using System.Data.SqlClient;

namespace CS6232_G1.View
{
    public partial class AddStageForm : Form
    {
        IEvaluationController _controller;
        private int _stageId;

        public int NewStageId { get { return _stageId; } }

        public AddStageForm(IEvaluationController controller)
        {
            InitializeComponent();
            _controller = controller;
            _stageId = 0;
        }

        private void AddStageForm_Load(object sender, EventArgs e)
        {
            if (_controller == null)
            {
                MessageBox.Show("Error: AddStageFrom created with a null controller.");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
        }

        private void CreateStageButton_Click(object sender, EventArgs e)
        {
            String name = stageNameTextBox.Text;
            try
            {
                _stageId = _controller.AddStage(name);
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

            this.DialogResult = DialogResult.OK;
                MessageBox.Show("Stage " + name + " created", "Notice");
                Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        public static int Run(IEvaluationController controller)
        {
            AddStageForm form = new AddStageForm(controller);
            DialogResult result = form.ShowDialog(Program.mainForm);
            if (result == DialogResult.OK)
            {
                return form.NewStageId;
            }
            return -1;
        }

    }
}
