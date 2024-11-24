﻿using Data.Model;
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

        public DbSet<Subject> subjects { get; set; }

        public DbSet<Standard_Subject> StandardSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define composite primary key for Standard_Subject
            modelBuilder.Entity<Standard_Subject>()
                .HasKey(ss => new { ss.StandardId, ss.SubjectId });

            modelBuilder.Entity<Standard>()
            .HasOne(s => s.ClassteacherId)
            .WithMany()
            .HasForeignKey(s => s.ClassTeacherId)
            .OnDelete(DeleteBehavior.Restrict);

            // Configuring the many-to-many relationship between Standard and Subject
            modelBuilder.Entity<Standard>()
                .HasMany(s => s.subjects)
                .WithMany()
                .UsingEntity(j => j.ToTable("Subject"));

            // Configuring the many-to-many relationship between Standard and Faculty
            modelBuilder.Entity<Standard>()
                .HasMany(s => s.Faculties)
                .WithMany()
                .UsingEntity(j => j.ToTable("Faculty"));
        }

    }
}
