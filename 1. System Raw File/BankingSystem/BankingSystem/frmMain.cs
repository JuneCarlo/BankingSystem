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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            usernameToolStripMenuItem.Text = frmLogin.NameOfUser.ToUpper();
            if(frmLogin.NameOfUser.Equals("Admin"))
            {
                clientToolStripMenuItem1.Visible = false;
                depositToolStripMenuItem1.Visible = false;
                withdrawToolStripMenuItem1.Visible = false;
                inquireBalanceToolStripMenuItem.Visible = false;
            }
            else
            {
                viewAllTransactionsToolStripMenuItem.Visible = false;
                tellerToolStripMenuItem1.Visible = false;
                manageUsersToolStripMenuItem.Visible = false;
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Logout?", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                frmLogin A = new frmLogin();
                A.ShowDialog();
                FormSlideEffect.Slide(A, FormSlideEffect.Slides.Up);
            }
            
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePass CP = new frmChangePass();
            CP.ShowDialog();
            FormSlideEffect.Slide(CP, FormSlideEffect.Slides.Right);
        }

        private void tellerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRegister R = new frmRegister();
            R.ShowDialog();
            FormSlideEffect.Slide(R, FormSlideEffect.Slides.Right);
        }

        private void clientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddClient C = new frmAddClient();
            C.ShowDialog();
            FormSlideEffect.Slide(C, FormSlideEffect.Slides.Up);
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewUser VU = new frmViewUser();
            VU.ShowDialog();
            FormSlideEffect.Slide(VU, FormSlideEffect.Slides.Up);
        }

        private void viewAllTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransaction T = new frmTransaction();
            T.ShowDialog();
            FormSlideEffect.Slide(T, FormSlideEffect.Slides.Down);
        }

        private void depositToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDeposit D = new frmDeposit();
            D.ShowDialog();
            FormSlideEffect.Slide(D, FormSlideEffect.Slides.Down);
        }

        private void viewAllTransactionsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmTransaction T = new frmTransaction();
            T.ShowDialog();
            FormSlideEffect.Slide(T, FormSlideEffect.Slides.Down);
        }

        private void withdrawToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmWithdraw W = new frmWithdraw();
            W.ShowDialog();
            FormSlideEffect.Slide(W, FormSlideEffect.Slides.Down);
        }

        private void inquireBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInquire I = new frmInquire();
            I.ShowDialog();
            FormSlideEffect.Slide(I, FormSlideEffect.Slides.Down);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
