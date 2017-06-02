using System.ComponentModel.DataAnnotations;

namespace PersonOfTheSprint.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public virtual TeamMember VotingTeamMember { get; set; }
        [Required(ErrorMessage = "Please select a team member")]
        public virtual TeamMember NominatedTeamMember { get; set; }
        public virtual Sprint SprintNumber { get; set; }
        public string Reason { get; set; }      
    }
}
