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

namespace CS6232_G1.View
{
    public partial class SelectCohortForm : Form
    {
        private Cohort _selectedCohort;
        private IEvaluationController _controller;

        public SelectCohortForm(IEvaluationController controller)
        {
            InitializeComponent();
            if (_controller == null)
            {
                throw new ArgumentNullException("Null controller on Select Cohort Form");
            }
            _selectedCohort = null;
        }

        public Cohort selectedCohort { get { return _selectedCohort; } }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

    }
}
