namespace HMS
{
    partial class EditFloorplanRoom
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
            this.buttonNewRoomConfirm = new System.Windows.Forms.Button();
            this.buttonNewRoomCancel = new System.Windows.Forms.Button();
            this.comboBoxRoomType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRoomid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonNewRoomConfirm
            // 
            this.buttonNewRoomConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonNewRoomConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewRoomConfirm.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonNewRoomConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewRoomConfirm.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewRoomConfirm.Location = new System.Drawing.Point(140, 70);
            this.buttonNewRoomConfirm.Name = "buttonNewRoomConfirm";
            this.buttonNewRoomConfirm.Size = new System.Drawing.Size(60, 28);
            this.buttonNewRoomConfirm.TabIndex = 73;
            this.buttonNewRoomConfirm.Text = "Save";
            this.buttonNewRoomConfirm.UseVisualStyleBackColor = false;
            this.buttonNewRoomConfirm.Click += new System.EventHandler(this.buttonNewRoomConfirm_Click);
            // 
            // buttonNewRoomCancel
            // 
            this.buttonNewRoomCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonNewRoomCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewRoomCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonNewRoomCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewRoomCancel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewRoomCancel.Location = new System.Drawing.Point(205, 70);
            this.buttonNewRoomCancel.Name = "buttonNewRoomCancel";
            this.buttonNewRoomCancel.Size = new System.Drawing.Size(60, 28);
            this.buttonNewRoomCancel.TabIndex = 72;
            this.buttonNewRoomCancel.Text = "Cancel";
            this.buttonNewRoomCancel.UseVisualStyleBackColor = false;
            this.buttonNewRoomCancel.Click += new System.EventHandler(this.buttonNewRoomCancel_Click);
            // 
            // comboBoxRoomType
            // 
            this.comboBoxRoomType.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.comboBoxRoomType.FormattingEnabled = true;
            this.comboBoxRoomType.Location = new System.Drawing.Point(140, 40);
            this.comboBoxRoomType.Name = "comboBoxRoomType";
            this.comboBoxRoomType.Size = new System.Drawing.Size(225, 24);
            this.comboBoxRoomType.TabIndex = 71;
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
            // textBoxRoomid
            // 
            this.textBoxRoomid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxRoomid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRoomid.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.textBoxRoomid.Location = new System.Drawing.Point(140, 11);
            this.textBoxRoomid.MaxLength = 40;
            this.textBoxRoomid.Name = "textBoxRoomid";
            this.textBoxRoomid.ReadOnly = true;
            this.textBoxRoomid.Size = new System.Drawing.Size(225, 23);
            this.textBoxRoomid.TabIndex = 69;
            this.textBoxRoomid.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 68;
            this.label1.Text = "Number";
            // 
            // EditFloorplanRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(434, 111);
            this.Controls.Add(this.buttonNewRoomConfirm);
            this.Controls.Add(this.buttonNewRoomCancel);
            this.Controls.Add(this.comboBoxRoomType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRoomid);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "EditFloorplanRoom";
            this.Text = "Edit room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNewRoomConfirm;
        private System.Windows.Forms.Button buttonNewRoomCancel;
        private System.Windows.Forms.ComboBox comboBoxRoomType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRoomid;
        private System.Windows.Forms.Label label1;
    }
}
