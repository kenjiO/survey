using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS6232_G1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // initialize these to both invisible until we know which to use, default menu will be visible
            menuStripAdmin.Visible = false;
            menuStripEmployee.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Enable/Disable admin mode
        /// </summary>
        /// <param name="on"></param>
        public void setAdminMode(bool on)
        {
            menuStripDefault.Visible = false;
            menuStripAdmin.Visible = on;
            menuStripEmployee.Visible = !on;
        }

    }
}
