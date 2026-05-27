using KPI.Core.DTOs;
using KPI.WinForms.Services;

namespace KPI.WinForms.Dialogs;

public partial class KpiHistoryDialog : Form
{
    private readonly ApiClient _apiClient;
    private readonly int _kpiId;

    public KpiHistoryDialog(ApiClient apiClient, int kpiId)
    {
        _apiClient = apiClient;
        _kpiId = kpiId;
        InitializeComponent();
        UI.ThemeManager.ApplyFormStyle(this);
        Load += KpiHistoryDialog_Load;
    }

    private async void KpiHistoryDialog_Load(object? sender, EventArgs e)
    {
        var updates = await _apiClient.GetKpiUpdatesAsync(_kpiId);
        var approvals = await _apiClient.GetKpiApprovalsAsync(_kpiId);
        updatesGrid.DataSource = updates.ToList();
        approvalsGrid.DataSource = approvals.ToList();
    }
}
