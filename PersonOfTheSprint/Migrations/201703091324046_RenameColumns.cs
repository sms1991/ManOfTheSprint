namespace PersonOfTheSprint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColumns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sprints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SprintNumber = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        WinnerTeamMember_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeamMembers", t => t.WinnerTeamMember_Id)
                .Index(t => t.WinnerTeamMember_Id);
            
            CreateTable(
                "dbo.TeamMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        NumberOfTimesWon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        NominatedTeamMember_Id = c.Int(),
                        SprintNumber_Id = c.Int(),
                        VotingTeamMember_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeamMembers", t => t.NominatedTeamMember_Id)
                .ForeignKey("dbo.Sprints", t => t.SprintNumber_Id)
                .ForeignKey("dbo.TeamMembers", t => t.VotingTeamMember_Id)
                .Index(t => t.NominatedTeamMember_Id)
                .Index(t => t.SprintNumber_Id)
                .Index(t => t.VotingTeamMember_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "VotingTeamMember_Id", "dbo.TeamMembers");
            DropForeignKey("dbo.Votes", "SprintNumber_Id", "dbo.Sprints");
            DropForeignKey("dbo.Votes", "NominatedTeamMember_Id", "dbo.TeamMembers");
            DropForeignKey("dbo.Sprints", "WinnerTeamMember_Id", "dbo.TeamMembers");
            DropIndex("dbo.Votes", new[] { "VotingTeamMember_Id" });
            DropIndex("dbo.Votes", new[] { "SprintNumber_Id" });
            DropIndex("dbo.Votes", new[] { "NominatedTeamMember_Id" });
            DropIndex("dbo.Sprints", new[] { "WinnerTeamMember_Id" });
            DropTable("dbo.Votes");
            DropTable("dbo.TeamMembers");
            DropTable("dbo.Sprints");
        }
    }
}
