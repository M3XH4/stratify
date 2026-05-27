using KPI.Core.Entities;
using KPI.Core.Enums;
using KPI.Data;
using Microsoft.EntityFrameworkCore;

namespace KPI.API.Infrastructure;

public class ReminderService
{
    private readonly KpiDbContext _context;
    private readonly NotificationEmailSender _emailSender;

    public ReminderService(KpiDbContext context, NotificationEmailSender emailSender)
    {
        _context = context;
        _emailSender = emailSender;
    }

    public async Task<int> GenerateDeadlineRemindersAsync(CancellationToken cancellationToken = default)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var deadline = today.AddDays(7);
        var todayUtc = DateTime.UtcNow.Date;

        var dueKpis = await _context.Kpis
            .Include(kpi => kpi.AssignedEmployee)
            .Where(kpi => kpi.AssignedEmployeeId.HasValue
                          && kpi.EndDate <= deadline
                          && kpi.EndDate >= today
                          && kpi.Status != KpiStatus.Completed)
            .ToListAsync(cancellationToken);

        var created = 0;
        foreach (var kpi in dueKpis)
        {
            var userId = kpi.AssignedEmployeeId!.Value;
            if (kpi.AssignedEmployee is null || !kpi.AssignedEmployee.ReceiveEmailNotifications)
            {
                continue;
            }

            var message = $"KPI {kpi.Id}: '{kpi.Name}' is due by {kpi.EndDate:yyyy-MM-dd}.";

            var alreadyExists = await _context.Notifications.AnyAsync(notification =>
                notification.UserId == userId
                && notification.Type == NotificationType.DeadlineReminder
                && notification.CreatedAt.Date == todayUtc
                && notification.Message.Contains($"KPI {kpi.Id}:", StringComparison.OrdinalIgnoreCase),
                cancellationToken);

            if (alreadyExists)
            {
                continue;
            }

            _context.Notifications.Add(new Notification
            {
                UserId = userId,
                Message = message,
                Type = NotificationType.DeadlineReminder,
                IsRead = false
            });

            created++;

            if (!string.IsNullOrWhiteSpace(kpi.AssignedEmployee?.Email))
            {
                var subject = "KPI Deadline Reminder";
                var body = $"Hello {kpi.AssignedEmployee.FirstName},\n\n{message}\n\nPlease update your progress in the KPI system.";
                await _emailSender.SendAsync(kpi.AssignedEmployee.Email, subject, body, cancellationToken);
            }
        }

        if (created > 0)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        return created;
    }
}
