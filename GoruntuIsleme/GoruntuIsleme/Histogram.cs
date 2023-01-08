using System;
using System.Collections;
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
    public partial class Histogram : Form
    {
        public Histogram()
        {
            InitializeComponent();
        }

        private void btn_SelectionImge_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string a = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(a);
        }

        private void btn_Histogram_Click(object sender, EventArgs e)
        {

            ArrayList ArryPixel = new ArrayList();
            int average_Color = 0; //Ortalama Renk
            Color reading_Color; // Okunan Renk
            int R = 0, G = 0, B = 0;
            Bitmap input_Imge; //Histogram için giriş resmi gri-ton olmalıdır.
            input_Imge = new Bitmap(pictureBox1.Image);
            int image_Width = input_Imge.Width; //GirisResmi global tanımlandı.
            int image_Hieght = input_Imge.Height;
            int i = 0; //piksel sayısı tutulacak.
            for (int x = 0; x < input_Imge.Width; x++)
            {
                for (int y = 0; y < input_Imge.Height; y++)
                {
                    reading_Color = input_Imge.GetPixel(x, y);
                    average_Color = (int)(reading_Color.R + reading_Color.G + reading_Color.B) / 3; //Griton resimde üç kanal  rengi aynı değere sahiptir.
                    ArryPixel.Add(average_Color); //Resimdeki tüm noktaları diziye atıyor. 
                }
            }
            int[] ArrayPixelCounts = new int[256]; //Dizi Piksel Sayilari
            for (int r = 0; r <= 255; r++) //256 tane renk tonu için dönecek.
            {
                int PixelValue = 0; //PikselSayisi
                for (int s = 0; s < ArryPixel.Count; s++) //resimdeki piksel sayısınca dönecek. 
                {
                    if (r == Convert.ToInt16(ArryPixel[s]))
                        PixelValue++;
                }
                ArrayPixelCounts[r] = PixelValue;
            }
            //Değerleri listbox'a ekliyor. 
            int colorMaxPixelCount = 0; //Grafikte y eksenini ölçeklerken kullanılacak. 
            for (int k = 0; k <= 255; k++)
            {
                listBox1.Items.Add("Color : " + k + " = " + ArrayPixelCounts[k] + " Pixel");
                //Maksimum piksel sayısını bulmaya çalışıyor.
                if (ArrayPixelCounts[k] > colorMaxPixelCount)
                {
                    colorMaxPixelCount = ArrayPixelCounts[k];
                }
            }
            //Grafiği çiziyor. 
            Graphics drawing_Arrys;
            Pen Pen01 = new Pen(System.Drawing.Color.Black, 1);
            Pen Pen02 = new Pen(System.Drawing.Color.Red, 1);
            drawing_Arrys = pictureBox2.CreateGraphics();
            pictureBox2.Refresh();
            int graphic_Height = 300; //Grafik Yuksekligi
            double OlcekY = colorMaxPixelCount / graphic_Height;
            double OlcekX = 1.5;
            int X_kaydirma = 10;
            for (int x = 0; x <= 255; x++)
            {
                if (x % 50 == 0)
                    drawing_Arrys.DrawLine(Pen02, (int)(X_kaydirma + x * OlcekX),
                   graphic_Height, (int)(X_kaydirma + x * OlcekX), 0);
                drawing_Arrys.DrawLine(Pen01, (int)(X_kaydirma + x * OlcekX), graphic_Height,
               (int)(X_kaydirma + x * OlcekX), (graphic_Height - (int)(ArrayPixelCounts[x] / OlcekY)));
                //Dikey kırmızı çizgiler.

            }
            //Texte maksimum piksel sayisini yaz
            txt_MaxPixel.Text = "Max.Pixels=" + colorMaxPixelCount.ToString(); 
        }
    }
}
