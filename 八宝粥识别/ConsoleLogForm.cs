namespace 八宝粥识别;

public partial class ConsoleLogForm : Form
{
    public static ConsoleLog Log { get; } = [];
    public ConsoleLogForm()
    {
        InitializeComponent();
        Log.MaxCount = 100;
        Log.LogAdded += Log_LogAdded;
        consoleLogLabel.Text = string.Empty;
        foreach (var logText in Log)
        {
            consoleLogLabel.Text += $"{logText}\n";
        }
    }

    private void Log_LogAdded(ConsoleLog sender, string e)
    {
        Invoke(() =>
        {
            consoleLogLabel.Text += $"{e}\n";
            AutoScrollPosition = new Point(0, consoleLogLabel.Height);
        });
    }

    private void ConsoleLogForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Log.LogAdded -= Log_LogAdded;
    }
}
