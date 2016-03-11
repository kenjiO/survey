using Evaluation.DAL;
using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Controller
{
    /// <summary>
    /// Evaluation view controller
    /// </summary>
    public partial class EvaluationController : IEvaluationController
    {


        public Employee login(string email, string password)
        {
            throw new NotSupportedException();
        }
    }
}