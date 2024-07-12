namespace Employee_Management_System
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.manageEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUser = new System.Windows.Forms.ToolStripMenuItem();
            this.logOut = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1095, 587);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Navy;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEmployee,
            this.manageEmployee,
            this.manageUser,
            this.logOut});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1095, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addEmployee
            // 
            this.addEmployee.BackColor = System.Drawing.Color.Navy;
            this.addEmployee.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEmployee.ForeColor = System.Drawing.Color.White;
            this.addEmployee.Name = "addEmployee";
            this.addEmployee.Size = new System.Drawing.Size(196, 31);
            this.addEmployee.Text = "Add Employee";
            this.addEmployee.Click += new System.EventHandler(this.addEmployee_Click);
            // 
            // manageEmployee
            // 
            this.manageEmployee.BackColor = System.Drawing.Color.Navy;
            this.manageEmployee.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageEmployee.ForeColor = System.Drawing.Color.White;
            this.manageEmployee.Name = "manageEmployee";
            this.manageEmployee.Size = new System.Drawing.Size(243, 31);
            this.manageEmployee.Text = "Manage Employee";
            this.manageEmployee.Click += new System.EventHandler(this.manageEmployee_Click);
            // 
            // manageUser
            // 
            this.manageUser.BackColor = System.Drawing.Color.Navy;
            this.manageUser.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageUser.ForeColor = System.Drawing.Color.White;
            this.manageUser.Name = "manageUser";
            this.manageUser.Size = new System.Drawing.Size(182, 31);
            this.manageUser.Text = "Manage User";
            this.manageUser.Click += new System.EventHandler(this.manageUser_Click);
            // 
            // logOut
            // 
            this.logOut.BackColor = System.Drawing.Color.Navy;
            this.logOut.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOut.ForeColor = System.Drawing.Color.White;
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(110, 31);
            this.logOut.Text = "Logout";
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Georgia", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(267, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Employee Management System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(315, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(467, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "WELCOME TO DASHBOARD";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 622);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addEmployee;
        private System.Windows.Forms.ToolStripMenuItem manageEmployee;
        private System.Windows.Forms.ToolStripMenuItem manageUser;
        private System.Windows.Forms.ToolStripMenuItem logOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}