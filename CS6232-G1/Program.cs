using Evaluation.Controller;
using Evaluation.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS6232_G1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // for standard operation, provide normal EvaluationController initialzed with a normal EvaluationDAL
            Application.Run(new MainForm(new EvaluationController(new EvaluationDAL())));
        }
    }
}
