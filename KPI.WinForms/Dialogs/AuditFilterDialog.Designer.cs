namespace KPI.WinForms.Dialogs;

partial class AuditFilterDialog
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label entityLabel;
    private System.Windows.Forms.ComboBox entityComboBox;
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
        entityLabel = new System.Windows.Forms.Label();
        entityComboBox = new System.Windows.Forms.ComboBox();
        startDateLabel = new System.Windows.Forms.Label();
        startDatePicker = new System.Windows.Forms.DateTimePicker();
        endDateLabel = new System.Windows.Forms.Label();
        endDatePicker = new System.Windows.Forms.DateTimePicker();
        applyButton = new System.Windows.Forms.Button();
        cancelButton = new System.Windows.Forms.Button();
        SuspendLayout();

        entityLabel.AutoSize = true;
        entityLabel.Location = new System.Drawing.Point(20, 18);
        entityLabel.Text = "Entity";

        entityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        entityComboBox.Location = new System.Drawing.Point(20, 38);
        entityComboBox.Size = new System.Drawing.Size(260, 23);

        startDateLabel.AutoSize = true;
        startDateLabel.Location = new System.Drawing.Point(20, 74);
        startDateLabel.Text = "Start Date";

        startDatePicker.Location = new System.Drawing.Point(20, 94);
        startDatePicker.Size = new System.Drawing.Size(260, 23);

        endDateLabel.AutoSize = true;
        endDateLabel.Location = new System.Drawing.Point(20, 130);
        endDateLabel.Text = "End Date";

        endDatePicker.Location = new System.Drawing.Point(20, 150);
        endDatePicker.Size = new System.Drawing.Size(260, 23);

        applyButton.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
        applyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        applyButton.ForeColor = System.Drawing.Color.White;
        applyButton.Location = new System.Drawing.Point(110, 195);
        applyButton.Size = new System.Drawing.Size(80, 30);
        applyButton.Text = "Apply";
        applyButton.UseVisualStyleBackColor = false;
        applyButton.DialogResult = System.Windows.Forms.DialogResult.OK;

        cancelButton.Location = new System.Drawing.Point(200, 195);
        cancelButton.Size = new System.Drawing.Size(80, 30);
        cancelButton.Text = "Cancel";
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(300, 240);
        Controls.Add(entityLabel);
        Controls.Add(entityComboBox);
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
        Text = "Audit Filters";
        ResumeLayout(false);
        PerformLayout();
    }
}
