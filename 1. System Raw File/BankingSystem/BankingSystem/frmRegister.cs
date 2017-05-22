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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
           
            db = new DCbankDataContext();
            var Query_User = db.sp_verifyusername(txtusername.Text);
            foreach (sp_verifyusernameResult entry in Query_User)
            {
                Username = entry.username.ToString();
            }
        }

        static string encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        string Username;
        static DCbankDataContext db = null;
        private void lblverifyUser_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            if(txtname.Text.Equals("") || txtusername.Text.Equals("") || txtpassword.Text.Equals("") || txtconfirmpass.Text.Equals("") || txtanswer.Text.Equals(""))
            {
                lblverifyUser.Text = "Fill up Everything";
            }
            else
            {
                if(txtpassword.Text != txtconfirmpass.Text)
                {
                    lblverifyUser.Text = "Your Password and Confirm Password is not match";
                }
                else
                {
                    if (txtusername.Text.Equals(Username))
                    {
                        lblverifyUser.Text = "Username is taken";
                    }
                    else
                    {
                        db.sp_INSERT_admin(txtusername.Text, txtname.Text, encrypt(txtpassword.Text), cboQuestion.Text, txtanswer.Text);
                        DialogResult result = MessageBox.Show("Back to Main Menu", "Successfully Register", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            this.Close();
                        }
                        else
                        {
                            txtusername.Clear();
                            txtname.Clear();
                            txtpassword.Clear();
                            cboQuestion.Text = "What is your favorite pet?";
                            txtanswer.Clear();
                        }
                    }
                }
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            var Query_User = db.sp_verifyusername(txtusername.Text);
            foreach(sp_verifyusernameResult entry in Query_User)
            {
                lblverifyUser.Text = "Username is taken";
            }
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormSlideEffect.Slide(this, FormSlideEffect.Slides.Up);
            this.Close();
        }
    }
}
