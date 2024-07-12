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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "Y5KCVS26FGHhnRo4bt84Fsf0xIdo4dgs1W0Z7lhU",
            BasePath = "https://employee-management-syst-3f259-default-rtdb.firebaseio.com/"
        };

        FirebaseClient client;

        private void LoginForm_Load(object sender, EventArgs e)
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

        private void btnLog_Click(object sender, EventArgs e)
        {
            #region Condition
            if (string.IsNullOrWhiteSpace(txtNICnumber.Text) &&
             string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please Fill All The Fields");
                return;
            }
            #endregion

            FirebaseResponse res = client.Get(@"User/" + txtNICnumber.Text);
            User ResUser = res.ResultAs<User>(); //Database Result

            User CurUser = new User()
            {
                NICNumber = txtNICnumber.Text,
                Password = txtPassword.Text
            };

            if (User.IsEqual(ResUser, CurUser))
            {
                MessageBox.Show("Login SuccessFully!");
                this.Hide();
                var dash = new DashboardForm();
                dash.Closed += (s, args) => this.Close();
                dash.Show();

            }
            else
            {
                User.ShowError();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNICnumber.Clear();
            txtPassword.Clear();
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
