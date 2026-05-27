namespace KPI.Core.DTOs;

public record KpiApprovalDto(
    int Id,
    int KpiId,
    int ApprovedById,
    string? Notes,
    DateTime CreatedAt);
