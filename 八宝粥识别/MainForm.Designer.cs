namespace 八宝粥识别
{
    partial class MainForm
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
            cameraPictureBox = new PictureBox();
            detectedPictureBox = new PictureBox();
            detectActionButton = new Button();
            selectPictureButton = new Button();
            openImageFileDialog = new OpenFileDialog();
            consoleLabel = new Label();
            startCaptureButton = new Button();
            ((System.ComponentModel.ISupportInitialize)cameraPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detectedPictureBox).BeginInit();
            SuspendLayout();
            // 
            // cameraPictureBox
            // 
            cameraPictureBox.Location = new Point(37, 48);
            cameraPictureBox.Margin = new Padding(4);
            cameraPictureBox.Name = "cameraPictureBox";
            cameraPictureBox.Size = new Size(799, 712);
            cameraPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            cameraPictureBox.TabIndex = 0;
            cameraPictureBox.TabStop = false;
            // 
            // detectedPictureBox
            // 
            detectedPictureBox.Location = new Point(1051, 48);
            detectedPictureBox.Margin = new Padding(4);
            detectedPictureBox.Name = "detectedPictureBox";
            detectedPictureBox.Size = new Size(799, 712);
            detectedPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            detectedPictureBox.TabIndex = 1;
            detectedPictureBox.TabStop = false;
            // 
            // detectActionButton
            // 
            detectActionButton.Location = new Point(1274, 803);
            detectActionButton.Margin = new Padding(4);
            detectActionButton.Name = "detectActionButton";
            detectActionButton.Size = new Size(340, 89);
            detectActionButton.TabIndex = 2;
            detectActionButton.Text = "识别";
            detectActionButton.UseVisualStyleBackColor = true;
            detectActionButton.Click += DetectActionButton_Click;
            // 
            // selectPictureButton
            // 
            selectPictureButton.Location = new Point(387, 987);
            selectPictureButton.Margin = new Padding(4);
            selectPictureButton.Name = "selectPictureButton";
            selectPictureButton.Size = new Size(1151, 66);
            selectPictureButton.TabIndex = 3;
            selectPictureButton.Text = "选择图片";
            selectPictureButton.UseVisualStyleBackColor = true;
            selectPictureButton.Click += SelectPictureButton_Click;
            // 
            // openImageFileDialog
            // 
            openImageFileDialog.Filter = "图片文件|*.*";
            openImageFileDialog.Title = "选择要检测八宝粥的图片";
            // 
            // consoleLabel
            // 
            consoleLabel.BackColor = Color.FromArgb(210, 210, 210);
            consoleLabel.ForeColor = SystemColors.ActiveCaptionText;
            consoleLabel.Location = new Point(1, 1097);
            consoleLabel.Margin = new Padding(4, 0, 4, 0);
            consoleLabel.Name = "consoleLabel";
            consoleLabel.Size = new Size(1885, 44);
            consoleLabel.TabIndex = 4;
            consoleLabel.Text = "NoOutPutInfo";
            // 
            // startCaptureButton
            // 
            startCaptureButton.Location = new Point(256, 803);
            startCaptureButton.Margin = new Padding(4);
            startCaptureButton.Name = "startCaptureButton";
            startCaptureButton.Size = new Size(340, 89);
            startCaptureButton.TabIndex = 5;
            startCaptureButton.Text = "打开摄像头";
            startCaptureButton.UseVisualStyleBackColor = true;
            startCaptureButton.Click += StartCaptureButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1889, 1139);
            Controls.Add(startCaptureButton);
            Controls.Add(consoleLabel);
            Controls.Add(selectPictureButton);
            Controls.Add(detectActionButton);
            Controls.Add(detectedPictureBox);
            Controls.Add(cameraPictureBox);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "八宝粥检测";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)cameraPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)detectedPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox cameraPictureBox;
        private PictureBox detectedPictureBox;
        private Button detectActionButton;
        private Button selectPictureButton;
        private OpenFileDialog openImageFileDialog;
        private Label consoleLabel;
        private Button startCaptureButton;
    }
}
