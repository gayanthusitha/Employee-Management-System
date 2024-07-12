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
    public partial class EmployeeRegistrationForm : Form
    {

        IFirebaseConfig rfc = new FirebaseConfig()
        {
            AuthSecret = "Y5KCVS26FGHhnRo4bt84Fsf0xIdo4dgs1W0Z7lhU",
            BasePath = "https://employee-management-syst-3f259-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        public EmployeeRegistrationForm()
        {
            InitializeComponent();
        }

        private void EmployeeRegistrationForm_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(rfc);
            }

            catch
            {
                MessageBox.Show("No Interenet or Connection Problem");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region Condition
            // Convert date picker values to DateTime and check if they are default
            DateTime defaultDate = DateTime.MinValue;
            DateTime birthDate;
            DateTime joiningDate;

            if (!DateTime.TryParse(dateBirth.Text, out birthDate) || birthDate == defaultDate ||
                !DateTime.TryParse(dateJoining.Text, out joiningDate) || joiningDate == defaultDate ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtNIC.Text) ||
                string.IsNullOrWhiteSpace(cmbGender.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtHomeAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtEID.Text) ||
                string.IsNullOrWhiteSpace(cmbJobTitle.Text) ||
                string.IsNullOrWhiteSpace(cmbDepartment.Text) ||
                string.IsNullOrWhiteSpace(txtContactName.Text) ||
                string.IsNullOrWhiteSpace(txtEPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtSalary.Text) ||
                string.IsNullOrWhiteSpace(txtBankName.Text) ||
                string.IsNullOrWhiteSpace(txtBankANumber.Text))
            {
                MessageBox.Show("Please Fill All The Fields");
                return;
            }
            #endregion

            Employee employee = new Employee()
            {
                FullName = txtFullName.Text,
                DateofBirth = birthDate.ToString("yyyy-MM-dd"), // or preferred format
                NICNumber = txtNIC.Text,
                Gender = cmbGender.Text,
                EmailAddress = txtEmail.Text,
                HomeAddress = txtHomeAddress.Text,
                PhoneNumber = txtPhoneNumber.Text,
                EmployeeID = txtEID.Text,
                DateofJoining = joiningDate.ToString("yyyy-MM-dd"), // or preferred format
                JobTitle = cmbJobTitle.Text,
                Department = cmbDepartment.Text,
                ContactName = txtContactName.Text,
                EmergencyPhoneNumber = txtEPhoneNumber.Text,
                Salary = txtSalary.Text,
                BankName = txtBankName.Text,
                BankAccountNumber = txtBankANumber.Text,
            };

            SetResponse set = client.Set(@"Employee/" + txtEID.Text, employee);

            MessageBox.Show("Employee Added!");

            // Clear all the fields
            txtFullName.Text = string.Empty;
            dateBirth.Value = DateTime.Now;
            txtNIC.Text = string.Empty;
            cmbGender.SelectedIndex = -1;
            txtEmail.Text = string.Empty;
            txtHomeAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEID.Text = string.Empty;
            dateJoining.Value = DateTime.Now;
            cmbJobTitle.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            txtContactName.Text = string.Empty;
            txtEPhoneNumber.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtBankName.Text = string.Empty;
            txtBankANumber.Text = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all the fields
            txtFullName.Text = string.Empty;
            dateBirth.Value = DateTime.Now;
            txtNIC.Text = string.Empty;
            cmbGender.SelectedIndex = -1;
            txtEmail.Text = string.Empty;
            txtHomeAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEID.Text = string.Empty;
            dateJoining.Value = DateTime.Now;
            cmbJobTitle.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            txtContactName.Text = string.Empty;
            txtEPhoneNumber.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtBankName.Text = string.Empty;
            txtBankANumber.Text = string.Empty;
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
