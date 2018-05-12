namespace HMS
{
    partial class Messages
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonReadMessage = new System.Windows.Forms.Button();
            this.buttonSearchMessage = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonEditMessage = new System.Windows.Forms.Button();
            this.buttonNewMessage = new System.Windows.Forms.Button();
            this.dataGridViewMessage = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReadMessage
            // 
            this.buttonReadMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonReadMessage.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonReadMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReadMessage.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReadMessage.Location = new System.Drawing.Point(185, 605);
            this.buttonReadMessage.Name = "buttonReadMessage";
            this.buttonReadMessage.Size = new System.Drawing.Size(80, 30);
            this.buttonReadMessage.TabIndex = 62;
            this.buttonReadMessage.Text = "Mark read";
            this.buttonReadMessage.UseVisualStyleBackColor = false;
            this.buttonReadMessage.Click += new System.EventHandler(this.buttonReadMessage_Click);
            // 
            // buttonSearchMessage
            // 
            this.buttonSearchMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonSearchMessage.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonSearchMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchMessage.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchMessage.Location = new System.Drawing.Point(925, 605);
            this.buttonSearchMessage.Name = "buttonSearchMessage";
            this.buttonSearchMessage.Size = new System.Drawing.Size(60, 30);
            this.buttonSearchMessage.TabIndex = 61;
            this.buttonSearchMessage.Text = "Search";
            this.buttonSearchMessage.UseVisualStyleBackColor = false;
            this.buttonSearchMessage.Click += new System.EventHandler(this.buttonSearchMessage_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.AcceptsTab = true;
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.Font = new System.Drawing.Font("Bahnschrift Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.ForeColor = System.Drawing.Color.White;
            this.textBoxSearch.Location = new System.Drawing.Point(620, 605);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxSearch.MaxLength = 80;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(300, 30);
            this.textBoxSearch.TabIndex = 60;
            // 
            // buttonEditMessage
            // 
            this.buttonEditMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonEditMessage.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonEditMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditMessage.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditMessage.Location = new System.Drawing.Point(100, 605);
            this.buttonEditMessage.Name = "buttonEditMessage";
            this.buttonEditMessage.Size = new System.Drawing.Size(80, 30);
            this.buttonEditMessage.TabIndex = 59;
            this.buttonEditMessage.Text = "Edit";
            this.buttonEditMessage.UseVisualStyleBackColor = false;
            this.buttonEditMessage.Click += new System.EventHandler(this.buttonEditMessage_Click);
            // 
            // buttonNewMessage
            // 
            this.buttonNewMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonNewMessage.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonNewMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewMessage.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewMessage.Location = new System.Drawing.Point(15, 605);
            this.buttonNewMessage.Name = "buttonNewMessage";
            this.buttonNewMessage.Size = new System.Drawing.Size(80, 30);
            this.buttonNewMessage.TabIndex = 58;
            this.buttonNewMessage.Text = "New";
            this.buttonNewMessage.UseVisualStyleBackColor = false;
            this.buttonNewMessage.Click += new System.EventHandler(this.buttonNewMessage_Click);
            // 
            // dataGridViewMessage
            // 
            this.dataGridViewMessage.AllowUserToAddRows = false;
            this.dataGridViewMessage.AllowUserToDeleteRows = false;
            this.dataGridViewMessage.AllowUserToResizeColumns = false;
            this.dataGridViewMessage.AllowUserToResizeRows = false;
            this.dataGridViewMessage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMessage.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.dataGridViewMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMessage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMessage.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewMessage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewMessage.GridColor = System.Drawing.Color.DimGray;
            this.dataGridViewMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewMessage.Location = new System.Drawing.Point(15, 50);
            this.dataGridViewMessage.Name = "dataGridViewMessage";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMessage.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewMessage.RowHeadersVisible = false;
            this.dataGridViewMessage.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewMessage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMessage.Size = new System.Drawing.Size(970, 550);
            this.dataGridViewMessage.TabIndex = 57;
            this.dataGridViewMessage.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMessage_CellDoubleClick);
            // 
            // Messages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.buttonReadMessage);
            this.Controls.Add(this.buttonSearchMessage);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonEditMessage);
            this.Controls.Add(this.buttonNewMessage);
            this.Controls.Add(this.dataGridViewMessage);
            this.Name = "Messages";
            this.Load += new System.EventHandler(this.Messages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReadMessage;
        private System.Windows.Forms.Button buttonSearchMessage;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonEditMessage;
        private System.Windows.Forms.Button buttonNewMessage;
        public System.Windows.Forms.DataGridView dataGridViewMessage;
    }
}
