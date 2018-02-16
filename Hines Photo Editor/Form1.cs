using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Hines_Photo_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        void openimage()
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = file;
                opened = true;
            }
        }


        void filter2()
        {
            if (!opened)
            {
                MessageBox.Show("Open an image then apply changes");

            }
            else
            {

                Image img = pictureBox1.Image;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);


                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]
                {
                    new float[] {.393f, .349f+0.5f, .272f, 0, 0},
                    new float[] {.769f+0.3f, .686f, .534f, 0, 0},
                    new float[] {.189f, .168f, .131f+0.5f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                    g.Dispose();
                pictureBox1.Image = bmpInverted;
                  
            }
        }


        void filter3()
        {
            if (!opened)
            {
                MessageBox.Show("Open an image then apply changes");

            }
            else
            {

                Image img = pictureBox1.Image;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);


                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]
                {
                    new float[] {.53f, .39f, 0, 0, 0},
                    new float[] {.769f+0.3f, .986f, .534f, 0, 0},
                    new float[] {.189f, .168f, 0, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }
        }



        void hue()
        {
            if (!opened)
            {
                MessageBox.Show("Open an image then apply changes");

            }
            else
            {

                Image img = pictureBox1.Image;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);


                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]
                {
                    new float[] {1+(trackBar1.Value), 0, 0, 0, 0},
                    new float[] {0, 1+(trackBar2.Value), 0, 0, 0},
                    new float[] {0, 0, 1+(trackBar3.Value), 0, 0, },
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }
        }

        void reload()
        {
            if (!opened)
            {
               // MessageBox.Show("Open an ImageThen Apply Changes");
            }
            else
            {
                if (opened)
                {
                    file = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = file;
                    opened = true;
                }
            }
        }

        void saveImage()
        {
            if (opened)
            {
                SaveFileDialog sfd = new SaveFileDialog(); // new save file dialog
                sfd.Filter = "Images |*.png;*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Png; //store it by default format
                if(sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox1.Image.Save(sfd.FileName, format);
                }


            }
            else { MessageBox.Show("No Image Loaded, Please Upload Image");  }
        }

        Image file;
        Boolean opened = false; // to check if there is an existing image loaded or not

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            openimage();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reload();
            filter2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reload();
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reload();
            filter3();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Information info1 = new Information();
                info1.Show();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            hue();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            hue();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            hue();
        }
    }
}
