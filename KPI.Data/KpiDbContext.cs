using KPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace KPI.Data;

public class KpiDbContext : DbContext
{
    public KpiDbContext(DbContextOptions<KpiDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Kpi> Kpis => Set<Kpi>();
    public DbSet<KpiProgressUpdate> KpiProgressUpdates => Set<KpiProgressUpdate>();
    public DbSet<KpiApproval> KpiApprovals => Set<KpiApproval>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var dateOnlyConverter = new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<DateOnly, DateTime>(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime));

        modelBuilder.Entity<Kpi>()
            .Property(k => k.StartDate)
            .HasConversion(dateOnlyConverter);

        modelBuilder.Entity<Kpi>()
            .Property(k => k.EndDate)
            .HasConversion(dateOnlyConverter);

        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        modelBuilder.Entity<Role>()
            .HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Manager" },
                new Role { Id = 3, Name = "Employee" },
                new Role { Id = 4, Name = "Viewer" });

        base.OnModelCreating(modelBuilder);
    }
}
