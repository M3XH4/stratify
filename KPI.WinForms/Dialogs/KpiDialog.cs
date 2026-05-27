using KPI.Core.DTOs;
using KPI.Core.Enums;

namespace KPI.WinForms.Dialogs;

public partial class KpiDialog : Form
{
    private readonly IReadOnlyCollection<DepartmentDto> _departments;
    private readonly IReadOnlyCollection<UserSummaryDto> _users;

    public KpiDialog(string title, IReadOnlyCollection<DepartmentDto> departments, IReadOnlyCollection<UserSummaryDto> users, KpiDto? kpi = null)
    {
        _departments = departments;
        _users = users;
        InitializeComponent();
        UI.ThemeManager.ApplyFormStyle(this);
        Text = title;
        saveButton.Click += SaveButton_Click;

        departmentComboBox.DataSource = _departments.ToList();
        departmentComboBox.DisplayMember = nameof(DepartmentDto.Name);
        departmentComboBox.ValueMember = nameof(DepartmentDto.Id);

        var unassignedUser = new UserSummaryDto(0, "Unassigned", string.Empty, true, true, null, Array.Empty<string>());
        assignedUserComboBox.Items.Add(unassignedUser);
        foreach (var user in _users)
        {
            assignedUserComboBox.Items.Add(user);
        }
        assignedUserComboBox.DisplayMember = nameof(UserSummaryDto.FullName);
        assignedUserComboBox.SelectedItem = unassignedUser;

        statusComboBox.DataSource = Enum.GetValues(typeof(KpiStatus));

        if (kpi is not null)
        {
            nameTextBox.Text = kpi.Name;
            descriptionTextBox.Text = kpi.Description;
            categoryTextBox.Text = kpi.Category;
            targetNumeric.Value = kpi.TargetValue;
            actualNumeric.Value = kpi.ActualValue ?? 0;
            unitTextBox.Text = kpi.UnitOfMeasurement;
            weightNumeric.Value = kpi.Weight;
            startDatePicker.Value = kpi.StartDate.ToDateTime(TimeOnly.MinValue);
            endDatePicker.Value = kpi.EndDate.ToDateTime(TimeOnly.MinValue);
            statusComboBox.SelectedItem = kpi.Status;

            var department = _departments.FirstOrDefault(d => d.Name == kpi.DepartmentName);
            if (department is not null)
            {
                departmentComboBox.SelectedValue = department.Id;
            }

            var assignedUser = _users.FirstOrDefault(u => u.FullName == kpi.AssignedEmployeeName);
            if (assignedUser is not null)
            {
                assignedUserComboBox.SelectedItem = assignedUser;
            }
        }
    }

    public KpiUpsertRequest BuildRequest()
    {
        var assignedUser = assignedUserComboBox.SelectedItem as UserSummaryDto;
        return new KpiUpsertRequest(
            nameTextBox.Text.Trim(),
            descriptionTextBox.Text.Trim(),
            categoryTextBox.Text.Trim(),
            targetNumeric.Value,
            actualNumeric.Value,
            unitTextBox.Text.Trim(),
            (int)weightNumeric.Value,
            departmentComboBox.SelectedItem is DepartmentDto department ? department.Id : 0,
            assignedUser?.Id == 0 ? null : assignedUser?.Id,
            DateOnly.FromDateTime(startDatePicker.Value),
            DateOnly.FromDateTime(endDatePicker.Value),
            (KpiStatus)statusComboBox.SelectedItem!);
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            MessageBox.Show("KPI name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        if (string.IsNullOrWhiteSpace(categoryTextBox.Text))
        {
            MessageBox.Show("Category is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        if (targetNumeric.Value <= 0)
        {
            MessageBox.Show("Target value must be greater than zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        if (startDatePicker.Value.Date > endDatePicker.Value.Date)
        {
            MessageBox.Show("End date must be after the start date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
        }
    }
}
