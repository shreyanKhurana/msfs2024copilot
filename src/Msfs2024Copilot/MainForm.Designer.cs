namespace Msfs2024Copilot
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage consoleTabPage;
        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Panel consolePanel;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button startListeningButton;
        private System.Windows.Forms.Button stopListeningButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label micLabel;
        private System.Windows.Forms.ComboBox micComboBox;
        private System.Windows.Forms.Button refreshMicsButton;
        private System.Windows.Forms.Button applyMicButton;
        private System.Windows.Forms.Button openSoundSettingsButton;
        private System.Windows.Forms.ProgressBar micLevelProgressBar;
        private System.Windows.Forms.Label micStatusLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.consoleTabPage = new System.Windows.Forms.TabPage();
            this.consolePanel = new System.Windows.Forms.Panel();
            this.connectButton = new System.Windows.Forms.Button();
            this.startListeningButton = new System.Windows.Forms.Button();
            this.stopListeningButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.micLabel = new System.Windows.Forms.Label();
            this.micComboBox = new System.Windows.Forms.ComboBox();
            this.refreshMicsButton = new System.Windows.Forms.Button();
            this.applyMicButton = new System.Windows.Forms.Button();
            this.openSoundSettingsButton = new System.Windows.Forms.Button();
            this.micLevelProgressBar = new System.Windows.Forms.ProgressBar();
            this.micStatusLabel = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.mainTabControl.Controls.Add(this.consoleTabPage);
            this.mainTabControl.Controls.Add(this.settingsTabPage);
            this.mainTabControl.Location = new System.Drawing.Point(12, 72);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(760, 456);
            this.mainTabControl.TabIndex = 0;

            this.consoleTabPage.Controls.Add(this.consolePanel);
            this.consoleTabPage.Location = new System.Drawing.Point(4, 26);
            this.consoleTabPage.Name = "consoleTabPage";
            this.consoleTabPage.Padding = new System.Windows.Forms.Padding(8);
            this.consoleTabPage.Size = new System.Drawing.Size(752, 426);
            this.consoleTabPage.TabIndex = 0;
            this.consoleTabPage.Text = "Console";
            this.consoleTabPage.UseVisualStyleBackColor = true;

            this.consolePanel.Controls.Add(this.connectButton);
            this.consolePanel.Controls.Add(this.startListeningButton);
            this.consolePanel.Controls.Add(this.stopListeningButton);
            this.consolePanel.Controls.Add(this.logTextBox);
            this.consolePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consolePanel.Location = new System.Drawing.Point(8, 8);
            this.consolePanel.Name = "consolePanel";
            this.consolePanel.Padding = new System.Windows.Forms.Padding(12);
            this.consolePanel.Size = new System.Drawing.Size(736, 410);
            this.consolePanel.TabIndex = 0;

            this.connectButton.Location = new System.Drawing.Point(16, 14);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(150, 36);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect to Sim";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);

            this.startListeningButton.Location = new System.Drawing.Point(176, 14);
            this.startListeningButton.Name = "startListeningButton";
            this.startListeningButton.Size = new System.Drawing.Size(150, 36);
            this.startListeningButton.TabIndex = 1;
            this.startListeningButton.Text = "Start Listening";
            this.startListeningButton.UseVisualStyleBackColor = true;
            this.startListeningButton.Click += new System.EventHandler(this.startListeningButton_Click);

            this.stopListeningButton.Location = new System.Drawing.Point(336, 14);
            this.stopListeningButton.Name = "stopListeningButton";
            this.stopListeningButton.Size = new System.Drawing.Size(150, 36);
            this.stopListeningButton.TabIndex = 2;
            this.stopListeningButton.Text = "Stop Listening";
            this.stopListeningButton.UseVisualStyleBackColor = true;
            this.stopListeningButton.Click += new System.EventHandler(this.stopListeningButton_Click);

            this.logTextBox.Location = new System.Drawing.Point(16, 62);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(704, 334);
            this.logTextBox.TabIndex = 3;

            this.settingsTabPage.Controls.Add(this.settingsPanel);
            this.settingsTabPage.Location = new System.Drawing.Point(4, 26);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Padding = new System.Windows.Forms.Padding(8);
            this.settingsTabPage.Size = new System.Drawing.Size(752, 426);
            this.settingsTabPage.TabIndex = 1;
            this.settingsTabPage.Text = "Settings";
            this.settingsTabPage.UseVisualStyleBackColor = true;

            this.settingsPanel.Controls.Add(this.micLabel);
            this.settingsPanel.Controls.Add(this.micComboBox);
            this.settingsPanel.Controls.Add(this.refreshMicsButton);
            this.settingsPanel.Controls.Add(this.applyMicButton);
            this.settingsPanel.Controls.Add(this.openSoundSettingsButton);
            this.settingsPanel.Controls.Add(this.micLevelProgressBar);
            this.settingsPanel.Controls.Add(this.micStatusLabel);
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPanel.Location = new System.Drawing.Point(8, 8);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Padding = new System.Windows.Forms.Padding(16);
            this.settingsPanel.Size = new System.Drawing.Size(736, 410);
            this.settingsPanel.TabIndex = 0;

            this.micLabel.Location = new System.Drawing.Point(20, 24);
            this.micLabel.Name = "micLabel";
            this.micLabel.Size = new System.Drawing.Size(200, 20);
            this.micLabel.TabIndex = 0;
            this.micLabel.Text = "Input microphone";

            this.micComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.micComboBox.FormattingEnabled = true;
            this.micComboBox.Location = new System.Drawing.Point(20, 48);
            this.micComboBox.Name = "micComboBox";
            this.micComboBox.Size = new System.Drawing.Size(500, 24);
            this.micComboBox.TabIndex = 1;

            this.refreshMicsButton.Location = new System.Drawing.Point(532, 46);
            this.refreshMicsButton.Name = "refreshMicsButton";
            this.refreshMicsButton.Size = new System.Drawing.Size(88, 28);
            this.refreshMicsButton.TabIndex = 2;
            this.refreshMicsButton.Text = "Refresh";
            this.refreshMicsButton.UseVisualStyleBackColor = true;
            this.refreshMicsButton.Click += new System.EventHandler(this.refreshMicsButton_Click);

            this.applyMicButton.Location = new System.Drawing.Point(628, 46);
            this.applyMicButton.Name = "applyMicButton";
            this.applyMicButton.Size = new System.Drawing.Size(88, 28);
            this.applyMicButton.TabIndex = 3;
            this.applyMicButton.Text = "Apply";
            this.applyMicButton.UseVisualStyleBackColor = true;
            this.applyMicButton.Click += new System.EventHandler(this.applyMicButton_Click);

            this.openSoundSettingsButton.Location = new System.Drawing.Point(20, 86);
            this.openSoundSettingsButton.Name = "openSoundSettingsButton";
            this.openSoundSettingsButton.Size = new System.Drawing.Size(200, 28);
            this.openSoundSettingsButton.TabIndex = 4;
            this.openSoundSettingsButton.Text = "Open Windows Sound";
            this.openSoundSettingsButton.UseVisualStyleBackColor = true;
            this.openSoundSettingsButton.Click += new System.EventHandler(this.openSoundSettingsButton_Click);

            this.micLevelProgressBar.Location = new System.Drawing.Point(20, 134);
            this.micLevelProgressBar.Maximum = 100;
            this.micLevelProgressBar.Name = "micLevelProgressBar";
            this.micLevelProgressBar.Size = new System.Drawing.Size(300, 12);
            this.micLevelProgressBar.TabIndex = 5;

            this.micStatusLabel.Location = new System.Drawing.Point(20, 156);
            this.micStatusLabel.Name = "micStatusLabel";
            this.micStatusLabel.Size = new System.Drawing.Size(600, 20);
            this.micStatusLabel.TabIndex = 6;
            this.micStatusLabel.Text = "No microphones found.";

            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.subtitleLabel);
            this.headerPanel.Location = new System.Drawing.Point(12, 12);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(12);
            this.headerPanel.Size = new System.Drawing.Size(760, 52);
            this.headerPanel.TabIndex = 1;

            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(16, 14);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(217, 21);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "MSFS 2024 Copilot";

            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Location = new System.Drawing.Point(240, 18);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(219, 17);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Offline voice + SimConnect";

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 540);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.mainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MSFS 2024 Copilot (Offline)";
            this.ResumeLayout(false);
        }
    }
}
