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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSubMenu1 = new System.Windows.Forms.Button();
            this.buttonSubMenu2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(215, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(770, 200);
            this.dataGridView1.TabIndex = 22;
            // 
            // buttonSubMenu1
            // 
            this.buttonSubMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonSubMenu1.FlatAppearance.BorderSize = 0;
            this.buttonSubMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubMenu1.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubMenu1.Location = new System.Drawing.Point(480, 45);
            this.buttonSubMenu1.Name = "buttonSubMenu1";
            this.buttonSubMenu1.Size = new System.Drawing.Size(120, 26);
            this.buttonSubMenu1.TabIndex = 26;
            this.buttonSubMenu1.Text = "Folio";
            this.buttonSubMenu1.UseVisualStyleBackColor = false;
            // 
            // buttonSubMenu2
            // 
            this.buttonSubMenu2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonSubMenu2.FlatAppearance.BorderSize = 0;
            this.buttonSubMenu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubMenu2.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubMenu2.Location = new System.Drawing.Point(605, 45);
            this.buttonSubMenu2.Name = "buttonSubMenu2";
            this.buttonSubMenu2.Size = new System.Drawing.Size(120, 26);
            this.buttonSubMenu2.TabIndex = 27;
            this.buttonSubMenu2.Text = "Sluttoppgjør";
            this.buttonSubMenu2.UseVisualStyleBackColor = false;
            // 
            // Folio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.buttonSubMenu2);
            this.Controls.Add(this.buttonSubMenu1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Folio";
            this.Controls.SetChildIndex(this.labelHeading, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.buttonSubMenu1, 0);
            this.Controls.SetChildIndex(this.buttonSubMenu2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSubMenu1;
        private System.Windows.Forms.Button buttonSubMenu2;
    }
}
