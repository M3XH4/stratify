using KPI.Core.Enums;

namespace KPI.Core.DTOs;

public record NotificationDto(
    int Id,
    int UserId,
    string Message,
    NotificationType Type,
    bool IsRead,
    DateTime CreatedAt);
