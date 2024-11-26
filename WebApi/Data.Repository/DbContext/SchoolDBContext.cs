using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data.Repository.DataBase
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options) 
        { 
        
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Standard> Standards { get; set; }

        public DbSet<Address> Addresses {  get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<User_Roles> User_Roles { get; set; }

        public DbSet<Standard_Subject> StandardSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define composite primary key for Standard_Subject
            modelBuilder.Entity<Standard_Subject>()
                .HasKey(ss => new { ss.StandardId, ss.SubjectId });

            modelBuilder.Entity<User_Roles>()
                .HasKey(ss => new { ss.RolesId, ss.UserId });

            modelBuilder.Entity<Standard>()
            .HasOne(s => s.ClassTeacher)
            .WithMany()
            .HasForeignKey(s => s.ClassTeacherId)
            .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
