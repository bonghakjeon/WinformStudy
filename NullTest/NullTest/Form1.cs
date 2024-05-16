using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NullTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Null 조건부 연산자 ?. 테스트용 이벤트 메서드 btnNull_Click
        /// </summary>
        private void btnNull_Click(object sender, EventArgs e)
        {
            try
            {
                // Null 조건부 연산자?.추가(checkedListBox1.SelectedItem?.ToString())(2024.05.16 jbh)
                // 참고 URL - https://learn.microsoft.com/ko-kr/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-
                // 참고  2 URL - https://velog.io/@jinuku/C-%EB%B0%8F-.-%EC%97%B0%EC%82%B0%EC%9E%90
                string test = null;
                var result = test.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
