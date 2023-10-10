using CodeBytes.API.Services;
using CodeBytes.Domain.Interfaces;
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
    }
}
