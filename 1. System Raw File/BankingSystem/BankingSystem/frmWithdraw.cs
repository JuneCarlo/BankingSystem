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
    public partial class frmWithdraw : Form
    {
        public frmWithdraw()
        {
            InitializeComponent();
            frmTransaction.GenTransacID(txtTransacID);
            
        }
        static DCbankDataContext db = null;
        int min = 100;
        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormSlideEffect.Slide(this, FormSlideEffect.Slides.Up);
            this.Close();
        }

        private void txtAccountID_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            if (cmbAccount.Text.Equals("") || txtAmount.Text.Equals(""))
            {
                lblAction.Text = "Fill up Everything";
            }
            else
            {
                if(decimal.Parse(txtAmount.Text) >= min)
                {
                     if (decimal.Parse(txtAmount.Text) <= decimal.Parse(lblBalance.Text))
                     {
                         db = new DCbankDataContext();
                         db.sp_client_withdraw(txtTransacID.Text,
                                              cmbAccount.Text.ToUpper(),
                                              frmLogin.Username,
                                              decimal.Parse(txtAmount.Text),
                                              decimal.Parse(lblBalance.Text) - decimal.Parse(txtAmount.Text),
                                              DateTime.Now.Date);

                         MessageBox.Show("Successfully Deposit", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);

                         frmTransaction.GenTransacID(txtTransacID);
                         cmbAccount.Text = "";
                         txtAmount.Clear();

                         var Query_Client = db.sp_view_client(cmbAccount.Text);
                         foreach (sp_view_clientResult entry in Query_Client)
                         {
                             lblBalance.Text = entry.CurrentBalance.ToString();
                         }
                         lblAction.Visible = false;
                     }
                     else
                     {
                         lblAction.Text = "Insufficient funds.";
                     }

                }
                else
                {
                    lblAction.Text = "Minimum Amount to Withdraw Is 100 Pesos";
                    txtAmount.Clear();
                }
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(txtAmount.Text);
            }
            catch (Exception)
            {
                txtAmount.Clear();
                lblAction.Text = "Numbers Only";
                lblAction.Visible = true;
            }
        }

        private void frmWithdraw_Load(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            var Query_View = db.sp_ViewAccountID();
            foreach(sp_ViewAccountIDResult entry in Query_View)
            {
                string ID = entry.CAccountID.ToString();
                cmbAccount.Items.Add(ID);
            }
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
    
    }
}
