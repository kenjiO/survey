using Evaluation.Controller;
using EvaluationModel;
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
    public partial class UserReportForm : Form
    {
        IEvaluationController _controller;
        private List<Stage> _stages;
        private List<EvalType> _types;

        public UserReportForm(IEvaluationController controller)
        {
            _controller = controller;
            InitializeComponent();
            if ((_stages = getStageList()) == null)
            {
                return;
            }
            cmboStage.DataSource = _stages;
            cmboStage.DisplayMember = "name";
            cmboStage.ValueMember = "id";
            cmboStage.SelectedIndex = -1;

            if ((_types = getTypeList()) == null)
            {
                return;
            }
            cmboType.DataSource = _types;
            cmboType.DisplayMember = "name";
            cmboType.ValueMember = "id";
            cmboType.SelectedIndex = -1;
        }

        private List<Stage> getStageList()
        {
            List<Stage> list = null;

            try
            {
                list = _controller.getStageList();
                if (list.Count == 0)
                {
                    MessageBox.Show("No stages available", "Notice");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from database.  Please check your SQL configuration. (Details: "
                                    + ex.Message + ")", "Notice");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            return list;
        }

        private List<EvalType> getTypeList()
        {
            List<EvalType> list = null;

            try
            {
                list = _controller.getTypeList();
                if (list.Count == 0)
                {
                    MessageBox.Show("No Evaluation Types available", "Notice");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred acquiring data from database.  Please check your SQL configuration. (Details: "
                                    + ex.Message + ")", "Notice");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            return list;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            // TODO: verify stage and type selected, else pop up warning, highlight missing field
            // TODO: generate report for selected stage/type
            // TODO: Bind results to TableView
        }
    }
}
