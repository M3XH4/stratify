using KPI.Core.DTOs;
using KPI.Core.Enums;
using KPI.WinForms.Dialogs;
using KPI.WinForms.UI;
using KPI.WinForms.Services;
using Guna.UI2.WinForms;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Drawing;
using System.IO;

namespace KPI.WinForms;

public partial class MainForm : Form
{
    private readonly AuthResponse _user;
    private readonly ApiClient _apiClient;
    private readonly Dictionary<KpiStatus, int> _statusCounts = new();
    private readonly List<(string Label, double Value)> _trendPoints = new();
    private List<KpiReportRowDto> _reportRows = new();
    private KpiReportFilter? _lastReportFilter;
    private KpiReportFilterSummary? _lastReportSummary;
    private AuditLogFilter _auditFilter = new(null, null, null);
    private List<NotificationDto> _notifications = new();
    private List<KpiDto> _kpisCache = new();
    private List<UserSummaryDto> _usersCache = new();
    private readonly System.Windows.Forms.Timer _progressTimer = new() { Interval = 20 };
    private int _targetTotalProgress;
    private int _targetAchievedProgress;
    private int _targetFailedProgress;
    private int _targetDelayedProgress;

    public MainForm(AuthResponse user, ApiClient apiClient)
    {
        _user = user;
        _apiClient = apiClient;
        InitializeComponent();
        ThemeManager.ApplyFormStyle(this);
        headerPanel.BackColor = ThemePalette.DarkBlue;
        appTitleLabel.ForeColor = ThemePalette.White;
        userLabel.ForeColor = ThemePalette.SkyBlue;
        logoutButton.BackColor = ThemePalette.RoyalBlue;
        logoutButton.BorderRadius = 10;
        ApplySidebarButtonStyle(dashboardNavButton);
        ApplySidebarButtonStyle(kpiNavButton);
        ApplySidebarButtonStyle(departmentsNavButton);
        ApplySidebarButtonStyle(reportsNavButton);
        ApplySidebarButtonStyle(usersNavButton);
        ApplySidebarButtonStyle(auditNavButton);
        ApplySidebarButtonStyle(notificationsNavButton);
        ApplySidebarButtonStyle(settingsNavButton);
        kpiSearchTextBox.IconLeft = SystemIcons.Information.ToBitmap();
        usersSearchTextBox.IconLeft = SystemIcons.Information.ToBitmap();
        ThemeManager.StyleGrid(kpiGrid);
        ThemeManager.StyleGrid(departmentsGrid);
        ThemeManager.StyleGrid(usersGrid);
        ThemeManager.StyleGrid(reportsGrid);
        ThemeManager.StyleGrid(auditGrid);
        ThemeManager.StyleGrid(notificationsGrid);
        userLabel.Text = $"Signed in as {_user.FullName} ({string.Join(", ", _user.Roles)})";
        logoutButton.Click += LogoutButton_Click;
        kpiStatusPanel.Paint += KpiStatusPanel_Paint;
        kpiTrendPanel.Paint += KpiTrendPanel_Paint;
        Load += MainForm_Load;
        kpiAddButton.Click += KpiAddButton_Click;
        kpiEditButton.Click += KpiEditButton_Click;
        kpiDeleteButton.Click += KpiDeleteButton_Click;
        kpiProgressButton.Click += KpiProgressButton_Click;
        kpiApproveButton.Click += KpiApproveButton_Click;
        kpiHistoryButton.Click += KpiHistoryButton_Click;
        kpiRefreshButton.Click += async (_, _) => await ExecuteApiCallAsync(LoadKpisAsync, "Unable to load KPIs.");
        departmentsAddButton.Click += DepartmentsAddButton_Click;
        departmentsEditButton.Click += DepartmentsEditButton_Click;
        departmentsDeleteButton.Click += DepartmentsDeleteButton_Click;
        departmentsRefreshButton.Click += async (_, _) => await ExecuteApiCallAsync(LoadDepartmentsAsync, "Unable to load departments.");
        usersAddButton.Click += UsersAddButton_Click;
        usersEditButton.Click += UsersEditButton_Click;
        usersDeactivateButton.Click += UsersDeactivateButton_Click;
        usersToggleEmailButton.Click += UsersToggleEmailButton_Click;
        usersRefreshButton.Click += async (_, _) => await ExecuteApiCallAsync(LoadUsersAsync, "Unable to load users.");
        reportsGenerateButton.Click += ReportsGenerateButton_Click;
        reportsExportCsvButton.Click += ReportsExportCsvButton_Click;
        reportsExportExcelButton.Click += ReportsExportExcelButton_Click;
        reportsExportPdfButton.Click += ReportsExportPdfButton_Click;
        auditRefreshButton.Click += async (_, _) => await ExecuteApiCallAsync(LoadAuditLogsAsync, "Unable to load audit logs.");
        auditFilterButton.Click += AuditFilterButton_Click;
        notificationsRefreshButton.Click += async (_, _) => await ExecuteApiCallAsync(LoadNotificationsAsync, "Unable to load notifications.");
        notificationsMarkReadButton.Click += NotificationsMarkReadButton_Click;
        notificationsRemindersButton.Click += NotificationsRemindersButton_Click;

        kpiSearchTextBox.TextChanged += (_, _) => ApplyKpiSearch();
        usersSearchTextBox.TextChanged += (_, _) => ApplyUserSearch();

        reportsGrid.DataBindingComplete += (_, _) => ApplyReportGridHeaders();
        notificationsGrid.DataBindingComplete += (_, _) => ApplyNotificationGridHeaders();

        kpiGrid.SelectionChanged += (_, _) => UpdateKpiDetails();
        _progressTimer.Tick += (_, _) => AnimateProgressBars();

        ApplyRoundedTabs();

        dashboardNavButton.Click += (_, _) => mainTabControl.SelectedTab = dashboardTabPage;
        kpiNavButton.Click += (_, _) => mainTabControl.SelectedTab = kpiTabPage;
        departmentsNavButton.Click += (_, _) => mainTabControl.SelectedTab = departmentsTabPage;
        reportsNavButton.Click += (_, _) => mainTabControl.SelectedTab = reportsTabPage;
        usersNavButton.Click += (_, _) => mainTabControl.SelectedTab = usersTabPage;
        auditNavButton.Click += (_, _) => mainTabControl.SelectedTab = auditTabPage;
        notificationsNavButton.Click += (_, _) => mainTabControl.SelectedTab = notificationsTabPage;
        settingsNavButton.Click += (_, _) => mainTabControl.SelectedTab = settingsTabPage;

        if (!_user.Roles.Any(role => role == "Manager" || role == "Admin"))
        {
            kpiApproveButton.Enabled = false;
        }
    }

