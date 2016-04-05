using Evaluation.Controller;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS6232_G1.View
{
    public partial class QuestionnaireForm : Form
    {
        private IEvaluationController _controller;
        private Employee _currentUser;

        public QuestionnaireForm(IEvaluationController controller)
        {
            InitializeComponent();
            _controller = controller;
            _currentUser = _controller.CurrentUser;
        }

        private void QuestionnaireForm_Load(object sender, EventArgs e)
        {
            //String evaluatedEmployeeName = _currentUser.FirstName + " " + _currentUser.LastName;
            //String evaluatedEmployeeName = "John Doe";
            //lblGeneral.Text += evaluatedEmployeeName + ".";

            // get answer range from DB
            int answerRange = 10;

            lblEmployeeName.Text += "John Doe";
            
            lblInstructions.Text = "Using a scale of 1 to " + answerRange + " (with 1 being the lowest and " +
            answerRange + " being the highest), rate this employee's performance. Please answer the questions thoroughly and truthfully. " +
                "Your responses will be compiled along with those provided by other employees. Thank you for your participation.";

            this.SuspendLayout();

            DBLayoutPanel tlpQuestionnaire = new DBLayoutPanel();
            tlpQuestionnaire.Location = new Point(12, 230);
            tlpQuestionnaire.Size = new Size(839, 110);
            tlpQuestionnaire.AutoSize = true;
            tlpQuestionnaire.Margin = new System.Windows.Forms.Padding(3, 3, 40, 30);
            tlpQuestionnaire.Name = "tlpQuestionnaire";
            tlpQuestionnaire.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            tlpQuestionnaire.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tlpQuestionnaire.ColumnCount = 3;
            tlpQuestionnaire.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tlpQuestionnaire.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 319F));
            tlpQuestionnaire.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tlpQuestionnaire.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpQuestionnaire.RowCount = 0;
            tlpQuestionnaire.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tlpQuestionnaire.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddRows;                  
            
            tlpQuestionnaire.Left = 30;

            // Add rows to the table layout panel
            tlpQuestionnaire.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            int questionsPerCategory = 5;
            tlpQuestionnaire.RowCount = tlpQuestionnaire.RowCount + 1;
            for (int categoryCount = 1; categoryCount <= 7; categoryCount++)
            {
                
                Label label = createCategoryLabel(tlpQuestionnaire.RowCount);
                label.Text = "Category " + categoryCount;                
                tlpQuestionnaire.Controls.Add(label, 0, tlpQuestionnaire.RowCount - 1);
                tlpQuestionnaire.SetRowSpan(label, questionsPerCategory);
                for (int questionCount = 0; questionCount < questionsPerCategory; questionCount++)
                {
                    label = createQuestionLabel(tlpQuestionnaire.RowCount);
                    label.Text = "Question " + (tlpQuestionnaire.RowCount);
                    tlpQuestionnaire.Controls.Add(label, 1, tlpQuestionnaire.RowCount - 1);
                    Panel panel = createPanel(tlpQuestionnaire.RowCount);
                    createRadioButtonPanel(panel, answerRange);
                    tlpQuestionnaire.Controls.Add(panel, 2, tlpQuestionnaire.RowCount - 1);
                    tlpQuestionnaire.RowCount = tlpQuestionnaire.RowCount + 1;
                }
            }          

            this.ResumeLayout();

            this.Controls.Add(tlpQuestionnaire); 

            int tableWidth = tlpQuestionnaire.Width;

            lblTitle.Left = 30;
            lblTitle.Width = tableWidth;

            lblGeneral.Left = 30;
            lblGeneral.Width = tableWidth;

            lblEmployeeName.Left = 30;
            lblEmployeeName.Width = tableWidth;

            lblInstructions.Left = 30;
            lblInstructions.Width = tableWidth;            

        }

        private Panel createPanel(int rowNumber)
        {
            Panel panel = new Panel();
            panel.Name = "panel" + rowNumber;
            panel.Dock = DockStyle.Fill;
            return panel;
        }

        private Label createCategoryLabel(int rowNumber) {
            Label label = new Label();
            label.Name = "lblCategory" + rowNumber;
            label.Font = new Font("Microsoft Sans Serif", 10);
            label.AutoSize = true;
            label.Margin = new Padding(3);
            label.MaximumSize = new Size(200, 0);
            return label;
        }

        private Label createQuestionLabel(int rowNumber)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Name = "lblQuestion" + rowNumber;
            label.Font = new Font("Microsoft Sans Serif", 10);
            label.Margin = new Padding(3);
            label.MaximumSize = new Size(400, 0);
            return label;
        }

        private void createRadioButtonPanel(Panel panel, int answerRange)
        {
            int spacer = 0;
            if (answerRange == 5)
            {
                spacer = 80;
            }
            else
            {
                spacer = 60;
            }
            for (int i = 1; i <= answerRange; i++)
            {
                RadioButton rb = new RadioButton();
                rb.AutoSize = true;
                rb.Text = "" + i;
                rb.Name = "rb" + i;
                rb.Tag = "" + i;
                rb.Location = new Point(10 + spacer * (i - 1), 6);
                panel.Controls.Add(rb);
                panel.AutoSize = true;
                //MessageBox.Show("panel height: " + panel1.Height);
            }
        }
    }

    /// <summary>
    /// Double Buffered layout panel - removes flicker during resize operations.
    /// </summary>
    public partial class DBLayoutPanel : TableLayoutPanel
    {
        public DBLayoutPanel()
        {
            this.DoubleBuffered = true;
        }
    }

    public partial class NonFlickerPanel : Panel
    {
        public NonFlickerPanel()
            : base()
       {
           this.DoubleBuffered = true;
       }
    } 
}
