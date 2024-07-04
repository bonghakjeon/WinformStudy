using System;
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
        /// <summary>
        /// 마우스로 이미지 자르기 실행 여부(드래그앤드롭) 
        /// </summary>
        private bool IsDragging { get; set; }

        int xDown = 0;
        int yDown = 0;
        //int xUp = 0;
        //int yUp = 0;
        int xMove = 0;
        int yMove = 0;
        Rectangle rectCropArea = new Rectangle();
        // System.IO.MemoryStream ms = new System.IO.MemoryStream();
        // Task timeout;
        string fn = "";
        public Form1()
        {
            InitializeComponent();
            InitSetting();
        }

        /// <summary>
        /// 화면 초기화 셋팅 
        /// </summary>
        private void InitSetting()
        {
            IsDragging = false;   // 마우스로 이미지 자르기 실행 여부 초기화
        }

        private void selectIm_Click(object sender, EventArgs e)
        {
            // this.Invalidate();
            // this.Refresh();
            // this.Controls.Clear();

            OpenFileDialog opf = new OpenFileDialog();
            if(opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Refresh();

                // opf.FileName;
                pictureBox1.Image = Image.FromFile(opf.FileName);
                fn = opf.FileName;

                IsDragging = false;
            }
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(true == IsDragging && MouseButtons.Left == e.Button)
            {
                // pictureBox1.Image.Clone();
                pictureBox1.Refresh();
                IsDragging = false;

                // xUp = e.X;
                // yUp = e.Y;
                // Rectangle rec = new Rectangle(xDown, yDown, Math.Abs(xUp - xDown), Math.Abs(yUp - yDown));
                //using (Pen pen = new Pen(Color.YellowGreen, 3))
                //{
                //    pictureBox1.CreateGraphics().DrawRectangle(pen, rec);
                //}
                // rectCropArea = rec;
                // crop.Enabled = true;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(MouseButtons.Left == e.Button)
            {
                pictureBox1.Refresh();

                IsDragging = true;

                xDown = e.X;
                yDown = e.Y;
                crop.Enabled = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(true == IsDragging && MouseButtons.Left == e.Button)
            {
                // pictureBox1.Image.Clone();
                pictureBox1.Refresh();

                xMove = e.X;
                yMove = e.Y;
                Rectangle rec = new Rectangle(xDown, yDown, Math.Abs(xMove - xDown), Math.Abs(yMove - yDown));
                //using (Pen pen = new Pen(Color.YellowGreen, 3))
                //{
                //    pictureBox1.CreateGraphics().DrawRectangle(pen, rec);
                //}
                rectCropArea = rec;
                crop.Enabled = true;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(true == IsDragging)
            {
                using(Pen pen = new Pen(Color.YellowGreen, 3))
                {
                    //pictureBox1.CreateGraphics().DrawRectangle(pen, rectCropArea);
                    e.Graphics.DrawRectangle(pen, rectCropArea);
                }
            }
        }

        private void crop_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("해당 이미지 자르기 진행할까요?", "이미지 자르기", MessageBoxButtons.YesNo);

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
                    // g.DrawImage(sourceBitmap, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height), rectCropArea, GraphicsUnit.Pixel);
                    g.DrawImage(sourceBitmap, new Rectangle(0, 0, rectCropArea.Width, rectCropArea.Height), rectCropArea, GraphicsUnit.Pixel);
                    sourceBitmap.Dispose();
                    crop.Enabled = false;
                    // var path = Environment.CurrentDirectory.ToString();

                    pictureBox1.Refresh();

                    // TODO : 아래 주석친 코드 필요시 사용 예정 (2024.06.25 jbh)
                    // pictureBox1.Image.Dispose();
                    // pictureBox1.Image = Image.FromFile(fn);
                    // pictureBox1.Refresh();

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

        private void btnBlackConvert_Click(object sender, EventArgs e)
        {
            // bool result = true;
            int average = 0;                 // RGB 색상값 평균
            Color orgColor = Color.White;    // 특정 픽셀의 기존 RGB 색상
            Color grayColor = Color.Black;   // 특정 픽셀의 흑백 전환 RGB 색상

            try
            {
                pictureBox1.Refresh();
                pictureBox2.Refresh();

                // 테스트 기능 - 흑백 전환 
                // 1. 흑백 전환할 원본 이미지(OrgImage) 불러오기
                // EditImage = OrgImage;
                Bitmap blackConvertBmp = pictureBox1.Image as Bitmap;
                // BlackConvertBmp = OrgImage as Bitmap;

                // 2. for문 돌면서 이미지 흑백 전환 처리 
                // x - 흑백 전환할 비트맵 객체 blackConvertBmp의 너비(Width)
                // y - 흑백 전환할 비트맵 객체 blackConvertBmp의 높이(Height)
                for(int x = 0; x < blackConvertBmp.Width; x++)
                {
                    for(int y = 0; y < blackConvertBmp.Height; y++)
                    {
                        // 3. 흑백 전환할 비트맵 객체 blackConvertBmp에 존재하는 특정 픽셀의 기존 RGB 색상을 가져오기
                        orgColor = blackConvertBmp.GetPixel(x, y);
                        average = (orgColor.R + orgColor.G + orgColor.B) / 3;   // orgColor의 RGB 색상값 평균 구하기 

                        // 4. 흑백 전환 RGB 색상 가져오기
                        // 메서드 FromArgb 호출해서 RGB 색상을 흑백으로 바꾸는 수식 적용
                        grayColor = Color.FromArgb(average, average, average);

                        // 5. 흑백 전환할 비트맵 객체 blackConvertBmp의 특정 픽셀의 RGB 색상을 흑백으로 설정 
                        blackConvertBmp.SetPixel(x, y, grayColor);
                    }
                }

                // 6. 이진화 처리 
                // BinaryConvert(ref blackConvertBmp);
                // EditImage = blackConvertBmp;

                // 7. 흑백 전환 + 이진화 처리 완료한 비트맵 객체 blackConvertBmp를 원본 이미지 pictureBoxEditImage의 Image 속성에 할당 
                //pictureBoxOrgImage.Image = OrgImage;
                pictureBox2.Image = blackConvertBmp;

                this.Activate();   // 메시지 박스 종료(TaskDialog.Show)후 부모 폼(ImageForm.cs) 다시 활성화


                // TODO : 이미지 흑백 전환 기능 구현 (2024.07.04 jbh)
                // MS 공식 문서
                // GetPixel 참고 URL - http://msdn.microsoft.com/ko-kr/library/system.drawing.bitmap.getpixel(v=vs.110).aspx 
                // SetPixel 참고 URL - http://msdn.microsoft.com/ko-kr/library/system.drawing.bitmap.setpixel(v=vs.110).aspx 
                // FromArgb 참고 URL - http://msdn.microsoft.com/en-us/library/cce5h557(v=vs.110).aspx 

                // 블로그 문서 
                // 참고 URL - https://tctt.tistory.com/129
                // 참고 2 URL - https://blog.naver.com/nersion/140141133683
                // 참고 3 URL - https://blog.naver.com/PostView.naver?blogId=kgg1959&logNo=30182499708
                // 참고 4 URL - https://son10001.blogspot.com/2014/04/blog-post_14.html

                // ChatGPT 문서
                // 참고 URL - https://chatgpt.com/c/772919c6-4936-4b8d-b796-0a4b4d02e6ef




                // DisplaySetting(RevitBoxHelper.TypeOfBlackConvert, OrgImageFilePath);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
