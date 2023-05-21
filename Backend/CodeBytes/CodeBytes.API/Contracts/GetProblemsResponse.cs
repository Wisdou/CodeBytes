using CodeBytes.Domain.Model;
using System.Collections.Generic;

namespace CodeBytes.API.Contracts
{
    public class GetProblemsResponse
    {
        public IReadOnlyCollection<Problem> Problems { get; set; }
    }
}
