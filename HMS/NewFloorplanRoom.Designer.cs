namespace HMS
{
    partial class NewFloorplanRoom
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRoomid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRoomType = new System.Windows.Forms.ComboBox();
            this.buttonNewGuestConfirm = new System.Windows.Forms.Button();
            this.buttonNewGuestCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 58;
            this.label2.Text = "Type";
            // 
            // textBoxRoomid
            // 
            this.textBoxRoomid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRoomid.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.textBoxRoomid.Location = new System.Drawing.Point(140, 11);
            this.textBoxRoomid.MaxLength = 40;
            this.textBoxRoomid.Name = "textBoxRoomid";
            this.textBoxRoomid.Size = new System.Drawing.Size(225, 23);
            this.textBoxRoomid.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "Number";
            // 
            // comboBoxRoomType
            // 
            this.comboBoxRoomType.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.comboBoxRoomType.FormattingEnabled = true;
            this.comboBoxRoomType.Location = new System.Drawing.Point(140, 40);
            this.comboBoxRoomType.Name = "comboBoxRoomType";
            this.comboBoxRoomType.Size = new System.Drawing.Size(225, 24);
            this.comboBoxRoomType.TabIndex = 59;
            // 
            // buttonNewGuestConfirm
            // 
            this.buttonNewGuestConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonNewGuestConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewGuestConfirm.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonNewGuestConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGuestConfirm.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewGuestConfirm.Location = new System.Drawing.Point(140, 70);
            this.buttonNewGuestConfirm.Name = "buttonNewGuestConfirm";
            this.buttonNewGuestConfirm.Size = new System.Drawing.Size(60, 28);
            this.buttonNewGuestConfirm.TabIndex = 67;
            this.buttonNewGuestConfirm.Text = "Save";
            this.buttonNewGuestConfirm.UseVisualStyleBackColor = false;
            this.buttonNewGuestConfirm.Click += new System.EventHandler(this.buttonNewGuestConfirm_Click);
            // 
            // buttonNewGuestCancel
            // 
            this.buttonNewGuestCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonNewGuestCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewGuestCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonNewGuestCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGuestCancel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewGuestCancel.Location = new System.Drawing.Point(205, 70);
            this.buttonNewGuestCancel.Name = "buttonNewGuestCancel";
            this.buttonNewGuestCancel.Size = new System.Drawing.Size(60, 28);
            this.buttonNewGuestCancel.TabIndex = 66;
            this.buttonNewGuestCancel.Text = "Cancel";
            this.buttonNewGuestCancel.UseVisualStyleBackColor = false;
            this.buttonNewGuestCancel.Click += new System.EventHandler(this.buttonNewGuestCancel_Click);
            // 
            // NewFloorplanRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(434, 111);
            this.Controls.Add(this.buttonNewGuestConfirm);
            this.Controls.Add(this.buttonNewGuestCancel);
            this.Controls.Add(this.comboBoxRoomType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRoomid);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NewFloorplanRoom";
            this.Text = "New room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRoomid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRoomType;
        private System.Windows.Forms.Button buttonNewGuestConfirm;
        private System.Windows.Forms.Button buttonNewGuestCancel;
    }
}
