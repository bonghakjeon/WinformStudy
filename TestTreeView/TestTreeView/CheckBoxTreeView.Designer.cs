
namespace TestTreeView
{
    // TODO : C# Winform(윈폼) 트리뷰 체크박스 더블클릭(체크 + 언체크) 체크 오류 버그 방지 해결책 구현 (2024.04.26 jbh)
    // 참고 URL - https://mintaku.tistory.com/33
    partial class CheckBoxTreeView
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
            //this.tvSteps = new System.Windows.Forms.TreeView();
            this.tvSteps = new NewTreeView();
            this.SuspendLayout();
            // 
            // tvSteps
            // 
            this.tvSteps.Location = new System.Drawing.Point(48, 37);
            this.tvSteps.Name = "tvSteps";
            this.tvSteps.Size = new System.Drawing.Size(400, 400);
            this.tvSteps.TabIndex = 0;
            this.tvSteps.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvSteps_AfterCheck);
            // 
            // CheckBoxTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 468);
            this.Controls.Add(this.tvSteps);
            this.Name = "CheckBoxTreeView";
            this.Text = "CheckBoxTreeView";
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.TreeView tvSteps;
        private NewTreeView tvSteps;
    }
}