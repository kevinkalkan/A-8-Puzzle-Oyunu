namespace _8_Puzzle_Ödevi
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
            this.gamePanel = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gamePanel.BackColor = System.Drawing.Color.GreenYellow;
            this.gamePanel.Controls.Add(this.button9);
            this.gamePanel.Controls.Add(this.button7);
            this.gamePanel.Controls.Add(this.button8);
            this.gamePanel.Controls.Add(this.button6);
            this.gamePanel.Controls.Add(this.button5);
            this.gamePanel.Controls.Add(this.button3);
            this.gamePanel.Controls.Add(this.button2);
            this.gamePanel.Controls.Add(this.button1);
            this.gamePanel.Controls.Add(this.button4);
            this.gamePanel.Location = new System.Drawing.Point(262, 64);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(296, 278);
            this.gamePanel.TabIndex = 1;
            // 
            // button9
            // 
            this.button9.AllowDrop = true;
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button9.Location = new System.Drawing.Point(191, 191);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(70, 70);
            this.button9.TabIndex = 8;
            this.button9.Tag = "8";
            this.button9.Text = "__";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.DragDrop += new System.Windows.Forms.DragEventHandler(this.Button_DragDrop);
            this.button9.DragEnter += new System.Windows.Forms.DragEventHandler(this.Button_DragEnter);
            this.button9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            // 
            // button7
            // 
            this.button7.AllowDrop = true;
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button7.Location = new System.Drawing.Point(17, 191);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(70, 70);
            this.button7.TabIndex = 7;
            this.button7.Tag = "6";
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.DragDrop += new System.Windows.Forms.DragEventHandler(this.Button_DragDrop);
            this.button7.DragEnter += new System.Windows.Forms.DragEventHandler(this.Button_DragEnter);
            this.button7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            // 
            // button8
            // 
            this.button8.AllowDrop = true;
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button8.Location = new System.Drawing.Point(101, 191);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(70, 70);
            this.button8.TabIndex = 6;
            this.button8.Tag = "7";
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.DragDrop += new System.Windows.Forms.DragEventHandler(this.Button_DragDrop);
            this.button8.DragEnter += new System.Windows.Forms.DragEventHandler(this.Button_DragEnter);
            this.button8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            // 
            // button6
            // 
            this.button6.AllowDrop = true;
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button6.Location = new System.Drawing.Point(191, 104);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(70, 70);
            this.button6.TabIndex = 5;
            this.button6.Tag = "5";
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.DragDrop += new System.Windows.Forms.DragEventHandler(this.Button_DragDrop);
            this.button6.DragEnter += new System.Windows.Forms.DragEventHandler(this.Button_DragEnter);
            this.button6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            // 
            // button5
            // 
            this.button5.AllowDrop = true;
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button5.Location = new System.Drawing.Point(101, 104);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 70);
            this.button5.TabIndex = 4;
            this.button5.Tag = "4";
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.DragDrop += new System.Windows.Forms.DragEventHandler(this.Button_DragDrop);
            this.button5.DragEnter += new System.Windows.Forms.DragEventHandler(this.Button_DragEnter);
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            // 
            // button3
            // 
            this.button3.AllowDrop = true;
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Location = new System.Drawing.Point(191, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 70);
            this.button3.TabIndex = 3;
            this.button3.Tag = "2";
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.DragDrop += new System.Windows.Forms.DragEventHandler(this.Button_DragDrop);
            this.button3.DragEnter += new System.Windows.Forms.DragEventHandler(this.Button_DragEnter);
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            // 
            // button2
            // 
            this.button2.AllowDrop = true;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Location = new System.Drawing.Point(101, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 70);
            this.button2.TabIndex = 2;
            this.button2.Tag = "1";
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Button_DragDrop);
            this.button2.DragEnter += new System.Windows.Forms.DragEventHandler(this.Button_DragEnter);
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(17, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 70);
            this.button1.TabIndex = 1;
            this.button1.Tag = "0";
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Button_DragDrop);
            this.button1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Button_DragEnter);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            // 
            // button4
            // 
            this.button4.AllowDrop = true;
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Location = new System.Drawing.Point(17, 104);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 70);
            this.button4.TabIndex = 0;
            this.button4.Tag = "3";
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.DragDrop += new System.Windows.Forms.DragEventHandler(this.Button_DragDrop);
            this.button4.DragEnter += new System.Windows.Forms.DragEventHandler(this.Button_DragEnter);
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShuffle.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonShuffle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShuffle.ForeColor = System.Drawing.Color.Black;
            this.buttonShuffle.Location = new System.Drawing.Point(145, 116);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(76, 26);
            this.buttonShuffle.TabIndex = 3;
            this.buttonShuffle.Text = "Karıştır";
            this.buttonShuffle.UseVisualStyleBackColor = false;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonStart.Location = new System.Drawing.Point(617, 116);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(76, 26);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Çöz";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(88, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(642, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "8 Taş Bulmacası A* Algoritması Çözümü";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 381);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonShuffle);
            this.Controls.Add(this.gamePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gamePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
    }
}

