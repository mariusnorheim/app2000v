namespace HMS
{
    partial class NewGuestForm
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
            this.buttonNewGuestCancel = new System.Windows.Forms.Button();
            this.buttonNewGuestConfirm = new System.Windows.Forms.Button();
            this.textBoxRoomAmount = new System.Windows.Forms.TextBox();
            this.listBoxGender = new System.Windows.Forms.ListBox();
            this.textBoxGuestName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonNewGuestCancel
            // 
            this.buttonNewGuestCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.buttonNewGuestCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonNewGuestCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGuestCancel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewGuestCancel.Location = new System.Drawing.Point(270, 233);
            this.buttonNewGuestCancel.Name = "buttonNewGuestCancel";
            this.buttonNewGuestCancel.Size = new System.Drawing.Size(60, 28);
            this.buttonNewGuestCancel.TabIndex = 47;
            this.buttonNewGuestCancel.Text = "Avbryt";
            this.buttonNewGuestCancel.UseVisualStyleBackColor = false;
            this.buttonNewGuestCancel.Click += new System.EventHandler(this.buttonNewGuestCancel_Click);
            // 
            // buttonNewGuestConfirm
            // 
            this.buttonNewGuestConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.buttonNewGuestConfirm.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonNewGuestConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGuestConfirm.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewGuestConfirm.Location = new System.Drawing.Point(190, 233);
            this.buttonNewGuestConfirm.Name = "buttonNewGuestConfirm";
            this.buttonNewGuestConfirm.Size = new System.Drawing.Size(75, 28);
            this.buttonNewGuestConfirm.TabIndex = 46;
            this.buttonNewGuestConfirm.Text = "Registrer";
            this.buttonNewGuestConfirm.UseVisualStyleBackColor = false;
            this.buttonNewGuestConfirm.Click += new System.EventHandler(this.buttonNewGuestConfirm_Click);
            // 
            // textBoxRoomAmount
            // 
            this.textBoxRoomAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRoomAmount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRoomAmount.Location = new System.Drawing.Point(190, 88);
            this.textBoxRoomAmount.MaxLength = 100;
            this.textBoxRoomAmount.Multiline = true;
            this.textBoxRoomAmount.Name = "textBoxRoomAmount";
            this.textBoxRoomAmount.Size = new System.Drawing.Size(215, 48);
            this.textBoxRoomAmount.TabIndex = 41;
            // 
            // listBoxGender
            // 
            this.listBoxGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxGender.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxGender.FormattingEnabled = true;
            this.listBoxGender.ItemHeight = 16;
            this.listBoxGender.Items.AddRange(new object[] {
            "M",
            "F"});
            this.listBoxGender.Location = new System.Drawing.Point(190, 50);
            this.listBoxGender.Name = "listBoxGender";
            this.listBoxGender.Size = new System.Drawing.Size(215, 34);
            this.listBoxGender.TabIndex = 39;
            // 
            // textBoxGuestName
            // 
            this.textBoxGuestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGuestName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGuestName.Location = new System.Drawing.Point(190, 23);
            this.textBoxGuestName.Name = "textBoxGuestName";
            this.textBoxGuestName.Size = new System.Drawing.Size(215, 23);
            this.textBoxGuestName.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Postkode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Adresse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Kjønn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Navn";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(190, 144);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 23);
            this.textBox1.TabIndex = 48;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(190, 174);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(215, 23);
            this.textBox2.TabIndex = 49;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(190, 204);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(215, 23);
            this.textBox3.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(75, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 51;
            this.label6.Text = "Telefon";
            // 
            // NewGuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonNewGuestCancel);
            this.Controls.Add(this.buttonNewGuestConfirm);
            this.Controls.Add(this.textBoxRoomAmount);
            this.Controls.Add(this.listBoxGender);
            this.Controls.Add(this.textBoxGuestName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NewGuestForm";
            this.Text = "Hotel Management System - Ny gjest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNewGuestCancel;
        private System.Windows.Forms.Button buttonNewGuestConfirm;
        private System.Windows.Forms.TextBox textBoxRoomAmount;
        private System.Windows.Forms.ListBox listBoxGender;
        private System.Windows.Forms.TextBox textBoxGuestName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
    }
}
