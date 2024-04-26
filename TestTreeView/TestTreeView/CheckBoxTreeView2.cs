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
    // 참고 URL - https://stackoverflow.com/questions/44927977/un-check-behavior-in-c-sharp-treeview

    public partial class CheckBoxTreeView2 : DevExpress.XtraEditors.XtraForm
    {
        #region 프로퍼티

        private bool isChildCheck = false;

        #endregion 프로퍼티

        #region 생성자

        public CheckBoxTreeView2()
        {
            InitializeComponent();

            SetTreeViewData();
        }

        #endregion 생성자

        #region SetTreeViewData

        #region SetTreeViewData

        private void SetTreeViewData()
        {
            // TreeView 컨트롤(tvSteps) CheckBox 속성 설정
            TREE_VIEW.CheckBoxes = true;

            // 상위 카테고리 노드 1
            TREE_VIEW.Nodes.Add("과일");

            // 상위 카테고리 노드 1 - 하위 카테고리 노드
            TREE_VIEW.Nodes[0].Nodes.Add("바나나");
            TREE_VIEW.Nodes[0].Nodes.Add("키위");
            TREE_VIEW.Nodes[0].Nodes.Add("사과");
            TREE_VIEW.Nodes[0].Nodes.Add("블루베리");
            TREE_VIEW.Nodes[0].Nodes.Add("딸기");
            TREE_VIEW.Nodes[0].Nodes.Add("체리");
            TREE_VIEW.Nodes[0].Nodes.Add("앵두");

            // 상위 카테고리 노드 2
            TREE_VIEW.Nodes.Add("직업");

            // 상위 카테고리 노드 2 - 하위 카테고리 노드 
            TREE_VIEW.Nodes[1].Nodes.Add("프로그래머");
            TREE_VIEW.Nodes[1].Nodes.Add("공무원");
            TREE_VIEW.Nodes[1].Nodes.Add("국회의원");
            TREE_VIEW.Nodes[1].Nodes.Add("선생님");
            TREE_VIEW.Nodes[1].Nodes.Add("생산직");
        }

        #endregion SetTreeViewData

        #endregion SetTreeViewData

        #region TREE_VIEW_AfterCheck

        private void TREE_VIEW_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // The code only executes if the user caused the checked state to change.
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    if (isChildCheck)
                    {
                        isChildCheck = false;
                        return;
                        //This will check the parent to exit AfterCheck loop
                    }
                    // Calls the CheckAllChildNodes method, passing in the current 
                    // checked value of the TreeNode whose checked state changed. 
                    CheckAllChildNodes(e.Node, e.Node.Checked);
                }
                else
                {
                    e.Node.Parent.Checked = GetCheckStateOfChildNodes(e.Node.Parent);
                    isChildCheck = !e.Node.Parent.Checked;
                }
            }
        }

        #endregion TREE_VIEW_AfterCheck

        #region CheckAllChildNodes

        //After a tree node's Checked property is changed, all its child nodes are updated to the same value.

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        } //Checks the childnodes of a node recursively

        #endregion CheckAllChildNodes

        #region GetCheckStateOfChildNodes

        //Additional Method to react on behavior when all childs are checked/unchecked
        //This part was added by dwza and is not in the VB part
        private bool GetCheckStateOfChildNodes(TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion GetCheckStateOfChildNodes
    }
}