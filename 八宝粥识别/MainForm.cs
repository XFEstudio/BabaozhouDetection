using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.ML.Data;
using System.Drawing.Imaging;
using TestConsole_ImageDetection;
using XFE各类拓展.NetCore.XFECode;

namespace 八宝粥识别;

public partial class MainForm : Form
{
    public static MainForm? CurrentForm { get; set; }
    public bool Loaded { get; private set; }
    public static bool EngineInitialized { get; private set; }
    public bool CameraMode { get; set; }
    public string SelectedImagePath { get; set; } = string.Empty;
    public int SelectedCameraIndex { get; set; } = 0;
    public Image? CurrentCameraImage { get; private set; }
    private readonly FilterInfoCollection videoDevices;
    private VideoCaptureDevice videoSource = new();
    public MainForm()
    {
        InitializeComponent();
        CurrentForm = this;
        videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        for (int i = 0; i < videoDevices.Count; i++)
        {
            ShowConsoleMessage($"检测到摄像头设备[{i}]：{videoDevices[i].Name}");
            Thread.Sleep(500);
            cameraPickComboBox.Items.Add(videoDevices[i].Name);
        }
        cameraPickComboBox.SelectedIndex = cameraPickComboBox.Items.Count - 1;
        Task.Run(() =>
        {
            ShowConsoleMessage("正在初始化引擎......");
            ImageDetectionTest.InitializeEngine();
            EngineInitialized = true;
            ShowConsoleMessage("引擎初始化完成！", Color.Green);
        });
    }

