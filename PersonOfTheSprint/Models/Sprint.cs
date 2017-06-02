using System;

namespace PersonOfTheSprint.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        public int SprintNumber { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public virtual TeamMember WinnerTeamMember { get; set; }
    }
}
