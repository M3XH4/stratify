using KPI.WinForms.UI;

namespace KPI.WinForms;

public partial class SplashForm : Form
{
    public SplashForm()
    {
        InitializeComponent();
        ThemeManager.ApplyFormStyle(this);
    }
}
