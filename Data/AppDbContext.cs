using Microsoft.EntityFrameworkCore;
using TaskFlowAPI.Entities;

namespace TaskFlowAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskFlow> TaskFlows { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique index on Username
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(100);

            // TaskFlow relationship
            modelBuilder.Entity<TaskFlow>()
                .HasOne(t => t.User)
                .WithMany(u => u.TaskFlows)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskFlow>()
                .Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<TaskFlow>()
                .Property(t => t.Description)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
