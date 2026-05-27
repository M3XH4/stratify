using KPI.Core.DTOs;

namespace KPI.WinForms.Dialogs;

public partial class AuditFilterDialog : Form
{
    public AuditFilterDialog()
    {
        InitializeComponent();
        UI.ThemeManager.ApplyFormStyle(this);
        entityComboBox.Items.AddRange(new object[]
        {
            "All",
            "User",
            "Department",
            "KPI"
        });
        entityComboBox.SelectedIndex = 0;
    }

    public AuditLogFilter BuildFilter()
    {
        var entityName = entityComboBox.SelectedItem?.ToString();
        if (string.Equals(entityName, "All", StringComparison.OrdinalIgnoreCase))
        {
            entityName = null;
        }

        return new AuditLogFilter(
            entityName,
            DateOnly.FromDateTime(startDatePicker.Value),
            DateOnly.FromDateTime(endDatePicker.Value));
    }
}
