using CodeBytes.Domain.Model;
using System.Collections.Generic;

namespace CodeBytes.API.Contracts
{
    public class GetProblemsResponse
    {
        public List<Problem> Problems { get; set; }
    }
}
