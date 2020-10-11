using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tree
{
    public partial class Form1 : Form
    {
        int counter = 0;
        Bitmap pic;
        Color col ;
        Color white ;
        public Form1()
        {
            InitializeComponent();
            pic = new Bitmap(pictureBox1.Image);
            col = new Color();
            white = new Color();
            white=Color.FromArgb(255,255,255);
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    col = pic.GetPixel(j, i);
                    if (col.R+col.G+col.B>710)
                        pic.SetPixel( j, i,white);
                    else
                        pic.SetPixel(j, i, col);
                }
            }
            pictureBox1.Image = pic;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Color green= new Color();
            green = Color.FromArgb(20, 105, 46);
            for (int i = counter; i < counter+10; i++)
            {
                for (int j = 0; j < pic.Height-90; j++)
                {
                    col = pic.GetPixel(i, j);
                    if (col.R + col.G + col.B < 710)
                        pic.SetPixel(i, j, green);
                }
            }
            counter +=10;
            if (counter+10>=pic.Width)
            {
                this.Close();
            }
            pictureBox1.Image = pic;
        }
    }
}
