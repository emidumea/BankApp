namespace BankApp
{
    partial class UserDashboardForm
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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.detailsBtn = new System.Windows.Forms.Button();
            this.transactionBtn = new System.Windows.Forms.Button();
            this.historyBtn = new System.Windows.Forms.Button();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(341, 54);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(61, 16);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Bun venit";
            // 
            // detailsBtn
            // 
            this.detailsBtn.Location = new System.Drawing.Point(327, 134);
            this.detailsBtn.Name = "detailsBtn";
            this.detailsBtn.Size = new System.Drawing.Size(75, 23);
            this.detailsBtn.TabIndex = 1;
            this.detailsBtn.Text = "Detalii Cont";
            this.detailsBtn.UseVisualStyleBackColor = true;
            this.detailsBtn.Click += new System.EventHandler(this.detailsBtn_Click);
            // 
            // transactionBtn
            // 
            this.transactionBtn.Location = new System.Drawing.Point(297, 224);
            this.transactionBtn.Name = "transactionBtn";
            this.transactionBtn.Size = new System.Drawing.Size(130, 23);
            this.transactionBtn.TabIndex = 2;
            this.transactionBtn.Text = "Tranzactie noua";
            this.transactionBtn.UseVisualStyleBackColor = true;
            this.transactionBtn.Click += new System.EventHandler(this.transactionBtn_Click);
            // 
            // historyBtn
            // 
            this.historyBtn.Location = new System.Drawing.Point(344, 253);
            this.historyBtn.Name = "historyBtn";
            this.historyBtn.Size = new System.Drawing.Size(75, 23);
            this.historyBtn.TabIndex = 3;
            this.historyBtn.Text = "Istoric Tranzactii";
            this.historyBtn.UseVisualStyleBackColor = true;
            this.historyBtn.Click += new System.EventHandler(this.historyBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(327, 163);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(75, 23);
            this.settingsBtn.TabIndex = 4;
            this.settingsBtn.Text = "Setari";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.Location = new System.Drawing.Point(312, 195);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(115, 23);
            this.disconnectBtn.TabIndex = 5;
            this.disconnectBtn.Text = "Deconectare";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.detailsBtn);
            this.mainPanel.Controls.Add(this.disconnectBtn);
            this.mainPanel.Controls.Add(this.welcomeLabel);
            this.mainPanel.Controls.Add(this.settingsBtn);
            this.mainPanel.Controls.Add(this.transactionBtn);
            this.mainPanel.Controls.Add(this.historyBtn);
            this.mainPanel.Location = new System.Drawing.Point(1, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 446);
            this.mainPanel.TabIndex = 6;
            // 
            // UserDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "UserDashboardForm";
            this.Text = "UserDashboardForm";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button detailsBtn;
        private System.Windows.Forms.Button transactionBtn;
        private System.Windows.Forms.Button historyBtn;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.Panel mainPanel;
    }
}