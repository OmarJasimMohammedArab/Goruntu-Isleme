namespace GoruntuIsleme
{
    partial class Gontrast_Germe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gontrast_Germe));
            this.txt_1 = new System.Windows.Forms.TextBox();
            this.txt_2 = new System.Windows.Forms.TextBox();
            this.txt_3 = new System.Windows.Forms.TextBox();
            this.txt_4 = new System.Windows.Forms.TextBox();
            this.btn_KontrastGerme = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_Upload = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_1
            // 
            this.txt_1.Location = new System.Drawing.Point(453, 265);
            this.txt_1.Name = "txt_1";
            this.txt_1.Size = new System.Drawing.Size(68, 20);
            this.txt_1.TabIndex = 2;
            this.txt_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_1_KeyPress);
            // 
            // txt_2
            // 
            this.txt_2.Location = new System.Drawing.Point(453, 291);
            this.txt_2.Name = "txt_2";
            this.txt_2.Size = new System.Drawing.Size(68, 20);
            this.txt_2.TabIndex = 3;
            this.txt_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_2_KeyPress);
            // 
            // txt_3
            // 
            this.txt_3.Location = new System.Drawing.Point(453, 317);
            this.txt_3.Name = "txt_3";
            this.txt_3.Size = new System.Drawing.Size(68, 20);
            this.txt_3.TabIndex = 4;
            this.txt_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_3_KeyPress);
            // 
            // txt_4
            // 
            this.txt_4.Location = new System.Drawing.Point(453, 343);
            this.txt_4.Name = "txt_4";
            this.txt_4.Size = new System.Drawing.Size(68, 20);
            this.txt_4.TabIndex = 5;
            this.txt_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_4_KeyPress);
            // 
            // btn_KontrastGerme
            // 
            this.btn_KontrastGerme.BackColor = System.Drawing.Color.Yellow;
            this.btn_KontrastGerme.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_KontrastGerme.Location = new System.Drawing.Point(286, 265);
            this.btn_KontrastGerme.Name = "btn_KontrastGerme";
            this.btn_KontrastGerme.Size = new System.Drawing.Size(142, 46);
            this.btn_KontrastGerme.TabIndex = 7;
            this.btn_KontrastGerme.Text = "Convert";
            this.btn_KontrastGerme.UseVisualStyleBackColor = false;
            this.btn_KontrastGerme.Click += new System.EventHandler(this.btn_KontrastGerme_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_Upload
            // 
            this.btn_Upload.Image = ((System.Drawing.Image)(resources.GetObject("btn_Upload.Image")));
            this.btn_Upload.Location = new System.Drawing.Point(29, 265);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(235, 46);
            this.btn_Upload.TabIndex = 6;
            this.btn_Upload.UseVisualStyleBackColor = true;
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(286, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(235, 234);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(29, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 234);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Gontrast_Germe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(543, 450);
            this.Controls.Add(this.btn_KontrastGerme);
            this.Controls.Add(this.btn_Upload);
            this.Controls.Add(this.txt_4);
            this.Controls.Add(this.txt_3);
            this.Controls.Add(this.txt_2);
            this.Controls.Add(this.txt_1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Gontrast_Germe";
            this.Text = "Gontrast_Germe";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txt_1;
        private System.Windows.Forms.TextBox txt_2;
        private System.Windows.Forms.TextBox txt_3;
        private System.Windows.Forms.TextBox txt_4;
        private System.Windows.Forms.Button btn_Upload;
        private System.Windows.Forms.Button btn_KontrastGerme;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}