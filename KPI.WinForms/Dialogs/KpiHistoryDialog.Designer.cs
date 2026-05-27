namespace KPI.WinForms.Dialogs;

partial class KpiHistoryDialog
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label updatesLabel;
    private System.Windows.Forms.Label approvalsLabel;
    private System.Windows.Forms.DataGridView updatesGrid;
    private System.Windows.Forms.DataGridView approvalsGrid;

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
        updatesLabel = new System.Windows.Forms.Label();
        approvalsLabel = new System.Windows.Forms.Label();
        updatesGrid = new System.Windows.Forms.DataGridView();
        approvalsGrid = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)updatesGrid).BeginInit();
        ((System.ComponentModel.ISupportInitialize)approvalsGrid).BeginInit();
        SuspendLayout();

        updatesLabel.AutoSize = true;
        updatesLabel.Location = new System.Drawing.Point(20, 15);
        updatesLabel.Text = "Progress Updates";

        updatesGrid.Location = new System.Drawing.Point(20, 35);
        updatesGrid.Size = new System.Drawing.Size(740, 180);
        updatesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        updatesGrid.ReadOnly = true;
        updatesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

        approvalsLabel.AutoSize = true;
        approvalsLabel.Location = new System.Drawing.Point(20, 225);
        approvalsLabel.Text = "Approvals";

        approvalsGrid.Location = new System.Drawing.Point(20, 245);
        approvalsGrid.Size = new System.Drawing.Size(740, 180);
        approvalsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        approvalsGrid.ReadOnly = true;
        approvalsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(780, 450);
        Controls.Add(updatesLabel);
        Controls.Add(updatesGrid);
        Controls.Add(approvalsLabel);
        Controls.Add(approvalsGrid);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "KPI History";
        ResumeLayout(false);
        PerformLayout();
        ((System.ComponentModel.ISupportInitialize)updatesGrid).EndInit();
        ((System.ComponentModel.ISupportInitialize)approvalsGrid).EndInit();
    }
}
