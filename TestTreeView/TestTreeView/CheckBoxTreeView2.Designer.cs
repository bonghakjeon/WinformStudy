
namespace TestTreeView
{
    partial class CheckBoxTreeView2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // this.TREE_VIEW = new System.Windows.Forms.TreeView();
            this.TREE_VIEW = new NewTreeView();
            this.SuspendLayout();
            // 
            // TREE_VIEW
            // 
            this.TREE_VIEW.Location = new System.Drawing.Point(45, 31);
            this.TREE_VIEW.Name = "TREE_VIEW";
            this.TREE_VIEW.Size = new System.Drawing.Size(400, 400);
            this.TREE_VIEW.TabIndex = 0;
            this.TREE_VIEW.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TREE_VIEW_AfterCheck);
            // 
            // CheckBoxTreeView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 468);
            this.Controls.Add(this.TREE_VIEW);
            this.Name = "CheckBoxTreeView2";
            this.Text = "CheckBoxTreeView2";
            this.ResumeLayout(false);

        }

        #endregion

        // private System.Windows.Forms.TreeView TREE_VIEW;
        private NewTreeView TREE_VIEW;
    }
}