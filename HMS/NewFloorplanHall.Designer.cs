namespace HMS
{
    partial class NewFloorplanHall
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
            if(disposing && (components != null))
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
            this.buttonNewHallConfirm = new System.Windows.Forms.Button();
            this.buttonNewHallCancel = new System.Windows.Forms.Button();
            this.comboBoxHallType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHallname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonNewHallConfirm
            // 
            this.buttonNewHallConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonNewHallConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewHallConfirm.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonNewHallConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewHallConfirm.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewHallConfirm.Location = new System.Drawing.Point(140, 70);
            this.buttonNewHallConfirm.Name = "buttonNewHallConfirm";
            this.buttonNewHallConfirm.Size = new System.Drawing.Size(60, 28);
            this.buttonNewHallConfirm.TabIndex = 73;
            this.buttonNewHallConfirm.Text = "Save";
            this.buttonNewHallConfirm.UseVisualStyleBackColor = false;
            this.buttonNewHallConfirm.Click += new System.EventHandler(this.buttonNewHallConfirm_Click);
            // 
            // buttonNewHallCancel
            // 
            this.buttonNewHallCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonNewHallCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewHallCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonNewHallCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewHallCancel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewHallCancel.Location = new System.Drawing.Point(205, 70);
            this.buttonNewHallCancel.Name = "buttonNewHallCancel";
            this.buttonNewHallCancel.Size = new System.Drawing.Size(60, 28);
            this.buttonNewHallCancel.TabIndex = 72;
            this.buttonNewHallCancel.Text = "Cancel";
            this.buttonNewHallCancel.UseVisualStyleBackColor = false;
            this.buttonNewHallCancel.Click += new System.EventHandler(this.buttonNewHallCancel_Click);
            // 
            // comboBoxHallType
            // 
            this.comboBoxHallType.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.comboBoxHallType.FormattingEnabled = true;
            this.comboBoxHallType.Location = new System.Drawing.Point(140, 40);
            this.comboBoxHallType.Name = "comboBoxHallType";
            this.comboBoxHallType.Size = new System.Drawing.Size(225, 24);
            this.comboBoxHallType.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 70;
            this.label2.Text = "Type";
            // 
            // textBoxHallname
            // 
            this.textBoxHallname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxHallname.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.textBoxHallname.Location = new System.Drawing.Point(140, 11);
            this.textBoxHallname.MaxLength = 40;
            this.textBoxHallname.Name = "textBoxHallname";
            this.textBoxHallname.Size = new System.Drawing.Size(225, 23);
            this.textBoxHallname.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 68;
            this.label1.Text = "Name";
            // 
            // NewFloorplanHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(434, 111);
            this.Controls.Add(this.buttonNewHallConfirm);
            this.Controls.Add(this.buttonNewHallCancel);
            this.Controls.Add(this.comboBoxHallType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxHallname);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NewFloorplanHall";
            this.Text = "New hall";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNewHallConfirm;
        private System.Windows.Forms.Button buttonNewHallCancel;
        private System.Windows.Forms.ComboBox comboBoxHallType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHallname;
        private System.Windows.Forms.Label label1;
    }
}
