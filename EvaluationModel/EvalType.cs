using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class EvalType
    {
        public int id { get { return _id; } }
        public string name { get { return _name; } }
        public int answerRange { get { return _answerRange; } }

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
