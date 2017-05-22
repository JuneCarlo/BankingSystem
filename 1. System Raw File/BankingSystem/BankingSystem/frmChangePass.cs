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
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
            txtusername.Text = frmLogin.Username.ToString();
        }
        static DCbankDataContext db = null;
        string Pass;

        static string encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            
            Pass = frmLogin.Password.ToString();
            if(txtusername.Text.Equals("") || txtoldpass.Text.Equals("") || txtnewpass.Text.Equals("") || txtconfirmnewpass.Text.Equals(""))
            {
                lblverifyUser.Text = "Fill up Everything";
            }
            else
            {
                if(Pass != encrypt(txtoldpass.Text))
                {
                    lblverifyUser.Text = "Incorrect Old Password";
                }
                else
                {
                   if(txtnewpass.Text != txtconfirmnewpass.Text)
                   {
                       lblverifyUser.Text = "Your New Password and Confirm New Password is not match";
                   }
                   else
                   {
                       db.sp_changepass(txtusername.Text, encrypt(txtoldpass.Text), encrypt(txtnewpass.Text));
                       DialogResult result = MessageBox.Show("Successfully Update", "Note", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                       if (result == DialogResult.OK)
                       {
                           this.Close();
                       }
                   }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FormSlideEffect.Slide(this, FormSlideEffect.Slides.Up);
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmChangePass_Load(object sender, EventArgs e)
        {

        }
    }
}
