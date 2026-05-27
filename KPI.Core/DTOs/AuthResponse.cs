namespace KPI.Core.DTOs;

public record AuthResponse(
    int UserId,
    string FullName,
    string Email,
    IReadOnlyCollection<string> Roles,
    int? DepartmentId);
