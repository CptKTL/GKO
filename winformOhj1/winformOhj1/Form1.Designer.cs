namespace winformOhj1
{
    partial class Form1
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
            this.nollaa = new System.Windows.Forms.Button();
            this.lisää = new System.Windows.Forms.Button();
            this.laskuri = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nollaa
            // 
            this.nollaa.Location = new System.Drawing.Point(45, 85);
            this.nollaa.Name = "nollaa";
            this.nollaa.Size = new System.Drawing.Size(75, 23);
            this.nollaa.TabIndex = 0;
            this.nollaa.Text = "nollaa";
            this.nollaa.UseVisualStyleBackColor = true;
            // 
            // lisää
            // 
            this.lisää.Location = new System.Drawing.Point(45, 114);
            this.lisää.Name = "lisää";
            this.lisää.Size = new System.Drawing.Size(75, 23);
            this.lisää.TabIndex = 1;
            this.lisää.Text = "lisää";
            this.lisää.UseVisualStyleBackColor = true;
            this.lisää.Click += new System.EventHandler(this.lisää_Click);
            // 
            // laskuri
            // 
            this.laskuri.AutoSize = true;
            this.laskuri.Location = new System.Drawing.Point(61, 43);
            this.laskuri.Name = "laskuri";
            this.laskuri.Size = new System.Drawing.Size(13, 13);
            this.laskuri.TabIndex = 2;
            this.laskuri.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 330);
            this.Controls.Add(this.laskuri);
            this.Controls.Add(this.lisää);
            this.Controls.Add(this.nollaa);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nollaa;
        private System.Windows.Forms.Button lisää;
        private System.Windows.Forms.Label laskuri;
    }
}

