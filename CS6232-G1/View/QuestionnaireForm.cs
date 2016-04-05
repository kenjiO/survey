﻿using Evaluation.Controller;
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
        private int _evaluationKind;
        private int _evaluationId;
        private int _answerRange;
        private int _categoryCount;
        private int _questionsPerCategoryCount;

        public QuestionnaireForm(IEvaluationController controller, int evaluationKind, int evaluationId)
        {
            InitializeComponent();
            _controller = controller;
            _currentUser = _controller.CurrentUser;
            _evaluationKind = evaluationKind;
            _evaluationId = evaluationId;

            if (_controller == null)
            {
                throw new ArgumentNullException("controller", "Controller cannot be null");
            }
            if (_currentUser == null)
            {
                throw new ArgumentNullException("currentUser", "Current User cannot be null");
            }
            if (_evaluationKind < 0 || _evaluationKind > 1)
            {
                throw new ArgumentOutOfRangeException("Invalid evaluationKind", "Evaluation Kind has to be 0 or 1");
            }
            if (_evaluationId < 1)
            {
                throw new ArgumentOutOfRangeException("Invalid evaluationId", "Evaluation Id must be greater than 0");
            }
        }

        private void QuestionnaireForm_Load(object sender, EventArgs e)
        {
            try
            {
                EvaluationDetails evalDetails = _controller.getEvaluationDetails(_evaluationId);
                _answerRange = evalDetails.AnswerRange;
                SetUpLabels(evalDetails);

                _categoryCount = evalDetails.CategoryCount;
                _questionsPerCategoryCount = evalDetails.QuestionCount;

                // retrieve categories and questions from DB
                List<QAndA> list = _controller.getQuestionsAndAnswers(_evaluationId);                                   
            
                this.SuspendLayout();

                DBLayoutPanel tlpQuestionnaire = new DBLayoutPanel();
                setUpTableLayoutPanel(tlpQuestionnaire);      
      
                // add rows to the table layout panel
                tlpQuestionnaire.RowCount = tlpQuestionnaire.RowCount + 1;


                for (int rowNumber = 0; rowNumber < list.Count; rowNumber++)
                {

                    Label label = createCategoryLabel(tlpQuestionnaire.RowCount);
                    label.Text = list[rowNumber].CategoryName;
                    tlpQuestionnaire.Controls.Add(label, 0, tlpQuestionnaire.RowCount - 1);
                    tlpQuestionnaire.SetRowSpan(label, _questionsPerCategoryCount);

                    for (int questionCount = 0; questionCount < _questionsPerCategoryCount; questionCount++)
                    {
                        label = createQuestionLabel(list[rowNumber].QuestionId);
                        label.Text = list[rowNumber].Question;
                        tlpQuestionnaire.Controls.Add(label, 1, tlpQuestionnaire.RowCount - 1);

                        Panel panel = createPanel(list[rowNumber].EvaluationId);
                        createRadioButtonPanel(panel, _answerRange);
                        tlpQuestionnaire.Controls.Add(panel, 2, tlpQuestionnaire.RowCount - 1);

                        tlpQuestionnaire.RowCount = tlpQuestionnaire.RowCount + 1;
                        if (questionCount < _questionsPerCategoryCount - 1)
                        {
                            rowNumber++;
                        }
                    }
                }          

                //for (int categoryCount = 1; categoryCount <= _categoryCount; categoryCount++)
                //{

                //    Label label = createCategoryLabel(tlpQuestionnaire.RowCount);
                //    label.Text = "Category " + categoryCount;
                //    tlpQuestionnaire.Controls.Add(label, 0, tlpQuestionnaire.RowCount - 1);
                //    tlpQuestionnaire.SetRowSpan(label, _questionsPerCategoryCount);
                //    for (int questionCount = 0; questionCount < _questionsPerCategoryCount; questionCount++)
                //    {
                //        label = createQuestionLabel(tlpQuestionnaire.RowCount);
                //        label.Text = "Question " + (tlpQuestionnaire.RowCount);
                //        tlpQuestionnaire.Controls.Add(label, 1, tlpQuestionnaire.RowCount - 1);
                //        Panel panel = createPanel(tlpQuestionnaire.RowCount);
                //        createRadioButtonPanel(panel, _answerRange);
                //        tlpQuestionnaire.Controls.Add(panel, 2, tlpQuestionnaire.RowCount - 1);
                //        tlpQuestionnaire.RowCount = tlpQuestionnaire.RowCount + 1;
                //    }
                //}          

                this.ResumeLayout();

                this.Controls.Add(tlpQuestionnaire);

                SetLabelWidths(tlpQuestionnaire);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred retrieving evaluation details.\n\n" +
                                "Details: " + ex.Message, "Notice");
            } 

        }

        private void setUpTableLayoutPanel(DBLayoutPanel tlpQuestionnaire)
        {            
            tlpQuestionnaire.Location = new Point(12, 230);
            tlpQuestionnaire.Size = new Size(839, 110);
            tlpQuestionnaire.AutoSize = true;
            tlpQuestionnaire.Margin = new System.Windows.Forms.Padding(3, 3, 40, 30);
            tlpQuestionnaire.Name = "tlpQuestionnaire";
            tlpQuestionnaire.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            tlpQuestionnaire.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tlpQuestionnaire.ColumnCount = 3;
            tlpQuestionnaire.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            tlpQuestionnaire.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 319F));
            tlpQuestionnaire.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tlpQuestionnaire.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpQuestionnaire.RowCount = 0;
            tlpQuestionnaire.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tlpQuestionnaire.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddRows;

            tlpQuestionnaire.Left = 30;
        }

        private void SetLabelWidths(DBLayoutPanel tlpQuestionnaire)
        {
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

        private void SetUpLabels(EvaluationDetails evalDetails)
        {
            String evaluatedEmployeeName = "";

            lblTitle.Text = evalDetails.TypeName + " " + lblTitle.Text;

            lblGeneral.Text =
                "As you know, Company XXX utilizes a 360-degree performance appraisal methodology. " +
                "Peer review is a critical part of this process. You have been selected to " +
                "provide a ";
            if (_evaluationKind == 0)
            {
                lblGeneral.Text += "self evaluation.";
                lblEmployeeName.Text = "Evaluated Employee: ";
                evaluatedEmployeeName = _currentUser.FullName;
            }
            else
            {
                
                lblGeneral.Text += "peer review for another employee.";
                try
                {
                    evaluatedEmployeeName = _controller.GetEmployeeNameFL(evalDetails.EmployeeId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred retrieving employee name from the database.\n\n" +
                                    "Details: " + ex.Message, "Notice");
                }
            }

            lblEmployeeName.Text += evaluatedEmployeeName;

            lblInstructions.Text = 
                "Using a scale of 1 to " + _answerRange + 
                " (with 1 being the lowest and " + _answerRange + " being the highest), " +
                "rate this employee's performance. Please answer the questions thoroughly and truthfully. " +
                "Your responses will be compiled along with those provided by other employees. Thank you for your participation.";

        }

        private Panel createPanel(int evaluationId)
        {
            NonFlickerPanel panel = new NonFlickerPanel();
            panel.Name = evaluationId.ToString();
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

        private Label createQuestionLabel(int questionId)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Name = "lblQuestion" + questionId;
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
