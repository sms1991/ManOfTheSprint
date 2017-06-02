using System;
using System.Linq;
using System.Web.Mvc;
using PersonOfTheSprint.Models;
using PersonOfTheSprint.ViewModels;

namespace PersonOfTheSprint.Controllers
{
    public class HomeController : Controller
    {
        private Sprint _currentSprint;
        private readonly PersonOfTheSprintDbContext _context = new PersonOfTheSprintDbContext();

        // GET: Vote
        public ActionResult Index()
        {
            GetCurrentSprint();

            var viewModel = new TeamMemberAndVoteViewModel
            {
                Vote = new Vote(),
                Sprint = _currentSprint,
                TeamMembersSelectList =
                    _context.TeamMembers.Select(
                            x => new SelectListItem {Value = x.Id.ToString(), Text = x.FirstName + " " + x.LastName})
                        .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CastVote(TeamMemberAndVoteViewModel teamMemberAndVoteViewModel)
        {
            var member = _context.TeamMembers.Find(teamMemberAndVoteViewModel.Vote.NominatedTeamMember.Id);
            teamMemberAndVoteViewModel.Vote.NominatedTeamMember = member;

            GetCurrentSprint();
            teamMemberAndVoteViewModel.Vote.SprintNumber = _currentSprint;

            //CountVotes(teamMemberAndVoteViewModel);

            _context.Votes.Add(teamMemberAndVoteViewModel.Vote);
            _context.SaveChanges();

           // ViewBag.numberOfTimesVotedFor = CountVotes(teamMemberAndVoteViewModel);

            return View(teamMemberAndVoteViewModel);
        }

        private void GetCurrentSprint()
        {
            var currentDate = DateTime.Now;
            _currentSprint = _context.Sprints.FirstOrDefault(x => x.StartDateTime <= currentDate && x.EndDateTime > currentDate);
        }

        //private int CountVotes(TeamMemberAndVoteViewModel teamMemberAndVoteViewModel)
        //{
        //    GetCurrentSprint();

        //    var countOfVotes = _context.Votes
        //        .Where(x => x.SprintNumber.SprintNumber == teamMemberAndVoteViewModel.Vote.SprintNumber.SprintNumber)
        //        .Count(x => x.NominatedTeamMember.Id == teamMemberAndVoteViewModel.Vote.NominatedTeamMember.Id);
        //    return countOfVotes;
        //}
    }
}