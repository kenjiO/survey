using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class EvalType
    {
        public enum Evaluator { Self, Peer};

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public int AnswerRange { get { return _answerRange; } }

        public EvalType(int id, string name, int answerRange)
        {
            _id = id;
            _name = name;
            _answerRange = answerRange;
        }

        private int _id;
        private string _name;
        private int _answerRange;
    }
}
