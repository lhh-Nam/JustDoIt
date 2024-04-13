using JDI.Core.Domain.Entties;
using Microsoft.EntityFrameworkCore;

namespace JDI.Infrastructure.Persistence;

public partial class ApplicationDbContext
{
    public DbSet<User> Users { get; set; }
}