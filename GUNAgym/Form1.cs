namespace GUNAgym
{
    public partial class Form1 : Form
    {
        Function Con;
        public Form1()
        {
            InitializeComponent();
            Con = new Function();
            ShowCoach();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void ShowCoach()
        {
            string Query = "select * from CoachsTbl";
            CoachsList.DataSource = Con.GetData(Query);
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChNameTb.Text == "" || PhoneTb.Text == "" || ExpTb.Text == "" || PassTb.Text == "" ||GenCb.SelectedIndex == -1) 
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string CName =ChNameTb.Text;
                    string Gender=GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    int experience = Convert.ToInt32(ExpTb.Text);
                    string Add = AddTb.Text;
                    string Password = PassTb.Text;
                    string Query = "insert into CoachsTbl values('{0}','{1}','{2}','{3}' ,'{4}','{5}','{6}' )";
                    Query=string.Format(Query, CName, Gender, DOBTb.Value.Date, Phone, experience, Add, Password);
                    Con.setData(Query);
                    ShowCoach();
                    MessageBox.Show("Coach Added !!!");

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int Key=0;
        private void CoachsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ChNameTb.Text = CoachsList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = CoachsList.SelectedRows[0].Cells[2].Value.ToString();
            DOBTb.Text = CoachsList.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = CoachsList.SelectedRows[0].Cells[4].Value.ToString();
            ExpTb.Text = CoachsList.SelectedRows[0].Cells[5].Value.ToString();
            AddTb.Text = CoachsList.SelectedRows[0].Cells[6].Value.ToString();
            PassTb.Text = CoachsList.SelectedRows[0].Cells[7].Value.ToString();
            if (ChNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CoachsList.SelectedRows[0].Cells[0].Value.ToString());
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
                    string CName = ChNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    int experience = Convert.ToInt32(ExpTb.Text);
                    string Add = AddTb.Text;
                    string Password = PassTb.Text;
                    string Query = "delete from CoachsTbl where CId = {0}";
                    Query = string.Format(Query,Key);
                    Con.setData(Query);
                    ShowCoach();
                    MessageBox.Show("Coach Deleted!!!");

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
                if (ChNameTb.Text == "" || PhoneTb.Text == "" || ExpTb.Text == "" || PassTb.Text == "" || GenCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string CName = ChNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    int experience = Convert.ToInt32(ExpTb.Text);
                    string Add = AddTb.Text;
                    string Password = PassTb.Text;
                    string Query = "update CoachsTbl set CName ='{0}', CGen='{1}', CDOB='{2}', CPhone='{3}' , CExperience='{4}', CAddress='{5}', CPass='{6}' where CID={7}";
                    Query = string.Format(Query, CName, Gender, DOBTb.Value.Date, Phone, experience, Add, Password,Key);
                    Con.setData(Query);
                    ShowCoach();
                    MessageBox.Show("Coach Updated !!!");

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void MemberLbl_Click(object sender, EventArgs e)
        {
            Members Obj = new Members();
            Obj.Show();
            this.Hide();
        }

        private void MshipLbl_Click(object sender, EventArgs e)
        {
            Membership Obj = new Membership();
            Obj.Show();
            this.Hide();
        }

        private void RecepLbl_Click(object sender, EventArgs e)
        {
            Receptionist Obj =new Receptionist();
            Obj.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Login Obj =new Login();
            Obj.Show();
            this.Hide();
        }
    }
}