    private async void MainForm_Load(object? sender, EventArgs e)
    {
        await ExecuteApiCallAsync(LoadDepartmentsAsync, "Unable to load departments.");
        await ExecuteApiCallAsync(LoadUsersAsync, "Unable to load users.");
        await ExecuteApiCallAsync(LoadKpisAsync, "Unable to load KPIs.");
        await ExecuteApiCallAsync(LoadAuditLogsAsync, "Unable to load audit logs.");
        await ExecuteApiCallAsync(LoadNotificationsAsync, "Unable to load notifications.");
    }

    private void LogoutButton_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private async Task LoadDepartmentsAsync()
    {
        var departments = await _apiClient.GetDepartmentsAsync();
        departmentsGrid.DataSource = departments.ToList();
    }

    private async Task LoadUsersAsync()
    {
        _usersCache = (await _apiClient.GetUsersAsync()).ToList();
        ApplyUserSearch();
    }

    private async Task LoadKpisAsync()
    {
        _kpisCache = (await _apiClient.GetKpisAsync()).ToList();
        ApplyKpiSearch();
        UpdateDashboard(_kpisCache);
        UpdateKpiDetails();
    }

    private void UpdateKpiDetails()
    {
        if (kpiGrid.CurrentRow?.DataBoundItem is not KpiDto kpi)
        {
            kpiDetailNameLabel.Text = "Name: -";
            kpiDetailCategoryLabel.Text = "Category: -";
            kpiDetailDepartmentLabel.Text = "Department: -";
            kpiDetailStatusLabel.Text = "Status: -";
            kpiDetailTargetLabel.Text = "Target: -";
            kpiDetailActualLabel.Text = "Actual: -";
            return;
        }

        kpiDetailNameLabel.Text = $"Name: {kpi.Name}";
        kpiDetailCategoryLabel.Text = $"Category: {kpi.Category}";
        kpiDetailDepartmentLabel.Text = $"Department: {kpi.DepartmentName}";
        kpiDetailStatusLabel.Text = $"Status: {kpi.Status}";
        kpiDetailTargetLabel.Text = $"Target: {kpi.TargetValue:0.##}";
        kpiDetailActualLabel.Text = $"Actual: {(kpi.ActualValue?.ToString("0.##") ?? "-")}";
    }

