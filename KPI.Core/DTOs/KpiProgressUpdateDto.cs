namespace KPI.Core.DTOs;

public record KpiProgressUpdateDto(
    int Id,
    int KpiId,
    int UpdatedById,
    decimal ActualValue,
    string? Comment,
    DateTime CreatedAt);
