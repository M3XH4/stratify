namespace KPI.WinForms;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label titleLabel;
    private System.Windows.Forms.Label emailLabel;
    private System.Windows.Forms.Label passwordLabel;
    private Guna.UI2.WinForms.Guna2TextBox emailTextBox;
    private Guna.UI2.WinForms.Guna2TextBox passwordTextBox;
    private Guna.UI2.WinForms.Guna2Button loginButton;
    private System.Windows.Forms.Label statusLabel;
    private Guna.UI2.WinForms.Guna2Panel backgroundPanel;

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
        titleLabel = new System.Windows.Forms.Label();
        emailLabel = new System.Windows.Forms.Label();
        passwordLabel = new System.Windows.Forms.Label();
        emailTextBox = new Guna.UI2.WinForms.Guna2TextBox();
        passwordTextBox = new Guna.UI2.WinForms.Guna2TextBox();
        loginButton = new Guna.UI2.WinForms.Guna2Button();
        statusLabel = new System.Windows.Forms.Label();
        backgroundPanel = new Guna.UI2.WinForms.Guna2Panel();
        SuspendLayout();

        backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        backgroundPanel.FillColor = System.Drawing.Color.White;
        backgroundPanel.BorderRadius = 18;
        backgroundPanel.Padding = new System.Windows.Forms.Padding(20);
        backgroundPanel.Controls.Add(titleLabel);
        backgroundPanel.Controls.Add(emailLabel);
        backgroundPanel.Controls.Add(emailTextBox);
        backgroundPanel.Controls.Add(passwordLabel);
        backgroundPanel.Controls.Add(passwordTextBox);
        backgroundPanel.Controls.Add(loginButton);
        backgroundPanel.Controls.Add(statusLabel);

        titleLabel.AutoSize = true;
        titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        titleLabel.Location = new System.Drawing.Point(85, 25);
        titleLabel.Text = "KPI Login";

        emailLabel.AutoSize = true;
        emailLabel.Location = new System.Drawing.Point(40, 85);
        emailLabel.Text = "Email";

        emailTextBox.Location = new System.Drawing.Point(40, 105);
        emailTextBox.Size = new System.Drawing.Size(300, 36);
        emailTextBox.BorderRadius = 10;
        emailTextBox.PlaceholderText = "name@company.com";

        passwordLabel.AutoSize = true;
        passwordLabel.Location = new System.Drawing.Point(40, 145);
        passwordLabel.Text = "Password";

        passwordTextBox.Location = new System.Drawing.Point(40, 165);
        passwordTextBox.Size = new System.Drawing.Size(300, 36);
        passwordTextBox.BorderRadius = 10;
        passwordTextBox.PlaceholderText = "••••••••";
        passwordTextBox.PasswordChar = '●';

        loginButton.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
        loginButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        loginButton.ForeColor = System.Drawing.Color.White;
        loginButton.BorderRadius = 12;
        loginButton.Location = new System.Drawing.Point(40, 210);
        loginButton.Size = new System.Drawing.Size(300, 40);
        loginButton.Text = "Sign In";

        statusLabel.AutoSize = true;
        statusLabel.ForeColor = System.Drawing.Color.Firebrick;
        statusLabel.Location = new System.Drawing.Point(40, 255);
        statusLabel.Size = new System.Drawing.Size(0, 15);

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(380, 300);
        Controls.Add(backgroundPanel);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Login";
        ResumeLayout(false);
    }
}