    private void AnimateProgressBars()
    {
        var done = true;
        done &= AnimateProgressBar(totalProgressBar, _targetTotalProgress);
        done &= AnimateProgressBar(achievedProgressBar, _targetAchievedProgress);
        done &= AnimateProgressBar(failedProgressBar, _targetFailedProgress);
        done &= AnimateProgressBar(delayedProgressBar, _targetDelayedProgress);

        if (done)
        {
            _progressTimer.Stop();
        }
    }

    private static bool AnimateProgressBar(Guna2ProgressBar progressBar, int target)
    {
        var current = progressBar.Value;
        if (current == target)
        {
            return true;
        }

        var step = Math.Max(1, Math.Abs(target - current) / 10);
        progressBar.Value = current < target ? Math.Min(target, current + step) : Math.Max(target, current - step);
        return progressBar.Value == target;
    }

    private void ApplyRoundedTabs()
    {
        ApplyTabCorner(dashboardTabPage);
        ApplyTabCorner(kpiTabPage);
        ApplyTabCorner(departmentsTabPage);
        ApplyTabCorner(reportsTabPage);
        ApplyTabCorner(usersTabPage);
        ApplyTabCorner(auditTabPage);
        ApplyTabCorner(notificationsTabPage);
        ApplyTabCorner(settingsTabPage);
    }

    private static void ApplyTabCorner(TabPage tabPage)
    {
        _ = new Guna2Elipse
        {
            BorderRadius = 12,
            TargetControl = tabPage
        };
    }

    private void ApplyKpiSearch()
    {
        var query = kpiSearchTextBox.Text.Trim();
        var filtered = string.IsNullOrWhiteSpace(query)
            ? _kpisCache
            : _kpisCache.Where(kpi => kpi.Name.Contains(query, StringComparison.OrdinalIgnoreCase)
                                      || kpi.Category.Contains(query, StringComparison.OrdinalIgnoreCase)
                                      || kpi.DepartmentName.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        kpiGrid.DataSource = filtered;
    }

    private void ApplyUserSearch()
    {
        var query = usersSearchTextBox.Text.Trim();
        var filtered = string.IsNullOrWhiteSpace(query)
            ? _usersCache
            : _usersCache.Where(user => user.FullName.Contains(query, StringComparison.OrdinalIgnoreCase)
                                        || user.Email.Contains(query, StringComparison.OrdinalIgnoreCase)
                                        || (user.DepartmentName?.Contains(query, StringComparison.OrdinalIgnoreCase) ?? false)).ToList();
        usersGrid.DataSource = filtered;
    }

    private static void ApplySidebarButtonStyle(Guna.UI2.WinForms.Guna2Button button)
    {
        button.FillColor = ThemePalette.DarkBlue;
        button.HoverState.FillColor = ThemePalette.RoyalBlue;
        button.HoverState.ForeColor = ThemePalette.White;
        button.ForeColor = ThemePalette.White;
        button.BorderRadius = 10;
        button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
    }

    private void ApplyReportGridHeaders()
    {
        if (reportsGrid.Columns.Count == 0)
        {
            return;
        }

        reportsGrid.Columns[nameof(KpiReportRowDto.Name)].HeaderText = "📄 KPI";
        reportsGrid.Columns[nameof(KpiReportRowDto.Department)].HeaderText = "🏢 Department";
        reportsGrid.Columns[nameof(KpiReportRowDto.Category)].HeaderText = "🏷️ Category";
        reportsGrid.Columns[nameof(KpiReportRowDto.TargetValue)].HeaderText = "🎯 Target";
        reportsGrid.Columns[nameof(KpiReportRowDto.ActualValue)].HeaderText = "✅ Actual";
        reportsGrid.Columns[nameof(KpiReportRowDto.PerformanceScore)].HeaderText = "📈 Score";
        reportsGrid.Columns[nameof(KpiReportRowDto.Status)].HeaderText = "📌 Status";
    }

    private void ApplyNotificationGridHeaders()
    {
        if (notificationsGrid.Columns.Count == 0)
        {
            return;
        }

        notificationsGrid.Columns[nameof(NotificationDto.Message)].HeaderText = "🔔 Message";
        notificationsGrid.Columns[nameof(NotificationDto.Type)].HeaderText = "🧭 Type";
        notificationsGrid.Columns[nameof(NotificationDto.IsRead)].HeaderText = "👀 Read";
        notificationsGrid.Columns[nameof(NotificationDto.CreatedAt)].HeaderText = "🕒 Date";
    }

    private async Task LoadAuditLogsAsync()
    {
        var logs = await _apiClient.GetAuditLogsAsync(_auditFilter);
        auditGrid.DataSource = logs.ToList();
    }

    private async Task LoadNotificationsAsync()
    {
        _notifications = (await _apiClient.GetNotificationsAsync(_user.UserId)).ToList();
        notificationsGrid.DataSource = _notifications;
    }

    private async void NotificationsMarkReadButton_Click(object? sender, EventArgs e)
    {
        if (notificationsGrid.CurrentRow?.DataBoundItem is not NotificationDto notification)
        {
            return;
        }

        await ExecuteApiCallAsync(async () =>
        {
            await _apiClient.MarkNotificationReadAsync(notification.Id);
            await LoadNotificationsAsync();
        }, "Unable to mark notification as read.");
    }

    private async void NotificationsRemindersButton_Click(object? sender, EventArgs e)
    {
        await ExecuteApiCallAsync(async () =>
        {
            var created = await _apiClient.GenerateNotificationRemindersAsync();
            await LoadNotificationsAsync();
            MessageBox.Show($"Created {created} reminder notifications.", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }, "Unable to generate reminders.");
    }

    private async void AuditFilterButton_Click(object? sender, EventArgs e)
    {
        using var dialog = new AuditFilterDialog();
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _auditFilter = dialog.BuildFilter();
            await ExecuteApiCallAsync(LoadAuditLogsAsync, "Unable to load audit logs.");
        }
    }

    private void KpiHistoryButton_Click(object? sender, EventArgs e)
    {
        if (kpiGrid.CurrentRow?.DataBoundItem is not KpiDto kpi)
        {
            return;
        }

        using var dialog = new KpiHistoryDialog(_apiClient, kpi.Id);
        dialog.ShowDialog(this);
    }

    private async void ReportsGenerateButton_Click(object? sender, EventArgs e)
    {
        var departments = await _apiClient.GetDepartmentsAsync();
        using var dialog = new ReportFilterDialog(departments);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            await ExecuteApiCallAsync(async () =>
            {
                var filter = dialog.BuildFilter();
                var reportRows = await _apiClient.GetKpiReportAsync(filter);
                _lastReportFilter = filter;
                _lastReportSummary = dialog.BuildSummary();
                _reportRows = reportRows.ToList();
                reportsGrid.DataSource = _reportRows;
                UpdateReportSummary();
            }, "Unable to generate report.");
        }
    }

