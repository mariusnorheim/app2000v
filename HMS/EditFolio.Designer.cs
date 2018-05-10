namespace HMS
{
    partial class EditFolio
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
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEditFolioConfirm = new System.Windows.Forms.Button();
            this.buttonEditFolioCancel = new System.Windows.Forms.Button();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.listBoxFolioItem = new System.Windows.Forms.ListBox();
            this.listBoxBillingItem = new System.Windows.Forms.ListBox();
            this.listBoxGuest = new System.Windows.Forms.ListBox();
            this.buttonSearchGuest = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonRemoveItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoveItem.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveItem.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveItem.Location = new System.Drawing.Point(522, 300);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(100, 26);
            this.buttonRemoveItem.TabIndex = 78;
            this.buttonRemoveItem.Text = "Remove item";
            this.buttonRemoveItem.UseVisualStyleBackColor = false;
            this.buttonRemoveItem.Click += new System.EventHandler(this.buttonRemoveItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 14);
            this.label1.TabIndex = 77;
            this.label1.Text = "Folio items";
            // 
            // buttonEditFolioConfirm
            // 
            this.buttonEditFolioConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonEditFolioConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditFolioConfirm.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonEditFolioConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditFolioConfirm.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditFolioConfirm.Location = new System.Drawing.Point(255, 325);
            this.buttonEditFolioConfirm.Name = "buttonEditFolioConfirm";
            this.buttonEditFolioConfirm.Size = new System.Drawing.Size(60, 28);
            this.buttonEditFolioConfirm.TabIndex = 76;
            this.buttonEditFolioConfirm.Text = "Save";
            this.buttonEditFolioConfirm.UseVisualStyleBackColor = false;
            this.buttonEditFolioConfirm.Click += new System.EventHandler(this.buttonEditFolioConfirm_Click);
            // 
            // buttonEditFolioCancel
            // 
            this.buttonEditFolioCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonEditFolioCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditFolioCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonEditFolioCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditFolioCancel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditFolioCancel.Location = new System.Drawing.Point(320, 325);
            this.buttonEditFolioCancel.Name = "buttonEditFolioCancel";
            this.buttonEditFolioCancel.Size = new System.Drawing.Size(60, 28);
            this.buttonEditFolioCancel.TabIndex = 75;
            this.buttonEditFolioCancel.Text = "Cancel";
            this.buttonEditFolioCancel.UseVisualStyleBackColor = false;
            this.buttonEditFolioCancel.Click += new System.EventHandler(this.buttonEditFolioCancel_Click);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddItem.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddItem.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddItem.Location = new System.Drawing.Point(522, 130);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(100, 26);
            this.buttonAddItem.TabIndex = 74;
            this.buttonAddItem.Text = "Add item";
            this.buttonAddItem.UseVisualStyleBackColor = false;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // listBoxFolioItem
            // 
            this.listBoxFolioItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxFolioItem.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.listBoxFolioItem.FormattingEnabled = true;
            this.listBoxFolioItem.ItemHeight = 16;
            this.listBoxFolioItem.Location = new System.Drawing.Point(12, 183);
            this.listBoxFolioItem.Name = "listBoxFolioItem";
            this.listBoxFolioItem.Size = new System.Drawing.Size(610, 114);
            this.listBoxFolioItem.TabIndex = 73;
            // 
            // listBoxBillingItem
            // 
            this.listBoxBillingItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxBillingItem.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.listBoxBillingItem.FormattingEnabled = true;
            this.listBoxBillingItem.ItemHeight = 16;
            this.listBoxBillingItem.Location = new System.Drawing.Point(322, 12);
            this.listBoxBillingItem.Name = "listBoxBillingItem";
            this.listBoxBillingItem.Size = new System.Drawing.Size(300, 114);
            this.listBoxBillingItem.TabIndex = 72;
            // 
            // listBoxGuest
            // 
            this.listBoxGuest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxGuest.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.listBoxGuest.FormattingEnabled = true;
            this.listBoxGuest.ItemHeight = 16;
            this.listBoxGuest.Location = new System.Drawing.Point(12, 12);
            this.listBoxGuest.Name = "listBoxGuest";
            this.listBoxGuest.Size = new System.Drawing.Size(300, 114);
            this.listBoxGuest.TabIndex = 70;
            // 
            // buttonSearchGuest
            // 
            this.buttonSearchGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonSearchGuest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearchGuest.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonSearchGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchGuest.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchGuest.Location = new System.Drawing.Point(253, 130);
            this.buttonSearchGuest.Name = "buttonSearchGuest";
            this.buttonSearchGuest.Size = new System.Drawing.Size(60, 26);
            this.buttonSearchGuest.TabIndex = 69;
            this.buttonSearchGuest.Text = "Search";
            this.buttonSearchGuest.UseVisualStyleBackColor = false;
            this.buttonSearchGuest.Click += new System.EventHandler(this.buttonSearchGuest_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.ForeColor = System.Drawing.Color.White;
            this.textBoxSearch.Location = new System.Drawing.Point(12, 130);
            this.textBoxSearch.MaxLength = 80;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(240, 26);
            this.textBoxSearch.TabIndex = 71;
            // 
            // EditFolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.buttonRemoveItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEditFolioConfirm);
            this.Controls.Add(this.buttonEditFolioCancel);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.listBoxFolioItem);
            this.Controls.Add(this.listBoxBillingItem);
            this.Controls.Add(this.listBoxGuest);
            this.Controls.Add(this.buttonSearchGuest);
            this.Controls.Add(this.textBoxSearch);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "EditFolio";
            this.Text = "Edit folio";
            this.Load += new System.EventHandler(this.EditFolio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEditFolioConfirm;
        private System.Windows.Forms.Button buttonEditFolioCancel;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.ListBox listBoxFolioItem;
        private System.Windows.Forms.ListBox listBoxBillingItem;
        private System.Windows.Forms.ListBox listBoxGuest;
        private System.Windows.Forms.Button buttonSearchGuest;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}
