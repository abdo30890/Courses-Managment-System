namespace CMS.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CmsDbCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        TrainerId = c.Guid(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        OrderNumber = c.String(),
                        CourseId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CoursesLessons",
                c => new
                    {
                        RefCourseId = c.Guid(nullable: false),
                        RefLessonId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RefCourseId, t.RefLessonId })
                .ForeignKey("dbo.Courses", t => t.RefCourseId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.RefLessonId, cascadeDelete: true)
                .Index(t => t.RefCourseId)
                .Index(t => t.RefLessonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.CoursesLessons", "RefLessonId", "dbo.Members");
            DropForeignKey("dbo.CoursesLessons", "RefCourseId", "dbo.Courses");
            DropForeignKey("dbo.Lessons", "CourseId", "dbo.Courses");
            DropIndex("dbo.CoursesLessons", new[] { "RefLessonId" });
            DropIndex("dbo.CoursesLessons", new[] { "RefCourseId" });
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "TrainerId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropTable("dbo.CoursesLessons");
            DropTable("dbo.Trainers");
            DropTable("dbo.Members");
            DropTable("dbo.Lessons");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
