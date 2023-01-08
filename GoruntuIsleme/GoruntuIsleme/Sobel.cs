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
    public partial class Sobel : Form
    {
        public Sobel()
        {
            InitializeComponent();
        }

        private void btn_Sobel_Click(object sender, EventArgs e)
        {
            Bitmap input_Imge, output_ImgeXY, output_ImgeX, output_ImgeY;
            input_Imge = new Bitmap(pictureBox1.Image);
            int image_Width = input_Imge.Width; //Resim Genisligi
            int image_Height = input_Imge.Height; //Resim Yuksekligi
            output_ImgeX =  new Bitmap(image_Width, image_Height);
            output_ImgeY =  new Bitmap(image_Width, image_Height);
            output_ImgeXY = new Bitmap(image_Width, image_Height);
            int template_Size = 3; //SablonBoyutu
            int item_Number = template_Size * template_Size;
            int x, y;
            Color colors;
            int P1, P2, P3, P4, P5, P6, P7, P8, P9;
            for (x = (template_Size - 1) / 2; x < image_Width - (template_Size - 1) / 2; x++) //Re  taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacak ve bitirecek.
            {
                for (y = (template_Size - 1) / 2; y < image_Height - (template_Size - 1) / 2; y++)
                {
                    colors = input_Imge.GetPixel(x - 1, y - 1);
                    P1 = (colors.R + colors.G + colors.B) / 3;
                    colors = input_Imge.GetPixel(x, y - 1);
                    P2 = (colors.R + colors.G + colors.B) / 3;
                    colors = input_Imge.GetPixel(x + 1, y - 1);
                    P3 = (colors.R + colors.G + colors.B) / 3;
                    colors = input_Imge.GetPixel(x - 1, y);
                    P4 = (colors.R + colors.G + colors.B) / 3;
                    colors = input_Imge.GetPixel(x, y);
                    P5 = (colors.R + colors.G + colors.B) / 3;
                    colors = input_Imge.GetPixel(x + 1, y);
                    P6 = (colors.R + colors.G + colors.B) / 3;
                    colors = input_Imge.GetPixel(x - 1, y + 1);
                    P7 = (colors.R + colors.G + colors.B) / 3;
                    colors = input_Imge.GetPixel(x, y + 1);
                    P8 = (colors.R + colors.G + colors.B) / 3;
                    colors = input_Imge.GetPixel(x + 1, y + 1);
                    P9 = (colors.R + colors.G + colors.B) / 3;
                    //Hesaplamayı yapan Sobel Temsili matrisi ve formülü.
                    int Gx = Math.Abs(-P1 + P3 - 2 * P4 + 2 * P6 - P7 + P9); //Dikey çizgiler
                    int Gy = Math.Abs(P1 + 2 * P2 + P3 - P7 - 2 * P8 - P9); //Yatay Çizgiler

                    int Gxy = Gx + Gy;
                    //if (Gxy > Esikleme)
                    // Gxy = 255;
                    //else
                    // Gxy = 0;
                    //Renkler sınırların dışına çıktıysa, sınır değer alınacak. Negatif olamaz,  formüllerde mutlak değer vardır.
                    if (Gx > 255) Gx = 255;
                    if (Gy > 255) Gy = 255;
                    if (Gxy > 255) Gxy = 255;
                    
                    output_ImgeX.SetPixel(x, y, Color.FromArgb(Gx, Gx, Gx));
                    output_ImgeY.SetPixel(x, y, Color.FromArgb(Gy, Gy, Gy));
                    output_ImgeXY.SetPixel(x, y, Color.FromArgb(Gxy, Gxy, Gxy));
                }
            }
            pictureBox2.Image = output_ImgeXY;
            pictureBox3.Image = output_ImgeX;
            pictureBox4.Image = output_ImgeY;


        }
    }
}


















//int TetaRadyan = 0;
//if (Gy != 0)
// TetaRadyan = Convert.ToInt32(Math.Atan(Gx / Gy));
//else
// TetaRadyan = Convert.ToInt32(Math.Atan(Gx));
//int TetaDerece = Convert.ToInt32((TetaRadyan * 360) / (2 * Math.PI));
//if (TetaDerece >= 0 && TetaDerece < 45)
// CikisResmiXY.SetPixel(x, y, Color.FromArgb(0, 0, 0));
//if (TetaDerece >= 45 && TetaDerece < 90)
// CikisResmiXY.SetPixel(x, y, Color.FromArgb(0, 255, 0));
//if (TetaDerece >= 90 && TetaDerece < 135)
// CikisResmiXY.SetPixel(x, y, Color.FromArgb(0, 0, 255));
//if (TetaDerece >= 135 && TetaDerece < 180)
// CikisResmiXY.SetPixel(x, y, Color.FromArgb(255, 255, 0));
