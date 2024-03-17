namespace ImageResizeParallel
{
    partial class ParallelForm
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
            btn_Upload = new Button();
            pictureBoxOriginal = new PictureBox();
            pictureBoxResized = new PictureBox();
            textBox = new TextBox();
            btn_Resize = new Button();
            btn_Save = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxResized).BeginInit();
            SuspendLayout();
            // 
            // btn_Upload
            // 
            btn_Upload.Location = new Point(61, 60);
            btn_Upload.Name = "btn_Upload";
            btn_Upload.Size = new Size(124, 45);
            btn_Upload.TabIndex = 0;
            btn_Upload.Text = "Upload Image";
            btn_Upload.UseVisualStyleBackColor = true;
            btn_Upload.Click += btn_Upload_Click;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Location = new Point(323, 12);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(411, 204);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOriginal.TabIndex = 1;
            pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxResized
            // 
            pictureBoxResized.Location = new Point(323, 239);
            pictureBoxResized.Name = "pictureBoxResized";
            pictureBoxResized.Size = new Size(411, 199);
            pictureBoxResized.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxResized.TabIndex = 2;
            pictureBoxResized.TabStop = false;
            // 
            // textBox
            // 
            textBox.Location = new Point(61, 157);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.PlaceholderText = "Enter a value between 0 and 100";
            textBox.Size = new Size(229, 29);
            textBox.TabIndex = 3;
            // 
            // btn_Resize
            // 
            btn_Resize.Location = new Point(61, 201);
            btn_Resize.Name = "btn_Resize";
            btn_Resize.Size = new Size(123, 42);
            btn_Resize.TabIndex = 4;
            btn_Resize.Text = "Resize";
            btn_Resize.UseVisualStyleBackColor = true;
            btn_Resize.Click += btn_Resize_Click;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(184, 394);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(123, 44);
            btn_Save.TabIndex = 5;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // ParallelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Save);
            Controls.Add(btn_Resize);
            Controls.Add(textBox);
            Controls.Add(pictureBoxResized);
            Controls.Add(pictureBoxOriginal);
            Controls.Add(btn_Upload);
            Name = "ParallelForm";
            Text = "ParallelForm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxResized).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Upload;
        private PictureBox pictureBoxOriginal;
        private PictureBox pictureBoxResized;
        private TextBox textBox;
        private Button btn_Resize;
        private Button btn_Save;
    }
}
