using CodeBytes.Domain.Model;

namespace CodeBytes.API.Contracts.ProblemController
{
    public class SaveProblemRequest
    {
        public Problem ProblemToSave { get; set; }
    }
}
