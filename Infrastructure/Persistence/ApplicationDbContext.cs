using Domain;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ServiceLink> ServiceLinks { get; set; }
    public DbSet<Stop> Stops { get; set; }
    public DbSet<Journey> Journeys { get; set; }
}