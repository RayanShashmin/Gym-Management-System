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
    public partial class Members : Form
    {
        Function Con;
        public Members()
        {
            InitializeComponent();
            Con = new Function();
            ShowMembers();
            GetCoaches();
            GetMship();
        }
        private void ShowMembers()
        {
            string Query = "select * from MemberTbl";
            MembersList.DataSource = Con.GetData(Query);
        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void CoachLbl_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }
        private void GetCoaches()
        {
            String Query = "select * from CoachsTbl";
            CoachCb.DisplayMember = Con.GetData(Query).Columns["CName"].ToString();
            CoachCb.ValueMember = Con.GetData(Query).Columns["CId"].ToString();
            CoachCb.DataSource = Con.GetData(Query);
        }

        private void GetMship()
        {
            String Query = "select * from MembershipsTbl";
            MshipCb.DisplayMember = Con.GetData(Query).Columns["MName"].ToString();
            MshipCb.ValueMember = Con.GetData(Query).Columns["MshipId"].ToString();
            MshipCb.DataSource = Con.GetData(Query);
        }

        private void Reset()
        {
            MNameTb.Text = "";
            PhoneTb.Text = "";
            CoachCb.SelectedIndex = -1;
            GenCb.SelectedIndex = -1;
            MshipCb.SelectedIndex = -1;
            StatusCb.SelectedIndex = -1;   
            TimingCb.SelectedIndex = -1;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || PhoneTb.Text == "" || CoachCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1 || MshipCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string MName = MNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string Dob = DOBTb.Value.Date.ToString();
                    string MJDate = JDateTb.Value.Date.ToString();
                    int Mship = Convert.ToInt32 (MshipCb.SelectedValue.ToString());
                    int Coach = Convert.ToInt32 (CoachCb.SelectedValue.ToString());
                    string Timing = TimingCb.SelectedItem.ToString();
                    string Status = StatusCb.SelectedItem.ToString();
                    string Query = "insert into MemberTbl values('{0}','{1}','{2}','{3}' ,'{4}','{5}','{6}','{7}','{8}' )";
                    Query = string.Format(Query, MName, Gender, DOBTb.Value.Date, JDateTb.Value.Date, Mship, Coach , Phone,Timing,Status);
                    Con.setData(Query);
                    ShowMembers();
                    Reset();
                    MessageBox.Show("Memmber Added !!!");

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void MembersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MNameTb.Text = MembersList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = MembersList.SelectedRows[0].Cells[2].Value.ToString();
            DOBTb.Text = MembersList.SelectedRows[0].Cells[3].Value.ToString();
            JDateTb.Text = MembersList.SelectedRows[0].Cells[4].Value.ToString();
            MshipCb.Text = MembersList.SelectedRows[0].Cells[5].Value.ToString();
            CoachCb.Text = MembersList.SelectedRows[0].Cells[6].Value.ToString();
            PhoneTb.Text = MembersList.SelectedRows[0].Cells[7].Value.ToString();
            TimingCb.Text = MembersList.SelectedRows[0].Cells[8].Value.ToString();
            StatusCb.Text = MembersList.SelectedRows[0].Cells[7].Value.ToString();
            if (MNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MembersList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || PhoneTb.Text == "" || CoachCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1 || MshipCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string MName = MNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string Dob = DOBTb.Value.Date.ToString();
                    string MJDate = JDateTb.Value.Date.ToString();
                    int Mship = Convert.ToInt32(MshipCb.SelectedValue.ToString());
                    int Coach = Convert.ToInt32(CoachCb.SelectedValue.ToString());
                    string Timing = TimingCb.SelectedItem.ToString();
                    string Status = StatusCb.SelectedItem.ToString();
                    string Query = "update MemberTbl set MName ='{0}', MGen='{1}', MDOB='{2}', MDate='{3}', MMembership={4}, MCoach='{5}', MPhone ='{6}', MTiming ='{7}', MStatus ='{8}' where MId = {9}"; 
                    Query = string.Format(Query, MName, Gender, DOBTb.Value.Date, JDateTb.Value.Date, Mship, Coach, Phone, Timing, Status,Key);
                    Con.setData(Query);
                    ShowMembers();
                    Reset();
                    MessageBox.Show("Memmber Updated !!!");

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Select a Coach!!!");

                }
                else
                {
                    
                    string Query = "delete from MemberTbl where MId = {0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowMembers();
                    MessageBox.Show("Member Deleted!!!");

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
