namespace HMS
{
    partial class Todo
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
            this.buttonDeleteTodo = new System.Windows.Forms.Button();
            this.buttonSearchTodo = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonEditTodo = new System.Windows.Forms.Button();
            this.buttonNewTodo = new System.Windows.Forms.Button();
            this.dataGridViewTodo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTodo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDeleteTodo
            // 
            this.buttonDeleteTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonDeleteTodo.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonDeleteTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteTodo.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteTodo.Location = new System.Drawing.Point(185, 605);
            this.buttonDeleteTodo.Name = "buttonDeleteTodo";
            this.buttonDeleteTodo.Size = new System.Drawing.Size(80, 30);
            this.buttonDeleteTodo.TabIndex = 56;
            this.buttonDeleteTodo.Text = "Completed";
            this.buttonDeleteTodo.UseVisualStyleBackColor = false;
            this.buttonDeleteTodo.Click += new System.EventHandler(this.buttonDeleteTodo_Click);
            // 
            // buttonSearchTodo
            // 
            this.buttonSearchTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonSearchTodo.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonSearchTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchTodo.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchTodo.Location = new System.Drawing.Point(925, 605);
            this.buttonSearchTodo.Name = "buttonSearchTodo";
            this.buttonSearchTodo.Size = new System.Drawing.Size(60, 30);
            this.buttonSearchTodo.TabIndex = 55;
            this.buttonSearchTodo.Text = "Search";
            this.buttonSearchTodo.UseVisualStyleBackColor = false;
            this.buttonSearchTodo.Click += new System.EventHandler(this.buttonSearchTodo_Click);
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
            this.textBoxSearch.TabIndex = 54;
            this.textBoxSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxSearch_MouseClick);
            // 
            // buttonEditTodo
            // 
            this.buttonEditTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonEditTodo.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonEditTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditTodo.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditTodo.Location = new System.Drawing.Point(100, 605);
            this.buttonEditTodo.Name = "buttonEditTodo";
            this.buttonEditTodo.Size = new System.Drawing.Size(80, 30);
            this.buttonEditTodo.TabIndex = 53;
            this.buttonEditTodo.Text = "Edit";
            this.buttonEditTodo.UseVisualStyleBackColor = false;
            this.buttonEditTodo.Click += new System.EventHandler(this.buttonEditTodo_Click);
            // 
            // buttonNewTodo
            // 
            this.buttonNewTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonNewTodo.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonNewTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewTodo.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewTodo.Location = new System.Drawing.Point(15, 605);
            this.buttonNewTodo.Name = "buttonNewTodo";
            this.buttonNewTodo.Size = new System.Drawing.Size(80, 30);
            this.buttonNewTodo.TabIndex = 52;
            this.buttonNewTodo.Text = "New";
            this.buttonNewTodo.UseVisualStyleBackColor = false;
            this.buttonNewTodo.Click += new System.EventHandler(this.buttonNewTodo_Click);
            // 
            // dataGridViewTodo
            // 
            this.dataGridViewTodo.AllowUserToAddRows = false;
            this.dataGridViewTodo.AllowUserToDeleteRows = false;
            this.dataGridViewTodo.AllowUserToResizeColumns = false;
            this.dataGridViewTodo.AllowUserToResizeRows = false;
            this.dataGridViewTodo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTodo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.dataGridViewTodo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTodo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTodo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTodo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewTodo.GridColor = System.Drawing.Color.DimGray;
            this.dataGridViewTodo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewTodo.Location = new System.Drawing.Point(15, 50);
            this.dataGridViewTodo.Name = "dataGridViewTodo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTodo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTodo.RowHeadersVisible = false;
            this.dataGridViewTodo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewTodo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTodo.Size = new System.Drawing.Size(970, 550);
            this.dataGridViewTodo.TabIndex = 51;
            this.dataGridViewTodo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTodo_CellDoubleClick);
            // 
            // Todo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.buttonDeleteTodo);
            this.Controls.Add(this.buttonSearchTodo);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonEditTodo);
            this.Controls.Add(this.buttonNewTodo);
            this.Controls.Add(this.dataGridViewTodo);
            this.Name = "Todo";
            this.Load += new System.EventHandler(this.Todo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTodo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDeleteTodo;
        private System.Windows.Forms.Button buttonSearchTodo;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonEditTodo;
        private System.Windows.Forms.Button buttonNewTodo;
        public System.Windows.Forms.DataGridView dataGridViewTodo;
    }
}
