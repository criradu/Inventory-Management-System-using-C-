This first form is used for login of an user who wants to conenct to the application.
All the users of the application will have their usernames and passwords saved in a database.




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cristina\Documents\Invetorydb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Usertable where Uname+'" + usernameBox.Text + "' and UserPassword'" + passwordBox.Text + "'");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                ManageCustomers cust = new ManageCustomers();
                cust.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or password");
            }
            Con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            usernameBox.Text = " ";
            passwordBox.Text = " ";
        }
    }
}
