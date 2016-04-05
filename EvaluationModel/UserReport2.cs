using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class UserReport2
    {
        public string Name { get; private set; }
        public string TypeName { get; private set; }
        public string StageName { get; private set; }

        public string Category { get; private set; }
        public int QuestionNumber { get; private set; }
        public int SelfEvaluation { get; private set; }
        public int SupervisorEvaluation { get; private set; }
        public int CoworkerEvaluation { get; private set; }
        public double AverageEvaluation { get; private set; }

        public UserReport2(string _name, string _type, string _stage, string _category, int _question, int _self, int _supervisor, int _coworker)
        {
            Name = _name;
            TypeName = _type;
            StageName = _stage;
            Category = _category;
            QuestionNumber = _question;
            SelfEvaluation = _self;
            SupervisorEvaluation = _supervisor;
            CoworkerEvaluation = _coworker;
            AverageEvaluation = GetEvaluationAverage();
        }

        public double GetEvaluationAverage()
        {
            return (double)(SelfEvaluation + SupervisorEvaluation + CoworkerEvaluation) / 3;
        }
    }
}
