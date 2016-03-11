using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evaluation.Controller;
using Evaluation.Model;

namespace CS6232_G1.View
{
    public partial class LoginForm : Form
    {
        IEvaluationController _controller;

        public LoginForm(IEvaluationController controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String username = UsernameTextBox.Text;
            String password = PasswordTextBox.Text;
            if (!Validate(username, password))
                return;

            if (_controller.login(username, password) == null)
            {
                ErrorMsgLabel.Text = "Invalid username/password";
                return;
            }

            if (_controller.idAdminSession)
            {
                ErrorMsgLabel.Text = "TODO: Start admin session";
            }
            else
            {
                ErrorMsgLabel.Text = "TODO: Start user session";
            }
        }

        private Boolean Validate(String username, String password)
        {
            if (username != null && username != "" && password != null && password != "")
            {
                return true;
            }
            else
            {
                ErrorMsgLabel.Text = "Username and Password required";
                return false;
            }
        }
    }
}
