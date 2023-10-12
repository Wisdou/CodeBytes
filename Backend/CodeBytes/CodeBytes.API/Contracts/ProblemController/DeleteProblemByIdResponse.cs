namespace CodeBytes.API.Contracts.ProblemController
{
    public class DeleteProblemByIdResponse
    {
        public int DeletedProblemId { get; set; }

        public DeleteProblemByIdResponse(int deletedProblemId)
        {
            DeletedProblemId = deletedProblemId;
        }
    }
}
