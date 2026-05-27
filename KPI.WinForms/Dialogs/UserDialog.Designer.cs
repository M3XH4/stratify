namespace KPI.WinForms.Dialogs;

partial class UserDialog
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label firstNameLabel;
    private System.Windows.Forms.TextBox firstNameTextBox;
    private System.Windows.Forms.Label lastNameLabel;
    private System.Windows.Forms.TextBox lastNameTextBox;
    private System.Windows.Forms.Label emailLabel;
    private System.Windows.Forms.TextBox emailTextBox;
    private System.Windows.Forms.Label passwordLabel;
    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.Label departmentLabel;
    private System.Windows.Forms.ComboBox departmentComboBox;
    private System.Windows.Forms.Label rolesLabel;
    private System.Windows.Forms.CheckedListBox rolesCheckedListBox;
    private System.Windows.Forms.CheckBox isActiveCheckBox;
    private System.Windows.Forms.CheckBox emailNotificationsCheckBox;
    private System.Windows.Forms.Button saveButton;
    private System.Windows.Forms.Button cancelButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        firstNameLabel = new System.Windows.Forms.Label();
        firstNameTextBox = new System.Windows.Forms.TextBox();
        lastNameLabel = new System.Windows.Forms.Label();
        lastNameTextBox = new System.Windows.Forms.TextBox();
        emailLabel = new System.Windows.Forms.Label();
        emailTextBox = new System.Windows.Forms.TextBox();
        passwordLabel = new System.Windows.Forms.Label();
        passwordTextBox = new System.Windows.Forms.TextBox();
        departmentLabel = new System.Windows.Forms.Label();
        departmentComboBox = new System.Windows.Forms.ComboBox();
        rolesLabel = new System.Windows.Forms.Label();
        rolesCheckedListBox = new System.Windows.Forms.CheckedListBox();
        isActiveCheckBox = new System.Windows.Forms.CheckBox();
        emailNotificationsCheckBox = new System.Windows.Forms.CheckBox();
        saveButton = new System.Windows.Forms.Button();
        cancelButton = new System.Windows.Forms.Button();
        SuspendLayout();

        firstNameLabel.AutoSize = true;
        firstNameLabel.Location = new System.Drawing.Point(20, 18);
        firstNameLabel.Text = "First Name";

        firstNameTextBox.Location = new System.Drawing.Point(20, 38);
        firstNameTextBox.Size = new System.Drawing.Size(180, 23);

        lastNameLabel.AutoSize = true;
        lastNameLabel.Location = new System.Drawing.Point(220, 18);
        lastNameLabel.Text = "Last Name";

        lastNameTextBox.Location = new System.Drawing.Point(220, 38);
        lastNameTextBox.Size = new System.Drawing.Size(180, 23);

        emailLabel.AutoSize = true;
        emailLabel.Location = new System.Drawing.Point(20, 74);
        emailLabel.Text = "Email";

        emailTextBox.Location = new System.Drawing.Point(20, 94);
        emailTextBox.Size = new System.Drawing.Size(380, 23);

        passwordLabel.AutoSize = true;
        passwordLabel.Location = new System.Drawing.Point(20, 130);
        passwordLabel.Text = "Password";

        passwordTextBox.Location = new System.Drawing.Point(20, 150);
        passwordTextBox.Size = new System.Drawing.Size(380, 23);
        passwordTextBox.PasswordChar = '●';

        departmentLabel.AutoSize = true;
        departmentLabel.Location = new System.Drawing.Point(20, 186);
        departmentLabel.Text = "Department";

        departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        departmentComboBox.Location = new System.Drawing.Point(20, 206);
        departmentComboBox.Size = new System.Drawing.Size(380, 23);

        rolesLabel.AutoSize = true;
        rolesLabel.Location = new System.Drawing.Point(20, 242);
        rolesLabel.Text = "Roles";

        rolesCheckedListBox.Location = new System.Drawing.Point(20, 262);
        rolesCheckedListBox.Size = new System.Drawing.Size(380, 76);

        isActiveCheckBox.AutoSize = true;
        isActiveCheckBox.Location = new System.Drawing.Point(20, 348);
        isActiveCheckBox.Text = "Active";

        emailNotificationsCheckBox.AutoSize = true;
        emailNotificationsCheckBox.Location = new System.Drawing.Point(120, 348);
        emailNotificationsCheckBox.Text = "Email Notifications";

        saveButton.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
        saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        saveButton.ForeColor = System.Drawing.Color.White;
        saveButton.Location = new System.Drawing.Point(230, 380);
        saveButton.Size = new System.Drawing.Size(80, 30);
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = false;
        saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;

        cancelButton.Location = new System.Drawing.Point(320, 380);
        cancelButton.Size = new System.Drawing.Size(80, 30);
        cancelButton.Text = "Cancel";
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(430, 430);
        Controls.Add(firstNameLabel);
        Controls.Add(firstNameTextBox);
        Controls.Add(lastNameLabel);
        Controls.Add(lastNameTextBox);
        Controls.Add(emailLabel);
        Controls.Add(emailTextBox);
        Controls.Add(passwordLabel);
        Controls.Add(passwordTextBox);
        Controls.Add(departmentLabel);
        Controls.Add(departmentComboBox);
        Controls.Add(rolesLabel);
        Controls.Add(rolesCheckedListBox);
        Controls.Add(isActiveCheckBox);
        Controls.Add(emailNotificationsCheckBox);
        Controls.Add(saveButton);
        Controls.Add(cancelButton);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        ResumeLayout(false);
        PerformLayout();
    }
}
