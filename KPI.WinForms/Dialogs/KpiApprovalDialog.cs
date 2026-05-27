using KPI.Core.DTOs;

namespace KPI.WinForms.Dialogs;

public partial class KpiApprovalDialog : Form
{
    public KpiApprovalDialog(string title)
    {
        InitializeComponent();
        UI.ThemeManager.ApplyFormStyle(this);
        Text = title;
    }

    public KpiApprovalRequest BuildRequest(int userId)
    {
        return new KpiApprovalRequest(userId, notesTextBox.Text.Trim());
    }
}
