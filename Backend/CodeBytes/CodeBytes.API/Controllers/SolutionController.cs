using CodeBytes.API.Contracts.SolutionController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBytes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        private readonly IHubContext<SolutionHub> _hub;

        public SolutionController(IHubContext<SolutionHub> hub)
        {
            this._hub = hub;
        }

        [HttpPost]
        public async Task<IActionResult> Get(GetSolutionPerProblemRequest request)
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                await this._hub.Clients.All.SendAsync("GetSolution", "Solution");
            }

            return Ok(new { Message = "Request Completed" });
        }
    }
}
