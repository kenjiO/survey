using Evaluation.Controller;
using System;
using System.Windows.Forms;

namespace CS6232_G1.View
{
    public partial class ViewEvaluationsForm : Form
    {
        private IEvaluationController _controller;

        public ViewEvaluationsForm(IEvaluationController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void ViewEvaluationDetailsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
