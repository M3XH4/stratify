namespace KPI.Core.DTOs;

public record UserSummaryDto(
    int Id,
    string FullName,
    string Email,
    bool IsActive,
    bool ReceiveEmailNotifications,
    string? DepartmentName,
    IReadOnlyCollection<string> Roles);
