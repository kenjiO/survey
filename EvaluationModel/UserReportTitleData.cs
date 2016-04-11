using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class UserReportTitleData
    {
        public string Name { get; private set; }
        public string TypeName { get; private set; }
        public string StageName { get; private set; }
        public DateTime DateGenerated { get; private set; }

        public UserReportTitleData(string _name, string _type, string _stage)
        {
            Name = _name;
            TypeName = _type;
            StageName = _stage;
            DateGenerated = DateTime.Now.Date;
        }
    }
}
