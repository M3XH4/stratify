namespace KPI.Core.DTOs;

public record KpiApprovalRequest(
    int ApprovedById,
    string? Notes);
