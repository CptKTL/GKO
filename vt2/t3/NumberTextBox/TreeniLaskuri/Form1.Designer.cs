namespace TreeniLaskuri
{
    partial class Treenilaskuri
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.matkaNumberTextbox = new NumberTextBox.NumberTextBox();
            this.LaskeButton = new System.Windows.Forms.Button();
            this.Matka = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeTextBox = new TimeTextBox.TimeTextBox();
            this.paceLabel = new PaceLabel.PaceLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.0625F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.9375F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.Controls.Add(this.LaskeButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.timeTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.matkaNumberTextbox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Matka, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.paceLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 78);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // matkaNumberTextbox
            // 
            this.matkaNumberTextbox.Location = new System.Drawing.Point(170, 3);
            this.matkaNumberTextbox.Max = 99999D;
            this.matkaNumberTextbox.Min = 0D;
            this.matkaNumberTextbox.Name = "matkaNumberTextbox";
            this.matkaNumberTextbox.Size = new System.Drawing.Size(121, 20);
            this.matkaNumberTextbox.TabIndex = 0;
            this.matkaNumberTextbox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // LaskeButton
            // 
            this.LaskeButton.Location = new System.Drawing.Point(343, 32);
            this.LaskeButton.Name = "LaskeButton";
            this.LaskeButton.Size = new System.Drawing.Size(75, 23);
            this.LaskeButton.TabIndex = 3;
            this.LaskeButton.Text = "Laske";
            this.LaskeButton.UseVisualStyleBackColor = true;
            this.LaskeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Matka
            // 
            this.Matka.AutoSize = true;
            this.Matka.Location = new System.Drawing.Point(3, 0);
            this.Matka.Name = "Matka";
            this.Matka.Size = new System.Drawing.Size(60, 13);
            this.Matka.TabIndex = 4;
            this.Matka.Text = "Matka (km)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Aika (HH:MM:SS)";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(170, 32);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(125, 20);
            this.timeTextBox.TabIndex = 1;
            this.timeTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // paceLabel
            // 
            this.paceLabel.AutoSize = true;
            this.paceLabel.Distance = 0D;
            this.paceLabel.Location = new System.Drawing.Point(170, 58);
            this.paceLabel.Name = "paceLabel";
            this.paceLabel.Size = new System.Drawing.Size(57, 13);
            this.paceLabel.TabIndex = 6;
            this.paceLabel.Text = "paceLabel";
            this.paceLabel.fast += new PaceLabel.PaceLabel.Fast(this.paceLabel_fast);
            this.paceLabel.average += new PaceLabel.PaceLabel.Average(this.paceLabel_average);
            this.paceLabel.slow += new PaceLabel.PaceLabel.Slow(this.paceLabel_slow);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pace";
            // 
            // Treenilaskuri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 262);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Treenilaskuri";
            this.Text = "Treenilaskuri";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private NumberTextBox.NumberTextBox matkaNumberTextbox;
        private TimeTextBox.TimeTextBox timeTextBox;
        private System.Windows.Forms.Button LaskeButton;
        private System.Windows.Forms.Label Matka;
        private System.Windows.Forms.Label label2;
        private PaceLabel.PaceLabel paceLabel;
        private System.Windows.Forms.Label label1;
    }
}

