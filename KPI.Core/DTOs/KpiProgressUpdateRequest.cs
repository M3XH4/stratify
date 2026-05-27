namespace KPI.Core.DTOs;

public record KpiProgressUpdateRequest(
    int UpdatedById,
    decimal ActualValue,
    string? Comment);
