using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUNAgym
{
    public partial class Receptionist : Form
    {
        Function Con;
        public Receptionist()
        {
            InitializeComponent();
            Con = new Function();
            ShowReceptionist();
        }

        private void ShowReceptionist()
        {
            string Query = "select * from ReceptionistTbl";
            RecepList.DataSource = Con.GetData(Query);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            RecepNameTb.Text = "";
            PhoneTb.Text = "";
            PasswordTb.Text = "";
            RecepAddTb.Text = "";
            GenCb.SelectedIndex = -1;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecepNameTb.Text == "" || PhoneTb.Text == "" || RecepAddTb.Text == "" || PhoneTb.Text == "" || GenCb.SelectedIndex == -1 || PasswordTb.Text =="")
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string RName = RecepNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string DOB = RecepDOBTb.Value.Date.ToString();
                    string Add = RecepAddTb.Text;
                    string Phone = PhoneTb.Text;
                    string Password = PasswordTb.Text;
                    string Query = "insert into ReceptionistTbl values('{0}','{1}','{2}','{3}' ,'{4}','{5}')";
                    Query = string.Format(Query, RName, Gender, DOB, Add, Phone,Password);
                    Con.setData(Query);
                    ShowReceptionist();
                    MessageBox.Show("Receptionist Added !!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void RecepList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RecepNameTb.Text = RecepList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = RecepList.SelectedRows[0].Cells[2].Value.ToString();
            RecepDOBTb.Text = RecepList.SelectedRows[0].Cells[3].Value.ToString();
            RecepAddTb.Text = RecepList.SelectedRows[0].Cells[4].Value.ToString();
            PhoneTb.Text = RecepList.SelectedRows[0].Cells[5].Value.ToString();
            PasswordTb.Text = RecepList.SelectedRows[0].Cells[6].Value.ToString();
            
            if (RecepNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(RecepList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void RecepDOBTb_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Select a Receptionist!!!");

                }
                else
                {
                    
                    string Query = "delete from ReceptionistTbl where RecepId = {0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowReceptionist();
                    MessageBox.Show("Receptionist Deleted!!!");

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecepNameTb.Text == "" || PhoneTb.Text == "" || RecepAddTb.Text == "" || PhoneTb.Text == "" || GenCb.SelectedIndex == -1 || PasswordTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string RName = RecepNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string DOB = RecepDOBTb.Value.Date.ToString();
                    string Add = RecepAddTb.Text;
                    string Phone = PhoneTb.Text;
                    string Password = PasswordTb.Text;
                    string Query = "update ReceptionistTbl set RecepName = '{0}',RecepGen='{1}',RecepDOB ='{2}',RecepAdd='{3}' ,RecepPhone ={4},RecepPass='{5}'where RecepId ={6}";
                    Query = string.Format(Query, RName, Gender, DOB, Add, Phone, Password,Key);
                    Con.setData(Query);
                    ShowReceptionist();
                    MessageBox.Show("Receptionist Updated !!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void CoachLbl_Click(object sender, EventArgs e)
        {
            Form1 Obj=new Form1();
            Obj.Show();
            this.Hide();
        }

        private void guna2ControlBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Membership Obj =new Membership();
            Obj.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
         
        }
    }
}
