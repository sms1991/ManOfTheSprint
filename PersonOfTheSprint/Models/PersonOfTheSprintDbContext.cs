using System.Data.Entity;

namespace PersonOfTheSprint.Models
{
    public class PersonOfTheSprintDbContext : DbContext
    {
        public PersonOfTheSprintDbContext() : base("PersonOfTheSprint")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<PersonOfTheSprintDbContext,Migrations.Configuration>()); 
        }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}