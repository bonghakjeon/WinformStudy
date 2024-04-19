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
    public partial class TreeViewForm : DevExpress.XtraEditors.XtraForm
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

        public TreeViewForm()
        {
            InitializeComponent();
        }

        private void TreeViewForm_Load(object sender, EventArgs e)
        {
            List<Test> TestList = new List<Test>();
            Test test1 = new Test("1", "조미란");
            Test test2 = new Test("2", "전민재");
            Test test3 = new Test("3", "전민태");

            TestList.Add(test1);
            TestList.Add(test2);
            TestList.Add(test3);

            this.treeList1.DataSource = TestList;
            this.treeList1.DataMember = "";

            

            this.treeList1.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;

            
        }
    }
}