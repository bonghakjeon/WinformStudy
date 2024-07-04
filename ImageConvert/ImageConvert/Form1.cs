using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConvert
{
    // TODO : 원본 이미지 "흑백 전환", "이진화 처리" 테스트 코드 구현 (2024.07.04 jbh)
    // 참고 URL - https://tctt.tistory.com/129
    // 참고 2 URL - https://blog.naver.com/nersion/140141133683
    // 참고 3 URL - https://blog.naver.com/PostView.naver?blogId=kgg1959&logNo=30182499708
    // 참고 4 URL - https://son10001.blogspot.com/2014/04/blog-post_14.html
    // 참고 5 URL - https://chatgpt.com/c/772919c6-4936-4b8d-b796-0a4b4d02e6ef

    public partial class Form1 : Form
    {
        Bitmap image;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 이미지 로드
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "jpg";
            openFile.Filter = "Graphics interchange Format (*.jpg)|*.jpg|All files(*.*)|*.*";
            openFile.ShowDialog();
            
            // 만약파일이선택되었으면
            if (openFile.FileName.Length > 0)
            {
                image = new Bitmap(openFile.FileName);

                // 이미지를 픽쳐박스 사이즈에 맞게 출력.
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color col;
            int Average;

            //x 는 image의 width
            //y 는 image의 hediht
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    //for문을 돌며 이미지 그레이스케일화
                    //그레이스케일은 약간식 다른방법으로도 가능하니 다른걸 사용해도 무관하다.
                    col = image.GetPixel(x, y);
                    Average = (col.R + col.G + col.B) / 3;

                    col = Color.FromArgb(Average, Average, Average);
                    image.SetPixel(x, y, col);
                }
            }
            pictureBox1.Image = image;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //이진화를 하기전, 그래이스케일을 거치고 해야 원하는 데이터를 얻을확률이 높다.
            Color col;
            int Average;

            for (int i = 0; i < image.Size.Width; i++)
            {
                for (int j = 0; j < image.Size.Height; j++)
                {
                    col = image.GetPixel(i, j);
                    Average = (col.R + col.G + col.B) / 3;

                    //이진화 흑, 백 위치를 변경하려면 아래 if문 주석위치 변경.
                    //이진화에 한계값은 120으로지정.. 0~255 사이의 숫자로 조정하면된다.
                    if (Average <= 120)
                    {
                        //image2.SetPixel(i, j, Color.White);
                        image.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        //image2.SetPixel(i, j, Color.Black);
                        image.SetPixel(i, j, Color.White);
                    }
                }
            }
            pictureBox1.Image = image;
        }





    }
}
