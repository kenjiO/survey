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

        public List<Role> GetRoleList()
        {
            _roles = _dal.GetRoleList();
            return _roles;
        }

        private bool TryLoadRoleList()
        {
            if (_roles == null)
            {
                try
                {
                    GetRoleList();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }


        public string GetRoleName(int roleId)
        {
            if (!TryLoadRoleList())
            {
                return "";
            }
            Role result = _roles.Find(r => r.Id == roleId);
            if (result == null || result.Id != roleId)
            {
                _roles = null;
                return "";
            }
            return result.Name;
        }

        public bool RoleExists(string name)
        {
            if (!TryLoadRoleList())
            {
                return false;
            }
            return _roles.Exists(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

    }
}
