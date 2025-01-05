using InveonCourseApp.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InveonCourseApp.Repository
{
    public class ApplicationDbContext: IdentityDbContext<AppUser, AppRole, int>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserCourse>()
                .HasKey(up => new { up.AppUserId, up.ProductId });

            modelBuilder.Entity<UserCourse>()
                .HasOne(up => up.AppUser)
                .WithMany(u => u.UserCourses)
                .HasForeignKey(up => up.AppUserId);

            modelBuilder.Entity<UserCourse>()
                .HasOne(up => up.Product)
                .WithMany(p => p.UserCourses)
                .HasForeignKey(up => up.ProductId);
        }

    }
}
