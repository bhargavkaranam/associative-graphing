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
    public partial class Main : Form
    {
        public String username;
        public int pid;
        List<String> fsuggest = new List<String>();
        List<String> closeness = new List<String>();
        public Main(String u)
        {
            username = u;
            InitializeComponent();
            label2.Text = username;
            DBConnect db = new DBConnect();
            

            //Create a list to store the result

            //Open connection
            if (db.OpenConnection() == true)
            {
                //Create Command
                String query = "select distinct B as b,sum(weight)/6 as closeness from suggestions where A = '" + username + "' group by b order by closeness desc limit 4";
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();


                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    fsuggest.Add(dataReader["b"].ToString());
                    closeness.Add(dataReader["closeness"].ToString());
                }
                
                if (fsuggest.Count == 4)
                {
                    label3.Text = fsuggest[0];                    
                    label8.Text = fsuggest[1];                    
                    label11.Text = fsuggest[2];
                    label15.Text = fsuggest[3];
                    label5.Text = closeness[0];
                    label6.Text = closeness[1];
                    label9.Text = closeness[2];
                    label13.Text = closeness[3]; 
                    
                }
                if (fsuggest.Count == 3)
                {
                    label3.Text = fsuggest[0];
                    label8.Text = fsuggest[1];
                    label11.Text = fsuggest[2];
                    
                    label5.Text = closeness[0];
                    label6.Text = closeness[1];
                    label9.Text = closeness[2];
                    
                }
                if (fsuggest.Count == 2)
                {
                    label3.Text = fsuggest[0];
                    label8.Text = fsuggest[1];
                    

                    label5.Text = closeness[0];
                    label6.Text = closeness[1];
                    
                    
                }
                if (fsuggest.Count == 1)
                {
                    label3.Text = fsuggest[0];
                    


                    label5.Text = closeness[0];
                    


                }
                if (fsuggest.Count == 0)
                    MessageBox.Show("No users found");
            }
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDetails vd = new ViewDetails(username);            
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void addAPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPhoto ap = new AddPhoto(username);
            this.Hide();
            ap.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void editDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditDetails ed = new EditDetails(username);
            
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckIn ci = new CheckIn(username);
            ci.Show();
            this.Hide();
        }

        private void addInterestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddInterests ad = new AddInterests(username);
            ad.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            String search = textBox1.Text;
            Search s = new Search(username, search);
            s.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void joinGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForGroups sfg = new SearchForGroups(username);
            sfg.Show();
            this.Hide();
        }

        private void createGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGroup cg = new CreateGroup(username);
            cg.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Search s = new Search(username, textBox1.Text);
            s.Show();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "insert into friends(A,B,closeness) values('" + username + "','" + fsuggest[0] + "','"+closeness[0]+"')";
            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(fsuggest[0] + " is your friend now.");
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
            string query = "insert into friends(A,B,closeness) values('" + username + "','" + fsuggest[1] + "','" + closeness[1] + "')";
            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(fsuggest[1] + " is your friend now.");
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

        private void button6_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "insert into friends(A,B,closeness) values('" + username + "','" + fsuggest[2] + "','" + closeness[2] + "')";
            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(fsuggest[2] + " is your friend now.");
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

        private void button9_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "insert into friends(A,B,closeness) values('" + username + "','" + fsuggest[3] + "','" + closeness[3] + "')";
            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(fsuggest[3] + " is your friend now.");
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

        private void button2_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "delete from suggestions where A = '" + username + "' and B = '" + fsuggest[0] + "'";
            
            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(fsuggest[0] + " will no more be shown as a suggestion");
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

        private void Main_Load_1(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "delete from suggestions where A = '" + username + "' and B = '" + fsuggest[1] + "'";

            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(fsuggest[1] + " will no more be shown as a suggestion");
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
        
        private void button5_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "delete from suggestions where A = '" + username + "' and B = '" + fsuggest[2] + "'";

            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(fsuggest[2] + " will no more be shown as a suggestion.");
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

        private void button8_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "delete from suggestions where A = '" + username + "' and B = '" + fsuggest[3] + "'";

            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(fsuggest[3] + " will no more be shown as your friend");
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
    }
}
