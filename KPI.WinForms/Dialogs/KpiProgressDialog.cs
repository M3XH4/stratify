using KPI.Core.DTOs;

namespace KPI.WinForms.Dialogs;

public partial class KpiProgressDialog : Form
{
    public KpiProgressDialog(string title, decimal? currentActual = null)
    {
        InitializeComponent();
        UI.ThemeManager.ApplyFormStyle(this);
        Text = title;
        if (currentActual.HasValue)
        {
            actualNumeric.Value = currentActual.Value;
        }
    }

    public KpiProgressUpdateRequest BuildRequest(int userId)
    {
        return new KpiProgressUpdateRequest(userId, actualNumeric.Value, commentTextBox.Text.Trim());
    }
}
