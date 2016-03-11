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
        private Boolean _isAdminSession;
        public Employee currentUser { get { return _currentUser; } }
        public Boolean idAdminSession { get { return _isAdminSession; } }

        public Employee login(string email, string password)
        {
            _currentUser = _dal.getLogin(email, password);
            if (_currentUser != null && _currentUser.isAdmin)
                _isAdminSession = true;
            else
                _isAdminSession = false;
            return _currentUser;
        }
    }
}