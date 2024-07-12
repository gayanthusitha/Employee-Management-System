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
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void addEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            var addemployee = new EmployeeRegistrationForm();
            addemployee.Closed += (s, args) => this.Close();
            addemployee.Show();
        }

        private void manageEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            var manageE = new EmployeeManageForm();
            manageE.Closed += (s, args) => this.Close();
            manageE.Show();
        }

        private void manageUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            var manageuser = new UserManageForm();
            manageuser.Closed += (s, args) => this.Close();
            manageuser.Show();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var log = new LoginForm();
            log.Closed += (s, args) => this.Close();
            log.Show();
        }
    }
}
