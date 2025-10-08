using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ContextAndMigrations.Context;

public class CAContextFactory : IDesignTimeDbContextFactory<CAContext>
{
    public CAContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CAContext>();
        optionsBuilder.UseSqlite("Data Source=app.db");

        return new CAContext(optionsBuilder.Options);
    }
}
