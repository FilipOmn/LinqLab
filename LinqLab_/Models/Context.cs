using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinqLab_.Models
{
    public class Context : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-FFB4Q97\SQLEXPRESS;Initial Catalog=LinqLaboration_2;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>()
                .HasOne(c => c.Course)
                .WithMany(cs => cs.CourseStudents)
                .HasForeignKey(ci => ci.CourseId);

            modelBuilder.Entity<CourseStudent>()
              .HasOne(c => c.Student)
              .WithMany(cs => cs.CourseStudents)
              .HasForeignKey(ci => ci.StudentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
