using Microsoft.EntityFrameworkCore;
using Portfolio.Model.Entities;

namespace Portfolio.DAL.Data;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
        : base(options)
    {
    }

    // ─────────────────────────────────────────────
    // DbSets — one per entity that maps to a table
    // ─────────────────────────────────────────────
    public DbSet<Project> Projects => Set<Project>();

    public DbSet<Technology> Technologies => Set<Technology>();

    public DbSet<ProjectTechnology> ProjectTechnologies => Set<ProjectTechnology>();

    // ─────────────────────────────────────────────
    // Fluent API Configuration
    // We use Fluent API instead of data annotations
    // to keep the Model layer free of EF Core dependencies.
    // ─────────────────────────────────────────────
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ── Project ──────────────────────────────
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(200);

            // Unique index: no two projects can share the same slug
            entity.HasIndex(x => x.Slug)
                .IsUnique();

            entity.Property(x => x.ShortDescription)
                .IsRequired()
                .HasMaxLength(300);

            entity.Property(x => x.Description)
                .IsRequired();

            entity.Property(x => x.GithubUrl)
                .HasMaxLength(500);

            entity.Property(x => x.LiveUrl)
                .HasMaxLength(500);

            entity.Property(x => x.ImageUrl)
                .HasMaxLength(500);
        });

        // ── Technology ───────────────────────────
        modelBuilder.Entity<Technology>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Unique index: "Angular" cannot be inserted twice
            entity.HasIndex(x => x.Name)
                .IsUnique();

            entity.Property(x => x.Category)
                .HasMaxLength(100);
        });

        // ── ProjectTechnology (junction table) ───
        modelBuilder.Entity<ProjectTechnology>(entity =>
        {
            // Composite primary key: (ProjectId, TechnologyId)
            // This prevents the same technology being linked
            // to the same project more than once.
            entity.HasKey(x => new { x.ProjectId, x.TechnologyId });

            entity.HasOne(x => x.Project)
                .WithMany(x => x.ProjectTechnologies)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(x => x.Technology)
                .WithMany(x => x.ProjectTechnologies)
                .HasForeignKey(x => x.TechnologyId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
