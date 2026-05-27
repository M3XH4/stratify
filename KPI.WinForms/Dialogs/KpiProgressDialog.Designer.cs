namespace KPI.WinForms.Dialogs;

partial class KpiProgressDialog
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label actualLabel;
    private System.Windows.Forms.NumericUpDown actualNumeric;
    private System.Windows.Forms.Label commentLabel;
    private System.Windows.Forms.TextBox commentTextBox;
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
        actualLabel = new System.Windows.Forms.Label();
        actualNumeric = new System.Windows.Forms.NumericUpDown();
        commentLabel = new System.Windows.Forms.Label();
        commentTextBox = new System.Windows.Forms.TextBox();
        saveButton = new System.Windows.Forms.Button();
        cancelButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)actualNumeric).BeginInit();
        SuspendLayout();

        actualLabel.AutoSize = true;
        actualLabel.Location = new System.Drawing.Point(20, 20);
        actualLabel.Text = "Actual Value";

        actualNumeric.Location = new System.Drawing.Point(20, 40);
        actualNumeric.Size = new System.Drawing.Size(240, 23);
        actualNumeric.Maximum = 1000000;
        actualNumeric.DecimalPlaces = 2;

        commentLabel.AutoSize = true;
        commentLabel.Location = new System.Drawing.Point(20, 76);
        commentLabel.Text = "Comment";

        commentTextBox.Location = new System.Drawing.Point(20, 96);
        commentTextBox.Size = new System.Drawing.Size(240, 80);
        commentTextBox.Multiline = true;

        saveButton.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
        saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        saveButton.ForeColor = System.Drawing.Color.White;
        saveButton.Location = new System.Drawing.Point(100, 190);
        saveButton.Size = new System.Drawing.Size(80, 30);
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = false;
        saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;

        cancelButton.Location = new System.Drawing.Point(190, 190);
        cancelButton.Size = new System.Drawing.Size(80, 30);
        cancelButton.Text = "Cancel";
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(290, 240);
        Controls.Add(actualLabel);
        Controls.Add(actualNumeric);
        Controls.Add(commentLabel);
        Controls.Add(commentTextBox);
        Controls.Add(saveButton);
        Controls.Add(cancelButton);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        ResumeLayout(false);
        PerformLayout();
        ((System.ComponentModel.ISupportInitialize)actualNumeric).EndInit();
    }
}
