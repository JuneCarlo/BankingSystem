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
    public partial class frmTransaction : Form
    {
        public frmTransaction()
        {
            InitializeComponent();
        }
        static DCbankDataContext db = null;
        private void frmTransaction_Load(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            dataGridView1.DataSource = db.sp_view_transactions();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormSlideEffect.Slide(this, FormSlideEffect.Slides.Up);
            this.Close();
        }

        private void txtsearchC_TextChanged(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            dataGridView1.DataSource = db.sp_searchT(txtsearch.Text);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public static string GenTransacID(TextBox TransacID)
        {
            int iiCount = 0;
            string ID = "";
            db = new DCbankDataContext();
            var query = db.sp_GetTransacIDCount();
            foreach (sp_GetTransacIDCountResult count in query)
            {
                iiCount = count.Count1.Value;
            }
            iiCount++;
            if (iiCount.ToString().Length.Equals(1))
            {
                ID = "T-" + iiCount.ToString().PadLeft(4, '0').ToString() + "-" + DateTime.Now.Year.ToString().Substring(2, 2);
            }
            else if (iiCount.ToString().Length.Equals(2))
            {
                ID = "T-" + iiCount.ToString().PadLeft(3, '0').ToString() + "-" + DateTime.Now.Year.ToString().Substring(2, 2);
            }
            else
            {
                ID = "T-" + iiCount.ToString().PadLeft(2, '0').ToString() + "-" + DateTime.Now.Year.ToString().Substring(2, 2);

            }
            return TransacID.Text = ID;
        }
    }
}
