using Application.Activities.Delete;
using Application.Activities.Get;
using Application.Activities.Save;
using Application.Activities.Update;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class EventsController : BaseController
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new GetAll()));
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetById.Query { Id = id }));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Activity activity)
        {
            return HandleResult(await Mediator.Send(new CreateActivity.Command { Activity = activity }));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Activity activity)
        {
            return HandleResult(await Mediator.Send(new UpdateActivity.Command { Activity = activity }));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }));
        }

    }
}
