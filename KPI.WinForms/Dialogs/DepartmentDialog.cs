using KPI.Core.DTOs;

namespace KPI.WinForms.Dialogs;

public partial class DepartmentDialog : Form
{
    public DepartmentDialog(string title, DepartmentDto? department = null)
    {
        InitializeComponent();
        UI.ThemeManager.ApplyFormStyle(this);
        Text = title;
        saveButton.Click += SaveButton_Click;

        if (department is not null)
        {
            nameTextBox.Text = department.Name;
            descriptionTextBox.Text = department.Description;
        }
    }

    public DepartmentRequest BuildRequest()
    {
        return new DepartmentRequest(nameTextBox.Text.Trim(), descriptionTextBox.Text.Trim());
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            MessageBox.Show("Department name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
        }
    }
}
