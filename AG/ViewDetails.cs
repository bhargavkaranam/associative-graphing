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
    public partial class ViewDetails : Form
    {
        String username;
        List<string>[] list = new List<string>[5];
        public ViewDetails(String u)
        {
            username = u;
            DBConnect db = new DBConnect();
            String q = "select emailid,dob,h.name as locality,w.name as workplace,gender from person,place as h,place as w where person.personID = '"+username+"' and person.locality = h.placeid and person.workplace = w.placeid";            
            db.SelectUserDetails(q);            
            InitializeComponent();
        }
        public ViewDetails(String e,String d,String l,String w,String g)
        {
            InitializeComponent();
            label2.Text = e;
            label3.Text = d;
            label4.Text = l;
            label5.Text = w;
            label6.Text = g;
        }
        private void ViewDetails_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Main m = new Main(username);
            this.Hide();
            m.Show();
        }
    }
}
