using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<Function> Functions { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<Salary> Salaries { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<ResetPasswordToken> Tokens { get; set; }
        void Save();
    }
}
