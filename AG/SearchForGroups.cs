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
    public partial class SearchForGroups : Form
    {
        String username;
        String search;
        List<String> gnames = new List<String>();
        List<String> gids = new List<String>();
        public SearchForGroups()
        {
            InitializeComponent();
        }
        public SearchForGroups(String u)
        {
            username = u;
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                if (c is Panel) c.Visible = false;
            }
        }

        private void SearchForGroups_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "select * from groups where name like '%" + search + "%' LIMIT 3";

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
                    gnames.Add(dataReader["name"].ToString());
                    gids.Add(dataReader["groupid"].ToString());
                }
                if (gnames.Count == 3)
                {
                    label3.Text = gnames[0];
                    panel1.Show();
                    label8.Text = gnames[1];
                    panel2.Show();
                    label11.Text = gnames[2];
                    panel3.Show();
                }
                if (gnames.Count == 2)
                {
                    label3.Text = gnames[0];
                    panel1.Show();
                    label8.Text = gnames[1];
                    panel2.Show();
                }
                if (gnames.Count == 1)
                {
                    label3.Text = gnames[0];
                    panel1.Show();
                }
                if (gnames.Count == 0)
                    MessageBox.Show("No groups found");
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

        private void button7_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "insert into membership(personID,groupid) values('" + username + "','" + gids[0] + "')";
            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(gnames[1] + " is your friend now.");
                    db.CloseConnection();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                //close connection
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string query = "insert into membership(personID,groupid) values('" + username + "','" + gids[1] + "')";
            //open connection
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(gnames[1] + " is your friend now.");
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

        }
    }
}
