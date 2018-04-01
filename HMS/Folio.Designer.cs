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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewFolio = new System.Windows.Forms.DataGridView();
            this.buttonEditFolio = new System.Windows.Forms.Button();
            this.buttonNewFolio = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearchFolio = new System.Windows.Forms.Button();
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFolio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewFolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFolio.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewFolio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewFolio.GridColor = System.Drawing.Color.DimGray;
            this.dataGridViewFolio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewFolio.Location = new System.Drawing.Point(15, 50);
            this.dataGridViewFolio.Name = "dataGridViewFolio";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFolio.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewFolio.RowHeadersVisible = false;
            this.dataGridViewFolio.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewFolio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFolio.Size = new System.Drawing.Size(970, 550);
            this.dataGridViewFolio.TabIndex = 37;
            this.dataGridViewFolio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGuest_CellDoubleClick);
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
            // Folio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1000, 670);
            this.Controls.Add(this.buttonSearchFolio);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonEditFolio);
            this.Controls.Add(this.buttonNewFolio);
            this.Controls.Add(this.dataGridViewFolio);
            this.Name = "Folio";
            this.Load += new System.EventHandler(this.Folio_Load);
            this.Controls.SetChildIndex(this.dataGridViewFolio, 0);
            this.Controls.SetChildIndex(this.buttonNewFolio, 0);
            this.Controls.SetChildIndex(this.buttonEditFolio, 0);
            this.Controls.SetChildIndex(this.textBoxSearch, 0);
            this.Controls.SetChildIndex(this.buttonSearchFolio, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFolio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFolio;
        private System.Windows.Forms.Button buttonEditFolio;
        private System.Windows.Forms.Button buttonNewFolio;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearchFolio;
    }
}
