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
    public partial class RenameStageForm : Form
    {
        IEvaluationController _controller;

        public RenameStageForm(IEvaluationController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void RenameStageForm_Load(object sender, EventArgs e)
        {
            if (_controller == null)
            {
                MessageBox.Show("Error: RenameStageFrom created with a null controller.");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            LoadComboBoxItems();
        }

        private void LoadComboBoxItems()
        {
            List<Stage> stageList = null;
            try
            {
                stageList = _controller.GetStageList();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A Database error occured fetching stages\n\n" +
                    "Details: " + ex.Message, "Notice");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            if (stageList == null || stageList.Count < 1)
            {
                MessageBox.Show("There are no stages");
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
            stagesComboBox.DataSource = stageList;
            stagesComboBox.DisplayMember = "Name";
            stagesComboBox.ValueMember = "Id";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {
            Stage selectedStage = (Stage) stagesComboBox.SelectedItem;
            if (selectedStage == null)
            {
                MessageBox.Show("Please select a stage first");
                return;
            }
            int stageId = selectedStage.Id;
            string oldName = selectedStage.Name;
            string newName = newNameBox.Text.Trim();
            if (newName == "")
            {
                MessageBox.Show("New name must not be blank");
                return;
            }

            bool result = false;
            try
            {
                result = _controller.RenameStage(stageId, oldName, newName);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A Database error occured renaming the stage\n\n" +
                     "Details: " + ex.Message);
                LoadComboBoxItems();
                return;
            }

            if (result)
            {
                MessageBox.Show("Stage " + oldName + " renamed to " + newName);
                this.DialogResult = DialogResult.OK;
                Close();
                return;
            }
            else
            {
                MessageBox.Show(selectedStage.Name + " was unable to be renamed");
            }
            LoadComboBoxItems();
        }

        public static void Run(IEvaluationController controller)
        {
            RenameStageForm form = new RenameStageForm(controller);
            form.ShowDialog(Program.mainForm);
        }


    }
}
