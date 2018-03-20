namespace HMS
{
    partial class EditBookingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxGuestName = new System.Windows.Forms.TextBox();
            this.listBoxGuest = new System.Windows.Forms.ListBox();
            this.listBoxRoomType = new System.Windows.Forms.ListBox();
            this.textBoxRoomAmount = new System.Windows.Forms.TextBox();
            this.datePickerArrival = new System.Windows.Forms.DateTimePicker();
            this.datePickerDeparture = new System.Windows.Forms.DateTimePicker();
            this.textBoxRemark = new System.Windows.Forms.TextBox();
            this.buttonSearchBookingGuest = new System.Windows.Forms.Button();
            this.buttonEditBookingConfirm = new System.Windows.Forms.Button();
            this.buttonCancelBookingConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gjest";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Romtype";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Romantall";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ankomst";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Avreise";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(75, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Anmerkning";
            // 
            // textBoxGuestName
            // 
            this.textBoxGuestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGuestName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGuestName.Location = new System.Drawing.Point(190, 21);
            this.textBoxGuestName.Name = "textBoxGuestName";
            this.textBoxGuestName.Size = new System.Drawing.Size(215, 23);
            this.textBoxGuestName.TabIndex = 6;
            // 
            // listBoxGuest
            // 
            this.listBoxGuest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxGuest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxGuest.FormattingEnabled = true;
            this.listBoxGuest.ItemHeight = 16;
            this.listBoxGuest.Location = new System.Drawing.Point(190, 48);
            this.listBoxGuest.Name = "listBoxGuest";
            this.listBoxGuest.Size = new System.Drawing.Size(215, 50);
            this.listBoxGuest.TabIndex = 7;
            // 
            // listBoxRoomType
            // 
            this.listBoxRoomType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxRoomType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxRoomType.FormattingEnabled = true;
            this.listBoxRoomType.ItemHeight = 16;
            this.listBoxRoomType.Location = new System.Drawing.Point(190, 105);
            this.listBoxRoomType.Name = "listBoxRoomType";
            this.listBoxRoomType.Size = new System.Drawing.Size(215, 50);
            this.listBoxRoomType.TabIndex = 8;
            // 
            // textBoxRoomAmount
            // 
            this.textBoxRoomAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRoomAmount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRoomAmount.Location = new System.Drawing.Point(190, 161);
            this.textBoxRoomAmount.Name = "textBoxRoomAmount";
            this.textBoxRoomAmount.Size = new System.Drawing.Size(215, 23);
            this.textBoxRoomAmount.TabIndex = 9;
            // 
            // datePickerArrival
            // 
            this.datePickerArrival.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.datePickerArrival.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerArrival.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerArrival.Location = new System.Drawing.Point(190, 190);
            this.datePickerArrival.Name = "datePickerArrival";
            this.datePickerArrival.Size = new System.Drawing.Size(215, 23);
            this.datePickerArrival.TabIndex = 10;
            // 
            // datePickerDeparture
            // 
            this.datePickerDeparture.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.datePickerDeparture.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerDeparture.Location = new System.Drawing.Point(190, 220);
            this.datePickerDeparture.Name = "datePickerDeparture";
            this.datePickerDeparture.Size = new System.Drawing.Size(215, 23);
            this.datePickerDeparture.TabIndex = 11;
            // 
            // textBoxRemark
            // 
            this.textBoxRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRemark.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRemark.Location = new System.Drawing.Point(190, 255);
            this.textBoxRemark.MaxLength = 90;
            this.textBoxRemark.Multiline = true;
            this.textBoxRemark.Name = "textBoxRemark";
            this.textBoxRemark.Size = new System.Drawing.Size(215, 50);
            this.textBoxRemark.TabIndex = 12;
            // 
            // buttonSearchBookingGuest
            // 
            this.buttonSearchBookingGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchBookingGuest.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchBookingGuest.Location = new System.Drawing.Point(410, 21);
            this.buttonSearchBookingGuest.Name = "buttonSearchBookingGuest";
            this.buttonSearchBookingGuest.Size = new System.Drawing.Size(50, 23);
            this.buttonSearchBookingGuest.TabIndex = 13;
            this.buttonSearchBookingGuest.Text = "Søk";
            this.buttonSearchBookingGuest.UseVisualStyleBackColor = true;
            this.buttonSearchBookingGuest.Click += new System.EventHandler(this.buttonSearchBookingGuest_Click);
            // 
            // buttonEditBookingConfirm
            // 
            this.buttonEditBookingConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditBookingConfirm.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditBookingConfirm.Location = new System.Drawing.Point(190, 310);
            this.buttonEditBookingConfirm.Name = "buttonEditBookingConfirm";
            this.buttonEditBookingConfirm.Size = new System.Drawing.Size(60, 28);
            this.buttonEditBookingConfirm.TabIndex = 14;
            this.buttonEditBookingConfirm.Text = "Endre";
            this.buttonEditBookingConfirm.UseVisualStyleBackColor = true;
            this.buttonEditBookingConfirm.Click += new System.EventHandler(this.buttonEditBookingConfirm_Click);
            // 
            // buttonCancelBookingConfirm
            // 
            this.buttonCancelBookingConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelBookingConfirm.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelBookingConfirm.Location = new System.Drawing.Point(256, 310);
            this.buttonCancelBookingConfirm.Name = "buttonCancelBookingConfirm";
            this.buttonCancelBookingConfirm.Size = new System.Drawing.Size(60, 28);
            this.buttonCancelBookingConfirm.TabIndex = 15;
            this.buttonCancelBookingConfirm.Text = "Avbryt";
            this.buttonCancelBookingConfirm.UseVisualStyleBackColor = true;
            this.buttonCancelBookingConfirm.Click += new System.EventHandler(this.buttonCancelBookingConfirm_Click);
            // 
            // EditBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.buttonCancelBookingConfirm);
            this.Controls.Add(this.buttonEditBookingConfirm);
            this.Controls.Add(this.buttonSearchBookingGuest);
            this.Controls.Add(this.textBoxRemark);
            this.Controls.Add(this.datePickerDeparture);
            this.Controls.Add(this.datePickerArrival);
            this.Controls.Add(this.textBoxRoomAmount);
            this.Controls.Add(this.listBoxRoomType);
            this.Controls.Add(this.listBoxGuest);
            this.Controls.Add(this.textBoxGuestName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "EditBookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Endre booking";
            this.Load += new System.EventHandler(this.EditBookingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGuestName;
        private System.Windows.Forms.ListBox listBoxGuest;
        private System.Windows.Forms.ListBox listBoxRoomType;
        private System.Windows.Forms.TextBox textBoxRoomAmount;
        private System.Windows.Forms.DateTimePicker datePickerArrival;
        private System.Windows.Forms.DateTimePicker datePickerDeparture;
        private System.Windows.Forms.TextBox textBoxRemark;
        private System.Windows.Forms.Button buttonSearchBookingGuest;
        private System.Windows.Forms.Button buttonEditBookingConfirm;
        private System.Windows.Forms.Button buttonCancelBookingConfirm;
    }
}
