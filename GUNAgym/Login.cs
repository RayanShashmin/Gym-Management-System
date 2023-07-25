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
    public partial class Login : Form
    {
        Function Con;
        public Login()
        {
            InitializeComponent();
            Con = new Function();
        }
        public static int UserId;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public static int Id;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (UNameTb .Text == "" || PasswordTb.Text =="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string Query = "select * from ReceptionistTbl where RecepName='{0}' and RecepPass ='{1}' ";
                    Query=string.Format(Query,UNameTb.Text,PasswordTb.Text);
                    DataTable dt = Con.GetData(Query);
                    if(dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Receptionist");
                    }
                    else
                    {
                        UserId =Convert.ToInt32(dt.Rows[0][0].ToString());
                        Members Obj = new Members();
                        Obj.Show();
                        this.Hide();    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AdminLbl_Click(object sender, EventArgs e)
        {
            admin_login Obj = new admin_login();
            Obj.Show();
            this.Hide();
        }
    }
}
