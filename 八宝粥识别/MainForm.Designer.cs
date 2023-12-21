﻿namespace 八宝粥识别
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
            ((System.ComponentModel.ISupportInitialize)cameraPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detectedPictureBox).BeginInit();
            SuspendLayout();
            // 
            // cameraPictureBox
            // 
            cameraPictureBox.Location = new Point(29, 37);
            cameraPictureBox.Name = "cameraPictureBox";
            cameraPictureBox.Size = new Size(628, 551);
            cameraPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            cameraPictureBox.TabIndex = 0;
            cameraPictureBox.TabStop = false;
            // 
            // detectedPictureBox
            // 
            detectedPictureBox.Location = new Point(826, 37);
            detectedPictureBox.Name = "detectedPictureBox";
            detectedPictureBox.Size = new Size(628, 551);
            detectedPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            detectedPictureBox.TabIndex = 1;
            detectedPictureBox.TabStop = false;
            // 
            // detectActionButton
            // 
            detectActionButton.Location = new Point(1001, 622);
            detectActionButton.Name = "detectActionButton";
            detectActionButton.Size = new Size(267, 69);
            detectActionButton.TabIndex = 2;
            detectActionButton.Text = "识别";
            detectActionButton.UseVisualStyleBackColor = true;
            detectActionButton.Click += DetectActionButton_Click;
            // 
            // selectPictureButton
            // 
            selectPictureButton.Location = new Point(304, 764);
            selectPictureButton.Name = "selectPictureButton";
            selectPictureButton.Size = new Size(904, 51);
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
            consoleLabel.Location = new Point(1, 849);
            consoleLabel.Name = "consoleLabel";
            consoleLabel.Size = new Size(1481, 34);
            consoleLabel.TabIndex = 4;
            consoleLabel.Text = "NoOutPutInfo";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1484, 882);
            Controls.Add(consoleLabel);
            Controls.Add(selectPictureButton);
            Controls.Add(detectActionButton);
            Controls.Add(detectedPictureBox);
            Controls.Add(cameraPictureBox);
            Name = "MainForm";
            Text = "八宝粥检测";
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
    }
}
