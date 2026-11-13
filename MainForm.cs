namespace KeyboardHookLab;

public sealed class MainForm : Form
{
    private readonly TextBox _logTextBox;

    public MainForm()
    {
        Text = "Keyboard Events";
        Width = 700;
        Height = 450;
        StartPosition = FormStartPosition.CenterScreen;

        KeyPreview = true;

        _logTextBox = new TextBox
        {
            Multiline = true,
            ReadOnly = true,
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Vertical,
            Font = new Font("Consolas", 10f) 
        };

        Controls.Add(_logTextBox);

        KeyDown += OnKeyDown;
        KeyUp += OnKeyUp;
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            _logTextBox.Clear();
            AppendLog("--- Журнал очищен ---");
            e.Handled = true; 
            return;
        }

        AppendLog($"[Нажата]   Клавиша: {e.KeyCode}");
    }

    private void OnKeyUp(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            return;
        }

        AppendLog($"[Отпущена] Клавиша: {e.KeyCode}");
    }

    private void AppendLog(string message)
    {
        _logTextBox.AppendText(message + Environment.NewLine);
        _logTextBox.SelectionStart = _logTextBox.Text.Length;
        _logTextBox.ScrollToCaret();
    }
}