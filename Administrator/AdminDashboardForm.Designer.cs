namespace BankApp.Administrator
{
    partial class AdminDashboardForm
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
            this.lblAdminWelcome = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnViewTransactions = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAdminWelcome
            // 
            this.lblAdminWelcome.AutoSize = true;
            this.lblAdminWelcome.Location = new System.Drawing.Point(212, 78);
            this.lblAdminWelcome.Name = "lblAdminWelcome";
            this.lblAdminWelcome.Size = new System.Drawing.Size(148, 16);
            this.lblAdminWelcome.TabIndex = 0;
            this.lblAdminWelcome.Text = "Bun venit, Administrator!";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(215, 115);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(145, 23);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Adauga utilizator";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Location = new System.Drawing.Point(215, 159);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(145, 23);
            this.btnSearchUser.TabIndex = 2;
            this.btnSearchUser.Text = "Cauta utilizator";
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(215, 199);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(145, 23);
            this.btnResetPassword.TabIndex = 3;
            this.btnResetPassword.Text = "Reseteaza Parola";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnViewTransactions
            // 
            this.btnViewTransactions.Location = new System.Drawing.Point(215, 242);
            this.btnViewTransactions.Name = "btnViewTransactions";
            this.btnViewTransactions.Size = new System.Drawing.Size(145, 23);
            this.btnViewTransactions.TabIndex = 4;
            this.btnViewTransactions.Text = "Tranzactii sistem";
            this.btnViewTransactions.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(215, 288);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(145, 23);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Deconectare";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewTransactions);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.btnSearchUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.lblAdminWelcome);
            this.Name = "AdminDashboardForm";
            this.Text = "AdminDashboardForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAdminWelcome;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnViewTransactions;
        private System.Windows.Forms.Button btnLogout;
    }
}