    private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        CurrentCameraImage = (Bitmap)eventArgs.Frame.Clone();
        cameraPictureBox.Image = CurrentCameraImage;
    }

    public static Stream ImageToStream(Image image, ImageFormat format)
    {
        MemoryStream stream = new();
        image.Save(stream, format);
        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }

    public void ShowConsoleMessage(string text, Color color)
    {
        try
        {
            var log = $"[{DateTime.Now:HH:mm:ss}] {text}";
            if (Loaded)
            {
                Invoke(() => consoleLabel.ForeColor = color);
                Invoke(() => consoleLabel.Text = log);
            }
            ConsoleLogForm.Log.Add(log);
        }
        catch { }
    }

    public void ShowConsoleMessage(string text)
    {
        ShowConsoleMessage(text, Color.Black);
    }

    private void DetectActionButton_Click(object sender, EventArgs e)
    {
        Task.Run(() =>
        {
            ShowConsoleMessage("正在检测...");
            if (CameraMode)
                DetectBottle(CurrentCameraImage);
            else
                DetectBottle(Image.FromFile(SelectedImagePath));
        });
    }

    private void DetectBottle(Image? originImage)
    {
        try
        {
            if (originImage?.Clone() is not Bitmap image)
            {
                ShowConsoleMessage("无图像传入！", Color.Red);
                if (!CameraMode)
                    MessageBox.Show("无图像传入");
                return;
            }
            if (!EngineInitialized)
            {
                ShowConsoleMessage("视觉识别引擎未初始化完成", Color.Red);
                if (!CameraMode)
                    MessageBox.Show("视觉识别引擎未初始化完成");
                return;
            }
            var detectImage = MLImage.CreateFromStream(ImageToStream(image, ImageFormat.Jpeg));
            ImageDetectionTest.ModelInput sampleData = new()
            {
                Image = detectImage
            };
            ImageDetectionTest.ModelOutput result = new();
            var runTime = XFECode.CTime(() => result = ImageDetectionTest.Predict(sampleData));
            if (result is null || result.Score is null)
            {
                detectedPictureBox.Image = image;
                ShowConsoleMessage($"未检测到目标\t用时：{(runTime.TotalSeconds > 1 ? $"{runTime.TotalSeconds:F2}秒" : $"{runTime.TotalMilliseconds:F2}毫秒"):F2}");
                return;
            }
            var boxes = result.PredictedBoundingBoxes.Chunk(4)
                                                     .Select(x => new { XTop = x[0], YTop = x[1], XBottom = x[2], YBottom = x[3] })
                                                     .Zip(result.Score, (a, b) => new { Box = a, Score = b });
            using var graphics = Graphics.FromImage(image);
            foreach (var box in boxes)
            {
                #region 获取矩形位置
                int x = (int)box.Box.XTop;
                int y = (int)box.Box.YTop;
                int width = (int)(box.Box.XBottom - box.Box.XTop);
                int height = (int)(box.Box.YBottom - box.Box.YTop);
                #endregion
                int borderThickness = (int)(Math.Min(width, height) * 0.01);//根据矩形大小调整边框粗细
                float fontSize = Math.Min(width, height) * 0.1f;//根据矩形大小调整字体大小
                var font = new Font(SystemFonts.DefaultFont.FontFamily, fontSize);
                var fillBrush = new SolidBrush(GetTransparentColorForScore(box.Score));
                var borderPen = new Pen(GetColorForScore(box.Score), borderThickness);
                graphics.FillRectangle(fillBrush, x, y, width, height);
                graphics.DrawRectangle(borderPen, x, y, width, height);
                var confidenceText = $"匹配度: {box.Score:F2}";
                SizeF textSize = graphics.MeasureString(confidenceText, font);
                graphics.FillRectangle(new SolidBrush(GetColorForScore(box.Score)), x - borderThickness / 2, y - textSize.Height - 5, textSize.Width, textSize.Height);
                graphics.DrawString(confidenceText, font, Brushes.White, x - borderThickness / 2, y - textSize.Height - 5);
            }
            Invoke(() => detectedPictureBox.Image = image);
            ShowConsoleMessage($"检测到目标数：{boxes.Count()}\t用时：{(runTime.TotalSeconds > 1 ? $"{runTime.TotalSeconds:F2}秒" : $"{runTime.TotalMilliseconds:F2}毫秒"):F2}");
        }
        catch (Exception ex)
        {
            ShowConsoleMessage($"错误信息：{ex.Message}", Color.Red);
        }
    }

    private void SelectPictureButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (CameraMode)
            {
                MessageBox.Show("请先关闭摄像头！");
                ShowConsoleMessage("摄像头运行中，无法选择图片！", Color.Red);
            }
            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedImagePath = openImageFileDialog.FileName;
                ShowConsoleMessage($"已选择图片：{SelectedImagePath}");
                cameraPictureBox.Image = Image.FromFile(SelectedImagePath);
            }
            else
            {
                ShowConsoleMessage("未选择图片");
            }
        }
        catch (Exception ex)
        {
            ShowConsoleMessage($"错误信息：{ex.Message}", Color.Red);
        }
    }

    private static Color GetTransparentColorForScore(float score)
    {
        return Color.FromArgb(80, GetColorForScore(score));
    }

    private static Color GetColorForScore(float score)
    {
        if (score > 0.8)
            return Color.Green;
        else if (score > 0.5)
            return Color.Yellow;
        else
            return Color.Red;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        Loaded = true;
        if (EngineInitialized)
            ShowConsoleMessage("引擎初始化完成！", Color.Green);
        else
            ShowConsoleMessage("正在初始化引擎......");
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        try
        {
            if (videoSource is not null && videoSource.IsRunning)
                videoSource.SignalToStop();
        }
        catch (Exception ex)
        {
            ShowConsoleMessage(ex.Message, Color.Red);
            Application.Exit();
        }
    }

    private void StartCaptureButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (CameraMode)
            {
                CameraMode = false;
                startCaptureButton.Text = "打开摄像头";
                videoSource.NewFrame -= VideoSource_NewFrame;
                videoSource.VideoSourceError -= VideoSource_VideoSourceError;
                videoSource.SignalToStop();
            }
            else
            {
                if (cameraPickComboBox.SelectedIndex >= 0)
                {
                    CameraMode = true;
                    startCaptureButton.Text = "关闭摄像头";
                    videoSource = new VideoCaptureDevice(videoDevices[cameraPickComboBox.SelectedIndex].MonikerString);
                    videoSource.NewFrame += VideoSource_NewFrame;
                    videoSource.VideoSourceError += VideoSource_VideoSourceError;
                    videoSource.Start();
                    ShowConsoleMessage("正在检测...");
                    Task.Run(() =>
                    {
                        while (CameraMode)
                            if (CurrentCameraImage is not null)
                                DetectBottle(CurrentCameraImage);
                    });
                }
                else
                {
                    ShowConsoleMessage("未选择摄像头！", Color.Red);
                }
            }
        }
        catch (Exception ex)
        {
            ShowConsoleMessage($"{ex.Message}\t行号：{ex.StackTrace}", Color.Red);
        }
    }

    private void VideoSource_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
    {
        ShowConsoleMessage(eventArgs.Description, Color.Red);
    }

    private void CameraPickComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CameraMode)
        {
            videoSource.SignalToStop();
            videoSource = new VideoCaptureDevice(videoDevices[cameraPickComboBox.SelectedIndex].MonikerString);
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.VideoSourceError += VideoSource_VideoSourceError;
            videoSource.Start();
        }
    }

    private void ShowLogButton_Click(object sender, EventArgs e)
    {
        ConsoleLogForm consoleLogForm = new();
        consoleLogForm.Show();
    }
}
