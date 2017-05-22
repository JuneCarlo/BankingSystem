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
    public partial class frmInquire : Form
    {
        public frmInquire()
        {
            InitializeComponent();
            frmTransaction.GenTransacID(txtTransacID);
        }
        static DCbankDataContext db = null;
        private void label9_Click(object sender, EventArgs e)
        {
            FormSlideEffect.Slide(this, FormSlideEffect.Slides.Up);
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtAccountID_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            db.sp_client_view(txtTransacID.Text, cmbAccount.Text.ToUpper(),
                                  frmLogin.Username,
                                  decimal.Parse(lblBalance.Text),
                                  DateTime.Now.Date);

            MessageBox.Show("Successfully Inquire", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmTransaction.GenTransacID(txtTransacID);
            cmbAccount.Text = "";
        }

        private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

            db = new DCbankDataContext();
            var Query_Client = db.sp_view_client(cmbAccount.Text);
            foreach (sp_view_clientResult entry in Query_Client)
            {
                lblBalance.Text = entry.CurrentBalance.Value.ToString();
                lblname.Text = entry.lname.ToString() + ", " + entry.fname.ToString();
            }

        }

        private void cmbAccount_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            var Query_Client = db.sp_view_client(cmbAccount.Text);
            foreach (sp_view_clientResult entry in Query_Client)
            {
                lblBalance.Text = entry.CurrentBalance.Value.ToString();
                lblname.Text = entry.lname.ToString() + ", " + entry.fname.ToString();
            }
        }

        private void frmInquire_Load(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            var Query_View = db.sp_ViewAccountID();
            foreach (sp_ViewAccountIDResult entry in Query_View)
            {
                string ID = entry.CAccountID.ToString();
                cmbAccount.Items.Add(ID);
            }
        }
    }
}
