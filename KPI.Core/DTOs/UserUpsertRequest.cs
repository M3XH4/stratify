namespace KPI.Core.DTOs;

public record UserUpsertRequest(
    string FirstName,
    string LastName,
    string Email,
    string? Password,
    int? DepartmentId,
    bool IsActive,
    bool ReceiveEmailNotifications,
    IReadOnlyCollection<int> RoleIds);
