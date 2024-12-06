using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces.Common
{
    public interface IApplicationDbContext
    {
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<ServiceLink> ServiceLinks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}