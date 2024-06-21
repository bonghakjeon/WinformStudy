namespace CropImage
{
    partial class CropImageForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPanel = new Panel();
            btnCrop = new Button();
            btnSelect = new Button();
            pictureBoxPanel1 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBoxPanel2 = new Panel();
            pictureBox2 = new PictureBox();
            btnPanel.SuspendLayout();
            pictureBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pictureBoxPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnPanel
            // 
            btnPanel.Controls.Add(btnCrop);
            btnPanel.Controls.Add(btnSelect);
            btnPanel.Dock = DockStyle.Top;
            btnPanel.Location = new Point(0, 0);
            btnPanel.Name = "btnPanel";
            btnPanel.Size = new Size(800, 100);
            btnPanel.TabIndex = 0;
            // 
            // btnCrop
            // 
            btnCrop.Location = new Point(197, 27);
            btnCrop.Name = "btnCrop";
            btnCrop.Size = new Size(108, 41);
            btnCrop.TabIndex = 1;
            btnCrop.Text = "Crop Selected Area";
            btnCrop.UseVisualStyleBackColor = true;
            btnCrop.Click += btnCrop_Click;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(32, 27);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(108, 41);
            btnSelect.TabIndex = 0;
            btnSelect.Text = "Select Image";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // pictureBoxPanel1
            // 
            pictureBoxPanel1.Controls.Add(pictureBox1);
            pictureBoxPanel1.Dock = DockStyle.Left;
            pictureBoxPanel1.Location = new Point(0, 100);
            pictureBoxPanel1.Name = "pictureBoxPanel1";
            pictureBoxPanel1.Size = new Size(476, 350);
            pictureBoxPanel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(476, 350);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // pictureBoxPanel2
            // 
            pictureBoxPanel2.Controls.Add(pictureBox2);
            pictureBoxPanel2.Dock = DockStyle.Fill;
            pictureBoxPanel2.Location = new Point(476, 100);
            pictureBoxPanel2.Name = "pictureBoxPanel2";
            pictureBoxPanel2.Size = new Size(324, 350);
            pictureBoxPanel2.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(324, 350);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // CropImageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBoxPanel2);
            Controls.Add(pictureBoxPanel1);
            Controls.Add(btnPanel);
            Name = "CropImageForm";
            Text = "Form1";
            btnPanel.ResumeLayout(false);
            pictureBoxPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pictureBoxPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel btnPanel;
        private Panel pictureBoxPanel1;
        private Panel pictureBoxPanel2;
        private Button btnCrop;
        private Button btnSelect;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
