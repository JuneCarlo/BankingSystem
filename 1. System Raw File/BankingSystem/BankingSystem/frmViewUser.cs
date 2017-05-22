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
    public partial class frmViewUser : Form
    {
        public frmViewUser()
        {
            InitializeComponent();
        }
        string User, Active;
        static DCbankDataContext db = null;

        private void frmViewUser_Load(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            dataGridView1.DataSource = db.sp_view_teller();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            db.sp_Update_isactive(User,"ACTIVE");
            MessageBox.Show("Successfuly Update");
            dataGridView1.DataSource = db.sp_view_teller();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            User = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Active = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db = new DCbankDataContext();
            db.sp_Update_isNotActive(User, "NOT ACTIVE");
            MessageBox.Show("Successfuly Update");
            dataGridView1.DataSource = db.sp_view_teller();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FormSlideEffect.Slide(this, FormSlideEffect.Slides.Up);
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
