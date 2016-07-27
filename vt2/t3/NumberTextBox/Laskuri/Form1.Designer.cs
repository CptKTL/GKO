namespace Laskuri
{
    partial class Laskuri
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
            this.Matka = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.laskeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nopeusLabel = new System.Windows.Forms.Label();
            this.nopeus = new System.Windows.Forms.Label();
            this.matkaNumberTextBox1 = new NumberTextBox.NumberTextBox();
            this.aikaNumberTextBox2 = new NumberTextBox.NumberTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Matka
            // 
            this.Matka.AutoSize = true;
            this.Matka.Location = new System.Drawing.Point(3, 0);
            this.Matka.Name = "Matka";
            this.Matka.Size = new System.Drawing.Size(60, 13);
            this.Matka.TabIndex = 2;
            this.Matka.Text = "Matka (km)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Aika (h)";
            // 
            // laskeButton
            // 
            this.laskeButton.Enabled = false;
            this.laskeButton.Location = new System.Drawing.Point(205, 32);
            this.laskeButton.Name = "laskeButton";
            this.laskeButton.Size = new System.Drawing.Size(68, 23);
            this.laskeButton.TabIndex = 4;
            this.laskeButton.Text = "Laske";
            this.laskeButton.UseVisualStyleBackColor = true;
            this.laskeButton.Click += new System.EventHandler(this.laskeButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.72186F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.27814F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.Controls.Add(this.Matka, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nopeusLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nopeus, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.laskeButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.matkaNumberTextBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.aikaNumberTextBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 78);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // nopeusLabel
            // 
            this.nopeusLabel.AutoSize = true;
            this.nopeusLabel.Location = new System.Drawing.Point(3, 58);
            this.nopeusLabel.Name = "nopeusLabel";
            this.nopeusLabel.Size = new System.Drawing.Size(44, 13);
            this.nopeusLabel.TabIndex = 5;
            this.nopeusLabel.Text = "Nopeus";
            // 
            // nopeus
            // 
            this.nopeus.AutoSize = true;
            this.nopeus.Location = new System.Drawing.Point(87, 58);
            this.nopeus.Name = "nopeus";
            this.nopeus.Size = new System.Drawing.Size(0, 13);
            this.nopeus.TabIndex = 6;
            // 
            // matkaNumberTextBox1
            // 
            this.matkaNumberTextBox1.Location = new System.Drawing.Point(87, 3);
            this.matkaNumberTextBox1.Max = 99999D;
            this.matkaNumberTextBox1.Min = 0D;
            this.matkaNumberTextBox1.Name = "matkaNumberTextBox1";
            this.matkaNumberTextBox1.Size = new System.Drawing.Size(112, 20);
            this.matkaNumberTextBox1.TabIndex = 0;
            this.matkaNumberTextBox1.TextChanged += new System.EventHandler(this.NumberTextBox1_TextChanged);
            // 
            // aikaNumberTextBox2
            // 
            this.aikaNumberTextBox2.Location = new System.Drawing.Point(87, 32);
            this.aikaNumberTextBox2.Max = 99999D;
            this.aikaNumberTextBox2.Min = 1E-05D;
            this.aikaNumberTextBox2.Name = "aikaNumberTextBox2";
            this.aikaNumberTextBox2.Size = new System.Drawing.Size(112, 20);
            this.aikaNumberTextBox2.TabIndex = 1;
            this.aikaNumberTextBox2.TextChanged += new System.EventHandler(this.NumberTextBox1_TextChanged);
            // 
            // Laskuri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Laskuri";
            this.Text = "Laskuri";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumberTextBox.NumberTextBox matkaNumberTextBox1;
        private NumberTextBox.NumberTextBox aikaNumberTextBox2;
        private System.Windows.Forms.Label Matka;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button laskeButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label nopeusLabel;
        private System.Windows.Forms.Label nopeus;
    }
}

