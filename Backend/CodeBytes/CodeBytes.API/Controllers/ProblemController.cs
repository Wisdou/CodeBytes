using CodeBytes.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBytes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProblemController : ControllerBase
    {
        private readonly ILogger<ProblemController> _logger;
        private readonly ProblemService _service;

        public ProblemController(ILogger<ProblemController> logger, ProblemService problemService)
        {
            this._logger = logger;
            this._service = problemService;
        }

        [HttpGet]
        [Route("GetProblemById/{id}")]
        public IActionResult GetProblemById(int id)
        {
            var problem = this._service.GetProblem(id);
            var content = JsonConvert.SerializeObject(problem);
            return Ok(content);
        }

        [HttpGet]
        [Route("GetProblems")]
        public IActionResult GetProblems()
        {
            var problems = this._service.GetProblems();
            var content = JsonConvert.SerializeObject(problems);
            return Ok(content);
        }
    }
}
