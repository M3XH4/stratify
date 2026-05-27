using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KPI.API.Infrastructure;

public class ReminderHostedService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<ReminderHostedService> _logger;
    private readonly ReminderScheduleOptions _options;

    public ReminderHostedService(IServiceScopeFactory scopeFactory, ILogger<ReminderHostedService> logger, IOptions<ReminderScheduleOptions> options)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
        _options = options.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await DelayUntilNextRunAsync(stoppingToken);
        await RunOnceAsync(stoppingToken);

        using var timer = new PeriodicTimer(TimeSpan.FromDays(1));
        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            await RunOnceAsync(stoppingToken);
        }
    }

    private async Task DelayUntilNextRunAsync(CancellationToken stoppingToken)
    {
        var now = DateTime.Now;
        var scheduled = new DateTime(now.Year, now.Month, now.Day, _options.HourOfDay, 0, 0);
        if (scheduled <= now)
        {
            scheduled = scheduled.AddDays(1);
        }

        var delay = scheduled - now;
        if (delay > TimeSpan.Zero)
        {
            await Task.Delay(delay, stoppingToken);
        }
    }

    private async Task RunOnceAsync(CancellationToken stoppingToken)
    {
        try
        {
            await using var scope = _scopeFactory.CreateAsyncScope();
            var reminderService = scope.ServiceProvider.GetRequiredService<ReminderService>();
            var created = await reminderService.GenerateDeadlineRemindersAsync(stoppingToken);
            _logger.LogInformation("Generated {Count} KPI deadline reminders.", created);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to generate KPI deadline reminders.");
        }
    }
}
