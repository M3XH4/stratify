using KPI.API.Infrastructure;
using KPI.API.Infrastructure;
using KPI.Core.DTOs;
using KPI.Core.Entities;
using KPI.Core.Interfaces;
using KPI.Data;
using KPI.Data.Repositories;
using KPI.Services.Auth;
using KPI.Services.Security;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KpiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<ReminderScheduleOptions>(builder.Configuration.GetSection("ReminderSchedule"));
builder.Services.AddSingleton<NotificationEmailSender>();
builder.Services.AddScoped<ReminderService>();
builder.Services.AddHostedService<ReminderHostedService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await DatabaseInitializer.InitializeAsync(app.Services, app.Configuration);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

static async Task AddAuditLogAsync(KpiDbContext context, HttpContext httpContext, string action, string entityName, int entityId, string? details)
{
    var userIdHeader = httpContext.Request.Headers["X-User-Id"].FirstOrDefault();
    var userId = int.TryParse(userIdHeader, out var parsedUserId) ? parsedUserId : 0;

    context.AuditLogs.Add(new AuditLog
    {
        UserId = userId,
        Action = action,
        EntityName = entityName,
        EntityId = entityId,
        Details = details
    });

    await context.SaveChangesAsync();
}

app.MapPost("/api/auth/register", async (UserRegistrationRequest request, IAuthService authService, KpiDbContext context, HttpContext httpContext) =>
{
    try
    {
        var response = await authService.RegisterAsync(request);
        await AddAuditLogAsync(context, httpContext, "Register", "User", response.UserId, $"Registered user {response.Email}.");
        return Results.Created($"/api/users/{response.UserId}", response);
    }
    catch (InvalidOperationException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.MapPost("/api/auth/login", async (AuthRequest request, IAuthService authService) =>
{
    var response = await authService.LoginAsync(request);
    return response is null ? Results.Unauthorized() : Results.Ok(response);
});

app.MapGet("/api/roles", async (KpiDbContext context) =>
{
    var roles = await context.Roles
        .OrderBy(role => role.Name)
        .Select(role => new RoleDto(role.Id, role.Name))
        .ToListAsync();
    return Results.Ok(roles);
});

app.MapGet("/api/departments", async (KpiDbContext context) =>
{
    var departments = await context.Departments
        .OrderBy(department => department.Name)
        .Select(department => new DepartmentDto(department.Id, department.Name, department.Description))
        .ToListAsync();
    return Results.Ok(departments);
});

app.MapPost("/api/departments", async (DepartmentRequest request, KpiDbContext context, HttpContext httpContext) =>
{
    var department = new Department { Name = request.Name, Description = request.Description };
    context.Departments.Add(department);
    await context.SaveChangesAsync();
    await AddAuditLogAsync(context, httpContext, "Create", "Department", department.Id, $"Created department {department.Name}.");
    return Results.Created($"/api/departments/{department.Id}", new DepartmentDto(department.Id, department.Name, department.Description));
});

app.MapPut("/api/departments/{id:int}", async (int id, DepartmentRequest request, KpiDbContext context, HttpContext httpContext) =>
{
    var department = await context.Departments.FindAsync(id);
    if (department is null)
    {
        return Results.NotFound();
    }

    department.Name = request.Name;
    department.Description = request.Description;
    department.UpdatedAt = DateTime.UtcNow;
    await context.SaveChangesAsync();
    await AddAuditLogAsync(context, httpContext, "Update", "Department", department.Id, $"Updated department {department.Name}.");
    return Results.Ok(new DepartmentDto(department.Id, department.Name, department.Description));
});

app.MapDelete("/api/departments/{id:int}", async (int id, KpiDbContext context, HttpContext httpContext) =>
{
    var department = await context.Departments.FindAsync(id);
    if (department is null)
    {
        return Results.NotFound();
    }

    context.Departments.Remove(department);
    await context.SaveChangesAsync();
    await AddAuditLogAsync(context, httpContext, "Delete", "Department", department.Id, $"Deleted department {department.Name}.");
    return Results.NoContent();
});

app.MapGet("/api/users", async (KpiDbContext context) =>
{
    var users = await context.Users
        .Include(user => user.Department)
        .Include(user => user.UserRoles)
        .ThenInclude(userRole => userRole.Role)
        .OrderBy(user => user.LastName)
        .ThenBy(user => user.FirstName)
        .Select(user => new UserSummaryDto(
            user.Id,
            $"{user.FirstName} {user.LastName}",
            user.Email,
            user.IsActive,
            user.ReceiveEmailNotifications,
            user.Department != null ? user.Department.Name : null,
            user.UserRoles.Select(userRole => userRole.Role.Name).ToList()))
        .ToListAsync();
    return Results.Ok(users);
});

app.MapPost("/api/users", async (UserUpsertRequest request, KpiDbContext context, IPasswordHasher passwordHasher, HttpContext httpContext) =>
{
    if (string.IsNullOrWhiteSpace(request.Password))
    {
        return Results.BadRequest(new { error = "Password is required." });
    }

    var user = new User
    {
        FirstName = request.FirstName,
        LastName = request.LastName,
        Email = request.Email,
        PasswordHash = passwordHasher.Hash(request.Password),
        DepartmentId = request.DepartmentId,
        IsActive = request.IsActive,
        ReceiveEmailNotifications = request.ReceiveEmailNotifications,
        UserRoles = request.RoleIds.Select(roleId => new UserRole { RoleId = roleId }).ToList()
    };

    context.Users.Add(user);
    await context.SaveChangesAsync();
    await AddAuditLogAsync(context, httpContext, "Create", "User", user.Id, $"Created user {user.Email}.");
    return Results.Created($"/api/users/{user.Id}", user.Id);
});

app.MapPut("/api/users/{id:int}", async (int id, UserUpsertRequest request, KpiDbContext context, IPasswordHasher passwordHasher, HttpContext httpContext) =>
{
    var user = await context.Users
        .Include(existing => existing.UserRoles)
        .FirstOrDefaultAsync(existing => existing.Id == id);
    if (user is null)
    {
        return Results.NotFound();
    }

    user.FirstName = request.FirstName;
    user.LastName = request.LastName;
    user.Email = request.Email;
    user.DepartmentId = request.DepartmentId;
    user.IsActive = request.IsActive;
    user.ReceiveEmailNotifications = request.ReceiveEmailNotifications;
    user.UpdatedAt = DateTime.UtcNow;

    if (!string.IsNullOrWhiteSpace(request.Password))
    {
        user.PasswordHash = passwordHasher.Hash(request.Password);
    }

    user.UserRoles.Clear();
    foreach (var roleId in request.RoleIds)
    {
        user.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = roleId });
    }

    await context.SaveChangesAsync();
    await AddAuditLogAsync(context, httpContext, "Update", "User", user.Id, $"Updated user {user.Email}.");
    return Results.NoContent();
});

app.MapGet("/api/kpis", async (KpiDbContext context) =>
{
    var kpis = await context.Kpis
        .Include(kpi => kpi.Department)
        .Include(kpi => kpi.AssignedEmployee)
        .OrderBy(kpi => kpi.Name)
        .Select(kpi => new KpiDto(
            kpi.Id,
            kpi.Name,
            kpi.Description,
            kpi.Category,
            kpi.TargetValue,
            kpi.ActualValue,
            kpi.UnitOfMeasurement,
            kpi.Weight,
            kpi.Department.Name,
            kpi.AssignedEmployee != null ? $"{kpi.AssignedEmployee.FirstName} {kpi.AssignedEmployee.LastName}" : null,
            kpi.StartDate,
            kpi.EndDate,
            kpi.Status))
        .ToListAsync();
    return Results.Ok(kpis);
});

app.MapPost("/api/kpis", async (KpiUpsertRequest request, KpiDbContext context, HttpContext httpContext) =>
{
    var kpi = new Kpi
    {
        Name = request.Name,
        Description = request.Description,
        Category = request.Category,
        TargetValue = request.TargetValue,
        ActualValue = request.ActualValue,
        UnitOfMeasurement = request.UnitOfMeasurement,
        Weight = request.Weight,
        DepartmentId = request.DepartmentId,
        AssignedEmployeeId = request.AssignedEmployeeId,
        StartDate = request.StartDate,
        EndDate = request.EndDate,
        Status = request.Status
    };

    context.Kpis.Add(kpi);
    await context.SaveChangesAsync();
    await AddAuditLogAsync(context, httpContext, "Create", "KPI", kpi.Id, $"Created KPI {kpi.Name}.");
    return Results.Created($"/api/kpis/{kpi.Id}", kpi.Id);
});

app.MapPut("/api/kpis/{id:int}", async (int id, KpiUpsertRequest request, KpiDbContext context, HttpContext httpContext) =>
{
    var kpi = await context.Kpis.FindAsync(id);
    if (kpi is null)
    {
        return Results.NotFound();
    }

    kpi.Name = request.Name;
    kpi.Description = request.Description;
    kpi.Category = request.Category;
    kpi.TargetValue = request.TargetValue;
    kpi.ActualValue = request.ActualValue;
    kpi.UnitOfMeasurement = request.UnitOfMeasurement;
    kpi.Weight = request.Weight;
    kpi.DepartmentId = request.DepartmentId;
    kpi.AssignedEmployeeId = request.AssignedEmployeeId;
    kpi.StartDate = request.StartDate;
    kpi.EndDate = request.EndDate;
    kpi.Status = request.Status;
    kpi.UpdatedAt = DateTime.UtcNow;

    await context.SaveChangesAsync();
    await AddAuditLogAsync(context, httpContext, "Update", "KPI", kpi.Id, $"Updated KPI {kpi.Name}.");
    return Results.NoContent();
});

app.MapGet("/api/kpis/{id:int}/updates", async (int id, KpiDbContext context) =>
{
    var updates = await context.KpiProgressUpdates
        .Where(update => update.KpiId == id)
        .OrderByDescending(update => update.CreatedAt)
        .Select(update => new KpiProgressUpdateDto(
            update.Id,
            update.KpiId,
            update.UpdatedById,
            update.ActualValue,
            update.Comment,
            update.CreatedAt))
        .ToListAsync();

    return Results.Ok(updates);
});

app.MapPost("/api/kpis/{id:int}/updates", async (int id, KpiProgressUpdateRequest request, KpiDbContext context, HttpContext httpContext) =>
{
    var kpi = await context.Kpis.FindAsync(id);
    if (kpi is null)
    {
        return Results.NotFound();
    }

    var progressUpdate = new KpiProgressUpdate
    {
        KpiId = id,
        UpdatedById = request.UpdatedById,
        ActualValue = request.ActualValue,
        Comment = request.Comment
    };

    kpi.ActualValue = request.ActualValue;
    if (kpi.Status == KPI.Core.Enums.KpiStatus.NotStarted)
    {
        kpi.Status = KPI.Core.Enums.KpiStatus.InProgress;
    }

    context.KpiProgressUpdates.Add(progressUpdate);
    await context.SaveChangesAsync();
    await AddAuditLogAsync(context, httpContext, "Update", "KPI", kpi.Id, $"Progress updated for KPI {kpi.Name}.");
    return Results.Created($"/api/kpis/{id}/updates/{progressUpdate.Id}", progressUpdate.Id);
});

app.MapGet("/api/kpis/{id:int}/approvals", async (int id, KpiDbContext context) =>
{
    var approvals = await context.KpiApprovals
        .Where(approval => approval.KpiId == id)
        .OrderByDescending(approval => approval.CreatedAt)
        .Select(approval => new KpiApprovalDto(
            approval.Id,
            approval.KpiId,
            approval.ApprovedById,
            approval.Notes,
            approval.CreatedAt))
        .ToListAsync();

    return Results.Ok(approvals);
});

app.MapPost("/api/kpis/{id:int}/approvals", async (int id, KpiApprovalRequest request, KpiDbContext context, HttpContext httpContext) =>
{
    var kpi = await context.Kpis.FindAsync(id);
    if (kpi is null)
    {
        return Results.NotFound();
    }

    var approver = await context.Users
        .Include(user => user.UserRoles)
        .ThenInclude(userRole => userRole.Role)
        .FirstOrDefaultAsync(user => user.Id == request.ApprovedById);

    if (approver is null)
    {
        return Results.BadRequest(new { error = "Approver not found." });
    }

    var isManager = approver.UserRoles.Any(userRole =>
        userRole.Role.Name == "Manager" || userRole.Role.Name == "Admin");

    if (!isManager)
    {
        return Results.Forbid();
    }

    var approval = new KpiApproval
    {
        KpiId = id,
        ApprovedById = request.ApprovedById,
        Notes = request.Notes
    };

    kpi.Status = KPI.Core.Enums.KpiStatus.Completed;
    kpi.UpdatedAt = DateTime.UtcNow;

    context.KpiApprovals.Add(approval);
    await context.SaveChangesAsync();
    await AddAuditLogAsync(context, httpContext, "Approve", "KPI", kpi.Id, $"Approved KPI {kpi.Name}.");
    return Results.Created($"/api/kpis/{id}/approvals/{approval.Id}", approval.Id);
});

app.MapDelete("/api/kpis/{id:int}", async (int id, KpiDbContext context, HttpContext httpContext) =>
{
    var kpi = await context.Kpis.FindAsync(id);
    if (kpi is null)
    {
        return Results.NotFound();
    }

    context.Kpis.Remove(kpi);
    await context.SaveChangesAsync();
    await AddAuditLogAsync(context, httpContext, "Delete", "KPI", kpi.Id, $"Deleted KPI {kpi.Name}.");
    return Results.NoContent();
});

app.MapGet("/api/reports/kpis", async (int? departmentId, DateOnly? startDate, DateOnly? endDate, KPI.Core.Enums.KpiStatus? status, KpiDbContext context) =>
{
    var query = context.Kpis
        .Include(kpi => kpi.Department)
        .AsQueryable();

    if (departmentId.HasValue)
    {
        query = query.Where(kpi => kpi.DepartmentId == departmentId.Value);
    }

    if (startDate.HasValue)
    {
        query = query.Where(kpi => kpi.StartDate >= startDate.Value);
    }

    if (endDate.HasValue)
    {
        query = query.Where(kpi => kpi.EndDate <= endDate.Value);
    }

    if (status.HasValue)
    {
        query = query.Where(kpi => kpi.Status == status.Value);
    }

    var reportRows = await query
        .OrderBy(kpi => kpi.Name)
        .Select(kpi => new KpiReportRowDto(
            kpi.Id,
            kpi.Name,
            kpi.Department.Name,
            kpi.Category,
            kpi.TargetValue,
            kpi.ActualValue,
            kpi.TargetValue > 0 && kpi.ActualValue.HasValue ? (kpi.ActualValue.Value / kpi.TargetValue) * 100 : 0,
            kpi.StartDate,
            kpi.EndDate,
            kpi.Status))
        .ToListAsync();

    return Results.Ok(reportRows);
});

app.MapGet("/api/notifications", async (int userId, KpiDbContext context) =>
{
    var notifications = await context.Notifications
        .Where(notification => notification.UserId == userId)
        .OrderByDescending(notification => notification.CreatedAt)
        .Select(notification => new NotificationDto(
            notification.Id,
            notification.UserId,
            notification.Message,
            notification.Type,
            notification.IsRead,
            notification.CreatedAt))
        .ToListAsync();

    return Results.Ok(notifications);
});

app.MapPost("/api/notifications", async (NotificationCreateRequest request, KpiDbContext context) =>
{
    var notification = new Notification
    {
        UserId = request.UserId,
        Message = request.Message,
        Type = request.Type,
        IsRead = false
    };

    context.Notifications.Add(notification);
    await context.SaveChangesAsync();
    return Results.Created($"/api/notifications/{notification.Id}", notification.Id);
});

app.MapPost("/api/notifications/{id:int}/read", async (int id, KpiDbContext context) =>
{
    var notification = await context.Notifications.FindAsync(id);
    if (notification is null)
    {
        return Results.NotFound();
    }

    notification.IsRead = true;
    notification.UpdatedAt = DateTime.UtcNow;
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapPost("/api/notifications/reminders", async (ReminderService reminderService) =>
{
    var created = await reminderService.GenerateDeadlineRemindersAsync();
    return Results.Ok(new { created });
});

app.Run();
