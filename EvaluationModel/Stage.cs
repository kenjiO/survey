using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class Stage
    {
        public int id { get { return _id; } }
        public string name { get { return _name; } }

        public Stage(int id, string name)
        {
            _id = id;
            _name = name;
        }

        private int _id;
        private string _name;
    }
}
