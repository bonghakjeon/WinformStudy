using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CropImage
{
    // TODO : ��Ʈ�� �̹��� ���Ͽ��� ����ڰ� ���콺�� �巡�׾� ����Ͽ� �̹��� �ڸ��� ���� (2024.06.18 jbh)
    // ��Ʃ�� ���� URL - https://youtu.be/Q63GV5tnXN0?si=TZgD_kRqTN0fWW97
    // �ҽ��ڵ� ���� URL - https://csharp.agrimetsoft.com/exercises/PictureBox_Crop_Image

    public partial class CropImageForm : Form
    {
        #region ������Ƽ

        int xDown = 0;
        int yDown = 0;
        int xUp = 0;
        int yUp = 0;
        Task timeout;
        Rectangle rectCropArea = new Rectangle();
        string fileName = "";

        #endregion ������Ƽ

        #region ������

        public CropImageForm()
        {
            InitializeComponent();
        }

        #endregion ������

        #region btnSelect_Click

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName); // pictureBox1�� �о�� ��Ʈ�� �̹��� ���Ϸ� ä��� 
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

                // TODO : �ڸ� �̹����� ���ػ󵵷� �׸��� ���� InterpolationMode ������ ����ü ��� HighQualityBicubic ��� (2024.06.21 jbh)
                // ���� URL - https://learn.microsoft.com/ko-kr/dotnet/api/system.drawing.drawing2d.interpolationmode?view=net-8.0&viewFallbackFrom=dotnet-plat-ext-8.0
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
