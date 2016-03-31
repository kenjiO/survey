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
        private Employee _currentUser;
        public Employee currentUser { get { return _currentUser; } }
        public bool idAdminSession { get { return _currentUser.IsAdmin; } }

        public Employee login(string email, string password)
        {
            _currentUser = _dal.getLogin(email, password);
            return _currentUser;
        }
    }
}