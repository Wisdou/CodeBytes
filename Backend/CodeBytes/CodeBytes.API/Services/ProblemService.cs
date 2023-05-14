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

        public List<Problem> GetProblems()
        {
            return this._repository.GetAll();
        }
    }
}
