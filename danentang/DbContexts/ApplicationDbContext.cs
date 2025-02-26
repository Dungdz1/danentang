using danentang.Entity;
using Microsoft.EntityFrameworkCore;

namespace danentang.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<ErrorLogs> Errors { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd()
                    .IsRequired();
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsRequired();
            });
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");
                entity.HasKey(e => e.Id);
                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd()
                    .IsRequired();
            });
            modelBuilder.Entity<Payroll>(entity =>
            {
                entity.ToTable("Payroll");
                entity.HasKey(e => e.Id);
                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd()
                    .IsRequired();
            });
            modelBuilder.Entity<ErrorLogs>(entity =>
            {
                entity.ToTable("ErrorLogs");
                entity.HasKey(e => e.Id);
                entity
                    .Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd()
                    .IsRequired();
            });

            // Qhe cac bang
            modelBuilder
                .Entity<Attendance>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Payroll>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
