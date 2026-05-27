namespace KPI.WinForms.Dialogs;

partial class DepartmentDialog
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label nameLabel;
    private System.Windows.Forms.TextBox nameTextBox;
    private System.Windows.Forms.Label descriptionLabel;
    private System.Windows.Forms.TextBox descriptionTextBox;
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
        saveButton = new System.Windows.Forms.Button();
        cancelButton = new System.Windows.Forms.Button();
        SuspendLayout();

        nameLabel.AutoSize = true;
        nameLabel.Location = new System.Drawing.Point(24, 22);
        nameLabel.Text = "Name";

        nameTextBox.Location = new System.Drawing.Point(24, 44);
        nameTextBox.Size = new System.Drawing.Size(320, 23);

        descriptionLabel.AutoSize = true;
        descriptionLabel.Location = new System.Drawing.Point(24, 82);
        descriptionLabel.Text = "Description";

        descriptionTextBox.Location = new System.Drawing.Point(24, 104);
        descriptionTextBox.Multiline = true;
        descriptionTextBox.Size = new System.Drawing.Size(320, 80);

        saveButton.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
        saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        saveButton.ForeColor = System.Drawing.Color.White;
        saveButton.Location = new System.Drawing.Point(160, 200);
        saveButton.Size = new System.Drawing.Size(90, 30);
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = false;
        saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;

        cancelButton.Location = new System.Drawing.Point(254, 200);
        cancelButton.Size = new System.Drawing.Size(90, 30);
        cancelButton.Text = "Cancel";
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(370, 250);
        Controls.Add(nameLabel);
        Controls.Add(nameTextBox);
        Controls.Add(descriptionLabel);
        Controls.Add(descriptionTextBox);
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
