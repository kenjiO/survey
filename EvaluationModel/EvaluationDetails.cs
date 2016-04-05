using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Model
{
    public class EvaluationDetails
    {
        public int EmployeeId { get; private set; }
        public int TypeId { get; private set; }
        public string TypeName { get; private set; }
        public int AnswerRange { get; private set; }
        public int CategoryCount { get; private set; }
        public int QuestionCount { get; private set; }
        

        public EvaluationDetails(int employeeId, int typeId, string typeName, int answerRange, int categoryCount, int questionCount) 
        {
            EmployeeId = employeeId;
            TypeId = typeId;
            TypeName = typeName;
            AnswerRange = answerRange;
            CategoryCount = categoryCount;
            QuestionCount = questionCount;
        }
    }
}
