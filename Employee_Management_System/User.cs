using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    class User
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string NICNumber { get; set; }
        public string Password { get; set; }

        private static string error = "There was some error";

        public static void ShowError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        public static bool IsEqual(User user1, User user2)
        {
            if (user1 == null || user2 == null) { return false; }

            if (user1.NICNumber != user2.NICNumber)
            {
                error = "Nic does not exist!";
                return false;
            }
            else if (user1.Password != user2.Password)
            {
                error = "Username and password does not match!";
                return false;
            }

            return true;
        }
    }
}
