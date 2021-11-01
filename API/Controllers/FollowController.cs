using Application.Followers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class FollowController : BaseController
    {
        [HttpPost("{username}")]
        public async Task<IActionResult> Follow(string username)
        {
            return HandleResult(await Mediator.Send(new FollowToggle.Command { TargetUsername = username }));
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetFollowings(string username, string predicate)
        {
            return HandleResult(await Mediator.Send(new List.Query { Predicate = predicate, Username = username}));
        }
    }
}
