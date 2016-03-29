using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class OpenEvaluation
    {
        public int scheduleId { get { return _scheduleId; } }
        public String employeeName { get { return _name; } }
        public int roleId { get { return _roleId; } }
        public String roleName { get { return _role; } }
        public String typeName { get { return _type; } }
        public String stageName { get { return _stage; } }
        public DateTime openDate { get { return _openDate; } }
        public DateTime closeDate { get { return _closeDate; } }

        public OpenEvaluation(int scheduleId, String employeeName, int roleId, String roleName, String typeName, 
                                    String stageName, DateTime openDate, DateTime closeDate)
        {
            _scheduleId = scheduleId;
            _name = employeeName;
            _roleId = roleId;
            _role = roleName;
            _type = typeName;
            _stage = stageName;
            _openDate = openDate;
            _closeDate = closeDate;
        }

        private int _scheduleId;
        private String _name;
        private int _roleId;
        private String _role;
        private String _type;
        private String _stage;
        private DateTime _openDate;
        private DateTime _closeDate;
    }
}
