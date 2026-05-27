namespace KPI.WinForms;

partial class SplashForm
{
    private System.ComponentModel.IContainer components = null;
    private Guna.UI2.WinForms.Guna2Panel splashPanel;
    private System.Windows.Forms.Label titleLabel;
    private System.Windows.Forms.Label subtitleLabel;
    private Guna.UI2.WinForms.Guna2ProgressBar progressBar;

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
        components = new System.ComponentModel.Container();
        splashPanel = new Guna.UI2.WinForms.Guna2Panel();
        titleLabel = new System.Windows.Forms.Label();
        subtitleLabel = new System.Windows.Forms.Label();
        progressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
        SuspendLayout();

        splashPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        splashPanel.FillColor = System.Drawing.Color.FromArgb(15, 23, 42);
        splashPanel.BorderRadius = 18;
        splashPanel.Controls.Add(titleLabel);
        splashPanel.Controls.Add(subtitleLabel);
        splashPanel.Controls.Add(progressBar);

        titleLabel.AutoSize = true;
        titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        titleLabel.ForeColor = System.Drawing.Color.White;
        titleLabel.Location = new System.Drawing.Point(40, 40);
        titleLabel.Text = "KPI Management";

        subtitleLabel.AutoSize = true;
        subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
        subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
        subtitleLabel.Location = new System.Drawing.Point(42, 85);
        subtitleLabel.Text = "Loading dashboard...";

        progressBar.BorderRadius = 10;
        progressBar.FillColor = System.Drawing.Color.FromArgb(30, 41, 59);
        progressBar.ProgressColor = System.Drawing.Color.FromArgb(37, 99, 235);
        progressBar.Location = new System.Drawing.Point(42, 120);
        progressBar.Size = new System.Drawing.Size(300, 10);
        progressBar.Value = 70;

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(380, 200);
        Controls.Add(splashPanel);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        ResumeLayout(false);
    }
}
