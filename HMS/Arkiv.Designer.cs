namespace HMS
{
    partial class Arkiv
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
            this.buttonSubMenu1 = new System.Windows.Forms.Button();
            this.buttonSubMenu2 = new System.Windows.Forms.Button();
            this.buttonSubMenu3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSubMenu1
            // 
            this.buttonSubMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonSubMenu1.FlatAppearance.BorderSize = 0;
            this.buttonSubMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubMenu1.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubMenu1.Location = new System.Drawing.Point(410, 45);
            this.buttonSubMenu1.Name = "buttonSubMenu1";
            this.buttonSubMenu1.Size = new System.Drawing.Size(120, 26);
            this.buttonSubMenu1.TabIndex = 21;
            this.buttonSubMenu1.Text = "Rom";
            this.buttonSubMenu1.UseVisualStyleBackColor = false;
            // 
            // buttonSubMenu2
            // 
            this.buttonSubMenu2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonSubMenu2.FlatAppearance.BorderSize = 0;
            this.buttonSubMenu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubMenu2.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubMenu2.Location = new System.Drawing.Point(535, 45);
            this.buttonSubMenu2.Name = "buttonSubMenu2";
            this.buttonSubMenu2.Size = new System.Drawing.Size(120, 26);
            this.buttonSubMenu2.TabIndex = 22;
            this.buttonSubMenu2.Text = "Hall";
            this.buttonSubMenu2.UseVisualStyleBackColor = false;
            // 
            // buttonSubMenu3
            // 
            this.buttonSubMenu3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.buttonSubMenu3.FlatAppearance.BorderSize = 0;
            this.buttonSubMenu3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubMenu3.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubMenu3.Location = new System.Drawing.Point(660, 45);
            this.buttonSubMenu3.Name = "buttonSubMenu3";
            this.buttonSubMenu3.Size = new System.Drawing.Size(120, 26);
            this.buttonSubMenu3.TabIndex = 23;
            this.buttonSubMenu3.Text = "Folio";
            this.buttonSubMenu3.UseVisualStyleBackColor = false;
            // 
            // Arkiv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.buttonSubMenu3);
            this.Controls.Add(this.buttonSubMenu2);
            this.Controls.Add(this.buttonSubMenu1);
            this.Name = "Arkiv";
            this.Controls.SetChildIndex(this.labelHeading, 0);
            this.Controls.SetChildIndex(this.buttonSubMenu1, 0);
            this.Controls.SetChildIndex(this.buttonSubMenu2, 0);
            this.Controls.SetChildIndex(this.buttonSubMenu3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSubMenu1;
        private System.Windows.Forms.Button buttonSubMenu2;
        private System.Windows.Forms.Button buttonSubMenu3;
    }
}
