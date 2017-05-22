namespace BankingSystem
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usernameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tellerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.depositToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.withdrawToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inquireBalanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterFileToolStripMenuItem1,
            this.transactionsToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1023, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // masterFileToolStripMenuItem1
            // 
            this.masterFileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usernameToolStripMenuItem,
            this.registerToolStripMenuItem1,
            this.manageUsersToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.masterFileToolStripMenuItem1.Name = "masterFileToolStripMenuItem1";
            this.masterFileToolStripMenuItem1.Size = new System.Drawing.Size(69, 21);
            this.masterFileToolStripMenuItem1.Text = "ACTION";
            // 
            // usernameToolStripMenuItem
            // 
            this.usernameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem});
            this.usernameToolStripMenuItem.Image = global::BankingSystem.Properties.Resources.user;
            this.usernameToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usernameToolStripMenuItem.Name = "usernameToolStripMenuItem";
            this.usernameToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.usernameToolStripMenuItem.Text = "User";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.changePasswordToolStripMenuItem.Text = "Change password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem1
            // 
            this.registerToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tellerToolStripMenuItem1,
            this.clientToolStripMenuItem1});
            this.registerToolStripMenuItem1.Name = "registerToolStripMenuItem1";
            this.registerToolStripMenuItem1.Size = new System.Drawing.Size(257, 22);
            this.registerToolStripMenuItem1.Text = "Register";
            // 
            // tellerToolStripMenuItem1
            // 
            this.tellerToolStripMenuItem1.Name = "tellerToolStripMenuItem1";
            this.tellerToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.tellerToolStripMenuItem1.Text = "Add Admin";
            this.tellerToolStripMenuItem1.Click += new System.EventHandler(this.tellerToolStripMenuItem1_Click);
            // 
            // clientToolStripMenuItem1
            // 
            this.clientToolStripMenuItem1.Name = "clientToolStripMenuItem1";
            this.clientToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.clientToolStripMenuItem1.Text = "Client";
            this.clientToolStripMenuItem1.Click += new System.EventHandler(this.clientToolStripMenuItem1_Click);
            // 
            // manageUsersToolStripMenuItem
            // 
            this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.manageUsersToolStripMenuItem.Text = "View Administrator\'s Accont";
            this.manageUsersToolStripMenuItem.Click += new System.EventHandler(this.manageUsersToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(257, 22);
            this.exitToolStripMenuItem1.Text = "Exit/Log Out";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // transactionsToolStripMenuItem1
            // 
            this.transactionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.depositToolStripMenuItem1,
            this.withdrawToolStripMenuItem1,
            this.inquireBalanceToolStripMenuItem,
            this.viewAllTransactionsToolStripMenuItem});
            this.transactionsToolStripMenuItem1.Name = "transactionsToolStripMenuItem1";
            this.transactionsToolStripMenuItem1.Size = new System.Drawing.Size(107, 21);
            this.transactionsToolStripMenuItem1.Text = "TRANSACTION";
            // 
            // depositToolStripMenuItem1
            // 
            this.depositToolStripMenuItem1.Name = "depositToolStripMenuItem1";
            this.depositToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
            this.depositToolStripMenuItem1.Text = "Deposit";
            this.depositToolStripMenuItem1.Click += new System.EventHandler(this.depositToolStripMenuItem1_Click);
            // 
            // withdrawToolStripMenuItem1
            // 
            this.withdrawToolStripMenuItem1.Name = "withdrawToolStripMenuItem1";
            this.withdrawToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
            this.withdrawToolStripMenuItem1.Text = "Withdraw";
            this.withdrawToolStripMenuItem1.Click += new System.EventHandler(this.withdrawToolStripMenuItem1_Click);
            // 
            // inquireBalanceToolStripMenuItem
            // 
            this.inquireBalanceToolStripMenuItem.Name = "inquireBalanceToolStripMenuItem";
            this.inquireBalanceToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.inquireBalanceToolStripMenuItem.Text = "Inquire Balance";
            this.inquireBalanceToolStripMenuItem.Click += new System.EventHandler(this.inquireBalanceToolStripMenuItem_Click);
            // 
            // viewAllTransactionsToolStripMenuItem
            // 
            this.viewAllTransactionsToolStripMenuItem.Name = "viewAllTransactionsToolStripMenuItem";
            this.viewAllTransactionsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.viewAllTransactionsToolStripMenuItem.Text = "View all Transactions";
            this.viewAllTransactionsToolStripMenuItem.Click += new System.EventHandler(this.viewAllTransactionsToolStripMenuItem_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BankingSystem.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(259, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(513, 600);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1023, 667);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterFileToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem usernameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tellerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem depositToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem withdrawToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inquireBalanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllTransactionsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}