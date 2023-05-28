namespace CodeBytes.API.Contracts.ProblemController
{
    public class NoProblemErrorResponse
    {
        private const string _code = "CODEBYTES_PROBLEM_NOT_FOUND";
        public NoProblemErrorResponse(int problemId)
        {
            this.ProblemId = problemId;
            this.Message = $"No problem with id: {problemId}";
        }

        public string Message { get; private set; }
        public string Code { get =>  _code; }
        public int ProblemId { get; private set; }
    }
}
