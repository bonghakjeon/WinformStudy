using System;
using System.Windows.Forms;

namespace TestTreeView
{
    // TODO : C# Winform(윈폼) 트리뷰 체크박스 더블클릭(체크 + 언체크) 체크 오류 버그 방지 해결책 구현 (2024.04.26 jbh)
    // 참고 URL - https://mintaku.tistory.com/33
    public class NewTreeView : TreeView
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x203) { m.Result = IntPtr.Zero; }
            else base.WndProc(ref m);
        }
    }
}
