﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureBox_Crop_Image
{
    public partial class Form1 : Form
    {
        int xDown = 0;
        int yDown = 0;
        int xUp = 0;
        int yUp = 0;
        Rectangle rectCropArea = new Rectangle();
        // System.IO.MemoryStream ms = new System.IO.MemoryStream();
        // Task timeout;
        string fn = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void selectIm_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                fn = opf.FileName;
            }
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //pictureBox1.Image.Clone();
            if (MouseButtons.Left == e.Button)
            {
                // pictureBox1.Image.Clone();
                xUp = e.X;
                yUp = e.Y;
                Rectangle rec = new Rectangle(xDown, yDown, Math.Abs(xUp - xDown), Math.Abs(yUp - yDown));
                using (Pen pen = new Pen(Color.YellowGreen, 3))
                {
                    pictureBox1.CreateGraphics().DrawRectangle(pen, rec);
                }
                rectCropArea = rec;
                crop.Enabled = true;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(MouseButtons.Left == e.Button)
            {
                pictureBox1.Refresh();

                xDown = e.X;
                yDown = e.Y;
                crop.Enabled = true;
            }
        }

        private void crop_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("해당 이미지 자르기 진행할까요?", "이미지 편집", MessageBoxButtons.YesNo);

                if(DialogResult.Yes == dialogResult)
                {
                    pictureBox2.Refresh();
                    //Prepare a new Bitmap on which the cropped image will be drawn
                    Bitmap sourceBitmap = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                    Graphics g = pictureBox2.CreateGraphics();

                    // TODO : 자른 이미지를 고해상도로 그리기 위해 InterpolationMode 열거형 구조체 멤버 HighQualityBicubic 사용 (2024.06.21 jbh)
                    // 참고 URL - https://learn.microsoft.com/ko-kr/dotnet/api/system.drawing.drawing2d.interpolationmode?view=net-8.0&viewFallbackFrom=dotnet-plat-ext-8.0
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;


                    //Draw the image on the Graphics object with the new dimesions
                    //g.DrawImage(sourceBitmap, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height), rectCropArea, GraphicsUnit.Pixel);
                    g.DrawImage(sourceBitmap, new Rectangle(0, 0, rectCropArea.Width, rectCropArea.Height), rectCropArea, GraphicsUnit.Pixel);
                    sourceBitmap.Dispose();
                    crop.Enabled = false;
                    var path = Environment.CurrentDirectory.ToString();
                    // ms = new System.IO.MemoryStream();
                    // pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    // byte[] ar = new byte[ms.Length];
                    // var timeout = ms.WriteAsync(ar, 0, ar.Length);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
