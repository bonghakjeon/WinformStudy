using System.Security.Policy;

namespace MouseWheelEvent
{
    // TODO : PictureBox 컨트롤에 출력되는 이미지를 마우스 휠을 사용해서 이미지 확대/축소 기능 구현 (2024.07.11 jbh)
    // 참고 URL - https://cs-solution.tistory.com/m/11

    // 유튜브 참고 URL
    // https://youtu.be/POJBq_a1Ea4?si=A7SgcIOOaoftMxhx

    public partial class Form1 : Form
    {
        #region 프로퍼티

        Image img;

        #endregion 프로퍼티

        #region 생성자

        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.MouseWheel += pictureBox1_MouseWheel;
        }

        /// <summary>
        /// pictureBox1 컨트롤 이미지 확대/축소 마우스 휠 이벤트 
        /// </summary>
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            var pictureBox = sender as PictureBox;

            if(pictureBox.Width + e.Delta > 0 && pictureBox.Height + e.Delta > 0)
            {
                pictureBox.Width += e.Delta;
                pictureBox.Height += e.Delta;
            }



            // TODO : 아래 주석친 코드 필요시 참고 (2024.07.11 jbh)
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

        #endregion 생성자

        #region button1_Click

        /// <summary>
        /// 버튼 "Choose" 클릭 이벤트
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
