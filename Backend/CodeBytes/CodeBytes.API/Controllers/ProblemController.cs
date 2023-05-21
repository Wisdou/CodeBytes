using CodeBytes.API.Contracts;
using CodeBytes.API.Services;
using CodeBytes.Domain.Interfaces;
using CodeBytes.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBytes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProblemsController : ControllerBase
    {
        private readonly ILogger<ProblemsController> _logger;
        private readonly IProblemService _service;

        public ProblemsController(ILogger<ProblemsController> logger, IProblemService problemService)
        {
            this._logger = logger;
            this._service = problemService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProblemById(int id)
        {
            var problem = await this._service.GetProblemAsync(id);
            var response = new GetProblemByIdResponse()
            {
                Problem = problem,
            };
            return Ok(response);
        }

        [HttpGet("problems")]
        public async Task<IActionResult> GetProblems()
        {
            var problems = await this._service.GetProblemsAsync();
            var response = new GetProblemsResponse()
            {
                Problems = problems,
            };
            return Ok(problems);
        }
    }
}
