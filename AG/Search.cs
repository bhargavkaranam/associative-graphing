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
    public partial class Search : Form
    {
        public String username;
        public String search;
        List<String> unames = new List<string>();
        public Search(String u, String s)
        {
            username = u;
            search = s;
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                if (c is Panel) c.Visible = false;
            }
            DBConnect db = new DBConnect();
            string query = "select * from person where personID like '%" + search + "%' LIMIT 3";

            //Create a list to store the result

            //Open connection
            if (db.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();


                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    unames.Add(dataReader["personID"].ToString());
                }
                if (unames.Count == 3)
                {
                    label3.Text = unames[0];
                    panel1.Show();
                    label7.Text = unames[1];
                    panel2.Show();
                    label10.Text = unames[2];
                    panel3.Show();
                }
                if (unames.Count == 2)
                {
                    label3.Text = unames[0];
                    panel1.Show();
                    label7.Text = unames[1];
                    panel2.Show();
                }
                if (unames.Count == 1)
                {
                    label3.Text = unames[0];
                    panel1.Show();
                }
                if (unames.Count == 0)
                    MessageBox.Show("No users found");
                //close Data Reader
                dataReader.Close();

                //close Connection
                db.CloseConnection();

                //return list to be displayed                
            }
            else
            {
            }
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }
        private void viewDetailsToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            ViewDetails vd = new ViewDetails(username);
            this.Hide();
        }

        private void logoutToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void addAPhotoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            AddPhoto ap = new AddPhoto(username);
            this.Hide();
            ap.Show();
        }

        private void editDetailsToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            EditDetails ed = new EditDetails(username);
        }

        private void deleteAccountToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            String q = "delete from person where personID = '" + username + "'";
            bool check = db.Delete(q);
            if (check == true)
            {
                MessageBox.Show("Account deleted");
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Some error occurred");
        }

        private void checkInToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            CheckIn ci = new CheckIn(username);
            ci.Show();
            this.Hide();
        }

        private void addInterestsToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            AddInterests ad = new AddInterests(username);
            ad.Show();
            this.Hide();
        }

        private void settingsToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "insert into friends(A,B,closeness) values('" + username + "','" + unames[0] + "',0.00)";
            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(unames[0] + " is your friend now.");
                    db.CloseConnection();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                //close connection

            }
            else
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "insert into friends(A,B,closeness) values('" + username + "','" + unames[1] + "',0.00)";
            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(unames[1] + " is your friend now.");
                    db.CloseConnection();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                //close connection
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "insert into friends(A,B,closeness) values('" + username + "','" + unames[2] + "',0.00)";
            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(unames[2] + " is your friend now.");
                    db.CloseConnection();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                //close connection
            }
        }
        

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
