using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CropImage
{
    // TODO : 비트맵 이미지 파일에서 사용자가 마우스로 드래그앤 드롭하여 이미지 자르기 구현 (2024.06.18 jbh)
    // 유튜브 참고 URL - https://youtu.be/Q63GV5tnXN0?si=TZgD_kRqTN0fWW97
    // 소스코드 참고 URL - https://csharp.agrimetsoft.com/exercises/PictureBox_Crop_Image

    public partial class CropImageForm : Form
    {
        #region 프로퍼티

        int xDown = 0;
        int yDown = 0;
        int xUp = 0;
        int yUp = 0;
        Task timeout;
        Rectangle rectCropArea = new Rectangle();
        string fileName = "";

        #endregion 프로퍼티

        #region 생성자

        public CropImageForm()
        {
            InitializeComponent();
        }

        #endregion 생성자

        #region btnSelect_Click

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName); // pictureBox1에 읽어온 비트맵 이미지 파일로 채우기 
                fileName = opf.FileName;
            }
            pictureBox1.Cursor = Cursors.Cross;
        }

        #endregion btnSelect_Click

        #region pictureBox1_MouseUp

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(MouseButtons.Left == e.Button)
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
                btnCrop.Enabled = true;
            }
        }

        #endregion pictureBox1_MouseUp

        #region pictureBox1_MouseDown

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(MouseButtons.Left == e.Button)
            {
                pictureBox1.Refresh();

                xDown = e.X;
                yDown = e.Y;
                btnCrop.Enabled = true;
            }
        }

        #endregion pictureBox1_MouseDown

        #region btnCrop_Click

        private void btnCrop_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Refresh();

                // Prepare a new Bitmap on which the cropped image will be drawn 
                Bitmap sourceBitmap = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                Graphics g = pictureBox2.CreateGraphics();

                // TODO : 자른 이미지를 고해상도로 그리기 위해 InterpolationMode 열거형 구조체 멤버 HighQualityBicubic 사용 (2024.06.21 jbh)
                // 참고 URL - https://learn.microsoft.com/ko-kr/dotnet/api/system.drawing.drawing2d.interpolationmode?view=net-8.0&viewFallbackFrom=dotnet-plat-ext-8.0
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Draw the image on the Graphics object with the new dimensions
                g.DrawImage(sourceBitmap, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height), rectCropArea, GraphicsUnit.Pixel);
                sourceBitmap.Dispose();
                btnCrop.Enabled = false;
                var path = Environment.CurrentDirectory.ToString();
                //ms = new System.IO.MemoryStream();
                //pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //byte[] ar = new byte[ms.Length];
            }
            catch(Exception ex)
            { 
            
            }
        }

        #endregion btnCrop_Click
    }
}
