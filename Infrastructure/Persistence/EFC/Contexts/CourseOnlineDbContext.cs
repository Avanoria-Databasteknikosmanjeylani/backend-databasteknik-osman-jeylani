using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EFC.Contexts;

public class CourseOnlineDbContext(DbContextOptions<CourseOnlineDbContext> options) : DbContext(options)
{
    public DbSet<InstructorEntity> Instructors => Set<InstructorEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InstructorEntity>(e =>
        {
            e.ToTable("Instructors");
            e.HasKey(e => e.Id);
            e.Property(e => e.FirstName).IsRequired();
            e.Property(e => e.LastName).IsRequired();
            e.Property(e => e.Email).IsRequired();

            e.HasIndex(e => e.Email).IsUnique();
        });

    }
}