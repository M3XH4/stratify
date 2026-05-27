using KPI.Core.DTOs;
using KPI.Core.Enums;

namespace KPI.WinForms.Dialogs;

public partial class ReportFilterDialog : Form
{
    private string _departmentLabel = "All Departments";
    private string _statusLabel = "All Statuses";

    public ReportFilterDialog(IReadOnlyCollection<DepartmentDto> departments)
    {
        InitializeComponent();
        UI.ThemeManager.ApplyFormStyle(this);

        departmentComboBox.Items.Add("All Departments");
        foreach (var department in departments)
        {
            departmentComboBox.Items.Add(department);
        }

        departmentComboBox.DisplayMember = nameof(DepartmentDto.Name);
        departmentComboBox.SelectedIndex = 0;

        statusComboBox.Items.Add("All Statuses");
        foreach (var status in Enum.GetValues(typeof(KpiStatus)))
        {
            statusComboBox.Items.Add(status);
        }
        statusComboBox.SelectedIndex = 0;
    }

    public KpiReportFilter BuildFilter()
    {
        var department = departmentComboBox.SelectedItem as DepartmentDto;
        var status = statusComboBox.SelectedItem is KpiStatus kpiStatus ? kpiStatus : (KpiStatus?)null;

        _departmentLabel = department?.Name ?? "All Departments";
        _statusLabel = status?.ToString() ?? "All Statuses";

        return new KpiReportFilter(
            department?.Id,
            DateOnly.FromDateTime(startDatePicker.Value),
            DateOnly.FromDateTime(endDatePicker.Value),
            status);
    }

    public KpiReportFilterSummary BuildSummary()
    {
        var dateRangeLabel = $"Date Range: {startDatePicker.Value:yyyy-MM-dd} - {endDatePicker.Value:yyyy-MM-dd}";
        return new KpiReportFilterSummary(
            _departmentLabel,
            _statusLabel,
            dateRangeLabel);
    }
}
