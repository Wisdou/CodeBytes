using CodeBytes.DAL.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeBytes.Domain.Interfaces;
using CodeBytes.Domain.Model;

namespace CodeBytes.API.Services
{
    public class ProblemService: IProblemService
    {
        private IProblemRepository _repository;
        public ProblemService(IProblemRepository repository)
        {
            _repository = repository;
        }

        public Problem GetProblem(int id)
        {
            return _repository.Get(id);
        }

        public IReadOnlyCollection<Problem> GetProblems()
        {
            return _repository.GetAll();
        }

        public async Task<Problem> GetProblemAsync(int id)
        {
            Problem problem = await _repository.GetAsync(id);
            return problem;
        }

        public async Task<IReadOnlyCollection<Problem>> GetProblemsAsync()
        {
            IReadOnlyCollection<Problem> problems = await _repository.GetAllAsync();
            return problems;
        }

        public IReadOnlyCollection<Problem> GetProblems(ProblemFilterParams problemFilter)
        {
            return _repository.Get(problemFilter);
        }

        public async Task<IReadOnlyCollection<Problem>> GetProblemsAsync(ProblemFilterParams problemFilter)
        {
            IReadOnlyCollection<Problem> problems = await _repository.GetAsync(problemFilter);
            return problems;
        }

        public int GetTotalCount()
        {
            return _repository.GetTotalCount();
        }

        public async Task<int> GetTotalCountAsync()
        {
            int totalCount = await _repository.GetTotalCountAsync();
            return totalCount;
        }

        public int GetTotalCount(ProblemFilterParams filter)
        {
            return _repository.GetTotalCount(filter);
        }

        public async Task<int> GetTotalCountAsync(ProblemFilterParams filter)
        {
            int totalCount = await _repository.GetTotalCountAsync(filter);
            return totalCount;
        }
    }
}
