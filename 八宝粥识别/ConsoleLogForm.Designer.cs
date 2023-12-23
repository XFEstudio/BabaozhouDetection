namespace 八宝粥识别
{
    partial class ConsoleLogForm
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
            consoleLogLabel = new Label();
            SuspendLayout();
            // 
            // consoleLogLabel
            // 
            consoleLogLabel.AutoSize = true;
            consoleLogLabel.Location = new Point(0, 0);
            consoleLogLabel.Name = "consoleLogLabel";
            consoleLogLabel.Size = new Size(131, 24);
            consoleLogLabel.TabIndex = 0;
            consoleLogLabel.Text = "NoOutPutInfo";
            // 
            // ConsoleLogForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            Controls.Add(consoleLogLabel);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "ConsoleLogForm";
            Text = "输出日志";
            FormClosing += ConsoleLogForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label consoleLogLabel;
    }
}