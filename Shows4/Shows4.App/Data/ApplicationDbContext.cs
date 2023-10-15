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
        
        modelBuilder.Entity<EpisodeCast>()
            .HasKey(ec => new { ec.EpisodeId, ec.CastId });

        modelBuilder.Entity<EpisodeCast>()
            .HasOne(ec => ec.Episode)
            .WithMany(e => e.EpisodeCasts)
            .HasForeignKey(ec => ec.EpisodeId);

        modelBuilder.Entity<EpisodeCast>()
            .HasOne(ec => ec.Cast)
            .WithMany(c => c.EpisodeCasts)
            .HasForeignKey(ec => ec.CastId);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => x.UserId);
    }
    public DbSet<Shows4.App.Data.Entities.EpisodeCast> EpisodeCast { get; set; }

}