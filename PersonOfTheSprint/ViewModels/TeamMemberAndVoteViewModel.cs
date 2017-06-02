using System.Collections.Generic;
using System.Web.Mvc;
using PersonOfTheSprint.Models;

namespace PersonOfTheSprint.ViewModels
{
    public class TeamMemberAndVoteViewModel
    {
        public Vote Vote { get; set; }
        public Sprint Sprint { get; set; }
        public List<SelectListItem> TeamMembersSelectList { get; set; }
    }
}