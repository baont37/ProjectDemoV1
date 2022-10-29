
namespace ProjectDemoV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        PassWord = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        FullName = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        Phone = c.String(),
                        SchoolName = c.String(),
                        Email = c.String(),
                        Avatar = c.Binary(),
                        GenderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .Index(t => t.AccountId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        GenderName = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionContent = c.String(),
                        OptionA = c.String(),
                        OptionB = c.String(),
                        OptionC = c.String(),
                        OptionD = c.String(),
                        Image = c.Binary(),
                        Solution = c.String(),
                        AccountId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        TestTypeId = c.Int(nullable: false),
                        Answer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Answers", t => t.Answer_Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .ForeignKey("dbo.Levels", t => t.LevelId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.TestTypes", t => t.TestTypeId)
                .Index(t => t.AccountId)
                .Index(t => t.SubjectId)
                .Index(t => t.StatusId)
                .Index(t => t.LevelId)
                .Index(t => t.TestTypeId)
                .Index(t => t.Answer_Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        AnswerName = c.String(),
                    })
                .PrimaryKey(t => t.AnswerId);
            
            CreateTable(
                "dbo.QuestionTests",
                c => new
                    {
                        QuetionTestId = c.Int(nullable: false, identity: true),
                        TestDetailId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuetionTestId)
                .ForeignKey("dbo.Answers", t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .ForeignKey("dbo.TestDetails", t => t.TestDetailId)
                .Index(t => t.TestDetailId)
                .Index(t => t.QuestionId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.TestDetails",
                c => new
                    {
                        TestDetailId = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        Score = c.Double(nullable: false),
                        Submitted = c.Boolean(nullable: false),
                        AccountId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestDetailId)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.AccountId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        Duration = c.Int(nullable: false),
                        TotalQuestion = c.Int(nullable: false),
                        ImgLink = c.String(),
                        CombinationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Combinations", t => t.CombinationId)
                .Index(t => t.CombinationId);
            
            CreateTable(
                "dbo.Combinations",
                c => new
                    {
                        CombinationId = c.Int(nullable: false, identity: true),
                        CombinationName = c.String(),
                    })
                .PrimaryKey(t => t.CombinationId);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        LevelName = c.String(),
                    })
                .PrimaryKey(t => t.LevelId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.TestTypes",
                c => new
                    {
                        TestTypeId = c.Int(nullable: false, identity: true),
                        TestTypeName = c.String(),
                    })
                .PrimaryKey(t => t.TestTypeId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Questions", "TestTypeId", "dbo.TestTypes");
            DropForeignKey("dbo.Questions", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Questions", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.TestDetails", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Questions", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "CombinationId", "dbo.Combinations");
            DropForeignKey("dbo.QuestionTests", "TestDetailId", "dbo.TestDetails");
            DropForeignKey("dbo.TestDetails", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.QuestionTests", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionTests", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Questions", "Answer_Id", "dbo.Answers");
            DropForeignKey("dbo.Questions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Profiles", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Profiles", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Subjects", new[] { "CombinationId" });
            DropIndex("dbo.TestDetails", new[] { "SubjectId" });
            DropIndex("dbo.TestDetails", new[] { "AccountId" });
            DropIndex("dbo.QuestionTests", new[] { "AnswerId" });
            DropIndex("dbo.QuestionTests", new[] { "QuestionId" });
            DropIndex("dbo.QuestionTests", new[] { "TestDetailId" });
            DropIndex("dbo.Questions", new[] { "Answer_Id" });
            DropIndex("dbo.Questions", new[] { "TestTypeId" });
            DropIndex("dbo.Questions", new[] { "LevelId" });
            DropIndex("dbo.Questions", new[] { "StatusId" });
            DropIndex("dbo.Questions", new[] { "SubjectId" });
            DropIndex("dbo.Questions", new[] { "AccountId" });
            DropIndex("dbo.Profiles", new[] { "GenderId" });
            DropIndex("dbo.Profiles", new[] { "AccountId" });
            DropIndex("dbo.Accounts", new[] { "RoleId" });
            DropTable("dbo.Roles");
            DropTable("dbo.TestTypes");
            DropTable("dbo.Status");
            DropTable("dbo.Levels");
            DropTable("dbo.Combinations");
            DropTable("dbo.Subjects");
            DropTable("dbo.TestDetails");
            DropTable("dbo.QuestionTests");
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.Genders");
            DropTable("dbo.Profiles");
            DropTable("dbo.Accounts");
        }
    }
}
