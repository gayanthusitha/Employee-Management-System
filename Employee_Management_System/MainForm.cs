using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var log = new LoginForm();
            log.Closed += (s, args) => this.Close();
            log.Show();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            var singup = new SingupForm();
            singup.Closed += (s, args) => this.Close();
            singup.Show();
        }
    }
}
