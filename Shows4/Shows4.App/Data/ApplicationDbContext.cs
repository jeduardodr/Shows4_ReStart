using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shows4.App.Data.Entities;
namespace Shows4.App.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Cast> Casts { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Writer> Writers { get; set; }
    public DbSet<Serie> Series { get; set; }
    public DbSet<Raking> Rakings { get; set; }
    public DbSet<RentDetail> RentDetails { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
    

}