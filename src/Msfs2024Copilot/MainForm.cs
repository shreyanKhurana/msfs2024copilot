using System;
using System.Windows.Forms;
using Msfs2024Copilot.Services;

namespace Msfs2024Copilot
{
    public partial class MainForm : Form
    {
        private readonly SpeechService _speechService;
        private readonly SimConnectService _simConnectService;

        public MainForm()
        {
            InitializeComponent();
            _speechService = new SpeechService();
            _simConnectService = new SimConnectService(Handle);

            _speechService.CommandRecognized += OnCommandRecognized;
            _speechService.StatusChanged += OnSpeechStatusChanged;
            _simConnectService.StatusChanged += OnSimConnectStatusChanged;
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

        private void AppendLog(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => AppendLog(message)));
                return;
            }

            logTextBox.AppendText($"{DateTime.Now:HH:mm:ss} {message}{Environment.NewLine}");
        }
    }
}
