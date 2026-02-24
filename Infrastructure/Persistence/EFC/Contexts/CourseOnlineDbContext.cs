using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EFC.Contexts;

public class CourseOnlineDbContext(DbContextOptions<CourseOnlineDbContext> options) : DbContext(options)
{
    public DbSet<InstructorEntity> Instructors => Set<InstructorEntity>();
	public DbSet<CourseEntity> Courses => Set<CourseEntity>();
	public DbSet<CourseSessionEntity> CourseSessions => Set<CourseSessionEntity>();
	public DbSet<ParticipantEntity> Participants => Set<ParticipantEntity>();
	public DbSet<CourseRegistrationEntity> CourseRegistrations => Set<CourseRegistrationEntity>();


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

		modelBuilder.Entity<CourseEntity>(e =>
		{
			e.ToTable("Courses");
			e.HasKey(x => x.Id);
			e.Property(x => x.Title).IsRequired();
			e.Property(x => x.Description).IsRequired();
		});

		modelBuilder.Entity<CourseSessionEntity>(e =>
		{
			e.ToTable("CourseSessions");
			e.HasKey(x => x.Id);

			e.HasOne(x => x.Course)
				.WithMany(c => c.Sessions)
				.HasForeignKey(x => x.CourseId)
				.OnDelete(DeleteBehavior.Cascade);

			e.HasOne(x => x.Instructor)
				.WithMany()
				.HasForeignKey(x => x.InstructorId)
				.OnDelete(DeleteBehavior.Restrict);
		});

		modelBuilder.Entity<ParticipantEntity>(e =>
		{
			e.ToTable("Participants");
			e.HasKey(x => x.Id);
			e.Property(x => x.Email).IsRequired();
			e.HasIndex(x => x.Email).IsUnique();
		});

		modelBuilder.Entity<CourseRegistrationEntity>(e =>
		{
			e.ToTable("CourseRegistrations");
			e.HasKey(x => x.Id);

			e.HasOne(x => x.CourseSession)
				.WithMany(s => s.Registrations)
				.HasForeignKey(x => x.CourseSessionId);

			e.HasOne(x => x.Participant)
				.WithMany(p => p.Registrations)
				.HasForeignKey(x => x.ParticipantId);

			e.HasIndex(x => new { x.CourseSessionId, x.ParticipantId })
				.IsUnique();
		});

	}
}