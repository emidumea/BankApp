namespace BankApp
{
    partial class TransactionHistoryForm
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
            this.lvTransactions = new System.Windows.Forms.ListView();
            this.colFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBack = new System.Windows.Forms.Button();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lvTransactions
            // 
            this.lvTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFrom,
            this.colTo,
            this.colAmount,
            this.colDate});
            this.lvTransactions.FullRowSelect = true;
            this.lvTransactions.GridLines = true;
            this.lvTransactions.HideSelection = false;
            this.lvTransactions.Location = new System.Drawing.Point(0, 161);
            this.lvTransactions.Name = "lvTransactions";
            this.lvTransactions.Size = new System.Drawing.Size(799, 191);
            this.lvTransactions.TabIndex = 0;
            this.lvTransactions.UseCompatibleStateImageBehavior = false;
            this.lvTransactions.View = System.Windows.Forms.View.Details;
            // 
            // colFrom
            // 
            this.colFrom.Text = "From";
            this.colFrom.Width = 200;
            // 
            // colTo
            // 
            this.colTo.Text = "To";
            this.colTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTo.Width = 200;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colAmount.Width = 80;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDate.Width = 120;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(30, 378);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Inapoi";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "Toate",
            "Trimise",
            "Primite"});
            this.cmbFilter.Location = new System.Drawing.Point(30, 65);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(121, 24);
            this.cmbFilter.TabIndex = 2;
            // 
            // TransactionHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lvTransactions);
            this.Name = "TransactionHistoryForm";
            this.Text = "TransactionHistoryForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvTransactions;
        private System.Windows.Forms.ColumnHeader colFrom;
        private System.Windows.Forms.ColumnHeader colTo;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cmbFilter;
    }
}