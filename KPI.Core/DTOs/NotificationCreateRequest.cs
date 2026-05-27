using KPI.Core.Enums;

namespace KPI.Core.DTOs;

public record NotificationCreateRequest(
    int UserId,
    string Message,
    NotificationType Type);
