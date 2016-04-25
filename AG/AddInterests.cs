using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AG
{
    public partial class AddInterests : Form
    {
        public String username;
        public AddInterests(String u)
        {
            username = u;
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            String like = textBox1.Text;
            int i_id = db.getIID(like);
            String q = "insert into likes values('" + username + "','" + like + "')";
            bool check = db.Insert(q);
            if(check == true)
            {
                MessageBox.Show("We recorded your interest, will help us understand you better");
                Main m = new Main(username);
                m.Show();
                this.Hide();
            }
        }

        private void AddInterests_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Main m = new Main(username);
            m.Show();
            this.Hide();
        }
    }
}
