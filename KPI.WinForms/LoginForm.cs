using KPI.Core.DTOs;
using KPI.WinForms.Services;

namespace KPI.WinForms;

public partial class LoginForm : Form
{
    private readonly ApiClient _apiClient;

    public LoginForm(ApiClient apiClient)
    {
        _apiClient = apiClient;
        InitializeComponent();
        UI.ThemeManager.ApplyFormStyle(this);
        loginButton.Click += LoginButton_Click;
    }

    public AuthResponse? AuthenticatedUser { get; private set; }

    private async void LoginButton_Click(object? sender, EventArgs e)
    {
        statusLabel.Text = string.Empty;
        loginButton.Enabled = false;

        try
        {
            var request = new AuthRequest(emailTextBox.Text.Trim(), passwordTextBox.Text);
            var response = await _apiClient.LoginAsync(request);
            if (response is null)
            {
                statusLabel.Text = "Invalid credentials or inactive account.";
                return;
            }

            AuthenticatedUser = response;
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            statusLabel.Text = ex.Message;
        }
        finally
        {
            loginButton.Enabled = true;
        }
    }
}
