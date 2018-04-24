namespace HMS
{
    partial class Folio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewFolio = new System.Windows.Forms.DataGridView();
            this.buttonEditFolio = new System.Windows.Forms.Button();
            this.buttonNewFolio = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearchFolio = new System.Windows.Forms.Button();
            this.buttonSetDuedate = new System.Windows.Forms.Button();
            this.buttonSetPaid = new System.Windows.Forms.Button();
            this.buttonDisplayDue = new System.Windows.Forms.Button();
            this.buttonDisplayAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFolio)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFolio
            // 
            this.dataGridViewFolio.AllowUserToAddRows = false;
            this.dataGridViewFolio.AllowUserToDeleteRows = false;
            this.dataGridViewFolio.AllowUserToResizeColumns = false;
            this.dataGridViewFolio.AllowUserToResizeRows = false;
            this.dataGridViewFolio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFolio.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.dataGridViewFolio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFolio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFolio.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFolio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewFolio.GridColor = System.Drawing.Color.DimGray;
            this.dataGridViewFolio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewFolio.Location = new System.Drawing.Point(15, 50);
            this.dataGridViewFolio.Name = "dataGridViewFolio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFolio.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewFolio.RowHeadersVisible = false;
            this.dataGridViewFolio.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewFolio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFolio.Size = new System.Drawing.Size(970, 550);
            this.dataGridViewFolio.TabIndex = 37;
            this.dataGridViewFolio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFolio_CellDoubleClick);
            // 
            // buttonEditFolio
            // 
            this.buttonEditFolio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonEditFolio.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonEditFolio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditFolio.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditFolio.Location = new System.Drawing.Point(100, 605);
            this.buttonEditFolio.Name = "buttonEditFolio";
            this.buttonEditFolio.Size = new System.Drawing.Size(80, 30);
            this.buttonEditFolio.TabIndex = 47;
            this.buttonEditFolio.Text = "Edit";
            this.buttonEditFolio.UseVisualStyleBackColor = false;
            this.buttonEditFolio.Click += new System.EventHandler(this.buttonEditFolio_Click);
            // 
            // buttonNewFolio
            // 
            this.buttonNewFolio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonNewFolio.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonNewFolio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewFolio.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewFolio.Location = new System.Drawing.Point(15, 605);
            this.buttonNewFolio.Name = "buttonNewFolio";
            this.buttonNewFolio.Size = new System.Drawing.Size(80, 30);
            this.buttonNewFolio.TabIndex = 46;
            this.buttonNewFolio.Text = "New";
            this.buttonNewFolio.UseVisualStyleBackColor = false;
            this.buttonNewFolio.Click += new System.EventHandler(this.buttonNewFolio_Click);
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
            this.textBoxSearch.TabIndex = 48;
            this.textBoxSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxSearch_MouseClick);
            // 
            // buttonSearchFolio
            // 
            this.buttonSearchFolio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonSearchFolio.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonSearchFolio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchFolio.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchFolio.Location = new System.Drawing.Point(925, 605);
            this.buttonSearchFolio.Name = "buttonSearchFolio";
            this.buttonSearchFolio.Size = new System.Drawing.Size(60, 30);
            this.buttonSearchFolio.TabIndex = 49;
            this.buttonSearchFolio.Text = "Search";
            this.buttonSearchFolio.UseVisualStyleBackColor = false;
            this.buttonSearchFolio.Click += new System.EventHandler(this.buttonSearchFolio_Click);
            // 
            // buttonSetDuedate
            // 
            this.buttonSetDuedate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonSetDuedate.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonSetDuedate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetDuedate.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetDuedate.Location = new System.Drawing.Point(186, 605);
            this.buttonSetDuedate.Name = "buttonSetDuedate";
            this.buttonSetDuedate.Size = new System.Drawing.Size(80, 30);
            this.buttonSetDuedate.TabIndex = 50;
            this.buttonSetDuedate.Text = "Due date";
            this.buttonSetDuedate.UseVisualStyleBackColor = false;
            this.buttonSetDuedate.Click += new System.EventHandler(this.buttonSetDuedate_Click);
            // 
            // buttonSetPaid
            // 
            this.buttonSetPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonSetPaid.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonSetPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetPaid.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetPaid.Location = new System.Drawing.Point(272, 605);
            this.buttonSetPaid.Name = "buttonSetPaid";
            this.buttonSetPaid.Size = new System.Drawing.Size(80, 30);
            this.buttonSetPaid.TabIndex = 51;
            this.buttonSetPaid.Text = "Paid";
            this.buttonSetPaid.UseVisualStyleBackColor = false;
            this.buttonSetPaid.Click += new System.EventHandler(this.buttonSetPaid_Click);
            // 
            // buttonDisplayDue
            // 
            this.buttonDisplayDue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDisplayDue.FlatAppearance.BorderSize = 0;
            this.buttonDisplayDue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.buttonDisplayDue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.buttonDisplayDue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisplayDue.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisplayDue.Location = new System.Drawing.Point(945, 24);
            this.buttonDisplayDue.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDisplayDue.Name = "buttonDisplayDue";
            this.buttonDisplayDue.Size = new System.Drawing.Size(40, 24);
            this.buttonDisplayDue.TabIndex = 58;
            this.buttonDisplayDue.Text = "Due";
            this.buttonDisplayDue.UseVisualStyleBackColor = true;
            this.buttonDisplayDue.Click += new System.EventHandler(this.buttonDisplayDue_Click);
            // 
            // buttonDisplayAll
            // 
            this.buttonDisplayAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDisplayAll.FlatAppearance.BorderSize = 0;
            this.buttonDisplayAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.buttonDisplayAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.buttonDisplayAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisplayAll.Font = new System.Drawing.Font("Ubuntu", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisplayAll.Location = new System.Drawing.Point(902, 24);
            this.buttonDisplayAll.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDisplayAll.Name = "buttonDisplayAll";
            this.buttonDisplayAll.Size = new System.Drawing.Size(40, 24);
            this.buttonDisplayAll.TabIndex = 59;
            this.buttonDisplayAll.Text = "All";
            this.buttonDisplayAll.UseVisualStyleBackColor = true;
            this.buttonDisplayAll.Click += new System.EventHandler(this.buttonDisplayAll_Click);
            // 
            // Folio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.buttonDisplayAll);
            this.Controls.Add(this.buttonDisplayDue);
            this.Controls.Add(this.buttonSetPaid);
            this.Controls.Add(this.buttonSetDuedate);
            this.Controls.Add(this.buttonSearchFolio);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonEditFolio);
            this.Controls.Add(this.buttonNewFolio);
            this.Controls.Add(this.dataGridViewFolio);
            this.Name = "Folio";
            this.Load += new System.EventHandler(this.Folio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFolio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonEditFolio;
        private System.Windows.Forms.Button buttonNewFolio;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearchFolio;
        private System.Windows.Forms.Button buttonSetDuedate;
        private System.Windows.Forms.Button buttonSetPaid;
        private System.Windows.Forms.Button buttonDisplayDue;
        private System.Windows.Forms.Button buttonDisplayAll;
        public System.Windows.Forms.DataGridView dataGridViewFolio;
    }
}
