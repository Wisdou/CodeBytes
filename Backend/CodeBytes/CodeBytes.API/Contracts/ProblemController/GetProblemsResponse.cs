using CodeBytes.Domain.Model;
using System.Collections.Generic;

namespace CodeBytes.API.Contracts
{
    public class GetProblemsResponse
    {
        public int Total { get; set; }
        public IReadOnlyCollection<Problem> Problems { get; set; }
    }
}
