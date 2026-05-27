namespace KPI.Core.DTOs;

public record UserRegistrationRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    int? DepartmentId);
