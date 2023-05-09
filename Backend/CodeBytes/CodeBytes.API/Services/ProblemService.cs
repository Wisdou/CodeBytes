using CodeBytes.DAL.Problems;
using CodeBytes.DTO.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBytes.API.Services
{
    public class ProblemService
    {
        private IProblemRepository _repository;
        public ProblemService(IProblemRepository repository)
        {
            this._repository = repository;
        }

        public void SaveProblem(ProblemDTO problemDTO)
        {
            this._repository.Save(problemDTO);
        }

        public void SaveProblems(IEnumerable<ProblemDTO> problemDTOs)
        {
            this._repository.SaveRange(problemDTOs);
        }

        public ProblemDTO GetProblem(int id)
        {
            return this._repository.Get(id);
        }

        public List<ProblemDTO> GetProblems()
        {
            return this._repository.GetAll();
        }
    }
}
