using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class Evaluations
    {
        public int EvaluationId { get; set; }
        public int EmployeeId { get; set; }
        public int TypeId { get; set; }
        public int StageId { get; set; }
        public int EvaluatorId { get; set; }
        public int RoleId { get; set; }
        public DateTime? CompletionDate { get; set; }

        public Evaluations(int employeeid, int typeId, int stageId, int evaluatorId, int roleId, DateTime? completionDate) 
        {
            EmployeeId = employeeid;
            TypeId = typeId;
            StageId = stageId;
            EvaluatorId = evaluatorId;
            RoleId = roleId;
            CompletionDate = completionDate;
        }
    }
}
