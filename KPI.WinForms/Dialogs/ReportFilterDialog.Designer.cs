namespace KPI.WinForms.Dialogs;

partial class ReportFilterDialog
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label departmentLabel;
    private System.Windows.Forms.ComboBox departmentComboBox;
    private System.Windows.Forms.Label statusLabel;
    private System.Windows.Forms.ComboBox statusComboBox;
    private System.Windows.Forms.Label startDateLabel;
    private System.Windows.Forms.DateTimePicker startDatePicker;
    private System.Windows.Forms.Label endDateLabel;
    private System.Windows.Forms.DateTimePicker endDatePicker;
    private System.Windows.Forms.Button applyButton;
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
        departmentLabel = new System.Windows.Forms.Label();
        departmentComboBox = new System.Windows.Forms.ComboBox();
        statusLabel = new System.Windows.Forms.Label();
        statusComboBox = new System.Windows.Forms.ComboBox();
        startDateLabel = new System.Windows.Forms.Label();
        startDatePicker = new System.Windows.Forms.DateTimePicker();
        endDateLabel = new System.Windows.Forms.Label();
        endDatePicker = new System.Windows.Forms.DateTimePicker();
        applyButton = new System.Windows.Forms.Button();
        cancelButton = new System.Windows.Forms.Button();
        SuspendLayout();

        departmentLabel.AutoSize = true;
        departmentLabel.Location = new System.Drawing.Point(20, 18);
        departmentLabel.Text = "Department";

        departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        departmentComboBox.Location = new System.Drawing.Point(20, 38);
        departmentComboBox.Size = new System.Drawing.Size(300, 23);

        statusLabel.AutoSize = true;
        statusLabel.Location = new System.Drawing.Point(20, 74);
        statusLabel.Text = "Status";

        statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        statusComboBox.Location = new System.Drawing.Point(20, 94);
        statusComboBox.Size = new System.Drawing.Size(300, 23);

        startDateLabel.AutoSize = true;
        startDateLabel.Location = new System.Drawing.Point(20, 130);
        startDateLabel.Text = "Start Date";

        startDatePicker.Location = new System.Drawing.Point(20, 150);
        startDatePicker.Size = new System.Drawing.Size(300, 23);

        endDateLabel.AutoSize = true;
        endDateLabel.Location = new System.Drawing.Point(20, 186);
        endDateLabel.Text = "End Date";

        endDatePicker.Location = new System.Drawing.Point(20, 206);
        endDatePicker.Size = new System.Drawing.Size(300, 23);

        applyButton.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
        applyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        applyButton.ForeColor = System.Drawing.Color.White;
        applyButton.Location = new System.Drawing.Point(150, 250);
        applyButton.Size = new System.Drawing.Size(80, 30);
        applyButton.Text = "Apply";
        applyButton.UseVisualStyleBackColor = false;
        applyButton.DialogResult = System.Windows.Forms.DialogResult.OK;

        cancelButton.Location = new System.Drawing.Point(240, 250);
        cancelButton.Size = new System.Drawing.Size(80, 30);
        cancelButton.Text = "Cancel";
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(350, 300);
        Controls.Add(departmentLabel);
        Controls.Add(departmentComboBox);
        Controls.Add(statusLabel);
        Controls.Add(statusComboBox);
        Controls.Add(startDateLabel);
        Controls.Add(startDatePicker);
        Controls.Add(endDateLabel);
        Controls.Add(endDatePicker);
        Controls.Add(applyButton);
        Controls.Add(cancelButton);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Report Filters";
        ResumeLayout(false);
        PerformLayout();
    }
}
