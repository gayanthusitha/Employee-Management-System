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
using System.Net;

namespace Employee_Management_System
{
    public partial class EmployeeManageForm : Form
    {
        IFirebaseConfig rfc = new FirebaseConfig()
        {
            AuthSecret = "Y5KCVS26FGHhnRo4bt84Fsf0xIdo4dgs1W0Z7lhU",
            BasePath = "https://employee-management-syst-3f259-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        public EmployeeManageForm()
        {
            InitializeComponent();
        }

        private void EmployeeManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(rfc);
            }

            catch
            {
                MessageBox.Show("No Interenet or Connection Problem");
            }
            //loadEmployee();
        }

        public void loadEmployee()
        {
            try
            {
                FirebaseResponse response = client.Get(@"Employee/");
                Dictionary<string, Employee> getEmployee = response.ResultAs<Dictionary<string, Employee>>();

                foreach (var get in getEmployee)
                {
                    tblEmployee.Rows.Add(
                        get.Value.FullName,
                        get.Value.DateofBirth,
                        get.Value.NICNumber,
                        get.Value.Gender,
                        get.Value.EmailAddress,
                        get.Value.HomeAddress,
                        get.Value.PhoneNumber,
                        get.Value.EmployeeID,
                        get.Value.DateofJoining,
                        get.Value.JobTitle,
                        get.Value.Department,
                        get.Value.ContactName,
                        get.Value.EmergencyPhoneNumber,
                        get.Value.Salary,
                        get.Value.BankName,
                        get.Value.BankAccountNumber
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
            if (string.IsNullOrWhiteSpace(txtEID.Text))
            {
                MessageBox.Show("Please provide the Employee ID.");
                return;
            }

            var result = client.Get(@"Employee/" + txtEID.Text);
            Employee employee = result.ResultAs<Employee>();

            if (employee != null)
            {
                txtFullName.Text = employee.FullName;
                dateBirth.Value = DateTime.Parse(employee.DateofBirth);
                txtNIC.Text = employee.NICNumber;
                cmbGender.Text = employee.Gender;
                txtEmail.Text = employee.EmailAddress;
                txtHomeAddress.Text = employee.HomeAddress;
                txtPhoneNumber.Text = employee.PhoneNumber;
                txtEID.Text = employee.EmployeeID;
                dateJoining.Value = DateTime.Parse(employee.DateofJoining);
                cmbJobTitle.Text = employee.JobTitle;
                cmbDepartment.Text = employee.Department;
                txtContactName.Text = employee.ContactName;
                txtEPhoneNumber.Text = employee.EmergencyPhoneNumber;
                txtSalary.Text = employee.Salary;
                txtBankName.Text = employee.BankName;
                txtBankANumber.Text = employee.BankAccountNumber;

                MessageBox.Show("Data Retrieved Successfully!");
            }
            else
            {
                MessageBox.Show("Employee not found.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEID.Text))
            {
                MessageBox.Show("Please provide the Employee ID.");
                return;
            }

            Employee employee = new Employee()
            {
                FullName = txtFullName.Text,
                DateofBirth = dateBirth.Value.ToString("yyyy-MM-dd"), // Adjust the format if necessary
                NICNumber = txtNIC.Text,
                Gender = cmbGender.Text,
                EmailAddress = txtEmail.Text,
                HomeAddress = txtHomeAddress.Text,
                PhoneNumber = txtPhoneNumber.Text,
                EmployeeID = txtEID.Text,
                DateofJoining = dateJoining.Value.ToString("yyyy-MM-dd"), // Adjust the format if necessary
                JobTitle = cmbJobTitle.Text,
                Department = cmbDepartment.Text,
                ContactName = txtContactName.Text,
                EmergencyPhoneNumber = txtEPhoneNumber.Text,
                Salary = txtSalary.Text,
                BankName = txtBankName.Text,
                BankAccountNumber = txtBankANumber.Text
            };

            var setResponse = client.Set(@"Employee/" + txtEID.Text, employee);

            if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Employee Updated Successfully!");

                // Clear all the fields after a successful update
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
            else
            {
                MessageBox.Show("Failed to update employee. Please try again.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEID.Text))
            {
                MessageBox.Show("Please provide the Employee ID.");
                return;
            }

            // Remove the employee data from the database
            var deleteResponse = client.Delete(@"Employee/" + txtEID.Text);

            if (deleteResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Employee Removed Successfully!");

                // Clear all the fields after a successful removal
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
            else
            {
                MessageBox.Show("Failed to remove employee. Please try again.");
            }
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
