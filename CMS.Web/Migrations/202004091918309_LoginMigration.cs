namespace CMS.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class LoginMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Lessons", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CoursesLessons", "RefCourseId", "dbo.Courses");
            DropForeignKey("dbo.CoursesLessons", "RefLessonId", "dbo.Members");
            DropForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropIndex("dbo.Courses", new[] { "TrainerId" });
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            DropIndex("dbo.CoursesLessons", new[] { "RefCourseId" });
            DropIndex("dbo.CoursesLessons", new[] { "RefLessonId" });
            DropPrimaryKey("dbo.Admins");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Courses");
            DropPrimaryKey("dbo.Lessons");
            DropPrimaryKey("dbo.Members");
            DropPrimaryKey("dbo.Trainers");
            DropPrimaryKey("dbo.CoursesLessons");
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Massage = c.String()
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categories", "CategoryName", c => c.String());
            AddColumn("dbo.Courses", "CourseName", c => c.String());
            AddColumn("dbo.Members", "MemberName", c => c.String());
            AddColumn("dbo.Trainers", "TrainerName", c => c.String());
            AlterColumn("dbo.Admins", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Courses", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Courses", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "TrainerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Lessons", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Lessons", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Trainers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CoursesLessons", "RefCourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.CoursesLessons", "RefLessonId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Admins", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Courses", "Id");
            AddPrimaryKey("dbo.Lessons", "Id");
            AddPrimaryKey("dbo.Members", "Id");
            AddPrimaryKey("dbo.Trainers", "Id");
            AddPrimaryKey("dbo.CoursesLessons", new[] { "RefCourseId", "RefLessonId" });
            CreateIndex("dbo.Courses", "CategoryId");
            CreateIndex("dbo.Courses", "TrainerId");
            CreateIndex("dbo.Lessons", "CourseId");
            CreateIndex("dbo.CoursesLessons", "RefCourseId");
            CreateIndex("dbo.CoursesLessons", "RefLessonId");
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessons", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CoursesLessons", "RefCourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CoursesLessons", "RefLessonId", "dbo.Members", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers", "Id", cascadeDelete: true);
            DropColumn("dbo.Categories", "Name");
            DropColumn("dbo.Courses", "Name");
            DropColumn("dbo.Members", "Name");
            DropColumn("dbo.Trainers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "Name", c => c.String());
            AddColumn("dbo.Members", "Name", c => c.String());
            AddColumn("dbo.Courses", "Name", c => c.String());
            AddColumn("dbo.Categories", "Name", c => c.String());
            DropForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.CoursesLessons", "RefLessonId", "dbo.Members");
            DropForeignKey("dbo.CoursesLessons", "RefCourseId", "dbo.Courses");
            DropForeignKey("dbo.Lessons", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.CoursesLessons", new[] { "RefLessonId" });
            DropIndex("dbo.CoursesLessons", new[] { "RefCourseId" });
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "TrainerId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropPrimaryKey("dbo.CoursesLessons");
            DropPrimaryKey("dbo.Trainers");
            DropPrimaryKey("dbo.Members");
            DropPrimaryKey("dbo.Lessons");
            DropPrimaryKey("dbo.Courses");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Admins");
            AlterColumn("dbo.CoursesLessons", "RefLessonId", c => c.Guid(nullable: false));
            AlterColumn("dbo.CoursesLessons", "RefCourseId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Trainers", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Members", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Lessons", "CourseId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Lessons", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Courses", "TrainerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Courses", "CategoryId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Courses", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Categories", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Admins", "Id", c => c.Guid(nullable: false));
            DropColumn("dbo.Trainers", "TrainerName");
            DropColumn("dbo.Members", "MemberName");
            DropColumn("dbo.Courses", "CourseName");
            DropColumn("dbo.Categories", "CategoryName");
            DropTable("dbo.Logins");
            AddPrimaryKey("dbo.CoursesLessons", new[] { "RefCourseId", "RefLessonId" });
            AddPrimaryKey("dbo.Trainers", "Id");
            AddPrimaryKey("dbo.Members", "Id");
            AddPrimaryKey("dbo.Lessons", "Id");
            AddPrimaryKey("dbo.Courses", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Admins", "Id");
            CreateIndex("dbo.CoursesLessons", "RefLessonId");
            CreateIndex("dbo.CoursesLessons", "RefCourseId");
            CreateIndex("dbo.Lessons", "CourseId");
            CreateIndex("dbo.Courses", "TrainerId");
            CreateIndex("dbo.Courses", "CategoryId");
            AddForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CoursesLessons", "RefLessonId", "dbo.Members", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CoursesLessons", "RefCourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessons", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
