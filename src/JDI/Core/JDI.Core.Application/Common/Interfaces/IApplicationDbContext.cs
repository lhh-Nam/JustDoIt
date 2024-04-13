using Microsoft.EntityFrameworkCore;
using JDI.Core.Domain.Entties;

namespace JDI.Core.Application.Common.Interfaces;

public interface IApplicationDbContext : IDisposable
{
    DbSet<User> Users { get; set; }
    void Clear();
}