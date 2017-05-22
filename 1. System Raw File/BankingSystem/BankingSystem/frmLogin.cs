using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace BankingSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            timer1.Start();
        }
        public static string Username = "Admin"; //Default username 
        public static string UserType = "Admin"; //Default User Type
        public static string NameOfUser = "Administrator";
        public static string Password = "admin"; // Default pass
        static DCbankDataContext db = null;

        static string encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongTimeString().ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            if (txtuser.Text.Equals("") || txtpass.Text.Equals(""))
            {
                lblAction.Text = "Fill up Everything";
            }
            else
            {
                int count = 0;
                var Query_Login = db.sp_verifyusernamepass(txtuser.Text, encrypt(txtpass.Text));
                foreach (sp_verifyusernamepassResult entry in Query_Login)
                {
                    if (entry.isactive.Equals("ACTIVE"))
                    {
                        Username = entry.username.ToString();
                        UserType = entry.usertype.ToString();
                        NameOfUser = entry.name.ToString();
                        Password = entry.password.ToString();

                        this.Hide();
                        frmMain M = new frmMain();
                        M.Show();
                    }
                    else
                    {
                        lblAction.Text = "Your Account is not Active";
                    }
                    count++;
                }
                if (count.Equals(0))
                {
                    int count1 = 0;
                    var Query_User = db.sp_verifyusername(txtuser.Text);
                    foreach (sp_verifyusernameResult entry in Query_User)
                    {
                        lblAction.Text = "Incorrect Password";
                        count1++;
                    }
                    if (count1.Equals(0))
                    {
                        lblAction.Text = "Invalid Account";
                    }

                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Exit?", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmForgotPass F = new frmForgotPass();
            F.Show();
            FormSlideEffect.Slide(F, FormSlideEffect.Slides.Up);
        }
    }
}
