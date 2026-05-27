namespace KPI.WinForms.Dialogs;

partial class KpiDialog
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label nameLabel;
    private System.Windows.Forms.TextBox nameTextBox;
    private System.Windows.Forms.Label descriptionLabel;
    private System.Windows.Forms.TextBox descriptionTextBox;
    private System.Windows.Forms.Label categoryLabel;
    private System.Windows.Forms.TextBox categoryTextBox;
    private System.Windows.Forms.Label targetLabel;
    private System.Windows.Forms.NumericUpDown targetNumeric;
    private System.Windows.Forms.Label actualLabel;
    private System.Windows.Forms.NumericUpDown actualNumeric;
    private System.Windows.Forms.Label unitLabel;
    private System.Windows.Forms.TextBox unitTextBox;
    private System.Windows.Forms.Label weightLabel;
    private System.Windows.Forms.NumericUpDown weightNumeric;
    private System.Windows.Forms.Label departmentLabel;
    private System.Windows.Forms.ComboBox departmentComboBox;
    private System.Windows.Forms.Label assignedLabel;
    private System.Windows.Forms.ComboBox assignedUserComboBox;
    private System.Windows.Forms.Label startDateLabel;
    private System.Windows.Forms.DateTimePicker startDatePicker;
    private System.Windows.Forms.Label endDateLabel;
    private System.Windows.Forms.DateTimePicker endDatePicker;
    private System.Windows.Forms.Label statusLabel;
    private System.Windows.Forms.ComboBox statusComboBox;
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
        nameLabel = new System.Windows.Forms.Label();
        nameTextBox = new System.Windows.Forms.TextBox();
        descriptionLabel = new System.Windows.Forms.Label();
        descriptionTextBox = new System.Windows.Forms.TextBox();
        categoryLabel = new System.Windows.Forms.Label();
        categoryTextBox = new System.Windows.Forms.TextBox();
        targetLabel = new System.Windows.Forms.Label();
        targetNumeric = new System.Windows.Forms.NumericUpDown();
        actualLabel = new System.Windows.Forms.Label();
        actualNumeric = new System.Windows.Forms.NumericUpDown();
        unitLabel = new System.Windows.Forms.Label();
        unitTextBox = new System.Windows.Forms.TextBox();
        weightLabel = new System.Windows.Forms.Label();
        weightNumeric = new System.Windows.Forms.NumericUpDown();
        departmentLabel = new System.Windows.Forms.Label();
        departmentComboBox = new System.Windows.Forms.ComboBox();
        assignedLabel = new System.Windows.Forms.Label();
        assignedUserComboBox = new System.Windows.Forms.ComboBox();
        startDateLabel = new System.Windows.Forms.Label();
        startDatePicker = new System.Windows.Forms.DateTimePicker();
        endDateLabel = new System.Windows.Forms.Label();
        endDatePicker = new System.Windows.Forms.DateTimePicker();
        statusLabel = new System.Windows.Forms.Label();
        statusComboBox = new System.Windows.Forms.ComboBox();
        saveButton = new System.Windows.Forms.Button();
        cancelButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)targetNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)actualNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)weightNumeric).BeginInit();
        SuspendLayout();

        nameLabel.AutoSize = true;
        nameLabel.Location = new System.Drawing.Point(20, 16);
        nameLabel.Text = "Name";

        nameTextBox.Location = new System.Drawing.Point(20, 36);
        nameTextBox.Size = new System.Drawing.Size(380, 23);

        descriptionLabel.AutoSize = true;
        descriptionLabel.Location = new System.Drawing.Point(20, 68);
        descriptionLabel.Text = "Description";

        descriptionTextBox.Location = new System.Drawing.Point(20, 88);
        descriptionTextBox.Size = new System.Drawing.Size(380, 50);
        descriptionTextBox.Multiline = true;

        categoryLabel.AutoSize = true;
        categoryLabel.Location = new System.Drawing.Point(20, 146);
        categoryLabel.Text = "Category";

        categoryTextBox.Location = new System.Drawing.Point(20, 166);
        categoryTextBox.Size = new System.Drawing.Size(180, 23);

        targetLabel.AutoSize = true;
        targetLabel.Location = new System.Drawing.Point(220, 146);
        targetLabel.Text = "Target";

        targetNumeric.Location = new System.Drawing.Point(220, 166);
        targetNumeric.Size = new System.Drawing.Size(180, 23);
        targetNumeric.Maximum = 1000000;
        targetNumeric.DecimalPlaces = 2;

        actualLabel.AutoSize = true;
        actualLabel.Location = new System.Drawing.Point(20, 200);
        actualLabel.Text = "Actual";

        actualNumeric.Location = new System.Drawing.Point(20, 220);
        actualNumeric.Size = new System.Drawing.Size(180, 23);
        actualNumeric.Maximum = 1000000;
        actualNumeric.DecimalPlaces = 2;

        unitLabel.AutoSize = true;
        unitLabel.Location = new System.Drawing.Point(220, 200);
        unitLabel.Text = "Unit";

        unitTextBox.Location = new System.Drawing.Point(220, 220);
        unitTextBox.Size = new System.Drawing.Size(180, 23);

        weightLabel.AutoSize = true;
        weightLabel.Location = new System.Drawing.Point(20, 254);
        weightLabel.Text = "Weight";

        weightNumeric.Location = new System.Drawing.Point(20, 274);
        weightNumeric.Size = new System.Drawing.Size(180, 23);
        weightNumeric.Maximum = 100;

        departmentLabel.AutoSize = true;
        departmentLabel.Location = new System.Drawing.Point(220, 254);
        departmentLabel.Text = "Department";

        departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        departmentComboBox.Location = new System.Drawing.Point(220, 274);
        departmentComboBox.Size = new System.Drawing.Size(180, 23);

        assignedLabel.AutoSize = true;
        assignedLabel.Location = new System.Drawing.Point(20, 308);
        assignedLabel.Text = "Assigned Employee";

        assignedUserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        assignedUserComboBox.Location = new System.Drawing.Point(20, 328);
        assignedUserComboBox.Size = new System.Drawing.Size(380, 23);

        startDateLabel.AutoSize = true;
        startDateLabel.Location = new System.Drawing.Point(20, 360);
        startDateLabel.Text = "Start Date";

        startDatePicker.Location = new System.Drawing.Point(20, 380);
        startDatePicker.Size = new System.Drawing.Size(180, 23);

        endDateLabel.AutoSize = true;
        endDateLabel.Location = new System.Drawing.Point(220, 360);
        endDateLabel.Text = "End Date";

        endDatePicker.Location = new System.Drawing.Point(220, 380);
        endDatePicker.Size = new System.Drawing.Size(180, 23);

        statusLabel.AutoSize = true;
        statusLabel.Location = new System.Drawing.Point(20, 412);
        statusLabel.Text = "Status";

        statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        statusComboBox.Location = new System.Drawing.Point(20, 432);
        statusComboBox.Size = new System.Drawing.Size(180, 23);

        saveButton.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
        saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        saveButton.ForeColor = System.Drawing.Color.White;
        saveButton.Location = new System.Drawing.Point(230, 470);
        saveButton.Size = new System.Drawing.Size(80, 30);
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = false;
        saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;

        cancelButton.Location = new System.Drawing.Point(320, 470);
        cancelButton.Size = new System.Drawing.Size(80, 30);
        cancelButton.Text = "Cancel";
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(430, 520);
        Controls.Add(nameLabel);
        Controls.Add(nameTextBox);
        Controls.Add(descriptionLabel);
        Controls.Add(descriptionTextBox);
        Controls.Add(categoryLabel);
        Controls.Add(categoryTextBox);
        Controls.Add(targetLabel);
        Controls.Add(targetNumeric);
        Controls.Add(actualLabel);
        Controls.Add(actualNumeric);
        Controls.Add(unitLabel);
        Controls.Add(unitTextBox);
        Controls.Add(weightLabel);
        Controls.Add(weightNumeric);
        Controls.Add(departmentLabel);
        Controls.Add(departmentComboBox);
        Controls.Add(assignedLabel);
        Controls.Add(assignedUserComboBox);
        Controls.Add(startDateLabel);
        Controls.Add(startDatePicker);
        Controls.Add(endDateLabel);
        Controls.Add(endDatePicker);
        Controls.Add(statusLabel);
        Controls.Add(statusComboBox);
        Controls.Add(saveButton);
        Controls.Add(cancelButton);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        ((System.ComponentModel.ISupportInitialize)targetNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)actualNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)weightNumeric).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
