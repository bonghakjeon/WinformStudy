using System.Security.Policy;

namespace MouseWheelEvent
{
    // TODO : PictureBox ��Ʈ�ѿ� ��µǴ� �̹����� ���콺 ���� ����ؼ� �̹��� Ȯ��/��� ��� ���� (2024.07.11 jbh)
    // ���� URL - https://cs-solution.tistory.com/m/11

    // ��Ʃ�� ���� URL
    // https://youtu.be/POJBq_a1Ea4?si=A7SgcIOOaoftMxhx

    public partial class Form1 : Form
    {
        #region ������Ƽ

        Image img;

        #endregion ������Ƽ

        #region ������

        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.MouseWheel += pictureBox1_MouseWheel;
        }

        /// <summary>
        /// pictureBox1 ��Ʈ�� �̹��� Ȯ��/��� ���콺 �� �̺�Ʈ 
        /// </summary>
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            var pictureBox = sender as PictureBox;

            if(pictureBox.Width + e.Delta > 0 && pictureBox.Height + e.Delta > 0)
            {
                pictureBox.Width += e.Delta;
                pictureBox.Height += e.Delta;
            }



            // TODO : �Ʒ� �ּ�ģ �ڵ� �ʿ�� ���� (2024.07.11 jbh)
            //if (e.Delta > 0)
            //{
            //    pictureBox1.Width = pictureBox1.Width + 50;
            //    pictureBox1.Height = pictureBox1.Height + 50;
            //}
            //else
            //{
            //    pictureBox1.Width = pictureBox1.Width - 50;
            //    pictureBox1.Height = pictureBox1.Height - 50;
            //}
        }

        #endregion ������

        #region button1_Click

        /// <summary>
        /// ��ư "Choose" Ŭ�� �̺�Ʈ
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if(DialogResult.OK == openFileDialog1.ShowDialog())
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

                img = pictureBox1.Image;


            }
        }

        #endregion button1_Click
    }
}
