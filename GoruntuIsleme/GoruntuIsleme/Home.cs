using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices.ComTypes;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace GoruntuIsleme
{
    public partial class Home : Form
    {
        private object input_Image;

        public Home()
        {
            InitializeComponent();
        }


        private void btn_SelectedImge_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string a = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(a);
        }
        private void DosyaAc_toolbar_Click(object sender, EventArgs e)
        {
            DosyaAc();
        }

        //DOSYA AÇ -----------------------------
        public void DosyaAc()
        {
            try
            {
                openFileDialog1.DefaultExt = ".jpg";
                openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                openFileDialog1.ShowDialog();
                String path = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(path);
            }
            catch { }
        }
        bool dolu = true;
        bool bos = false;

        private void btn_GrayImge_Click(object sender, EventArgs e)
        {
            /*if(pictureBox1 == bos)
            {
                MessageBox.Show("Bos Gecilemez");
            } */
            
            Color reading_Color, convert_Color;

            Bitmap input_Image = new Bitmap(pictureBox1.Image);
            int image_Width  = input_Image.Width; //GirisResmi global tanımlandı. Fonksiyonla gelmedi.
            int image_Height = input_Image.Height;
            Bitmap output_Image = new Bitmap(image_Width, image_Height); //Cikis resmini
                                                                             // oluşturuyor.Boyutları giriş resmi ile aynı olur.
            int gray_Value = 0;
            for (int x = 0; x < image_Width; x++)
            {
                for (int y = 0; y < image_Height; y++)
                {
                    reading_Color = input_Image.GetPixel(x, y);
                    double R = reading_Color.R;
                    double G = reading_Color.G;
                    double B = reading_Color.B;
                    //GriDeger = Convert.ToInt16((R + G + B) / 3);
                    //RGB Sabit degerleri R=0.299, G=0.587, B=0.114
                    gray_Value = Convert.ToInt16(R * 0.299 + G * 0.587 + B * 0.114);
                    convert_Color = Color.FromArgb(gray_Value, gray_Value, gray_Value);
                    output_Image.SetPixel(x, y, convert_Color);
                }
            }
            pictureBox2.Image = output_Image;
        }

        //Negatif Islem
        private void btn_Negatif_Click(object sender, EventArgs e)
        {
            {
                Color reading_Color, convert_Color;
                int R = 0, G = 0, B = 0;
                Bitmap input_Image, output_Image;
                input_Image = new Bitmap(pictureBox1.Image);
                int image_Width  = input_Image.Width; //GirisResmi global tanımlandı. İçerisine görüntü yüklendi.
                int image_Height = input_Image.Height;
                output_Image = new Bitmap(image_Width, image_Height); //Cikis resmini oluşturuyor.
                                                                          // Boyutları giriş resmi ile aynı olur. Tanımlaması globalde yapıldı.
                int i = 0, j = 0; //Çıkış resminin x ve y si olacak.
                for (int x = 0; x < image_Width; x++)
                {
                    for (int y = 0; y < image_Height; y++)
                    {
                        reading_Color = input_Image.GetPixel(x, y);
                        R = 255 - reading_Color.R;
                        G = 255 - reading_Color.G;
                        B = 255 - reading_Color.B;
                        convert_Color = Color.FromArgb(R, G, B);
                        output_Image.SetPixel(x, y, convert_Color);
                    }
                }
                pictureBox2.Image = output_Image;
            }
        }

        //Netlestrme Islemi
        private void btn_Netting_Click(object sender, EventArgs e)
        {
            Color reading_Color;
            Bitmap input_Image, output_Image;
            input_Image = new Bitmap(pictureBox1.Image);
            int image_Width = input_Image.Width;
            int image_Height  = input_Image.Height;
            output_Image = new Bitmap(image_Width, image_Height);
            int SablonBoyutu = 3;
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y, i, j, toplamR, toplamG, toplamB;
            int R, G, B;
            int[] Matris = { 0, -2, 0, -2, 11, -2, 0, -2, 0 };
            int MatrisToplami = 0 + -2 + 0 + -2 + 11 + -2 + 0 + -2 + 0;
            for (x = (SablonBoyutu - 1) / 2; x < image_Width - (SablonBoyutu - 1) / 2; x++) //Resmi taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacak ve bitirecek.
            {
                for (y = (SablonBoyutu - 1) / 2; y < image_Height - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                    int k = 0; //matris içindeki elemanları sırayla okurken kullanılacak.
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            reading_Color = input_Image.GetPixel(x + i, y + j);
                            toplamR = toplamR + reading_Color.R * Matris[k];
                            toplamG = toplamG + reading_Color.G * Matris[k];
                            toplamB = toplamB + reading_Color.B * Matris[k];
                            k++;
                        }
                    }
                    R = toplamR / MatrisToplami;
                    G = toplamG / MatrisToplami;
                    B = toplamB / MatrisToplami;
                    //===========================================================
                    //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    //===========================================================
                    output_Image.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
            pictureBox2.Image = output_Image;
        }

        private void btn_Histogram_Click(object sender, EventArgs e)
        {
            Histogram show = new Histogram();
            show.Show();
        }

        private void btn_Sobel_Click(object sender, EventArgs e)
        {
            Sobel show = new Sobel();
            show.Show();
        }

        private void btn_Prewitt_Click(object sender, EventArgs e)
        {
            Bitmap input_Image, output_Image;
            input_Image = new Bitmap(pictureBox1.Image);
            int image_Width = input_Image.Width;
            int image_Height  = input_Image.Height;
            output_Image = new Bitmap(image_Width, image_Height);
            int SablonBoyutu = 3;
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y;
            Color Renk;
            int P1, P2, P3, P4, P5, P6, P7, P8, P9;
            for (x = (SablonBoyutu - 1) / 2; x < image_Width - (SablonBoyutu - 1) / 2; x++) //Resmi  taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacak ve bitirecek.
            {
                for (y = (SablonBoyutu - 1) / 2; y < image_Height - (SablonBoyutu - 1) / 2; y++)
                {
                    Renk = input_Image.GetPixel(x - 1, y - 1);
                    P1 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x, y - 1);
                    P2 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x + 1, y - 1);
                    P3 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x - 1, y);
                    P4 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x, y);
                    P5 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x + 1, y);
                    P6 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x - 1, y + 1);
                    P7 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x, y + 1);
                    P8 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x + 1, y + 1);
                    P9 = (Renk.R + Renk.G + Renk.B) / 3;
                    int Gx = Math.Abs(-P1 + P3 - P4 + P6 - P7 + P9); //Dikey çizgileri Bulur
                    int Gy = Math.Abs(P1 + P2 + P3 - P7 - P8 - P9); //Yatay Çizgileri Bulur.
                    int PrewittDegeri = 0;
                    PrewittDegeri = Gx;
                    PrewittDegeri = Gy;
                    PrewittDegeri = Gx + Gy; //1. Formül
                                             //PrewittDegeri = Convert.ToInt16(Math.Sqrt(Gx * Gx + Gy * Gy)); //2.Formül
                                             //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (PrewittDegeri > 255) PrewittDegeri = 255;
                    //Eşikleme: Örnek olarak 100 değeri kullanıldı.
                    //if (PrewittDegeri > 100)
                    //PrewittDegeri = 255;
                    //else
                    //PrewittDegeri = 0;
                    output_Image.SetPixel(x, y, Color.FromArgb(PrewittDegeri, PrewittDegeri, PrewittDegeri));
                }
            }
            pictureBox2.Image = output_Image;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Jpeg Resmi|*.jpg|Bitmap Resmi|*.bmp|Gif Resmi|*.gif";
            saveFileDialog1.Title = "Resmi Kaydet";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "") //Dosya adı boş değilse kaydedecek.
            {
                // FileStream nesnesi ile kayıtı gerçekleştirecek. 
                FileStream DosyaAkisi = (FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        pictureBox2.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
                DosyaAkisi.Close();
            }
        }

        private void bar_RGB_R_Scroll(object sender, EventArgs e)
        {
            lbl_RGB_R.Text = bar_RGB_R.Value.ToString();
            int R = 0, G = 0, B = 0;
            Color reading_Color, convert_Color;
            Bitmap input_Image, output_Image;
            input_Image = new Bitmap(pictureBox1.Image);
            int image_Width  = input_Image.Width;
            int image_Height = input_Image.Height;
            output_Image = new Bitmap(image_Width, image_Height);
           
            int i = 0, j = 0;
            for (int x = 0; x < image_Width; x++)
            {
                j = 0;
                for (int y = 0; y < image_Height; y++)
                {
                    reading_Color = input_Image.GetPixel(x, y);

                    R = reading_Color.R + bar_RGB_R.Value;
                    G = reading_Color.G + bar_RGB_G.Value;
                    B = reading_Color.B + bar_RGB_B.Value;

                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    convert_Color = Color.FromArgb(R, G, B);
                    output_Image.SetPixel(i, j, convert_Color);
                    j++;
                }
                i++;
            }
            pictureBox2.Image = output_Image;
        }

        private void bar_RGB_G_Scroll(object sender, EventArgs e)
        {
            lbl_RGB_G.Text = bar_RGB_G.Value.ToString();
            int R = 0, G = 0, B = 0;
            Color reading_Color, convert_Color;
            Bitmap input_Image, output_Image;
            input_Image = new Bitmap(pictureBox1.Image);
            int image_Width = input_Image.Width;
            int image_Height  = input_Image.Height;
            output_Image = new Bitmap(image_Width, image_Height);

            int i = 0, j = 0;
            for (int x = 0; x < image_Width; x++)
            {
                j = 0;
                for (int y = 0; y < image_Height; y++)
                {
                    reading_Color = input_Image.GetPixel(x, y);

                    R = reading_Color.R + bar_RGB_R.Value;
                    G = reading_Color.G + bar_RGB_G.Value;
                    B = reading_Color.B + bar_RGB_B.Value;

                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    convert_Color = Color.FromArgb(R, G, B);
                    output_Image.SetPixel(i, j, convert_Color);
                    j++;
                }
                i++;
            }
            pictureBox2.Image = output_Image;
        }

        private void bar_RGB_B_Scroll(object sender, EventArgs e)
        {
            lbl_RGB_B.Text = bar_RGB_B.Value.ToString();
            int R = 0, G = 0, B = 0;
            Color reading_Color, convert_Color;
            Bitmap input_Image, output_Image;
            input_Image = new Bitmap(pictureBox1.Image);
            int image_Width = input_Image.Width;
            int image_Height = input_Image.Height;
            output_Image = new Bitmap(image_Width, image_Height);

            int i = 0, j = 0;
            for (int x = 0; x < image_Width; x++)
            {
                j = 0;
                for (int y = 0; y < image_Height; y++)
                {
                    reading_Color = input_Image.GetPixel(x, y);

                    R = reading_Color.R + bar_RGB_R.Value;
                    G = reading_Color.G + bar_RGB_G.Value;
                    B = reading_Color.B + bar_RGB_B.Value;

                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    convert_Color = Color.FromArgb(R, G, B);
                    output_Image.SetPixel(i, j, convert_Color);
                    j++;
                }
                i++;
            }
            pictureBox2.Image = output_Image;
        }

        private void bar_Kontrast_Scroll(object sender, EventArgs e)
        {
            lbl_Kontrast.Text = bar_Kontrast.Value.ToString();
            int R = 0, G = 0, B = 0;
            Color reading_Color, convert_Color;
            Bitmap input_Image, output_Image;
            input_Image = new Bitmap(pictureBox1.Image);
            int image_Width = input_Image.Width;  //GirisResmi global tanımlandı.
            int image_Height = input_Image.Height;
           
            output_Image = new Bitmap(image_Width, image_Height); //Cikis resmini oluşturuyor. Boyutları  giriş resmi ile aynı olur.
            double C_KontrastSeviyesi = bar_Kontrast.Value;
            double F_KontrastFaktoru = (259 * (C_KontrastSeviyesi + 255)) / (255 * (259 -
            C_KontrastSeviyesi));
            for (int x = 0; x < image_Width; x++)
            {
                for (int y = 0; y < image_Height; y++)
                {
                    reading_Color = input_Image.GetPixel(x, y);
                    R = reading_Color.R;
                    G = reading_Color.G;
                    B = reading_Color.B;
                    R = (int)((F_KontrastFaktoru * (R - 128)) + 128);
                    G = (int)((F_KontrastFaktoru * (G - 128)) + 128);
                    B = (int)((F_KontrastFaktoru * (B - 128)) + 128);
                    //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    convert_Color = Color.FromArgb(R, G, B);
                    output_Image.SetPixel(x, y, convert_Color);
                }
            }
            pictureBox2.Image = output_Image;
        }

        private void btn_TersCevirme_Click(object sender, EventArgs e)
        {
            Color reading_Color;
            Bitmap input_Image, output_Image;
            input_Image = new Bitmap(pictureBox1.Image);
            int image_Width = input_Image.Width;
            int image_Height = input_Image.Height;
            output_Image = new Bitmap(image_Width, image_Height);
            double Aci = 360;
            double RadyanAci = Aci * 2 * Math.PI / 180;
            double x2 = 0, y2 = 0;
            int x0 = image_Width / 2;
            int y0 = image_Height / 2;
            for (int x1 = 0; x1 < (image_Width); x1++)
            {
                for (int y1 = 0; y1 < (image_Height); y1++)
                {
                    reading_Color = input_Image.GetPixel(x1, y1);
                    x2 = Convert.ToInt16(x1);
                    y2 = Convert.ToInt16(-y1 + 2 * y0);
                    if (x2 > 0 && x2 < image_Width && y2 > 0 && y2 < image_Height)
                        output_Image.SetPixel((int)x2, (int)y2, reading_Color);
                }
            }
            pictureBox2.Image = output_Image;
        }

        private void btn_Aynalama_Click(object sender, EventArgs e)
        {
            Color reading_Color;
            Bitmap input_Image, output_Image;
            input_Image = new Bitmap(pictureBox1.Image);
            int image_Width = input_Image.Width;
            int image_Height = input_Image.Height;
            output_Image = new Bitmap(image_Width, image_Height);
            double Aci = Convert.ToDouble(90);
            double RadyanAci = Aci * 2 * Math.PI / 360;
            double x2 = 0, y2 = 0;
            //Resim merkezini buluyor. Resim merkezi etrafında döndürecek. 
            int x0 = image_Width / 2;
            int y0 = image_Height / 2;
            for (int x1 = 0; x1 < (image_Width); x1++)
            {
                for (int y1 = 0; y1 < (image_Height); y1++)
                {
                    reading_Color = input_Image.GetPixel(x1, y1);
                    //----A-Orta dikey eksen etrafında aynalama ----------------
                    //x2 = Convert.ToInt16(-x1 + 2 * x0); 
                    //y2 = Convert.ToInt16(y1);
                    //----B-Orta yatay eksen etrafında aynalama ----------------
                    //x2 = Convert.ToInt16(x1);
                    //y2 = Convert.ToInt16(-y1 + 2 *y0);

                    //----C-Ortadan geçen 45 açılı çizgi etrafında aynalama----------
                    double Delta = (x1 - x0) * Math.Sin(RadyanAci) - (y1 - y0) * Math.Cos(RadyanAci);
                    x2 = Convert.ToInt16(x1 + 2 * Delta * (-Math.Sin(RadyanAci)));
                    y2 = Convert.ToInt16(y1 + 2 * Delta * (Math.Cos(RadyanAci)));
                    if (x2 > 0 && x2 < image_Width && y2 > 0 && y2 < image_Height)
                        output_Image.SetPixel((int)x2, (int)y2, reading_Color);
                }
            }
            pictureBox2.Image = output_Image;
        }

        private void btn_Netlestirme_Click(object sender, EventArgs e)
        {
            Color reading_Color;
            Bitmap input_Image, output_Image;
            input_Image = new Bitmap(pictureBox1.Image);
            int image_Width = input_Image.Width;
            int image_Height = input_Image.Height;
            output_Image = new Bitmap(image_Width, image_Height);
            int SablonBoyutu = 3;
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y, i, j, toplamR, toplamG, toplamB;
            int R, G, B;
            int[] Matris = { 0, -2, 0, -2, 11, -2, 0, -2, 0 };
            int MatrisToplami = 0 + -2 + 0 + -2 + 11 + -2 + 0 + -2 + 0;
            for (x = (SablonBoyutu - 1) / 2; x < image_Width - (SablonBoyutu - 1) / 2; x++) //Resmi taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacak ve bitirecek.
            {
                for (y = (SablonBoyutu - 1) / 2; y < image_Height - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                    int k = 0; //matris içindeki elemanları sırayla okurken kullanılacak.
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            reading_Color = input_Image.GetPixel(x + i, y + j);
                            toplamR = toplamR + reading_Color.R * Matris[k];
                            toplamG = toplamG + reading_Color.G * Matris[k];
                            toplamB = toplamB + reading_Color.B * Matris[k];
                            k++;
                        }
                    }
                    R = toplamR / MatrisToplami;
                    G = toplamG / MatrisToplami;
                    B = toplamB / MatrisToplami;
                    //===========================================================
                    //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    //===========================================================
                    output_Image.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
            pictureBox2.Image = output_Image;
        }

        private void btn_Parlaklik_Click(object sender, EventArgs e)
        {
            int R = 0, G = 0, B = 0;
            Color reading_Color, convert_Image;
            Bitmap input_Image, output_Image;
            input_Image = new Bitmap(pictureBox1.Image);
            int image_Width = input_Image.Width;
            int image_Height = input_Image.Height;
            output_Image = new Bitmap(image_Width, image_Height); //Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur.
            int i = 0, j = 0; //Çıkış resminin x ve y si olacak.
            for (int x = 0; x < image_Width; x++)
            {
                j = 0;
                for (int y = 0; y < image_Height; y++)
                {
                    reading_Color = input_Image.GetPixel(x, y);
                    //Rengini 50 değeri ile açacak.
                    R = reading_Color.R + 50;
                    G = reading_Color.G + 50;
                    B = reading_Color.B + 50;
                    //Renkler 255 geçtiyse son sınır olan 255 alınacak.
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    convert_Image = Color.FromArgb(R, G, B);
                    output_Image.SetPixel(i, j, convert_Image);
                    j++;
                }
                i++;
            }
            pictureBox2.Image = output_Image;
        }

        private void btn_Zoom_Click(object sender, EventArgs e)
        {
            Zoom z_Open = new Zoom();
            z_Open.Show();
        }

        private void btn_Zoomout_Click(object sender, EventArgs e)
        {
            int R = 0, G = 0, B = 0;
            Color reading_Color, convert_Image;
            Bitmap input_Image, output_Image;
            input_Image = new Bitmap(pictureBox1.Image);
            int image_Width = input_Image.Width;
            int image_Height = input_Image.Height;
            output_Image = new Bitmap(image_Width, image_Height); //Cikis resminin boyutları
            int x2 = 0, y2 = 0; //Çıkış resminin x ve y si olacak.
            int KucultmeKatsayisi = 2;
            for (int x1 = 0; x1 < image_Width; x1 = x1 + KucultmeKatsayisi)
            {
                y2 = 0;
                for (int y1 = 0; y1 < image_Height; y1 = y1 + KucultmeKatsayisi)
                {
                    //x ve y de ilerlerken her atlanan pikselleri okuyacak ve ortalama değerini alacak.
                    R = 0; G = 0; B = 0;
                    try //resim sınırının dışına çıkaldığında hata vermesin diye
                    {
                        for (int i = 0; i < KucultmeKatsayisi; i++)
                        {
                            for (int j = 0; j < KucultmeKatsayisi; j++)
                            {
                                reading_Color = input_Image.GetPixel(x1 + i, y1 + j);
                                R = R + reading_Color.R;
                                G = G + reading_Color.G;
                                B = B + reading_Color.B;
                            }
                        }
                    }
                    catch { }
                    //Renk kanallarının ortalamasını alıyor
                    R = R / (KucultmeKatsayisi * KucultmeKatsayisi);
                    G = G / (KucultmeKatsayisi * KucultmeKatsayisi);
                    B = B / (KucultmeKatsayisi * KucultmeKatsayisi);
                    convert_Image = Color.FromArgb(R, G, B);
                    output_Image.SetPixel(x2, y2, convert_Image);
                    y2++;
                }
                x2++;
            }
            pictureBox2.Image = output_Image;
        }

        private void btn_Converted_Click(object sender, EventArgs e)
        {
            
            Bitmap input_Image, output_Image;
            input_Image = new Bitmap(pictureBox1.Image);
            int image_Width = input_Image.Width;
            int image_Height = input_Image.Height;
            output_Image = new Bitmap(image_Width, image_Height);
            int x, y;
            Color Renk;
            int P1, P2, P3, P4, P5, P6, P7, P8, P9;
            int GM, G;
            int[,] Matris = { { -1, 0, 1, -1, 0, 1, -1, 0, 1 }, { 0, 1, 1, -1, 0, 1, -1, -1, 0 }, { 1,
                   1, 1, 0, 0, 0, -1, -1, -1 }, { 1, 1, 0, 1, 0, -1, 0, -1, -1 }, { 1, 0, -1, 1, 0, -1, 1, 0, -1 },
                         { 0, -1, -1, 1, 0, -1, 1, 1, 0 }, {-1, -1, -1, 0, 0, 0, 1, 1, 1 }, {-1, -1, 0, -1, 0, 1, 0, 1, 1
                   } }; // Robinson Matrisi
            for (x = 1; x < image_Width - 1; x++) //Resmi taramaya şablonun yarısı kadar dış  kenarlardan içeride başlayacak ve bitirecek.
            {
                for (y = 1; y < image_Height - 1; y++)
                {
                    Renk = input_Image.GetPixel(x - 1, y - 1);
                    P1 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x, y - 1);
                    P2 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x + 1, y - 1);
                    P3 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x - 1, y);
                    P4 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x, y);
                    P5 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x + 1, y);
                    P6 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x - 1, y + 1);
                    P7 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x, y + 1);
                    P8 = (Renk.R + Renk.G + Renk.B) / 3;
                    Renk = input_Image.GetPixel(x + 1, y + 1);
                    P9 = (Renk.R + Renk.G + Renk.B) / 3;
                    GM = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        G = Math.Abs(P1 * Matris[i, 0] + P2 * Matris[i, 1] + P3 * Matris[i, 2] + P4 *
                       Matris[i, 3] + P5 * Matris[i, 4] + P6 * Matris[i, 5] + P7 * Matris[i, 6] + P8 * Matris[i, 7] +
                       P9 * Matris[i, 8]);
                        if (G > GM) GM = G;
                    }
                    if (GM > 50)
                        output_Image.SetPixel(x, y, Color.Yellow);
                    else
                        output_Image.SetPixel(x, y, Color.Black);
                }
            }
            pictureBox2.Image = output_Image;
        }

        private void btn_Perspective_Click(object sender, EventArgs e)
        {
            Perspective p_Open = new Perspective();
            p_Open.Show();
        }

        private void btn_Karsitlik_Click(object sender, EventArgs e)
        {
            Karisitlik k_Open = new Karisitlik();
            k_Open.Show();
                
        }

        private void btn_Oteleme_Click(object sender, EventArgs e)
        {

            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            double x2 = 0, y2 = 0;              //Taşıma mesafelerini atıyor.
            int Tx = 50;
            int Ty = 25;
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);
                    x2 = x1 + Tx;
                    y2 = y1 + Ty;
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void btn_Medin_Click(object sender, EventArgs e)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = Convert.ToInt32(txt_Medin.Text); //şablon boyutu 3 den büyük tek rakam   olmalıdır(3, 5, 7 gibi).
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R;
                            toplamG = toplamG + OkunanRenk.G;
                            toplamB = toplamB + OkunanRenk.B;
                        }
                    }
                    ortalamaR = toplamR / (SablonBoyutu * SablonBoyutu);
                    ortalamaG = toplamG / (SablonBoyutu * SablonBoyutu);
                    ortalamaB = toplamB / (SablonBoyutu * SablonBoyutu);



                    CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void bar_Dondur_Scroll(object sender, EventArgs e)
        {
            lbl_Dondur.Text = bar_Dondur.Value.ToString();
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int Aci = bar_Dondur.Value;
            double RadyanAci = Aci * 2 * Math.PI / 360;
            double x2 = 0, y2 = 0;
            //Resim merkezini buluyor. Resim merkezi etrafında döndürecek. 
            int x0 = ResimGenisligi / 2;
            int y0 = ResimYuksekligi / 2;
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);
                    //Aliaslı Döndürme -Sağa Kaydırma
                    x2 = (x1 - x0) - Math.Tan(RadyanAci / 2) * (y1 - y0) + x0;
                    y2 = (y1 - y0) + y0;
                    x2 = Convert.ToInt16(x2);
                    y2 = Convert.ToInt16(y2);
                    //Aliaslı Döndürme -Aşağı kaydırma
                    x2 = (x2 - x0) + x0;
                    y2 = Math.Sin(RadyanAci) * (x2 - x0) + (y2 - y0) + y0;
                    x2 = Convert.ToInt16(x2);
                    y2 = Convert.ToInt16(y2);
                    //Aliaslı Döndürme -Sağa Kaydırma
                    x2 = (x2 - x0) - Math.Tan(RadyanAci / 2) * (y2 - y0) + x0;
                    y2 = (y2 - y0) + y0;
                    x2 = Convert.ToInt16(x2);
                    y2 = Convert.ToInt16(y2);
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void bar_Pazalt_Scroll(object sender, EventArgs e)
        {
            lbl_Azalt.Text = bar_Pazalt.Value.ToString();
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. Boyutları giriş resmi

            int i = 0, j = 0; //Çıkış resminin x ve y si olacak.
            for (int x = 0; x < ResimGenisligi; x++)
            {
                j = 0;
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    //Rengini 50 değeri ile açacak.
                    R = OkunanRenk.R - bar_Pazalt.Value;
                    G = OkunanRenk.G - bar_Pazalt.Value;
                    B = OkunanRenk.B - bar_Pazalt.Value;
                    //Renkler 255 geçtiyse son sınır olan 255 alınacak.
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(i, j, DonusenRenk);
                    j++;
                }
                i++;
            }
            pictureBox2.Image = CikisResmi;
        }

        private void bar_Pcogalt_Scroll(object sender, EventArgs e)
        {
            lbl_Cogalt.Text = bar_Pcogalt.Value.ToString();
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. Boyutları giriş resmi

            int i = 0, j = 0; //Çıkış resminin x ve y si olacak.
            for (int x = 0; x < ResimGenisligi; x++)
            {
                j = 0;
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    //Rengini 50 değeri ile açacak.
                    R = OkunanRenk.R + bar_Pcogalt.Value;
                    G = OkunanRenk.G + bar_Pcogalt.Value;
                    B = OkunanRenk.B + bar_Pcogalt.Value;
                    //Renkler 255 geçtiyse son sınır olan 255 alınacak.
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(i, j, DonusenRenk);
                    j++;
                }
                i++;
            }
            pictureBox2.Image = CikisResmi;
        }

        private void txt_Medin_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar){
                case '1': 
                case '2': 
                case '3': 
                case '4': 
                case '5': 
                case '6': 
                case '7': 
                case '8': 
                case '9': 
                case '0':
                case '\b':
                    break;
                    default: 
                    e.Handled= true;
                    break;



            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gontrast_Germe g_Open = new Gontrast_Germe();
            g_Open.Show();
        }

        private void btn_Laplace_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(pictureBox1.Image);
            Bitmap image = new Bitmap(img);
            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    Color color2, color4, color5, color6, color8;
                    color2 = image.GetPixel(x, y - 1);
                    color4 = image.GetPixel(x - 1, y);
                    color5 = image.GetPixel(x, y);
                    color6 = image.GetPixel(x + 1, y);
                    color8 = image.GetPixel(x, y + 1);
                    int r = color2.R + color4.R + color5.R * (-4) + color6.R + color8.R;
                    int g = color2.G + color4.G + color5.G * (-4) + color6.G + color8.G;
                    int b = color2.B + color4.B + color5.B * (-4) + color6.B + color8.B;
                    int avg = (r + g + b) / 3;
                    if (avg > 255) avg = 255;
                    if (avg < 0) avg = 0;
                    image.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
            pictureBox2.Image = image;
        }

        private void btn_Gaus_Click(object sender, EventArgs e)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 5; //Çekirdek matrisin boyutu
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;
            int[] Matris = { 1, 4, 7, 4, 1, 4, 20, 33, 20, 4, 7, 33, 55, 33, 7, 4, 20, 33, 20, 4, 1, 4, 7, 4, 1 };
            int MatrisToplami = 1 + 4 + 7 + 4 + 1 + 4 + 20 + 33 + 20 + 4 + 7 + 33 + 55 + 33 + 7 + 4 + 20 +
           33 + 20 + 4 + 1 + 4 + 7 + 4 + 1;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            //Resmi taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacak ve bitirecek.
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                    int k = 0; //matris içindeki elemanları sırayla okurken kullanılacak.
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R * Matris[k];
                            toplamG = toplamG + OkunanRenk.G * Matris[k];
                            toplamB = toplamB + OkunanRenk.B * Matris[k];
                            k++;
                        }
                    }
                    ortalamaR = toplamR / MatrisToplami;
                    ortalamaG = toplamG / MatrisToplami;
                    ortalamaB = toplamB / MatrisToplami;
                    CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void btn_HisEsitleme_Click(object sender, EventArgs e)
        {
            H_Esitleme H_Open = new H_Esitleme();
            H_Open.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
