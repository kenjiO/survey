using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.DAL
{
    public partial class EvaluationDAL : IEvaluationDAL
    {
        public List<UserReport> GetUserReport(int employeeId, int typeId, int stageId)
        {
            // TODO: Query user report data from SQL
            return null;
        }
    }
}
