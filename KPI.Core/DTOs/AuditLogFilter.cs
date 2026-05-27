namespace KPI.Core.DTOs;

public record AuditLogFilter(
    string? EntityName,
    DateOnly? StartDate,
    DateOnly? EndDate);
