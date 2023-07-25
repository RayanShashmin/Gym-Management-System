using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUNAgym
{
    public partial class admin_login : Form
    {
        public admin_login()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = "AdminShashmin";
            string password = "1234";
            string enteredUsername = UNameTb.Text;
            string enteredPassword = PasswordTb.Text;
            if (enteredUsername == "" || enteredPassword == "")
            {
                MessageBox.Show("Missing Password or Username !!!");
            }
            else
            {
                try
                {

                    if (username == enteredUsername && password == enteredPassword)
                    {
                        Receptionist Obj = new Receptionist();
                        Obj.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Receptionist!!!, Please try again.");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
