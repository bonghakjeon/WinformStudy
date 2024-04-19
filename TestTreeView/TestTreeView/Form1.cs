using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTreeView
{
    // TODO : C# Winform TreeView 컨트롤 테스트 프로그램 구현 (2024.04.19 jbh)
    // 유튜브 참고 URL - https://youtu.be/PNIZDLFPmXE?si=75KBfK1PFYu5Kfrp
    public partial class Form1 : Form
    {
        public class Test
        {
            public string No { get; set; }

            public string Name { get; set; }

            public Test(string no, string name)
            {
                No = no;
                Name = name;
            }
        }

        #region 프로퍼티

        List<TreeNode> checkedNodes = new List<TreeNode>();

        #endregion 프로퍼티

        #region 생성자

        public Form1()
        {
            InitializeComponent();
        }

        #endregion 생성자

        #region button1_Click

        /// <summary>
        /// TreeView 컨트롤에 노드 추가 
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Collection<Test> TestCollection = new Collection<Test>();
            // Test test1 = new Test("1", "조미란");
            // Test test2 = new Test("2", "전민재");
            // Test test3 = new Test("3", "전민태");


            // this.treeView1.DataBindings = TestCollection;

            this.treeView1.Nodes.Add("Books");
            this.treeView1.Nodes.Add("Papers");
            this.treeView1.Nodes.Add("Folders");

            this.treeView1.Nodes[0].Nodes.Add("Book1");
            this.treeView1.Nodes[0].Nodes.Add("Book2");
            this.treeView1.Nodes[0].Nodes.Add("Book3");

            this.treeView1.Nodes[1].Nodes.Add("Papers1");
            this.treeView1.Nodes[1].Nodes.Add("Papers2");
            this.treeView1.Nodes[1].Nodes.Add("Papers3");




            this.treeView1.CheckBoxes = true;   // TreeView 컨트롤(treeView1)에 속한 모든 노드들을 체크박스로 변경 
        }

        #endregion button1_Click

        #region button2_Click

        /// <summary>
        /// TreeView 컨트롤(treeView1)에 체크한 노드 삭제  
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            // this.treeView1.SelectedNode.Remove();   // 사용자가 TreeView 컨트롤(treeView1)에서 선택한 노드만 삭제
            // this.treeView1.Nodes.Clear();   // 사용자가 TreeView 컨트롤(treeView1)에 속한 모든 노드 삭제

            // var test = this.treeView1.Nodes;

            RemoveCheckedNodes(this.treeView1.Nodes);
        }

        #endregion button2_Click

        #region RemoveCheckedNodes

        /// <summary>
        /// TreeView 컨트롤(treeView1)에 체크한 노드 삭제  
        /// </summary>
        private void RemoveCheckedNodes(TreeNodeCollection nodes) {
            foreach(TreeNode node in nodes)
            {
                if(true == node.Checked)
                {
                    checkedNodes.Add(node);
                }
                else
                {
                    RemoveCheckedNodes(node.Nodes);  // 해당 노드의 하위 노드 탐색
                }
            }

            foreach(TreeNode checkedNode in checkedNodes)
            {
                nodes.Remove(checkedNode);
            }
        }

        #endregion RemoveCheckedNodes
    }
}
