namespace Msfs2024Copilot
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button startListeningButton;
        private System.Windows.Forms.Button stopListeningButton;
        private System.Windows.Forms.TextBox logTextBox;

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
            this.connectButton = new System.Windows.Forms.Button();
            this.startListeningButton = new System.Windows.Forms.Button();
            this.stopListeningButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            
            this.connectButton.Location = new System.Drawing.Point(12, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(140, 35);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect to Sim";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            
            this.startListeningButton.Location = new System.Drawing.Point(168, 12);
            this.startListeningButton.Name = "startListeningButton";
            this.startListeningButton.Size = new System.Drawing.Size(140, 35);
            this.startListeningButton.TabIndex = 1;
            this.startListeningButton.Text = "Start Listening";
            this.startListeningButton.UseVisualStyleBackColor = true;
            this.startListeningButton.Click += new System.EventHandler(this.startListeningButton_Click);
            
            this.stopListeningButton.Location = new System.Drawing.Point(324, 12);
            this.stopListeningButton.Name = "stopListeningButton";
            this.stopListeningButton.Size = new System.Drawing.Size(140, 35);
            this.stopListeningButton.TabIndex = 2;
            this.stopListeningButton.Text = "Stop Listening";
            this.stopListeningButton.UseVisualStyleBackColor = true;
            this.stopListeningButton.Click += new System.EventHandler(this.stopListeningButton_Click);
            
            this.logTextBox.Location = new System.Drawing.Point(12, 60);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(600, 340);
            this.logTextBox.TabIndex = 3;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 412);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.stopListeningButton);
            this.Controls.Add(this.startListeningButton);
            this.Controls.Add(this.connectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MSFS 2024 Copilot (Offline)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
