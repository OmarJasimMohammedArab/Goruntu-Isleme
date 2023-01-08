using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoruntuIsleme
{
    public partial class Zoom : Form
    {
        public Zoom()
        {
            InitializeComponent();
        }
      /*  private void btn_Zoom_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string a = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(a);
        }*/
        Image ZoomPicture(Image img, Size size)
        {
            Bitmap bitmap = new Bitmap(img, Convert.ToInt32(img.Width * size.Width), Convert.ToInt32(img.Height * size.Height));
            Graphics gpu = Graphics.FromImage(bitmap);
            gpu.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bitmap;
        }

        PictureBox org;
        
        private void Zoom_Load(object sender, EventArgs e)
        {
            tBar_Zoom.Minimum = 1;
            tBar_Zoom.Maximum = 6;
            tBar_Zoom.SmallChange = 1;
            tBar_Zoom.LargeChange = 1;
            tBar_Zoom.UseWaitCursor = false;

            this.DoubleBuffered = true;
            org = new PictureBox();
            org.Image = pictureBox1.Image;
        }

        private void tBar_Zoom_Scroll(object sender, EventArgs e)
        {

            if (tBar_Zoom.Value != 0)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = ZoomPicture(org.Image, new Size(tBar_Zoom.Value, tBar_Zoom.Value));
            }
        }

        private void btn_Zoom_Click(object sender, EventArgs e)
        {

        }
    }
}
