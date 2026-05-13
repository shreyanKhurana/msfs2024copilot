using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Msfs2024Copilot.Services;

namespace Msfs2024Copilot
{
    public partial class MainForm : Form
    {
        private readonly SpeechService _speechService;
        private readonly SimConnectService _simConnectService;
        private List<SpeechService.InputDevice> _inputDevices;

        public MainForm()
        {
            InitializeComponent();
            _speechService = new SpeechService();
            _simConnectService = new SimConnectService(Handle);

            _speechService.CommandRecognized += OnCommandRecognized;
            _speechService.StatusChanged += OnSpeechStatusChanged;
            _speechService.AudioLevelChanged += OnAudioLevelChanged;
            _simConnectService.StatusChanged += OnSimConnectStatusChanged;

            ApplyGlassTheme();
            Load += MainForm_Load;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
                ClientRectangle,
                Color.FromArgb(255, 16, 22, 32),
                Color.FromArgb(255, 28, 35, 52),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            _simConnectService.Connect();
        }

        private void startListeningButton_Click(object sender, EventArgs e)
        {
            _speechService.Start();
        }

        private void stopListeningButton_Click(object sender, EventArgs e)
        {
            _speechService.Stop();
        }

        private void refreshMicsButton_Click(object sender, EventArgs e)
        {
            LoadInputDevices();
        }

        private void applyMicButton_Click(object sender, EventArgs e)
        {
            if (micComboBox.SelectedItem is SpeechService.InputDevice device)
            {
                _speechService.SetInputDevice(device.Id);
                micStatusLabel.Text = $"Active mic: {device.Name}";
                AppendLog($"Mic set to: {device.Name}");
            }
        }

        private void openSoundSettingsButton_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("ms-settings:sound") { UseShellExecute = true });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadInputDevices();
        }

        private void OnCommandRecognized(object sender, string command)
        {
            AppendLog($"> {command}");
            _simConnectService.ExecuteCommand(command);
        }

        private void OnSpeechStatusChanged(object sender, string status)
        {
            AppendLog(status);
        }

        private void OnSimConnectStatusChanged(object sender, string status)
        {
            AppendLog(status);
        }

        private void OnAudioLevelChanged(object sender, int level)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => OnAudioLevelChanged(sender, level)));
                return;
            }

            micLevelProgressBar.Value = Math.Max(0, Math.Min(100, level));
        }

        private void AppendLog(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => AppendLog(message)));
                return;
            }

            logTextBox.AppendText($"{DateTime.Now:HH:mm:ss} {message}{Environment.NewLine}");
        }

        private void LoadInputDevices()
        {
            _inputDevices = _speechService.GetInputDevices();
            micComboBox.DataSource = _inputDevices;
            micComboBox.DisplayMember = nameof(SpeechService.InputDevice.Name);
            micComboBox.ValueMember = nameof(SpeechService.InputDevice.Id);

            if (_inputDevices.Count > 0)
            {
                micComboBox.SelectedIndex = 0;
                micStatusLabel.Text = $"Found {_inputDevices.Count - 1} microphone(s).";
            }
            else
            {
                micStatusLabel.Text = "No microphones found.";
            }
        }

        private void ApplyGlassTheme()
        {
            BackColor = Color.FromArgb(18, 24, 34);
            Font = new Font("Segoe UI Variable Display", 9.5f, FontStyle.Regular);

            headerPanel.BackColor = Color.FromArgb(180, 22, 28, 40);
            headerPanel.ForeColor = Color.White;
            titleLabel.ForeColor = Color.White;
            subtitleLabel.ForeColor = Color.FromArgb(190, 220, 230, 255);

            consolePanel.BackColor = Color.FromArgb(150, 24, 30, 42);
            settingsPanel.BackColor = Color.FromArgb(150, 24, 30, 42);

            logTextBox.BackColor = Color.FromArgb(18, 22, 32);
            logTextBox.ForeColor = Color.FromArgb(220, 230, 240);
            logTextBox.BorderStyle = BorderStyle.FixedSingle;

            micStatusLabel.ForeColor = Color.FromArgb(200, 220, 240);
        }
    }
}
