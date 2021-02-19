using Application.Activities.Delete;
using Application.Activities.Get;
using Application.Activities.Save;
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

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] Activity activity)
        {
            return HandleResult(await Mediator.Send(new SaveActivity.Command { Activity = activity }));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }));
        }

    }
}
