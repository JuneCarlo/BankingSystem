using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem
{
    public partial class frmForgotPass : Form
    {
        public frmForgotPass()
        {
            InitializeComponent();
        }
        static DCbankDataContext db = null;
        private void btnForgotPass_Click(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            if (txtanswer.Text.Equals("") || txtanswer.Text.Equals(""))
            {
                lblAction.Text = "Fill up Everything";
            }
            else
            {
                int counter = 0;
                var Query_Pass = db.sp_retrieve_user(txtusername.Text, cboQuestion.Text, txtanswer.Text);
                foreach (sp_retrieve_userResult entry in Query_Pass)
                {
                    DialogResult result = MessageBox.Show("Your Password: " +entry.password.ToString(), "Successfully retrieved", MessageBoxButtons.OK);
                    if(result == DialogResult.OK)
                    {
                        this.Hide();
                        frmLogin A = new frmLogin();
                        A.Show();
                        FormSlideEffect.Slide(A, FormSlideEffect.Slides.Up);
                    }
                   
                    counter++;
                }
                if(counter.Equals(0))
                {
                    lblAction.Text = "Incorrect Information";
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin A = new frmLogin();
            A.Show();
            FormSlideEffect.Slide(A, FormSlideEffect.Slides.Up);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
