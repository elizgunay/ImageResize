namespace ImageResize
{
    partial class Consequential
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
            btnOpenImage = new Button();
            btnResize = new Button();
            pictureBoxOriginal = new PictureBox();
            pictureBoxResized = new PictureBox();
            textBox = new TextBox();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxResized).BeginInit();
            SuspendLayout();
            // 
            // btnOpenImage
            // 
            btnOpenImage.Location = new Point(64, 37);
            btnOpenImage.Name = "btnOpenImage";
            btnOpenImage.Size = new Size(131, 33);
            btnOpenImage.TabIndex = 0;
            btnOpenImage.Text = "Open Image";
            btnOpenImage.UseVisualStyleBackColor = true;
            btnOpenImage.Click += btnOpenImage_Click;
            // 
            // btnResize
            // 
            btnResize.Location = new Point(64, 169);
            btnResize.Name = "btnResize";
            btnResize.Size = new Size(94, 29);
            btnResize.TabIndex = 1;
            btnResize.Text = "Resize";
            btnResize.UseVisualStyleBackColor = true;
            btnResize.Click += btnResize_Click;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Location = new Point(346, 12);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(330, 186);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOriginal.TabIndex = 2;
            pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxResized
            // 
            pictureBoxResized.Location = new Point(346, 223);
            pictureBoxResized.Name = "pictureBoxResized";
            pictureBoxResized.Size = new Size(337, 197);
            pictureBoxResized.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxResized.TabIndex = 3;
            pictureBoxResized.TabStop = false;
            // 
            // textBox
            // 
            textBox.Location = new Point(64, 126);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.PlaceholderText = "Enter a value between 0 and 100";
            textBox.Size = new Size(229, 37);
            textBox.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(218, 381);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Consequential
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(textBox);
            Controls.Add(pictureBoxResized);
            Controls.Add(pictureBoxOriginal);
            Controls.Add(btnResize);
            Controls.Add(btnOpenImage);
            Name = "Consequential";
            Text = "Consequential";
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxResized).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpenImage;
        private Button btnResize;
        private PictureBox pictureBoxOriginal;
        private PictureBox pictureBoxResized;
        private TextBox textBox;
        private Button btnSave;
    }
}
