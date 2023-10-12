using AngleSharp.Io;
using CodeBytes.API.Contracts;
using CodeBytes.API.Contracts.ProblemController;
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
    [Route("api/crm")]
    public class ProblemCRMController : Controller
    {
        private readonly ILogger<ProblemCRMController> _logger;
        private readonly IProblemCRMService _service;

        public ProblemCRMController(ILogger<ProblemCRMController> logger, IProblemCRMService problemCRMService)
        {
            this._logger = logger;
            this._service = problemCRMService;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProblemById([FromBody] DeleteProblemByIdRequest deleteProblemRequest)
        {
            if (deleteProblemRequest == null)
            {
                return BadRequest();
            }

            var isDeleted = this._service.DeleteProblem(deleteProblemRequest.Id);

            if (!isDeleted)
            {
                return BadRequest(new NoProblemErrorResponse(deleteProblemRequest.Id));
            }
            else
            {
                return Ok(new DeleteProblemByIdResponse(deleteProblemRequest.Id));
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveProblem([FromBody] SaveProblemRequest saveProblemRequest)
        {
            if (saveProblemRequest == null)
            {
                return BadRequest();
            }

            this._service.SaveProblem(saveProblemRequest.ProblemToSave);

            return Ok(new SaveProblemResponse());
        }
    }
}
