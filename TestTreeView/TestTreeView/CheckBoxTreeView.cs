using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTreeView
{
    // TODO : TreeView 컨트롤 (tvSteps) 체크박스 구현 및 체크박스 전체 선택 및 전체 해제 기능 구현 (2024.04.26 jbh)
    // 참고 URL - https://afsdzvcx123.tistory.com/entry/C-%EC%9C%88%ED%8F%BC-TreeView-%EC%BB%A8%ED%8A%B8%EB%A1%A4-CheckBox-%EB%A1%9C-%EB%B3%80%EA%B2%BD-%EB%B0%8F-%EC%B2%B4%ED%81%AC-%EC%9D%B4%EB%B2%A4%ED%8A%B8-%EC%84%A0%EC%96%B8%ED%95%98%EA%B8%B0

    // TODO : C# Winform(윈폼) 트리뷰 체크박스 더블클릭(체크 + 언체크) 체크 오류 버그 방지 해결책 구현 (2024.04.26 jbh)
    // 참고 URL - https://mintaku.tistory.com/33
    public partial class CheckBoxTreeView : XtraForm
    {
        #region 프로퍼티

        // 마우스를 클릭해서 이벤트와 소스상에서 생긴 이벤트 구분 
        public bool m_bEntrance = true;

        #endregion 프로퍼티

        #region 생성자

        public CheckBoxTreeView()
        {
            InitializeComponent();

            SetTreeViewData();
        }

        #endregion 생성자

        #region SetTreeViewData

        private void SetTreeViewData()
        {
            // TreeView 컨트롤(tvSteps) CheckBox 속성 설정
            tvSteps.CheckBoxes = true;

            // 상위 카테고리 노드 1
            tvSteps.Nodes.Add("과일");

            // 상위 카테고리 노드 1 - 하위 카테고리 노드
            tvSteps.Nodes[0].Nodes.Add("바나나");
            tvSteps.Nodes[0].Nodes.Add("키위");
            tvSteps.Nodes[0].Nodes.Add("사과");
            tvSteps.Nodes[0].Nodes.Add("블루베리");
            tvSteps.Nodes[0].Nodes.Add("딸기");
            tvSteps.Nodes[0].Nodes.Add("체리");
            tvSteps.Nodes[0].Nodes.Add("앵두");

            // 상위 카테고리 노드 2
            tvSteps.Nodes.Add("직업");

            // 상위 카테고리 노드 2 - 하위 카테고리 노드 
            tvSteps.Nodes[1].Nodes.Add("프로그래머");
            tvSteps.Nodes[1].Nodes.Add("공무원");
            tvSteps.Nodes[1].Nodes.Add("국회의원");
            tvSteps.Nodes[1].Nodes.Add("선생님");
            tvSteps.Nodes[1].Nodes.Add("생산직");
        }

        #endregion SetTreeViewData

        #region tvSteps_AfterCheck

        private void tvSteps_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(true == m_bEntrance)
            {
                // ChildNode와 ParentNode를 처리하면서 생기는 이벤트를 막기 위해서 False
                m_bEntrance = false;

                // ChildNode 확인
                ChildTreeNodeCheck(e.Node, e.Node.Checked);

                // ParentNode 확인
                ParentTreeNodeCheck(e.Node, e.Node.Checked);

                // 다시 이벤트를 받기 위해서 True
                m_bEntrance = true;
            }
        }

        #endregion tvSteps_AfterCheck

        #region ChildTreeNodeCheck

        private void ChildTreeNodeCheck(TreeNode node, bool Checked)
        {
            foreach(TreeNode childNode in node.Nodes) 
            {
                 // 현재 노드의 Child 노드 확인 (메서드 재귀 호출)
                 ChildTreeNodeCheck(childNode, Checked);
            }
            // 현재 노드 체크 또는 체크해제
            node.Checked = Checked;
        }

        #endregion ChildTreeNodeCheck

        #region ParentTreeNodeCheck

        private void ParentTreeNodeCheck(TreeNode node, bool Checked)
        {
            if(node.Parent == null) return;

            bool bNodesAllCheck = true;

            foreach(TreeNode childNode in node.Parent.Nodes)
            {
                if(childNode.Checked == false)
                {
                    // 부모 노드의 Child 노드들을 확인해서 모두 체크가 아니면 False
                    bNodesAllCheck = false;
                    break;
                }

                // 현재 노드의 부모 노드 체크 또는 체크 해제
                node.Parent.Checked = bNodesAllCheck;
                // node.Parent.Checked = Checked;

                // 부모의 부모 노드를 확인
                ParentTreeNodeCheck(node.Parent, bNodesAllCheck);
                // ParentTreeNodeCheck(node.Parent, Checked);
            }
        }

        #endregion ParentTreeNodeCheck
    }
}