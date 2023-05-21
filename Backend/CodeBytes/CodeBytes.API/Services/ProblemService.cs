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
            this._repository = repository;
        }

        public void SaveProblem(Problem Problem)
        {
            this._repository.Save(Problem);
        }

        public void SaveProblems(IEnumerable<Problem> Problems)
        {
            this._repository.SaveRange(Problems);
        }

        public Problem GetProblem(int id)
        {
            return this._repository.Get(id);
        }

        public IReadOnlyCollection<Problem> GetProblems()
        {
            return this._repository.GetAll();
        }

        public async Task SaveProblemAsync(Problem problemDTO)
        {
            await this._repository.SaveAsync(problemDTO);
        }

        public async Task SaveProblemsAsync(IEnumerable<Problem> problemDTOs)
        {
            await this._repository.SaveRangeAsync(problemDTOs);
        }

        public async Task<Problem> GetProblemAsync(int id)
        {
            Problem problem = await this._repository.GetAsync(id);
            return problem;
        }

        public async Task<IReadOnlyCollection<Problem>> GetProblemsAsync()
        {
            IReadOnlyCollection<Problem> problems = await this._repository.GetAllAsync();
            return problems;
        }
    }
}
