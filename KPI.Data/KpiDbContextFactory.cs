using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KPI.Data;

public class KpiDbContextFactory : IDesignTimeDbContextFactory<KpiDbContext>
{
    public KpiDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<KpiDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=KpiManagementDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        return new KpiDbContext(optionsBuilder.Options);
    }
}
