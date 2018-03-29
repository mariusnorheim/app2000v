namespace HMS
{
    partial class NewBookingRoom
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
            this.datePickerDeparture = new System.Windows.Forms.DateTimePicker();
            this.datePickerArrival = new System.Windows.Forms.DateTimePicker();
            this.comboBoxRoomType = new System.Windows.Forms.ComboBox();
            this.listBoxGuest = new System.Windows.Forms.ListBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearchGuest = new System.Windows.Forms.Button();
            this.buttonSearchRoomBookingAvailable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRemark = new System.Windows.Forms.TextBox();
            this.buttonNewBookingCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonNewBookingConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // datePickerDeparture
            // 
            this.datePickerDeparture.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.datePickerDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerDeparture.Location = new System.Drawing.Point(400, 41);
            this.datePickerDeparture.Name = "datePickerDeparture";
            this.datePickerDeparture.Size = new System.Drawing.Size(225, 23);
            this.datePickerDeparture.TabIndex = 40;
            // 
            // datePickerArrival
            // 
            this.datePickerArrival.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.datePickerArrival.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerArrival.Location = new System.Drawing.Point(400, 13);
            this.datePickerArrival.Name = "datePickerArrival";
            this.datePickerArrival.Size = new System.Drawing.Size(225, 23);
            this.datePickerArrival.TabIndex = 41;
            // 
            // comboBoxRoomType
            // 
            this.comboBoxRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoomType.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.comboBoxRoomType.FormattingEnabled = true;
            this.comboBoxRoomType.Location = new System.Drawing.Point(400, 70);
            this.comboBoxRoomType.Name = "comboBoxRoomType";
            this.comboBoxRoomType.Size = new System.Drawing.Size(225, 24);
            this.comboBoxRoomType.TabIndex = 42;
            // 
            // listBoxGuest
            // 
            this.listBoxGuest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxGuest.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.listBoxGuest.FormattingEnabled = true;
            this.listBoxGuest.ItemHeight = 16;
            this.listBoxGuest.Location = new System.Drawing.Point(10, 15);
            this.listBoxGuest.Name = "listBoxGuest";
            this.listBoxGuest.Size = new System.Drawing.Size(300, 114);
            this.listBoxGuest.TabIndex = 55;
            this.listBoxGuest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxGuest_MouseDown);
            this.listBoxGuest.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxGuest_MouseMove);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.ForeColor = System.Drawing.Color.White;
            this.textBoxSearch.Location = new System.Drawing.Point(10, 140);
            this.textBoxSearch.MaxLength = 80;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(230, 26);
            this.textBoxSearch.TabIndex = 58;
            // 
            // buttonSearchGuest
            // 
            this.buttonSearchGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonSearchGuest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearchGuest.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonSearchGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchGuest.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchGuest.Location = new System.Drawing.Point(241, 140);
            this.buttonSearchGuest.Name = "buttonSearchGuest";
            this.buttonSearchGuest.Size = new System.Drawing.Size(70, 26);
            this.buttonSearchGuest.TabIndex = 39;
            this.buttonSearchGuest.Text = "Søk gjest";
            this.buttonSearchGuest.UseVisualStyleBackColor = false;
            this.buttonSearchGuest.Click += new System.EventHandler(this.buttonSearchGuest_Click);
            // 
            // buttonSearchRoomBookingAvailable
            // 
            this.buttonSearchRoomBookingAvailable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonSearchRoomBookingAvailable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearchRoomBookingAvailable.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonSearchRoomBookingAvailable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchRoomBookingAvailable.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchRoomBookingAvailable.Location = new System.Drawing.Point(400, 140);
            this.buttonSearchRoomBookingAvailable.Name = "buttonSearchRoomBookingAvailable";
            this.buttonSearchRoomBookingAvailable.Size = new System.Drawing.Size(70, 26);
            this.buttonSearchRoomBookingAvailable.TabIndex = 54;
            this.buttonSearchRoomBookingAvailable.Text = "Søk rom";
            this.buttonSearchRoomBookingAvailable.UseVisualStyleBackColor = false;
            this.buttonSearchRoomBookingAvailable.Click += new System.EventHandler(this.buttonSearchRoomBookingAvailable_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(336, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Romtype";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(336, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "Ankomst";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(336, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "Avreise";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(335, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 49;
            this.label6.Text = "Merknad";
            // 
            // textBoxRemark
            // 
            this.textBoxRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRemark.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.textBoxRemark.Location = new System.Drawing.Point(400, 99);
            this.textBoxRemark.MaxLength = 45;
            this.textBoxRemark.Multiline = true;
            this.textBoxRemark.Name = "textBoxRemark";
            this.textBoxRemark.Size = new System.Drawing.Size(225, 40);
            this.textBoxRemark.TabIndex = 51;
            // 
            // buttonNewBookingCancel
            // 
            this.buttonNewBookingCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonNewBookingCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewBookingCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonNewBookingCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewBookingCancel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewBookingCancel.Location = new System.Drawing.Point(320, 422);
            this.buttonNewBookingCancel.Name = "buttonNewBookingCancel";
            this.buttonNewBookingCancel.Size = new System.Drawing.Size(60, 28);
            this.buttonNewBookingCancel.TabIndex = 53;
            this.buttonNewBookingCancel.Text = "Avbryt";
            this.buttonNewBookingCancel.UseVisualStyleBackColor = false;
            this.buttonNewBookingCancel.Click += new System.EventHandler(this.buttonNewBookingCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoScrollMinSize = new System.Drawing.Size(10, 0);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 175);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(615, 240);
            this.flowLayoutPanel1.TabIndex = 56;
            // 
            // buttonNewBookingConfirm
            // 
            this.buttonNewBookingConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonNewBookingConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewBookingConfirm.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonNewBookingConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewBookingConfirm.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewBookingConfirm.Location = new System.Drawing.Point(255, 422);
            this.buttonNewBookingConfirm.Name = "buttonNewBookingConfirm";
            this.buttonNewBookingConfirm.Size = new System.Drawing.Size(60, 28);
            this.buttonNewBookingConfirm.TabIndex = 59;
            this.buttonNewBookingConfirm.Text = "Lagre";
            this.buttonNewBookingConfirm.UseVisualStyleBackColor = false;
            this.buttonNewBookingConfirm.Click += new System.EventHandler(this.buttonNewBookingConfirm_Click);
            // 
            // NewBookingRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.buttonNewBookingConfirm);
            this.Controls.Add(this.textBoxRemark);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.listBoxGuest);
            this.Controls.Add(this.buttonSearchRoomBookingAvailable);
            this.Controls.Add(this.buttonNewBookingCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxRoomType);
            this.Controls.Add(this.datePickerArrival);
            this.Controls.Add(this.datePickerDeparture);
            this.Controls.Add(this.buttonSearchGuest);
            this.Controls.Add(this.textBoxSearch);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NewBookingRoom";
            this.Text = "Ny booking";
            this.Load += new System.EventHandler(this.NewBookingRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxGuest;
        private System.Windows.Forms.DateTimePicker datePickerDeparture;
        private System.Windows.Forms.DateTimePicker datePickerArrival;
        private System.Windows.Forms.ComboBox comboBoxRoomType;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearchGuest;
        private System.Windows.Forms.Button buttonSearchRoomBookingAvailable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRemark;
        private System.Windows.Forms.Button buttonNewBookingCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonNewBookingConfirm;
    }
}
