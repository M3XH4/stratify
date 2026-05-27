namespace KPI.WinForms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private Guna.UI2.WinForms.Guna2GradientPanel headerPanel;
    private Guna.UI2.WinForms.Guna2Panel sidebarPanel;
    private System.Windows.Forms.Label appTitleLabel;
    private System.Windows.Forms.Label userLabel;
    private Guna.UI2.WinForms.Guna2Button logoutButton;
    private Guna.UI2.WinForms.Guna2Button dashboardNavButton;
    private Guna.UI2.WinForms.Guna2Button kpiNavButton;
    private Guna.UI2.WinForms.Guna2Button departmentsNavButton;
    private Guna.UI2.WinForms.Guna2Button reportsNavButton;
    private Guna.UI2.WinForms.Guna2Button usersNavButton;
    private Guna.UI2.WinForms.Guna2Button auditNavButton;
    private Guna.UI2.WinForms.Guna2Button notificationsNavButton;
    private Guna.UI2.WinForms.Guna2Button settingsNavButton;
    private System.Windows.Forms.TabControl mainTabControl;
    private System.Windows.Forms.TabPage dashboardTabPage;
    private System.Windows.Forms.TabPage kpiTabPage;
    private System.Windows.Forms.TabPage departmentsTabPage;
    private System.Windows.Forms.TabPage reportsTabPage;
    private System.Windows.Forms.TabPage auditTabPage;
    private System.Windows.Forms.TabPage notificationsTabPage;
    private System.Windows.Forms.TabPage usersTabPage;
    private System.Windows.Forms.TabPage settingsTabPage;
    private System.Windows.Forms.TableLayoutPanel dashboardLayout;
    private System.Windows.Forms.Label totalKpisLabel;
    private System.Windows.Forms.Label achievedKpisLabel;
    private System.Windows.Forms.Label failedKpisLabel;
    private System.Windows.Forms.Label delayedKpisLabel;
    private Guna.UI2.WinForms.Guna2ShadowPanel totalCardPanel;
    private Guna.UI2.WinForms.Guna2ShadowPanel achievedCardPanel;
    private Guna.UI2.WinForms.Guna2ShadowPanel failedCardPanel;
    private Guna.UI2.WinForms.Guna2ShadowPanel delayedCardPanel;
    private Guna.UI2.WinForms.Guna2ProgressBar totalProgressBar;
    private Guna.UI2.WinForms.Guna2ProgressBar achievedProgressBar;
    private Guna.UI2.WinForms.Guna2ProgressBar failedProgressBar;
    private Guna.UI2.WinForms.Guna2ProgressBar delayedProgressBar;
    private System.Windows.Forms.Label overallPerformanceLabel;
    private System.Windows.Forms.Panel kpiStatusPanel;
    private System.Windows.Forms.Panel kpiTrendPanel;
    private System.Windows.Forms.DataGridView kpiGrid;
    private Guna.UI2.WinForms.Guna2Panel kpiSearchPanel;
    private Guna.UI2.WinForms.Guna2TextBox kpiSearchTextBox;
    private Guna.UI2.WinForms.Guna2ShadowPanel kpiDetailPanel;
    private System.Windows.Forms.Label kpiDetailTitleLabel;
    private System.Windows.Forms.Label kpiDetailNameLabel;
    private System.Windows.Forms.Label kpiDetailCategoryLabel;
    private System.Windows.Forms.Label kpiDetailDepartmentLabel;
    private System.Windows.Forms.Label kpiDetailStatusLabel;
    private System.Windows.Forms.Label kpiDetailTargetLabel;
    private System.Windows.Forms.Label kpiDetailActualLabel;
    private System.Windows.Forms.DataGridView departmentsGrid;
    private System.Windows.Forms.DataGridView reportsGrid;
    private System.Windows.Forms.DataGridView usersGrid;
    private Guna.UI2.WinForms.Guna2Panel usersSearchPanel;
    private Guna.UI2.WinForms.Guna2TextBox usersSearchTextBox;
    private System.Windows.Forms.ToolStrip kpiToolStrip;
    private System.Windows.Forms.ToolStripButton kpiAddButton;
    private System.Windows.Forms.ToolStripButton kpiEditButton;
    private System.Windows.Forms.ToolStripButton kpiDeleteButton;
    private System.Windows.Forms.ToolStripButton kpiProgressButton;
    private System.Windows.Forms.ToolStripButton kpiApproveButton;
    private System.Windows.Forms.ToolStripButton kpiHistoryButton;
    private System.Windows.Forms.ToolStripButton kpiRefreshButton;
    private System.Windows.Forms.ToolStrip departmentsToolStrip;
    private System.Windows.Forms.ToolStripButton departmentsAddButton;
    private System.Windows.Forms.ToolStripButton departmentsEditButton;
    private System.Windows.Forms.ToolStripButton departmentsDeleteButton;
    private System.Windows.Forms.ToolStripButton departmentsRefreshButton;
    private System.Windows.Forms.ToolStrip reportsToolStrip;
    private System.Windows.Forms.ToolStripButton reportsGenerateButton;
    private System.Windows.Forms.ToolStripButton reportsExportCsvButton;
    private System.Windows.Forms.ToolStripButton reportsExportExcelButton;
    private System.Windows.Forms.ToolStripButton reportsExportPdfButton;
    private System.Windows.Forms.Panel reportsSummaryPanel;
    private System.Windows.Forms.Label reportsTotalLabel;
    private System.Windows.Forms.Label reportsAverageLabel;
    private System.Windows.Forms.Label reportsCompletedLabel;
    private System.Windows.Forms.Label reportsBelowTargetLabel;
    private System.Windows.Forms.ToolStrip usersToolStrip;
    private System.Windows.Forms.ToolStripButton usersAddButton;
    private System.Windows.Forms.ToolStripButton usersEditButton;
    private System.Windows.Forms.ToolStripButton usersDeactivateButton;
    private System.Windows.Forms.ToolStripButton usersToggleEmailButton;
    private System.Windows.Forms.ToolStripButton usersRefreshButton;
    private System.Windows.Forms.ToolStrip auditToolStrip;
    private System.Windows.Forms.ToolStripButton auditRefreshButton;
    private System.Windows.Forms.ToolStripButton auditFilterButton;
    private System.Windows.Forms.DataGridView auditGrid;
    private System.Windows.Forms.ToolStrip notificationsToolStrip;
    private System.Windows.Forms.ToolStripButton notificationsRefreshButton;
    private System.Windows.Forms.ToolStripButton notificationsMarkReadButton;
    private System.Windows.Forms.ToolStripButton notificationsRemindersButton;
    private System.Windows.Forms.DataGridView notificationsGrid;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        headerPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
        sidebarPanel = new Guna.UI2.WinForms.Guna2Panel();
        appTitleLabel = new System.Windows.Forms.Label();
        userLabel = new System.Windows.Forms.Label();
        logoutButton = new Guna.UI2.WinForms.Guna2Button();
        dashboardNavButton = new Guna.UI2.WinForms.Guna2Button();
        kpiNavButton = new Guna.UI2.WinForms.Guna2Button();
        departmentsNavButton = new Guna.UI2.WinForms.Guna2Button();
        reportsNavButton = new Guna.UI2.WinForms.Guna2Button();
        usersNavButton = new Guna.UI2.WinForms.Guna2Button();
        auditNavButton = new Guna.UI2.WinForms.Guna2Button();
        notificationsNavButton = new Guna.UI2.WinForms.Guna2Button();
        settingsNavButton = new Guna.UI2.WinForms.Guna2Button();
        mainTabControl = new System.Windows.Forms.TabControl();
        dashboardTabPage = new System.Windows.Forms.TabPage();
        departmentsTabPage = new System.Windows.Forms.TabPage();
        reportsTabPage = new System.Windows.Forms.TabPage();
        auditTabPage = new System.Windows.Forms.TabPage();
        notificationsTabPage = new System.Windows.Forms.TabPage();
        usersTabPage = new System.Windows.Forms.TabPage();
        settingsTabPage = new System.Windows.Forms.TabPage();
        departmentsGrid = new System.Windows.Forms.DataGridView();
        reportsGrid = new System.Windows.Forms.DataGridView();
        usersGrid = new System.Windows.Forms.DataGridView();
        dashboardLayout = new System.Windows.Forms.TableLayoutPanel();
        totalKpisLabel = new System.Windows.Forms.Label();
        achievedKpisLabel = new System.Windows.Forms.Label();
        failedKpisLabel = new System.Windows.Forms.Label();
        delayedKpisLabel = new System.Windows.Forms.Label();
        totalCardPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
        achievedCardPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
        failedCardPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
        delayedCardPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
        totalProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
        achievedProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
        failedProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
        delayedProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
        overallPerformanceLabel = new System.Windows.Forms.Label();
        kpiStatusPanel = new System.Windows.Forms.Panel();
        kpiTrendPanel = new System.Windows.Forms.Panel();
        kpiTabPage = new System.Windows.Forms.TabPage();
        kpiGrid = new System.Windows.Forms.DataGridView();
        kpiSearchPanel = new Guna.UI2.WinForms.Guna2Panel();
        kpiSearchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
        kpiDetailPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
        kpiDetailTitleLabel = new System.Windows.Forms.Label();
        kpiDetailNameLabel = new System.Windows.Forms.Label();
        kpiDetailCategoryLabel = new System.Windows.Forms.Label();
        kpiDetailDepartmentLabel = new System.Windows.Forms.Label();
        kpiDetailStatusLabel = new System.Windows.Forms.Label();
        kpiDetailTargetLabel = new System.Windows.Forms.Label();
        kpiDetailActualLabel = new System.Windows.Forms.Label();
        usersSearchPanel = new Guna.UI2.WinForms.Guna2Panel();
        usersSearchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
        kpiToolStrip = new System.Windows.Forms.ToolStrip();
        kpiAddButton = new System.Windows.Forms.ToolStripButton();
        kpiEditButton = new System.Windows.Forms.ToolStripButton();
        kpiDeleteButton = new System.Windows.Forms.ToolStripButton();
        kpiProgressButton = new System.Windows.Forms.ToolStripButton();
        kpiApproveButton = new System.Windows.Forms.ToolStripButton();
        kpiHistoryButton = new System.Windows.Forms.ToolStripButton();
        kpiRefreshButton = new System.Windows.Forms.ToolStripButton();
        departmentsToolStrip = new System.Windows.Forms.ToolStrip();
        departmentsAddButton = new System.Windows.Forms.ToolStripButton();
        departmentsEditButton = new System.Windows.Forms.ToolStripButton();
        departmentsDeleteButton = new System.Windows.Forms.ToolStripButton();
        departmentsRefreshButton = new System.Windows.Forms.ToolStripButton();
        reportsToolStrip = new System.Windows.Forms.ToolStrip();
        reportsGenerateButton = new System.Windows.Forms.ToolStripButton();
        reportsExportCsvButton = new System.Windows.Forms.ToolStripButton();
        reportsExportExcelButton = new System.Windows.Forms.ToolStripButton();
        reportsExportPdfButton = new System.Windows.Forms.ToolStripButton();
        reportsSummaryPanel = new System.Windows.Forms.Panel();
        reportsTotalLabel = new System.Windows.Forms.Label();
        reportsAverageLabel = new System.Windows.Forms.Label();
        reportsCompletedLabel = new System.Windows.Forms.Label();
        reportsBelowTargetLabel = new System.Windows.Forms.Label();
        usersToolStrip = new System.Windows.Forms.ToolStrip();
        usersAddButton = new System.Windows.Forms.ToolStripButton();
        usersEditButton = new System.Windows.Forms.ToolStripButton();
        usersDeactivateButton = new System.Windows.Forms.ToolStripButton();
        usersToggleEmailButton = new System.Windows.Forms.ToolStripButton();
        usersRefreshButton = new System.Windows.Forms.ToolStripButton();
        auditToolStrip = new System.Windows.Forms.ToolStrip();
        auditRefreshButton = new System.Windows.Forms.ToolStripButton();
        auditFilterButton = new System.Windows.Forms.ToolStripButton();
        auditGrid = new System.Windows.Forms.DataGridView();
        notificationsToolStrip = new System.Windows.Forms.ToolStrip();
        notificationsRefreshButton = new System.Windows.Forms.ToolStripButton();
        notificationsMarkReadButton = new System.Windows.Forms.ToolStripButton();
        notificationsRemindersButton = new System.Windows.Forms.ToolStripButton();
        notificationsGrid = new System.Windows.Forms.DataGridView();
        headerPanel.SuspendLayout();
        mainTabControl.SuspendLayout();
        dashboardTabPage.SuspendLayout();
        dashboardLayout.SuspendLayout();
        kpiTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)kpiGrid).BeginInit();
        departmentsTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)departmentsGrid).BeginInit();
        reportsTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)reportsGrid).BeginInit();
        auditTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)auditGrid).BeginInit();
        notificationsTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)notificationsGrid).BeginInit();
        usersTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)usersGrid).BeginInit();
        SuspendLayout();

        headerPanel.FillColor = System.Drawing.Color.FromArgb(15, 23, 42);
        headerPanel.FillColor2 = System.Drawing.Color.FromArgb(30, 64, 175);
        headerPanel.Controls.Add(appTitleLabel);
        headerPanel.Controls.Add(userLabel);
        headerPanel.Controls.Add(logoutButton);
        headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
        headerPanel.Height = 64;

        sidebarPanel.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
        sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
        sidebarPanel.Width = 200;
        sidebarPanel.Controls.Add(settingsNavButton);
        sidebarPanel.Controls.Add(notificationsNavButton);
        sidebarPanel.Controls.Add(auditNavButton);
        sidebarPanel.Controls.Add(usersNavButton);
        sidebarPanel.Controls.Add(reportsNavButton);
        sidebarPanel.Controls.Add(departmentsNavButton);
        sidebarPanel.Controls.Add(kpiNavButton);
        sidebarPanel.Controls.Add(dashboardNavButton);

        appTitleLabel.AutoSize = true;
        appTitleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        appTitleLabel.ForeColor = System.Drawing.Color.White;
        appTitleLabel.Location = new System.Drawing.Point(20, 16);
        appTitleLabel.Text = "KPI Management";

        userLabel.AutoSize = true;
        userLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
        userLabel.Location = new System.Drawing.Point(420, 24);
        userLabel.Text = "Signed in as";

        logoutButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        logoutButton.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
        logoutButton.ForeColor = System.Drawing.Color.White;
        logoutButton.Location = new System.Drawing.Point(780, 16);
        logoutButton.Size = new System.Drawing.Size(100, 32);
        logoutButton.Text = "Logout";
        logoutButton.BorderRadius = 10;

        dashboardNavButton.FillColor = System.Drawing.Color.FromArgb(30, 41, 59);
        dashboardNavButton.ForeColor = System.Drawing.Color.White;
        dashboardNavButton.Text = "Dashboard";
        dashboardNavButton.Size = new System.Drawing.Size(180, 36);
        dashboardNavButton.Location = new System.Drawing.Point(10, 80);
        dashboardNavButton.BorderRadius = 10;

        kpiNavButton.FillColor = System.Drawing.Color.FromArgb(30, 41, 59);
        kpiNavButton.ForeColor = System.Drawing.Color.White;
        kpiNavButton.Text = "KPIs";
        kpiNavButton.Size = new System.Drawing.Size(180, 36);
        kpiNavButton.Location = new System.Drawing.Point(10, 124);
        kpiNavButton.BorderRadius = 10;

        departmentsNavButton.FillColor = System.Drawing.Color.FromArgb(30, 41, 59);
        departmentsNavButton.ForeColor = System.Drawing.Color.White;
        departmentsNavButton.Text = "Departments";
        departmentsNavButton.Size = new System.Drawing.Size(180, 36);
        departmentsNavButton.Location = new System.Drawing.Point(10, 168);
        departmentsNavButton.BorderRadius = 10;

        reportsNavButton.FillColor = System.Drawing.Color.FromArgb(30, 41, 59);
        reportsNavButton.ForeColor = System.Drawing.Color.White;
        reportsNavButton.Text = "Reports";
        reportsNavButton.Size = new System.Drawing.Size(180, 36);
        reportsNavButton.Location = new System.Drawing.Point(10, 212);
        reportsNavButton.BorderRadius = 10;

        usersNavButton.FillColor = System.Drawing.Color.FromArgb(30, 41, 59);
        usersNavButton.ForeColor = System.Drawing.Color.White;
        usersNavButton.Text = "Users";
        usersNavButton.Size = new System.Drawing.Size(180, 36);
        usersNavButton.Location = new System.Drawing.Point(10, 256);
        usersNavButton.BorderRadius = 10;

        auditNavButton.FillColor = System.Drawing.Color.FromArgb(30, 41, 59);
        auditNavButton.ForeColor = System.Drawing.Color.White;
        auditNavButton.Text = "Audit Trail";
        auditNavButton.Size = new System.Drawing.Size(180, 36);
        auditNavButton.Location = new System.Drawing.Point(10, 300);
        auditNavButton.BorderRadius = 10;

        notificationsNavButton.FillColor = System.Drawing.Color.FromArgb(30, 41, 59);
        notificationsNavButton.ForeColor = System.Drawing.Color.White;
        notificationsNavButton.Text = "Notifications";
        notificationsNavButton.Size = new System.Drawing.Size(180, 36);
        notificationsNavButton.Location = new System.Drawing.Point(10, 344);
        notificationsNavButton.BorderRadius = 10;

        settingsNavButton.FillColor = System.Drawing.Color.FromArgb(30, 41, 59);
        settingsNavButton.ForeColor = System.Drawing.Color.White;
        settingsNavButton.Text = "Settings";
        settingsNavButton.Size = new System.Drawing.Size(180, 36);
        settingsNavButton.Location = new System.Drawing.Point(10, 388);
        settingsNavButton.BorderRadius = 10;

        mainTabControl.Controls.Add(dashboardTabPage);
        mainTabControl.Controls.Add(kpiTabPage);
        mainTabControl.Controls.Add(departmentsTabPage);
        mainTabControl.Controls.Add(reportsTabPage);
        mainTabControl.Controls.Add(usersTabPage);
        mainTabControl.Controls.Add(auditTabPage);
        mainTabControl.Controls.Add(notificationsTabPage);
        mainTabControl.Controls.Add(settingsTabPage);
        mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
        mainTabControl.Location = new System.Drawing.Point(200, 64);
        mainTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
        mainTabControl.ItemSize = new System.Drawing.Size(0, 1);
        mainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;

        dashboardTabPage.Text = "Dashboard";
        dashboardTabPage.Controls.Add(dashboardLayout);

        dashboardLayout.ColumnCount = 2;
        dashboardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        dashboardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        dashboardLayout.Dock = System.Windows.Forms.DockStyle.Fill;
        dashboardLayout.Padding = new System.Windows.Forms.Padding(20);
        dashboardLayout.RowCount = 4;
        dashboardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
        dashboardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
        dashboardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
        dashboardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44F));
        dashboardLayout.Controls.Add(totalCardPanel, 0, 0);
        dashboardLayout.Controls.Add(achievedCardPanel, 1, 0);
        dashboardLayout.Controls.Add(failedCardPanel, 0, 1);
        dashboardLayout.Controls.Add(delayedCardPanel, 1, 1);
        dashboardLayout.Controls.Add(overallPerformanceLabel, 0, 2);
        dashboardLayout.Controls.Add(kpiStatusPanel, 0, 3);
        dashboardLayout.Controls.Add(kpiTrendPanel, 1, 3);
        dashboardLayout.SetColumnSpan(overallPerformanceLabel, 2);

        totalCardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        totalCardPanel.FillColor = System.Drawing.Color.White;
        totalCardPanel.ShadowColor = System.Drawing.Color.FromArgb(148, 163, 184);
        totalCardPanel.Radius = 12;
        totalCardPanel.Controls.Add(totalKpisLabel);
        totalCardPanel.Controls.Add(totalProgressBar);

        totalKpisLabel.Dock = System.Windows.Forms.DockStyle.Top;
        totalKpisLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        totalKpisLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        totalKpisLabel.Text = "Total KPIs: 0";
        totalKpisLabel.Height = 48;

        totalProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
        totalProgressBar.Height = 10;
        totalProgressBar.BorderRadius = 5;
        totalProgressBar.FillColor = System.Drawing.Color.FromArgb(226, 232, 240);
        totalProgressBar.ProgressColor = System.Drawing.Color.FromArgb(37, 99, 235);

        achievedCardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        achievedCardPanel.FillColor = System.Drawing.Color.White;
        achievedCardPanel.ShadowColor = System.Drawing.Color.FromArgb(148, 163, 184);
        achievedCardPanel.Radius = 12;
        achievedCardPanel.Controls.Add(achievedKpisLabel);
        achievedCardPanel.Controls.Add(achievedProgressBar);

        achievedKpisLabel.Dock = System.Windows.Forms.DockStyle.Top;
        achievedKpisLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        achievedKpisLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        achievedKpisLabel.Text = "Achieved KPIs: 0";
        achievedKpisLabel.Height = 48;

        achievedProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
        achievedProgressBar.Height = 10;
        achievedProgressBar.BorderRadius = 5;
        achievedProgressBar.FillColor = System.Drawing.Color.FromArgb(226, 232, 240);
        achievedProgressBar.ProgressColor = System.Drawing.Color.FromArgb(16, 185, 129);

        failedCardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        failedCardPanel.FillColor = System.Drawing.Color.White;
        failedCardPanel.ShadowColor = System.Drawing.Color.FromArgb(148, 163, 184);
        failedCardPanel.Radius = 12;
        failedCardPanel.Controls.Add(failedKpisLabel);
        failedCardPanel.Controls.Add(failedProgressBar);

        failedKpisLabel.Dock = System.Windows.Forms.DockStyle.Top;
        failedKpisLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        failedKpisLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        failedKpisLabel.Text = "Failed KPIs: 0";
        failedKpisLabel.Height = 48;

        failedProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
        failedProgressBar.Height = 10;
        failedProgressBar.BorderRadius = 5;
        failedProgressBar.FillColor = System.Drawing.Color.FromArgb(226, 232, 240);
        failedProgressBar.ProgressColor = System.Drawing.Color.FromArgb(239, 68, 68);

        delayedCardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        delayedCardPanel.FillColor = System.Drawing.Color.White;
        delayedCardPanel.ShadowColor = System.Drawing.Color.FromArgb(148, 163, 184);
        delayedCardPanel.Radius = 12;
        delayedCardPanel.Controls.Add(delayedKpisLabel);
        delayedCardPanel.Controls.Add(delayedProgressBar);

        delayedKpisLabel.Dock = System.Windows.Forms.DockStyle.Top;
        delayedKpisLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        delayedKpisLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        delayedKpisLabel.Text = "Delayed KPIs: 0";
        delayedKpisLabel.Height = 48;

        delayedProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
        delayedProgressBar.Height = 10;
        delayedProgressBar.BorderRadius = 5;
        delayedProgressBar.FillColor = System.Drawing.Color.FromArgb(226, 232, 240);
        delayedProgressBar.ProgressColor = System.Drawing.Color.FromArgb(251, 191, 36);

        overallPerformanceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        overallPerformanceLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        overallPerformanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        overallPerformanceLabel.Text = "Overall Performance: 0%";
        overallPerformanceLabel.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

        kpiStatusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        kpiStatusPanel.BackColor = System.Drawing.Color.White;

        kpiTrendPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        kpiTrendPanel.BackColor = System.Drawing.Color.White;

        kpiTabPage.Text = "KPIs";
        kpiTabPage.Controls.Add(kpiGrid);
        kpiTabPage.Controls.Add(kpiDetailPanel);
        kpiTabPage.Controls.Add(kpiSearchPanel);
        kpiTabPage.Controls.Add(kpiToolStrip);

        kpiSearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
        kpiSearchPanel.Height = 50;
        kpiSearchPanel.FillColor = System.Drawing.Color.White;
        kpiSearchPanel.Controls.Add(kpiSearchTextBox);

        kpiSearchTextBox.PlaceholderText = "Search KPIs";
        kpiSearchTextBox.BorderRadius = 10;
        kpiSearchTextBox.Location = new System.Drawing.Point(16, 8);
        kpiSearchTextBox.Size = new System.Drawing.Size(280, 34);

        kpiDetailPanel.Dock = System.Windows.Forms.DockStyle.Right;
        kpiDetailPanel.Width = 260;
        kpiDetailPanel.FillColor = System.Drawing.Color.White;
        kpiDetailPanel.Radius = 12;
        kpiDetailPanel.ShadowColor = System.Drawing.Color.FromArgb(148, 163, 184);
        kpiDetailPanel.Padding = new System.Windows.Forms.Padding(12);
        kpiDetailPanel.Controls.Add(kpiDetailActualLabel);
        kpiDetailPanel.Controls.Add(kpiDetailTargetLabel);
        kpiDetailPanel.Controls.Add(kpiDetailStatusLabel);
        kpiDetailPanel.Controls.Add(kpiDetailDepartmentLabel);
        kpiDetailPanel.Controls.Add(kpiDetailCategoryLabel);
        kpiDetailPanel.Controls.Add(kpiDetailNameLabel);
        kpiDetailPanel.Controls.Add(kpiDetailTitleLabel);

        kpiDetailTitleLabel.AutoSize = true;
        kpiDetailTitleLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        kpiDetailTitleLabel.Location = new System.Drawing.Point(16, 16);
        kpiDetailTitleLabel.Text = "KPI Details";

        kpiDetailNameLabel.AutoSize = true;
        kpiDetailNameLabel.Location = new System.Drawing.Point(16, 52);
        kpiDetailNameLabel.Text = "Name: -";

        kpiDetailCategoryLabel.AutoSize = true;
        kpiDetailCategoryLabel.Location = new System.Drawing.Point(16, 76);
        kpiDetailCategoryLabel.Text = "Category: -";

        kpiDetailDepartmentLabel.AutoSize = true;
        kpiDetailDepartmentLabel.Location = new System.Drawing.Point(16, 100);
        kpiDetailDepartmentLabel.Text = "Department: -";

        kpiDetailStatusLabel.AutoSize = true;
        kpiDetailStatusLabel.Location = new System.Drawing.Point(16, 124);
        kpiDetailStatusLabel.Text = "Status: -";

        kpiDetailTargetLabel.AutoSize = true;
        kpiDetailTargetLabel.Location = new System.Drawing.Point(16, 148);
        kpiDetailTargetLabel.Text = "Target: -";

        kpiDetailActualLabel.AutoSize = true;
        kpiDetailActualLabel.Location = new System.Drawing.Point(16, 172);
        kpiDetailActualLabel.Text = "Actual: -";

        kpiToolStrip.Dock = System.Windows.Forms.DockStyle.Top;
        kpiAddButton.Text = "Add";
        kpiEditButton.Text = "Edit";
        kpiDeleteButton.Text = "Delete";
        kpiProgressButton.Text = "Update Progress";
        kpiApproveButton.Text = "Approve";
        kpiHistoryButton.Text = "History";
        kpiRefreshButton.Text = "Refresh";
        kpiToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
        {
            kpiAddButton,
            kpiEditButton,
            kpiDeleteButton,
            kpiProgressButton,
            kpiApproveButton,
            kpiHistoryButton,
            kpiRefreshButton
        });

        kpiGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        kpiGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        kpiGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        kpiGrid.ReadOnly = true;

        departmentsTabPage.Text = "Departments";
        departmentsTabPage.Controls.Add(departmentsGrid);
        departmentsTabPage.Controls.Add(departmentsToolStrip);

        departmentsToolStrip.Dock = System.Windows.Forms.DockStyle.Top;
        departmentsAddButton.Text = "Add";
        departmentsEditButton.Text = "Edit";
        departmentsDeleteButton.Text = "Delete";
        departmentsRefreshButton.Text = "Refresh";
        departmentsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
        {
            departmentsAddButton,
            departmentsEditButton,
            departmentsDeleteButton,
            departmentsRefreshButton
        });

        departmentsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        departmentsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        departmentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        departmentsGrid.ReadOnly = true;

        reportsTabPage.Text = "Reports";
        reportsTabPage.Controls.Add(reportsGrid);
        reportsTabPage.Controls.Add(reportsSummaryPanel);
        reportsTabPage.Controls.Add(reportsToolStrip);

        reportsToolStrip.Dock = System.Windows.Forms.DockStyle.Top;
        reportsGenerateButton.Text = "Generate";
        reportsExportCsvButton.Text = "Export CSV";
        reportsExportExcelButton.Text = "Export Excel";
        reportsExportPdfButton.Text = "Export PDF";
        reportsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
        {
            reportsGenerateButton,
            reportsExportCsvButton,
            reportsExportExcelButton,
            reportsExportPdfButton
        });

        reportsSummaryPanel.Dock = System.Windows.Forms.DockStyle.Top;
        reportsSummaryPanel.Height = 40;
        reportsSummaryPanel.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
        reportsSummaryPanel.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
        reportsSummaryPanel.Controls.Add(reportsTotalLabel);
        reportsSummaryPanel.Controls.Add(reportsAverageLabel);
        reportsSummaryPanel.Controls.Add(reportsCompletedLabel);
        reportsSummaryPanel.Controls.Add(reportsBelowTargetLabel);

        reportsTotalLabel.AutoSize = true;
        reportsTotalLabel.Location = new System.Drawing.Point(10, 12);
        reportsTotalLabel.Text = "Total: 0";

        reportsAverageLabel.AutoSize = true;
        reportsAverageLabel.Location = new System.Drawing.Point(120, 12);
        reportsAverageLabel.Text = "Average: 0%";

        reportsCompletedLabel.AutoSize = true;
        reportsCompletedLabel.Location = new System.Drawing.Point(260, 12);
        reportsCompletedLabel.Text = "Completed: 0";

        reportsBelowTargetLabel.AutoSize = true;
        reportsBelowTargetLabel.Location = new System.Drawing.Point(400, 12);
        reportsBelowTargetLabel.Text = "Below Target: 0";

        reportsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        reportsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        reportsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        reportsGrid.ReadOnly = true;

        auditTabPage.Text = "Audit Trail";
        auditTabPage.Controls.Add(auditGrid);
        auditTabPage.Controls.Add(auditToolStrip);

        auditToolStrip.Dock = System.Windows.Forms.DockStyle.Top;
        auditRefreshButton.Text = "Refresh";
        auditFilterButton.Text = "Filter";
        auditToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
        {
            auditFilterButton,
            auditRefreshButton
        });

        auditGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        auditGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        auditGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        auditGrid.ReadOnly = true;

        notificationsTabPage.Text = "Notifications";
        notificationsTabPage.Controls.Add(notificationsGrid);
        notificationsTabPage.Controls.Add(notificationsToolStrip);

        notificationsToolStrip.Dock = System.Windows.Forms.DockStyle.Top;
        notificationsRefreshButton.Text = "Refresh";
        notificationsMarkReadButton.Text = "Mark Read";
        notificationsRemindersButton.Text = "Generate Reminders";
        notificationsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
        {
            notificationsRemindersButton,
            notificationsMarkReadButton,
            notificationsRefreshButton
        });

        notificationsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        notificationsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        notificationsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        notificationsGrid.ReadOnly = true;

        usersTabPage.Text = "Users";
        usersTabPage.Controls.Add(usersGrid);
        usersTabPage.Controls.Add(usersSearchPanel);
        usersTabPage.Controls.Add(usersToolStrip);

        usersSearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
        usersSearchPanel.Height = 50;
        usersSearchPanel.FillColor = System.Drawing.Color.White;
        usersSearchPanel.Controls.Add(usersSearchTextBox);

        usersSearchTextBox.PlaceholderText = "Search users";
        usersSearchTextBox.BorderRadius = 10;
        usersSearchTextBox.Location = new System.Drawing.Point(16, 8);
        usersSearchTextBox.Size = new System.Drawing.Size(280, 34);

        usersToolStrip.Dock = System.Windows.Forms.DockStyle.Top;
        usersAddButton.Text = "Add";
        usersEditButton.Text = "Edit";
        usersDeactivateButton.Text = "Deactivate";
        usersToggleEmailButton.Text = "Toggle Email";
        usersRefreshButton.Text = "Refresh";
        usersToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
        {
            usersAddButton,
            usersEditButton,
            usersDeactivateButton,
            usersToggleEmailButton,
            usersRefreshButton
        });

        usersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        usersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        usersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        usersGrid.ReadOnly = true;

        settingsTabPage.Text = "Settings";
        settingsTabPage.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1100, 700);
        Controls.Add(sidebarPanel);
        Controls.Add(mainTabControl);
        Controls.Add(headerPanel);
        Text = "KPI Management";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        headerPanel.ResumeLayout(false);
        headerPanel.PerformLayout();
        sidebarPanel.ResumeLayout(false);
        mainTabControl.ResumeLayout(false);
        dashboardTabPage.ResumeLayout(false);
        dashboardLayout.ResumeLayout(false);
        kpiTabPage.ResumeLayout(false);
        kpiTabPage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)kpiGrid).EndInit();
        departmentsTabPage.ResumeLayout(false);
        departmentsTabPage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)departmentsGrid).EndInit();
        reportsTabPage.ResumeLayout(false);
        reportsTabPage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)reportsGrid).EndInit();
        auditTabPage.ResumeLayout(false);
        auditTabPage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)auditGrid).EndInit();
        notificationsTabPage.ResumeLayout(false);
        notificationsTabPage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)notificationsGrid).EndInit();
        usersTabPage.ResumeLayout(false);
        usersTabPage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)usersGrid).EndInit();
        ResumeLayout(false);
    }

    #endregion
}
