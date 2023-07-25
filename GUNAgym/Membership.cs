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
    public partial class Membership : Form
    {
        Function Con;
        public Membership()
        {
            InitializeComponent();
            Con = new Function();
            Mships();
        }
        private void Mships()
        {
            string Query = "select * from MembershipsTbl";
            MshipList.DataSource = Con.GetData(Query);
        }

        private void Reset()
        {
            MNameTb.Text = "";
            CostTb.Text = "";
            MDurationTb.Text = "";
            GoalTb.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || MDurationTb.Text == "" || GoalTb.Text == "" || CostTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string MName = MNameTb.Text;
                    int Duration = Convert.ToInt32(MDurationTb.Text);
                    string Goal = GoalTb.Text;
                    int Cost = Convert.ToInt32(CostTb.Text);
                    string Query = "insert into MembershipsTbl values('{0}',{1},'{2}',{3} )";
                    Query = string.Format(Query, MName, Duration, Goal, Cost);
                    Con.setData(Query);
                    Mships();
                    MessageBox.Show("Membership Added !!!");
                    Reset();
                }

                
                }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void MshipList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MNameTb.Text = MshipList.SelectedRows[0].Cells[1].Value.ToString();
            MDurationTb.Text = MshipList.SelectedRows[0].Cells[2].Value.ToString();
            GoalTb.Text = MshipList.SelectedRows[0].Cells[3].Value.ToString();
            CostTb.Text = MshipList.SelectedRows[0].Cells[4].Value.ToString();
            
            if (MNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MshipList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Select a Membership!!!");

                }
                else
                {
                    
                    string Query = "delete from MembershipsTbl where MShipId = {0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    Mships();
                    MessageBox.Show("Membership Deleted!!!");
                    Reset();

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
                if (MNameTb.Text == "" || MDurationTb.Text == "" || GoalTb.Text == "" || CostTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string MName = MNameTb.Text;
                    int Duration = Convert.ToInt32(MDurationTb.Text);
                    string Goal = GoalTb.Text;
                    int Cost = Convert.ToInt32(CostTb.Text);
                    string Query = "update MembershipsTbl set MName = '{0}',MDuration= {1},MGoal= '{2}',MCost={3} where  MshipId ={4}";
                    Query = string.Format(Query, MName, Duration, Goal, Cost,Key);
                    Con.setData(Query);
                    Mships();
                    MessageBox.Show("Membership Updated !!!");
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
            Form1 Obj = new Form1();
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
