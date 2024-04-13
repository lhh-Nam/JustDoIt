using JDI.Core.Application.Common.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JDI.Infrastructure.Persistence;

public partial class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}

    public IEnumerable<T> ExecuteScript<T>(string script, SqlParameter sqlParameters = null) where T : class
    {
        var dbSet = Set<T>();
        return sqlParameters is not null ? dbSet.FromSqlRaw(script, sqlParameters) : dbSet.FromSqlRaw(script);
    }

    public void Clear()
    {
        ChangeTracker.Clear();
    }
}