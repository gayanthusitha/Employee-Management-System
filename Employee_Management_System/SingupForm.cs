using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;

namespace Employee_Management_System
{
    public partial class SingupForm : Form
    {
        public SingupForm()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "Y5KCVS26FGHhnRo4bt84Fsf0xIdo4dgs1W0Z7lhU",
            BasePath = "https://employee-management-syst-3f259-default-rtdb.firebaseio.com/"
        };

        FirebaseClient client;
        private void SingupForm_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("No Interenet or Connection Problem");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            #region Condition
            if (
               string.IsNullOrWhiteSpace(txtFullName.Text) &&
               string.IsNullOrWhiteSpace(txtUserName.Text) &&
               string.IsNullOrWhiteSpace(txtNICnumber.Text) &&
               string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please Fill All The Fields");
                return;
            }

            #endregion

            User user = new User()
            {
                FullName = txtFullName.Text,
                UserName = txtUserName.Text,
                NICNumber = txtNICnumber.Text,
                Password = txtPassword.Text
            };

            SetResponse set = client.Set(@"User/" + txtNICnumber.Text, user);

            MessageBox.Show("Successfully Registered!");

            txtFullName.Clear();
            txtUserName.Clear();
            txtNICnumber.Clear();
            txtPassword.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtUserName.Clear();
            txtNICnumber.Clear();
            txtPassword.Clear();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var log = new LoginForm();
            log.Closed += (s, args) => this.Close();
            log.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main = new MainForm();
            main.Closed += (s, args) => this.Close();
            main.Show();
        }
    }
}
