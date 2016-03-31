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
        public Employee CurrentUser { get { return _currentUser; } }
        public bool IsAdminSession { get { return _currentUser.IsAdmin; } }

        public Employee Login(string email, string password)
        {
            _currentUser = _dal.GetLogin(email, password);
            return _currentUser;
        }
    }
}