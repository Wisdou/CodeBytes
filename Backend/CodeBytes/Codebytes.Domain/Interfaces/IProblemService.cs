using CodeBytes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.Domain.Interfaces
{
    public interface IProblemService
    {
        public void SaveProblem(Problem problemDTO);

        public void SaveProblems(IEnumerable<Problem> problemDTOs);

        public Problem GetProblem(int id);

        public IReadOnlyCollection<Problem> GetProblems();

        public IReadOnlyCollection<Problem> GetProblems(ProblemFilterParams problemFilter);

        public Task SaveProblemAsync(Problem problemDTO);

        public Task SaveProblemsAsync(IEnumerable<Problem> problemDTOs);

        public Task<Problem> GetProblemAsync(int id);

        public Task<IReadOnlyCollection<Problem>> GetProblemsAsync();

        public Task<IReadOnlyCollection<Problem>> GetProblemsAsync(ProblemFilterParams problemFilter);
        int GetTotalCount();
        Task<int> GetTotalCountAsync();
    }
}
