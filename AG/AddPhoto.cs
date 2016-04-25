using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
namespace AG
{
    public partial class AddPhoto : Form
    {
        public String username;
        public String fname;
        int r;
        public AddPhoto(String u)
        {
            username = u;
            InitializeComponent();
            textBox1.Hide();
            button2.Hide();
        }
        private void settingsToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void editDetailsToolStripMenuItem1_Click_1(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void editDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                try
                {
                    fname = dialog.SafeFileName;
                    String name = dialog.FileName;
                    MessageBox.Show(fname + " has been uploaded!");
                    DBConnect db = new DBConnect();
                    Random rand = new Random();
                     r = rand.Next(10000);
                    string query = "insert into photo(photoid,url) values('"+r+"','"+fname+"')";

            //open connection
                    if (db.OpenConnection() == true)
                    {
               
                     MySqlCommand cmd = new MySqlCommand(query, db.connection);               
                     try
                      {
                       cmd.ExecuteNonQuery();
                       db.CloseConnection();                    
                      }catch(MySqlException ex)
                        {
                        MessageBox.Show(ex.ToString());                    
                        }   
                //close connection
                
                    }
                   else
                    {
             
                    }
                    button1.Hide();
                    textBox1.Show();
                    button2.Show();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
                
            }

        }

        private void AddPhoto_Load(object sender, EventArgs e)
        {
            Main m = new Main(username);
            this.Hide();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String tags = textBox1.Text;
            String[] tag = tags.Split(',');
            int size = tag.Length;
            DBConnect db = new DBConnect();                                    
            for(int i=0;i<size;i++)
            {
                string query = "insert into tagged(personid,photoid) values('" + tag[i] +"','"+r+"')";

                //open connection
                if (db.OpenConnection() == true)
                {

                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        db.CloseConnection();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    //close connection

                }
            }
            Main m = new Main(username);
            this.Hide();
            m.Show();
        }
    }
}
