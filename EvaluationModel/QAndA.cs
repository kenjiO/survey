using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class QAndA
    {
        public int EvaluationId { get; private set; }
        public int QuestionId {get; private set;}
        public string CategoryName {get; private set;}
        public string Question {get; private set;}
        public int AnswerID {get; private set;}
        public int Answer {get; private set;}

        public QAndA(int evaluationId, int questionId, string categroryName, string question, int answerId, int answer)
        {
            EvaluationId = evaluationId;
            QuestionId = questionId;
            CategoryName = categroryName;
            Question = question;
            AnswerID = answerId;
            Answer = answer;
        }
    }
}
