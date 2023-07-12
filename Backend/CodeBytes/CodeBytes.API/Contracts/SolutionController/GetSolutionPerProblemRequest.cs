using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBytes.API.Contracts.SolutionController
{
    public class GetSolutionPerProblemRequest
    {
        public enum ProgrammingLanguage
        {
            CSharp,
            Python,
            Go,
            FSharp,
            CPP
        }

        public int ProblemId { get; set; }

        public string Code { get; set; }

        public string Language { get; set; }
    }
}
