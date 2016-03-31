using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class OpenEvaluation
    {
        public int? evaluationId { get { return _evaluationId; } }
        public int scheduleId { get { return _scheduleId; } }
        public String employeeName { get { return _name; } }
        public int roleId { get { return _roleId; } }
        public String roleName { get { return _role; } }
        public String typeName { get { return _type; } }
        public String stageName { get { return _stage; } }
        public DateTime startDate { get { return _startDate; } }
        public DateTime endDate { get { return _endDate; } }

        public OpenEvaluation(int? evaluationId, int scheduleId, String employeeName, int roleId, String roleName, String typeName, 
                                    String stageName, DateTime startDate, DateTime endDate)
        {
            _evaluationId = evaluationId;
            _scheduleId = scheduleId;
            _name = employeeName;
            _roleId = roleId;
            _role = roleName;
            _type = typeName;
            _stage = stageName;
            _startDate = startDate;
            _endDate = endDate;
        }

        private int? _evaluationId;
        private int _scheduleId;
        private String _name;
        private int _roleId;
        private String _role;
        private String _type;
        private String _stage;
        private DateTime _startDate;
        private DateTime _endDate;
    }
}
