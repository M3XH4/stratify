using KPI.Core.DTOs;

namespace KPI.WinForms.Dialogs;

public partial class UserDialog : Form
{
    private readonly IReadOnlyCollection<DepartmentDto> _departments;
    private readonly IReadOnlyCollection<RoleDto> _roles;
    private readonly bool _requirePassword;

    public UserDialog(string title, IReadOnlyCollection<DepartmentDto> departments, IReadOnlyCollection<RoleDto> roles, UserSummaryDto? user = null, bool requirePassword = false)
    {
        _departments = departments;
        _roles = roles;
        _requirePassword = requirePassword;
        InitializeComponent();
        UI.ThemeManager.ApplyFormStyle(this);
        Text = title;
        saveButton.Click += SaveButton_Click;

        departmentComboBox.DataSource = _departments.ToList();
        departmentComboBox.DisplayMember = nameof(DepartmentDto.Name);
        departmentComboBox.ValueMember = nameof(DepartmentDto.Id);

        rolesCheckedListBox.DisplayMember = nameof(RoleDto.Name);

        foreach (var role in _roles)
        {
            rolesCheckedListBox.Items.Add(role, user?.Roles.Contains(role.Name) == true);
        }

        if (user is not null)
        {
            var nameParts = user.FullName.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            firstNameTextBox.Text = nameParts.ElementAtOrDefault(0) ?? string.Empty;
            lastNameTextBox.Text = nameParts.ElementAtOrDefault(1) ?? string.Empty;
            emailTextBox.Text = user.Email;
            isActiveCheckBox.Checked = user.IsActive;
            emailNotificationsCheckBox.Checked = user.ReceiveEmailNotifications;

            var selectedDepartment = _departments.FirstOrDefault(d => d.Name == user.DepartmentName);
            if (selectedDepartment is not null)
            {
                departmentComboBox.SelectedValue = selectedDepartment.Id;
            }
        }
        else
        {
            isActiveCheckBox.Checked = true;
            emailNotificationsCheckBox.Checked = true;
        }

        if (user is null)
        {
            passwordLabel.Text = "Password *";
        }
    }

    public UserUpsertRequest BuildRequest(bool requirePassword)
    {
        var selectedRoles = rolesCheckedListBox.CheckedItems
            .OfType<RoleDto>()
            .Select(role => role.Id)
            .ToList();

        var password = requirePassword ? passwordTextBox.Text : string.IsNullOrWhiteSpace(passwordTextBox.Text) ? null : passwordTextBox.Text;

        return new UserUpsertRequest(
            firstNameTextBox.Text.Trim(),
            lastNameTextBox.Text.Trim(),
            emailTextBox.Text.Trim(),
            password,
            departmentComboBox.SelectedItem is DepartmentDto department ? department.Id : null,
            isActiveCheckBox.Checked,
            emailNotificationsCheckBox.Checked,
            selectedRoles);
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) || string.IsNullOrWhiteSpace(lastNameTextBox.Text))
        {
            MessageBox.Show("First and last name are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        if (string.IsNullOrWhiteSpace(emailTextBox.Text))
        {
            MessageBox.Show("Email is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        if (_requirePassword && string.IsNullOrWhiteSpace(passwordTextBox.Text))
        {
            MessageBox.Show("Password is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        if (rolesCheckedListBox.CheckedItems.Count == 0)
        {
            MessageBox.Show("Select at least one role.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
        }
    }
}
