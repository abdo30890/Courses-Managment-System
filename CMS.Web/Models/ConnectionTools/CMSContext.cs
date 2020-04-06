using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMS.Web.Models.ConnectionTools
{
    public class CmsContext : DbContext
    {
        public CmsContext() :base(ConnectionString.Connection())
        {
            
        }



        #region //Db Sets

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        #endregion

        #region Fluent API

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(d => d.Courses)
                .WithRequired(d => d.Category)
                .HasForeignKey(d => d.CategoryId);
            modelBuilder.Entity<Trainer>()
                .HasMany(d => d.Courses)
                .WithRequired(d => d.Trainer)
                .HasForeignKey(d => d.TrainerId);
            modelBuilder.Entity<Course>()
                .HasMany(d => d.Lessons)
                .WithRequired(d => d.Course)
                .HasForeignKey(d => d.CourseId);
            modelBuilder.Entity<Course>()
                .HasMany(d => d.Members)
                .WithMany(d => d.Courses)
                .Map(cs =>
                {
                    cs.MapLeftKey("RefCourseId");
                    cs.MapRightKey("RefLessonId");
                    cs.ToTable("CoursesLessons");
                });












            base.OnModelCreating(modelBuilder);
        }

        #endregion


    }
}