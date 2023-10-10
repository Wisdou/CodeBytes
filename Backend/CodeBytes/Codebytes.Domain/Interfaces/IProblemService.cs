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
        public Problem GetProblem(int id);
        public IReadOnlyCollection<Problem> GetProblems();
        public IReadOnlyCollection<Problem> GetProblems(ProblemFilterParams problemFilter);
        public Task<Problem> GetProblemAsync(int id);
        public Task<IReadOnlyCollection<Problem>> GetProblemsAsync();
        public Task<IReadOnlyCollection<Problem>> GetProblemsAsync(ProblemFilterParams problemFilter);
        int GetTotalCount();
        Task<int> GetTotalCountAsync();
        int GetTotalCount(ProblemFilterParams filter);
        Task<int> GetTotalCountAsync(ProblemFilterParams filter);
    }
}
