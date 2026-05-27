using KPI.Core.Enums;

namespace KPI.Core.DTOs;

public record KpiUpsertRequest(
    string Name,
    string Description,
    string Category,
    decimal TargetValue,
    decimal? ActualValue,
    string UnitOfMeasurement,
    int Weight,
    int DepartmentId,
    int? AssignedEmployeeId,
    DateOnly StartDate,
    DateOnly EndDate,
    KpiStatus Status);
