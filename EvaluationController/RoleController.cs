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
        private List<Role> _roles;

        public List<Role> getRoleList()
        {
            _roles = _dal.getRoleList();
            return _roles;
        }

        private bool tryLoadRoleList()
        {
            if (_roles == null)
            {
                try
                {
                    getRoleList();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }


        public string getRoleName(int roleId)
        {
            if (!tryLoadRoleList())
            {
                return "";
            }
            Role result = _roles.Find(r => r.id == roleId);
            if (result == null || result.id != roleId)
            {
                _roles = null;
                return "";
            }
            return result.name;
        }

        public bool roleExists(string name)
        {
            if (!tryLoadRoleList())
            {
                return false;
            }
            return _roles.Exists(r => r.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

    }
}
