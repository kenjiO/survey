using Evaluation.DAL;
using EvaluationModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.Controller
{
    /// <summary>
    /// Interface for Evaluations View Controller
    /// </summary>
    public interface IEvaluationController
    {
        List<Stage> getStageList();

        List<EvalType> getTypeList();

        DataTable getUserReport(int stage, int evalType);

    }
}
