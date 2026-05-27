namespace KPI.WinForms.Dialogs;

partial class KpiApprovalDialog
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label notesLabel;
    private System.Windows.Forms.TextBox notesTextBox;
    private System.Windows.Forms.Button approveButton;
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
        notesLabel = new System.Windows.Forms.Label();
        notesTextBox = new System.Windows.Forms.TextBox();
        approveButton = new System.Windows.Forms.Button();
        cancelButton = new System.Windows.Forms.Button();
        SuspendLayout();

        notesLabel.AutoSize = true;
        notesLabel.Location = new System.Drawing.Point(20, 20);
        notesLabel.Text = "Approval Notes";

        notesTextBox.Location = new System.Drawing.Point(20, 40);
        notesTextBox.Size = new System.Drawing.Size(260, 90);
        notesTextBox.Multiline = true;

        approveButton.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
        approveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        approveButton.ForeColor = System.Drawing.Color.White;
        approveButton.Location = new System.Drawing.Point(110, 145);
        approveButton.Size = new System.Drawing.Size(80, 30);
        approveButton.Text = "Approve";
        approveButton.UseVisualStyleBackColor = false;
        approveButton.DialogResult = System.Windows.Forms.DialogResult.OK;

        cancelButton.Location = new System.Drawing.Point(200, 145);
        cancelButton.Size = new System.Drawing.Size(80, 30);
        cancelButton.Text = "Cancel";
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(300, 190);
        Controls.Add(notesLabel);
        Controls.Add(notesTextBox);
        Controls.Add(approveButton);
        Controls.Add(cancelButton);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        ResumeLayout(false);
        PerformLayout();
    }
}
