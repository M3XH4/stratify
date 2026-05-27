namespace KPI.Core.DTOs;

public record AuditLogDto(
    int Id,
    int UserId,
    string Action,
    string EntityName,
    int EntityId,
    string? Details,
    DateTime CreatedAt);