    private void ReportsExportCsvButton_Click(object? sender, EventArgs e)
    {
        if (_reportRows.Count == 0)
        {
            MessageBox.Show("Generate a report before exporting.", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Filter = "CSV Files|*.csv",
            FileName = "KpiReport.csv"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        using var writer = new StreamWriter(dialog.FileName);
        writer.WriteLine("Id,Name,Department,Category,Target,Actual,Performance,StartDate,EndDate,Status");
        foreach (var row in _reportRows)
        {
            writer.WriteLine(string.Join(",",
                row.Id,
                EscapeCsv(row.Name),
                EscapeCsv(row.Department),
                EscapeCsv(row.Category),
                row.TargetValue,
                row.ActualValue,
                row.PerformanceScore,
                row.StartDate,
                row.EndDate,
                row.Status));
        }

        MessageBox.Show("CSV export completed.", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ReportsExportExcelButton_Click(object? sender, EventArgs e)
    {
        if (_reportRows.Count == 0)
        {
            MessageBox.Show("Generate a report before exporting.", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Filter = "Excel Files|*.xlsx",
            FileName = "KpiReport.xlsx"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("KPI Report");
        worksheet.Cell(1, 1).Value = "Id";
        worksheet.Cell(1, 2).Value = "Name";
        worksheet.Cell(1, 3).Value = "Department";
        worksheet.Cell(1, 4).Value = "Category";
        worksheet.Cell(1, 5).Value = "Target";
        worksheet.Cell(1, 6).Value = "Actual";
        worksheet.Cell(1, 7).Value = "Performance";
        worksheet.Cell(1, 8).Value = "Start Date";
        worksheet.Cell(1, 9).Value = "End Date";
        worksheet.Cell(1, 10).Value = "Status";

        for (var i = 0; i < _reportRows.Count; i++)
        {
            var row = _reportRows[i];
            var rowIndex = i + 2;
            worksheet.Cell(rowIndex, 1).Value = row.Id;
            worksheet.Cell(rowIndex, 2).Value = row.Name;
            worksheet.Cell(rowIndex, 3).Value = row.Department;
            worksheet.Cell(rowIndex, 4).Value = row.Category;
            worksheet.Cell(rowIndex, 5).Value = row.TargetValue;
            worksheet.Cell(rowIndex, 6).Value = row.ActualValue;
            worksheet.Cell(rowIndex, 7).Value = row.PerformanceScore;
            worksheet.Cell(rowIndex, 8).Value = row.StartDate.ToString("yyyy-MM-dd");
            worksheet.Cell(rowIndex, 9).Value = row.EndDate.ToString("yyyy-MM-dd");
            worksheet.Cell(rowIndex, 10).Value = row.Status.ToString();
        }

        worksheet.Columns().AdjustToContents();
        workbook.SaveAs(dialog.FileName);
        MessageBox.Show("Excel export completed.", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ReportsExportPdfButton_Click(object? sender, EventArgs e)
    {
        if (_reportRows.Count == 0)
        {
            MessageBox.Show("Generate a report before exporting.", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Filter = "PDF Files|*.pdf",
            FileName = "KpiReport.pdf"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(30);
                page.Header().Text("KPI Report").FontSize(18).SemiBold();
                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn(2);
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    table.Header(header =>
                    {
                        header.Cell().Text("Name").SemiBold();
                        header.Cell().Text("Department").SemiBold();
                        header.Cell().Text("Category").SemiBold();
                        header.Cell().Text("Target").SemiBold();
                        header.Cell().Text("Actual").SemiBold();
                        header.Cell().Text("Performance").SemiBold();
                        header.Cell().Text("Status").SemiBold();
                    });

                    foreach (var row in _reportRows)
                    {
                        table.Cell().Text(row.Name);
                        table.Cell().Text(row.Department);
                        table.Cell().Text(row.Category);
                        table.Cell().Text(row.TargetValue.ToString("0.##"));
                        table.Cell().Text(row.ActualValue?.ToString("0.##") ?? "-");
                        table.Cell().Text(row.PerformanceScore.ToString("0.##") + "%");
                        table.Cell().Text(row.Status.ToString());
                    }
                });

                page.Footer().AlignRight().Text(text =>
                {
                    text.Span("Generated on ");
                    text.Span(DateTime.Now.ToString("yyyy-MM-dd"));
                });
            });
        });

        document.GeneratePdf(dialog.FileName);
        MessageBox.Show("PDF export completed.", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void UpdateReportSummary()
    {
        var total = _reportRows.Count;
        var completed = _reportRows.Count(row => row.Status == KpiStatus.Completed);
        var belowTarget = _reportRows.Count(row => row.PerformanceScore < 100);
        var average = total == 0 ? 0 : _reportRows.Average(row => row.PerformanceScore);

        reportsTotalLabel.Text = $"Total: {total}";
        reportsAverageLabel.Text = $"Average: {average:0.##}%";
        reportsCompletedLabel.Text = $"Completed: {completed}";
        reportsBelowTargetLabel.Text = $"Below Target: {belowTarget}";
    }

    private static string BuildFilterSummary(KpiReportFilterSummary summary)
    {
        return string.Join(" | ", new[]
        {
            $"Department: {summary.DepartmentLabel}",
            $"Status: {summary.StatusLabel}",
            summary.DateRangeLabel
        });
    }

    private void UpdateDashboard(IReadOnlyCollection<KpiDto> kpis)
    {
        var total = kpis.Count;
        var achieved = kpis.Count(kpi => kpi.Status == KpiStatus.Completed);
        var delayed = kpis.Count(kpi => kpi.EndDate < DateOnly.FromDateTime(DateTime.Today) && kpi.Status != KpiStatus.Completed);
        var failed = kpis.Count(kpi => kpi.ActualValue.HasValue && kpi.TargetValue > 0 && kpi.ActualValue.Value < kpi.TargetValue && kpi.EndDate < DateOnly.FromDateTime(DateTime.Today));

        var performanceValues = kpis
            .Where(kpi => kpi.TargetValue > 0 && kpi.ActualValue.HasValue)
            .Select(kpi => (double)(kpi.ActualValue!.Value / kpi.TargetValue * 100))
            .ToList();
        var overallPerformance = performanceValues.Count == 0 ? 0 : performanceValues.Average();

        totalKpisLabel.Text = $"Total KPIs: {total}";
        achievedKpisLabel.Text = $"Achieved KPIs: {achieved}";
        failedKpisLabel.Text = $"Failed KPIs: {failed}";
        delayedKpisLabel.Text = $"Delayed KPIs: {delayed}";
        overallPerformanceLabel.Text = $"Overall Performance: {overallPerformance:0.##}%";

        totalProgressBar.Value = 100;
        _targetTotalProgress = 100;
        _targetAchievedProgress = total == 0 ? 0 : (int)Math.Round(achieved / (double)total * 100);
        _targetFailedProgress = total == 0 ? 0 : (int)Math.Round(failed / (double)total * 100);
        _targetDelayedProgress = total == 0 ? 0 : (int)Math.Round(delayed / (double)total * 100);
        _progressTimer.Start();

        _statusCounts[KpiStatus.NotStarted] = kpis.Count(kpi => kpi.Status == KpiStatus.NotStarted);
        _statusCounts[KpiStatus.InProgress] = kpis.Count(kpi => kpi.Status == KpiStatus.InProgress);
        _statusCounts[KpiStatus.Completed] = kpis.Count(kpi => kpi.Status == KpiStatus.Completed);
        _statusCounts[KpiStatus.Archived] = kpis.Count(kpi => kpi.Status == KpiStatus.Archived);
        kpiStatusPanel.Invalidate();

        UpdateTrendPoints(kpis);
        kpiTrendPanel.Invalidate();
    }

    private static string EscapeCsv(string value)
    {
        if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
        {
            return '"' + value.Replace("\"", "\"\"") + '"';
        }

        return value;
    }

    private void UpdateTrendPoints(IReadOnlyCollection<KpiDto> kpis)
    {
        _trendPoints.Clear();

        var startMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-5);
        for (var i = 0; i < 6; i++)
        {
            var month = startMonth.AddMonths(i);
            var monthKpis = kpis.Where(kpi => kpi.EndDate.Year == month.Year && kpi.EndDate.Month == month.Month);
            var monthScores = monthKpis
                .Where(kpi => kpi.TargetValue > 0 && kpi.ActualValue.HasValue)
                .Select(kpi => (double)(kpi.ActualValue!.Value / kpi.TargetValue * 100))
                .ToList();

            var average = monthScores.Count == 0 ? 0 : monthScores.Average();
            _trendPoints.Add((month.ToString("MMM"), average));
        }
    }

    private void KpiStatusPanel_Paint(object? sender, PaintEventArgs e)
    {
        var statuses = new[]
        {
            (KpiStatus.NotStarted, "Not Started", Color.Gray),
            (KpiStatus.InProgress, "In Progress", Color.Goldenrod),
            (KpiStatus.Completed, "Completed", Color.SeaGreen),
            (KpiStatus.Archived, "Archived", Color.SteelBlue)
        };

        var graphics = e.Graphics;
        graphics.Clear(Color.White);
        var chartArea = kpiStatusPanel.ClientRectangle;
        var padding = 20;
        var chartHeight = Math.Max(1, chartArea.Height - 50);
        var chartWidth = Math.Max(1, chartArea.Width - (padding * 2));
        var maxValue = Math.Max(1, statuses.Max(status => _statusCounts.GetValueOrDefault(status.Item1)));
        var barWidth = Math.Max(20, (chartWidth / statuses.Length) - 10);
        var x = padding;

        using var labelBrush = new SolidBrush(Color.Black);
        using var titleFont = new Font(Font, FontStyle.Bold);
        graphics.DrawString("KPI Status Overview", titleFont, labelBrush, new PointF(padding, 5));

        foreach (var status in statuses)
        {
            var value = _statusCounts.GetValueOrDefault(status.Item1);
            var barHeight = (int)(chartHeight * (value / (double)maxValue));
            var barTop = padding + (chartHeight - barHeight) + 20;
            var barRect = new Rectangle(x, barTop, barWidth, barHeight);

            using var barBrush = new SolidBrush(status.Item3);
            graphics.FillRectangle(barBrush, barRect);
            graphics.DrawRectangle(Pens.DimGray, barRect);

            var valueText = value.ToString();
            var valueSize = graphics.MeasureString(valueText, Font);
            graphics.DrawString(valueText, Font, labelBrush, x + (barWidth - valueSize.Width) / 2, barTop - valueSize.Height - 2);

            var labelSize = graphics.MeasureString(status.Item2, Font);
            graphics.DrawString(status.Item2, Font, labelBrush, x + (barWidth - labelSize.Width) / 2, barTop + barHeight + 4);

            x += barWidth + 10;
        }
    }

    private void KpiTrendPanel_Paint(object? sender, PaintEventArgs e)
    {
        var graphics = e.Graphics;
        graphics.Clear(Color.White);
        var chartArea = kpiTrendPanel.ClientRectangle;
        var padding = 30;
        var plotWidth = Math.Max(1, chartArea.Width - (padding * 2));
        var plotHeight = Math.Max(1, chartArea.Height - (padding * 2));

        using var axisPen = new Pen(Color.DimGray);
        graphics.DrawLine(axisPen, padding, padding, padding, padding + plotHeight);
        graphics.DrawLine(axisPen, padding, padding + plotHeight, padding + plotWidth, padding + plotHeight);

        using var labelBrush = new SolidBrush(Color.Black);
        using var titleFont = new Font(Font, FontStyle.Bold);
        graphics.DrawString("Monthly Performance Trend", titleFont, labelBrush, new PointF(padding, 5));

        if (_trendPoints.Count == 0)
        {
            return;
        }

        var maxValue = Math.Max(1, _trendPoints.Max(point => point.Value));
        var stepX = plotWidth / Math.Max(1, _trendPoints.Count - 1);

        using var linePen = new Pen(Color.RoyalBlue, 2);
        using var pointBrush = new SolidBrush(Color.RoyalBlue);

        for (var i = 0; i < _trendPoints.Count; i++)
        {
            var point = _trendPoints[i];
            var x = padding + (int)(i * stepX);
            var y = padding + plotHeight - (int)(plotHeight * (point.Value / maxValue));

            graphics.FillEllipse(pointBrush, x - 3, y - 3, 6, 6);
            if (i > 0)
            {
                var prev = _trendPoints[i - 1];
                var prevX = padding + (int)((i - 1) * stepX);
                var prevY = padding + plotHeight - (int)(plotHeight * (prev.Value / maxValue));
                graphics.DrawLine(linePen, prevX, prevY, x, y);
            }

            var labelSize = graphics.MeasureString(point.Label, Font);
            graphics.DrawString(point.Label, Font, labelBrush, x - labelSize.Width / 2, padding + plotHeight + 5);
        }
    }

    private static async Task ExecuteApiCallAsync(Func<Task> action, string errorMessage)
    {
        try
        {
            await action();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{errorMessage}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void DepartmentsAddButton_Click(object? sender, EventArgs e)
    {
        using var dialog = new DepartmentDialog("Add Department");
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            await ExecuteApiCallAsync(async () =>
            {
                await _apiClient.CreateDepartmentAsync(dialog.BuildRequest());
                await LoadDepartmentsAsync();
            }, "Unable to create department.");
        }
    }

    private async void DepartmentsEditButton_Click(object? sender, EventArgs e)
    {
        if (departmentsGrid.CurrentRow?.DataBoundItem is not DepartmentDto department)
        {
            return;
        }

        using var dialog = new DepartmentDialog("Edit Department", department);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            await ExecuteApiCallAsync(async () =>
            {
                await _apiClient.UpdateDepartmentAsync(department.Id, dialog.BuildRequest());
                await LoadDepartmentsAsync();
            }, "Unable to update department.");
        }
    }

    private async void DepartmentsDeleteButton_Click(object? sender, EventArgs e)
    {
        if (departmentsGrid.CurrentRow?.DataBoundItem is not DepartmentDto department)
        {
            return;
        }

        if (MessageBox.Show("Delete this department?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
        {
            return;
        }

        await ExecuteApiCallAsync(async () =>
        {
            await _apiClient.DeleteDepartmentAsync(department.Id);
            await LoadDepartmentsAsync();
        }, "Unable to delete department.");
    }

    private async void UsersAddButton_Click(object? sender, EventArgs e)
    {
        var departments = await _apiClient.GetDepartmentsAsync();
        var roles = await _apiClient.GetRolesAsync();
        using var dialog = new UserDialog("Add User", departments, roles, requirePassword: true);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            var request = dialog.BuildRequest(true);
            await ExecuteApiCallAsync(async () =>
            {
                await _apiClient.CreateUserAsync(request);
                await LoadUsersAsync();
            }, "Unable to create user.");
        }
    }

    private async void UsersEditButton_Click(object? sender, EventArgs e)
    {
        if (usersGrid.CurrentRow?.DataBoundItem is not UserSummaryDto user)
        {
            return;
        }

        var departments = await _apiClient.GetDepartmentsAsync();
        var roles = await _apiClient.GetRolesAsync();
        using var dialog = new UserDialog("Edit User", departments, roles, user);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            var request = dialog.BuildRequest(false);
            await ExecuteApiCallAsync(async () =>
            {
                await _apiClient.UpdateUserAsync(user.Id, request);
                await LoadUsersAsync();
            }, "Unable to update user.");
        }
    }

    private async void UsersDeactivateButton_Click(object? sender, EventArgs e)
    {
        if (usersGrid.CurrentRow?.DataBoundItem is not UserSummaryDto user)
        {
            return;
        }

        if (MessageBox.Show("Deactivate this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
        {
            return;
        }

        var departments = await _apiClient.GetDepartmentsAsync();
        var roles = await _apiClient.GetRolesAsync();
        var request = new UserUpsertRequest(
            user.FullName.Split(' ', 2).ElementAtOrDefault(0) ?? user.FullName,
            user.FullName.Split(' ', 2).ElementAtOrDefault(1) ?? string.Empty,
            user.Email,
            null,
            departments.FirstOrDefault(d => d.Name == user.DepartmentName)?.Id,
            false,
            user.ReceiveEmailNotifications,
            roles.Where(role => user.Roles.Contains(role.Name)).Select(role => role.Id).ToList());

        await ExecuteApiCallAsync(async () =>
        {
            await _apiClient.UpdateUserAsync(user.Id, request);
            await LoadUsersAsync();
        }, "Unable to deactivate user.");
    }

    private async void UsersToggleEmailButton_Click(object? sender, EventArgs e)
    {
        if (usersGrid.CurrentRow?.DataBoundItem is not UserSummaryDto user)
        {
            return;
        }

        var departments = await _apiClient.GetDepartmentsAsync();
        var roles = await _apiClient.GetRolesAsync();
        var request = new UserUpsertRequest(
            user.FullName.Split(' ', 2).ElementAtOrDefault(0) ?? user.FullName,
            user.FullName.Split(' ', 2).ElementAtOrDefault(1) ?? string.Empty,
            user.Email,
            null,
            departments.FirstOrDefault(d => d.Name == user.DepartmentName)?.Id,
            user.IsActive,
            !user.ReceiveEmailNotifications,
            roles.Where(role => user.Roles.Contains(role.Name)).Select(role => role.Id).ToList());

        await ExecuteApiCallAsync(async () =>
        {
            await _apiClient.UpdateUserAsync(user.Id, request);
            await LoadUsersAsync();
        }, "Unable to update email notification setting.");
    }

    private async void KpiAddButton_Click(object? sender, EventArgs e)
    {
        var departments = await _apiClient.GetDepartmentsAsync();
        var users = await _apiClient.GetUsersAsync();
        using var dialog = new KpiDialog("Add KPI", departments, users);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            await ExecuteApiCallAsync(async () =>
            {
                await _apiClient.CreateKpiAsync(dialog.BuildRequest());
                await LoadKpisAsync();
            }, "Unable to create KPI.");
        }
    }

    private async void KpiEditButton_Click(object? sender, EventArgs e)
    {
        if (kpiGrid.CurrentRow?.DataBoundItem is not KpiDto kpi)
        {
            return;
        }

        var departments = await _apiClient.GetDepartmentsAsync();
        var users = await _apiClient.GetUsersAsync();
        using var dialog = new KpiDialog("Edit KPI", departments, users, kpi);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            await ExecuteApiCallAsync(async () =>
            {
                await _apiClient.UpdateKpiAsync(kpi.Id, dialog.BuildRequest());
                await LoadKpisAsync();
            }, "Unable to update KPI.");
        }
    }

    private async void KpiDeleteButton_Click(object? sender, EventArgs e)
    {
        if (kpiGrid.CurrentRow?.DataBoundItem is not KpiDto kpi)
        {
            return;
        }

        if (MessageBox.Show("Delete this KPI?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
        {
            return;
        }

        await ExecuteApiCallAsync(async () =>
        {
            await _apiClient.DeleteKpiAsync(kpi.Id);
            await LoadKpisAsync();
        }, "Unable to delete KPI.");
    }

    private async void KpiProgressButton_Click(object? sender, EventArgs e)
    {
        if (kpiGrid.CurrentRow?.DataBoundItem is not KpiDto kpi)
        {
            return;
        }

        using var dialog = new KpiProgressDialog("Update KPI Progress", kpi.ActualValue);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            await ExecuteApiCallAsync(async () =>
            {
                await _apiClient.CreateKpiProgressUpdateAsync(kpi.Id, dialog.BuildRequest(_user.UserId));
                await LoadKpisAsync();
            }, "Unable to update KPI progress.");
        }
    }

    private async void KpiApproveButton_Click(object? sender, EventArgs e)
    {
        if (kpiGrid.CurrentRow?.DataBoundItem is not KpiDto kpi)
        {
            return;
        }

        using var dialog = new KpiApprovalDialog("Approve KPI");
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            await ExecuteApiCallAsync(async () =>
            {
                await _apiClient.ApproveKpiAsync(kpi.Id, dialog.BuildRequest(_user.UserId));
                await LoadKpisAsync();
            }, "Unable to approve KPI.");
        }
    }
}
