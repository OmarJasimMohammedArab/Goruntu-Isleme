﻿namespace GoruntuIsleme
{
    partial class Karisitlik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Karisitlik));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_SelectImage = new System.Windows.Forms.Button();
            this.btn_karisit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_X1 = new System.Windows.Forms.TextBox();
            this.txt_X2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Y1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Y2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 289);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(371, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(334, 289);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btn_SelectImage
            // 
            this.btn_SelectImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_SelectImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_SelectImage.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectImage.Image")));
            this.btn_SelectImage.Location = new System.Drawing.Point(13, 331);
            this.btn_SelectImage.Name = "btn_SelectImage";
            this.btn_SelectImage.Size = new System.Drawing.Size(212, 59);
            this.btn_SelectImage.TabIndex = 2;
            this.btn_SelectImage.UseVisualStyleBackColor = false;
            this.btn_SelectImage.Click += new System.EventHandler(this.btn_SelectImage_Click);
            // 
            // btn_karisit
            // 
            this.btn_karisit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_karisit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_karisit.Location = new System.Drawing.Point(272, 331);
            this.btn_karisit.Name = "btn_karisit";
            this.btn_karisit.Size = new System.Drawing.Size(146, 59);
            this.btn_karisit.TabIndex = 3;
            this.btn_karisit.Text = "KARŞITLIK";
            this.btn_karisit.UseVisualStyleBackColor = false;
            this.btn_karisit.Click += new System.EventHandler(this.btn_karisit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(477, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "X1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_X1
            // 
            this.txt_X1.Location = new System.Drawing.Point(519, 323);
            this.txt_X1.Name = "txt_X1";
            this.txt_X1.Size = new System.Drawing.Size(80, 20);
            this.txt_X1.TabIndex = 5;
            this.txt_X1.TextChanged += new System.EventHandler(this.txt_X1_TextChanged);
            this.txt_X1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_X1_KeyPress);
            // 
            // txt_X2
            // 
            this.txt_X2.Location = new System.Drawing.Point(519, 370);
            this.txt_X2.Name = "txt_X2";
            this.txt_X2.Size = new System.Drawing.Size(80, 20);
            this.txt_X2.TabIndex = 7;
            this.txt_X2.TextChanged += new System.EventHandler(this.txt_X2_TextChanged);
            this.txt_X2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_X2_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(477, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "X2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txt_Y1
            // 
            this.txt_Y1.Location = new System.Drawing.Point(675, 323);
            this.txt_Y1.Name = "txt_Y1";
            this.txt_Y1.Size = new System.Drawing.Size(80, 20);
            this.txt_Y1.TabIndex = 9;
            this.txt_Y1.TextChanged += new System.EventHandler(this.txt_Y1_TextChanged);
            this.txt_Y1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Y1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(633, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Y1";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_Y2
            // 
            this.txt_Y2.Location = new System.Drawing.Point(675, 370);
            this.txt_Y2.Name = "txt_Y2";
            this.txt_Y2.Size = new System.Drawing.Size(80, 20);
            this.txt_Y2.TabIndex = 11;
            this.txt_Y2.TextChanged += new System.EventHandler(this.txt_Y2_TextChanged);
            this.txt_Y2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Y2_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(633, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y2";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Karisitlik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_Y2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Y1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_X2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_X1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_karisit);
            this.Controls.Add(this.btn_SelectImage);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Karisitlik";
            this.Text = "Karisitlik";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_SelectImage;
        private System.Windows.Forms.Button btn_karisit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_X1;
        private System.Windows.Forms.TextBox txt_X2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Y1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Y2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}