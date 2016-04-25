using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace AG
{
    public partial class CreateGroup : Form
    {
        public String username;
        public CreateGroup(String u)
        {
            username = u;
            InitializeComponent();
        }

        private void CreateGroup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "insert into groups(name) values('" + textBox1.Text + "')";
            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("You've created the group successfully");                    
                    Main m = new Main(username);
                    this.Hide();
                    m.Show();
                    db.CloseConnection();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                //close connection
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Main m = new Main(username);
            this.Hide();
            m.Show();
        }
    }
}
