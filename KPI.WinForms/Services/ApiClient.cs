using System.Net;
using System.Net.Http.Json;
using KPI.Core.DTOs;
using KPI.Core.Enums;

namespace KPI.WinForms.Services;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(string baseUrl)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
    }

    public void SetUserId(int userId)
    {
        if (_httpClient.DefaultRequestHeaders.Contains("X-User-Id"))
        {
            _httpClient.DefaultRequestHeaders.Remove("X-User-Id");
        }

        _httpClient.DefaultRequestHeaders.Add("X-User-Id", userId.ToString());
    }

    public async Task<AuthResponse?> LoginAsync(AuthRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/auth/login", request, cancellationToken);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<AuthResponse>(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<RoleDto>> GetRolesAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<List<RoleDto>>("/api/roles", cancellationToken)
               ?? new List<RoleDto>();
    }

    public async Task<IReadOnlyCollection<DepartmentDto>> GetDepartmentsAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<List<DepartmentDto>>("/api/departments", cancellationToken)
               ?? new List<DepartmentDto>();
    }

    public async Task CreateDepartmentAsync(DepartmentRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/departments", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateDepartmentAsync(int id, DepartmentRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync($"/api/departments/{id}", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteDepartmentAsync(int id, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"/api/departments/{id}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<IReadOnlyCollection<UserSummaryDto>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<List<UserSummaryDto>>("/api/users", cancellationToken)
               ?? new List<UserSummaryDto>();
    }

    public async Task CreateUserAsync(UserUpsertRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/users", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateUserAsync(int id, UserUpsertRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync($"/api/users/{id}", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<IReadOnlyCollection<KpiDto>> GetKpisAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<List<KpiDto>>("/api/kpis", cancellationToken)
               ?? new List<KpiDto>();
    }

    public async Task CreateKpiAsync(KpiUpsertRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/kpis", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateKpiAsync(int id, KpiUpsertRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync($"/api/kpis/{id}", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteKpiAsync(int id, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"/api/kpis/{id}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<IReadOnlyCollection<KpiReportRowDto>> GetKpiReportAsync(KpiReportFilter filter, CancellationToken cancellationToken = default)
    {
        var query = new List<string>();

        if (filter.DepartmentId.HasValue)
        {
            query.Add($"departmentId={filter.DepartmentId.Value}");
        }

        if (filter.StartDate.HasValue)
        {
            query.Add($"startDate={filter.StartDate:yyyy-MM-dd}");
        }

        if (filter.EndDate.HasValue)
        {
            query.Add($"endDate={filter.EndDate:yyyy-MM-dd}");
        }

        if (filter.Status.HasValue)
        {
            query.Add($"status={filter.Status.Value}");
        }

        var queryString = query.Count > 0 ? "?" + string.Join("&", query) : string.Empty;
        return await _httpClient.GetFromJsonAsync<List<KpiReportRowDto>>($"/api/reports/kpis{queryString}", cancellationToken)
               ?? new List<KpiReportRowDto>();
    }

    public async Task<IReadOnlyCollection<AuditLogDto>> GetAuditLogsAsync(AuditLogFilter filter, CancellationToken cancellationToken = default)
    {
        var query = new List<string>();

        if (!string.IsNullOrWhiteSpace(filter.EntityName))
        {
            query.Add($"entityName={Uri.EscapeDataString(filter.EntityName)}");
        }

        if (filter.StartDate.HasValue)
        {
            query.Add($"startDate={filter.StartDate:yyyy-MM-dd}");
        }

        if (filter.EndDate.HasValue)
        {
            query.Add($"endDate={filter.EndDate:yyyy-MM-dd}");
        }

        var queryString = query.Count > 0 ? "?" + string.Join("&", query) : string.Empty;
        return await _httpClient.GetFromJsonAsync<List<AuditLogDto>>($"/api/audit-logs{queryString}", cancellationToken)
               ?? new List<AuditLogDto>();
    }

    public async Task<IReadOnlyCollection<NotificationDto>> GetNotificationsAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<List<NotificationDto>>($"/api/notifications?userId={userId}", cancellationToken)
               ?? new List<NotificationDto>();
    }

    public async Task MarkNotificationReadAsync(int id, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync($"/api/notifications/{id}/read", null, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<int> GenerateNotificationRemindersAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync("/api/notifications/reminders", null, cancellationToken);
        response.EnsureSuccessStatusCode();
        var payload = await response.Content.ReadFromJsonAsync<Dictionary<string, int>>(cancellationToken: cancellationToken);
        return payload?.GetValueOrDefault("created") ?? 0;
    }

    public async Task CreateKpiProgressUpdateAsync(int kpiId, KpiProgressUpdateRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync($"/api/kpis/{kpiId}/updates", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task ApproveKpiAsync(int kpiId, KpiApprovalRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync($"/api/kpis/{kpiId}/approvals", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<IReadOnlyCollection<KpiProgressUpdateDto>> GetKpiUpdatesAsync(int kpiId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<List<KpiProgressUpdateDto>>($"/api/kpis/{kpiId}/updates", cancellationToken)
               ?? new List<KpiProgressUpdateDto>();
    }

    public async Task<IReadOnlyCollection<KpiApprovalDto>> GetKpiApprovalsAsync(int kpiId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<List<KpiApprovalDto>>($"/api/kpis/{kpiId}/approvals", cancellationToken)
               ?? new List<KpiApprovalDto>();
    }
}
