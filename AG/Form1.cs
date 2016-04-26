using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using System.Web;
using System.Net.Mail;
namespace AG
{
    public partial class Form1 : Form
    {       
        List<String> loc = new List<String>();
        public Form1()
        {
            InitializeComponent();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String name = textBox3.Text;
            String email = textBox2.Text;
            String date = (String)comboBox1.SelectedItem;
            String month = (String)comboBox2.SelectedItem;
            String year = (String)comboBox3.SelectedItem;
            String dob = year + "/" + month + "/" + date;
            String locality = (String)comboBox5.SelectedItem;
            String workplace = (String)comboBox6.SelectedItem;            
            String gender = (String)comboBox4.SelectedItem;
            if (username.Length == 0 || name.Length == 0 || email.Length == 0 || date.Length == 0 || month.Length == 0 || year.Length == 0 || locality.Length == 0 || workplace.Length == 0 || gender.Length == 0)
                MessageBox.Show("All fields are required!");
            else if (!IsValid(email))
                MessageBox.Show("Email not valid");                            
            else
            {                             
                DBConnect db = new DBConnect();
                int l = db.getLID(locality);
                int w = db.getWID(workplace);
                String q = "insert into person(personID,name,emailid,gender,dob,locality,workplace) values ('" + username + "','" + name + "','" + email + "','" + gender + "','" + dob + "','" + l + "','" + w + "')";
                bool check = db.Insert(q);                
                if (check == true)
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                        mail.From = new MailAddress("bhargav.karanam@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "Registration";
                        mail.Body = "Thank you for registering with us.";
                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("yourmail", "yourpassword");
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);
                        MessageBox.Show("Check your email");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't send the email. Try again.");

                    }
                    Main m = new Main(username);
                    this.Hide();
                    m.Show();
                    
                }                
            }
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mail m = new Mail();
            m.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
