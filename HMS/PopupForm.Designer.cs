namespace HMS
{
    partial class PopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupForm));
            this.buttonFormExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFormExit
            // 
            this.buttonFormExit.FlatAppearance.BorderSize = 0;
            this.buttonFormExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFormExit.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFormExit.ForeColor = System.Drawing.Color.Silver;
            this.buttonFormExit.Location = new System.Drawing.Point(472, 0);
            this.buttonFormExit.Name = "buttonFormExit";
            this.buttonFormExit.Size = new System.Drawing.Size(28, 28);
            this.buttonFormExit.TabIndex = 2;
            this.buttonFormExit.Text = "X";
            this.buttonFormExit.UseVisualStyleBackColor = true;
            this.buttonFormExit.Click += new System.EventHandler(this.buttonFormExit_Click);
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.buttonFormExit);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(800, 400);
            this.MaximizeBox = false;
            this.Name = "PopupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Hotel Management System";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFormExit;
    }
}