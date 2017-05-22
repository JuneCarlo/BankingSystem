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
    public partial class frmAddClient : Form
    {
        public frmAddClient()
        {
            InitializeComponent();
            ClientID();
        }
        static DCbankDataContext db = null;
        private void btnClient_Click(object sender, EventArgs e)
        {

            db = new DCbankDataContext();
            if (txtfname.Text.Equals("") || txtlname.Text.Equals(""))
            {
                lblstatus.Text = "Fill up Everything";
            }
            else
            {
                db.sp_insert_client(txtAccID.Text, txtfname.Text, txtlname.Text);
                DialogResult result = MessageBox.Show("Back to Main Menu?", "Successfully Add Client", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    ClientID();
                    txtfname.Clear();
                    txtlname.Clear();
                }
            }
        }

        private void frmAddClient_Load(object sender, EventArgs e)
        {
            
        }
        string ClientID()
        {
            int iCount = 0;
            string ID;
            db = new DCbankDataContext();
            var Query_ID = db.sp_GetClientIDCount();
            foreach (sp_GetClientIDCountResult count in Query_ID)
            {
                iCount = count.Count.Value;
            }
            iCount++;
            if (iCount.ToString().Length.Equals(1))
            {
                ID = "AC-" + iCount.ToString().PadLeft(4, '0').ToString() + "-" + DateTime.Now.Year.ToString().Substring(2, 2);
            }
            else if (iCount.ToString().Length.Equals(2))
            {
                ID = "AC-" + iCount.ToString().PadLeft(3, '0').ToString() + "-" + DateTime.Now.Year.ToString().Substring(2, 2);
            }
            else
            {
                ID = "AC-" + iCount.ToString().PadLeft(2, '0').ToString() + "-" + DateTime.Now.Year.ToString().Substring(2, 2);
            }
            return txtAccID.Text = ID;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
