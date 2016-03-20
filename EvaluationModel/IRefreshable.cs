using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationModel
{
    /// <summary>
    /// Interface that can be implemented by refreshable parent views
    /// </summary>
    public interface IRefreshable
    {
        void refreshViews();
    }
}
