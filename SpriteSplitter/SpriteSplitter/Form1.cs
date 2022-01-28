using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteSplitter
{
    public partial class Form1 : Form
    {
        bool imgUploaded;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(imgUploaded)
            {
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    imgUploaded = false;
                    button1.Text = "העלה תמונה";
                    Bitmap[,] imgs = new Bitmap[(int)numY.Value, (int)numX.Value];
                    Bitmap img = new Bitmap(pictureBox1.Image);
                    int w = img.Width / imgs.GetLength(1);
                    int h = img.Height / imgs.GetLength(0);
                    for(int y = 0; y<imgs.GetLength(0); y++)
                    {
                        for(int x = 0; x<imgs.GetLength(1); x++)
                        {
                            
                            imgs[y,x] = img.Clone(new Rectangle(x * w, y * h, w, h), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                            imgs[y, x].Save(saveFileDialog1.FileName +" " + y + "," + x + ".png");
                        }
                    }
                }
            }
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imgUploaded = true;
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                button1.Text = "שמור תמונות";
            }
        }
    }
}
