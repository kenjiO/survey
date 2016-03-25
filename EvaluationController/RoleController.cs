using Evaluation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Controller
{
    /// <summary>
    /// Role portion of Evaluation View-Controller
    /// </summary>
    public partial class EvaluationController : IEvaluationController
    {
        /// <summary>
        /// Get Role name from role id
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns>Role name</returns>
        public String getRoleName(int roleId)
        {
            throw new NotSupportedException();
        }
    }
}
