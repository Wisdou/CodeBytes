using CodeBytes.API.Services;
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
        private readonly ProblemService _service;

        public ProblemsController(ILogger<ProblemsController> logger, ProblemService problemService)
        {
            this._logger = logger;
            this._service = problemService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProblemById(int id)
        {
            var problem = this._service.GetProblem(id);
            return Ok(problem);
        }

        [HttpGet]
        [Route("problems")]
        public async Task<IActionResult> GetProblems()
        {
            var problems = this._service.GetProblems();
            return Ok(problems);
        }
    }
}
