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
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Employee_Management_System
{
    public partial class UserManageForm : Form
    {

        IFirebaseConfig Ifc = new FirebaseConfig()
        {
            AuthSecret = "Y5KCVS26FGHhnRo4bt84Fsf0xIdo4dgs1W0Z7lhU",
            BasePath = "https://employee-management-syst-3f259-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        public UserManageForm()
        {
            InitializeComponent();
        }

        private void UserManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(Ifc);
            }

            catch
            {
                MessageBox.Show("No Interenet or Connection Problem");
            }
            loadusers();
        }

        public void loadusers()
        {
            try
            {
                FirebaseResponse response = client.Get(@"User/");
                Dictionary<string, User> getUser = response.ResultAs<Dictionary<string, User>>();

                foreach (var get in getUser)
                {
                    tblUser.Rows.Add(
                        get.Value.FullName,
                        get.Value.UserName,
                        get.Value.NICNumber,
                        get.Value.Password

                        );
                }
            }
            catch
            {
                MessageBox.Show("No Data Stored!");
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNICnumber.Text))
            {
                MessageBox.Show("Please provide the User NIC.");
                return;
            }

            var result = client.Get(@"User/" + txtNICnumber.Text);
            User user = result.ResultAs<User>();

            if (user != null)
            {
                txtFullName.Text = user.FullName;
                txtUserName.Text = user.UserName;
                txtNICnumber.Text = user.NICNumber;
                txtPassword.Text = user.Password;         

                MessageBox.Show("Data Retrieved Successfully!");
            }
            else
            {
                MessageBox.Show("Employee not found.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNICnumber.Text))
            {
                MessageBox.Show("Please provide the User NIC.");
                return;
            }

            User user = new User()
            {
                FullName = txtFullName.Text,
                UserName = txtUserName.Text,
                NICNumber = txtNICnumber.Text,
                Password = txtPassword.Text,
            };

            var setResponse = client.Set(@"User/" + txtNICnumber.Text, user);

            if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("User Updated Successfully!");

                // Clear all the fields after a successful update
                txtFullName.Text = string.Empty;
                txtUserName.Text = string.Empty;
                txtNICnumber.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Failed to update user. Please try again.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tblUser.DataSource = null;
            tblUser.Rows.Clear();
            loadusers();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNICnumber.Text))
            {
                MessageBox.Show("Please provide the User NIC.");
                return;
            }

            // Remove the employee data from the database
            var deleteResponse = client.Delete(@"User/" + txtNICnumber.Text);

            if (deleteResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("User Removed Successfully!");

                // Clear all the fields after a successful removal
                txtFullName.Text = string.Empty;
                txtUserName.Text = string.Empty;
                txtNICnumber.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Failed to remove user. Please try again.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all the fields
            txtFullName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtNICnumber.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dash = new DashboardForm();
            dash.Closed += (s, args) => this.Close();
            dash.Show();
        }
    }
}
