namespace KPI.WinForms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        using (var splash = new SplashForm())
        {
            splash.Show();
            Application.DoEvents();
            System.Threading.Thread.Sleep(1500);
        }
        var apiClient = new Services.ApiClient("https://localhost:7247");
        using var loginForm = new LoginForm(apiClient);
        if (loginForm.ShowDialog() == DialogResult.OK && loginForm.AuthenticatedUser is not null)
        {
            apiClient.SetUserId(loginForm.AuthenticatedUser.UserId);
            Application.Run(new MainForm(loginForm.AuthenticatedUser, apiClient));
        }
    }    
}