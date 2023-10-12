using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeBytes.Domain.Interfaces;
using CodeBytes.Domain.Model;

namespace CodeBytes.API.Services
{
    public class ProblemCRMService : IProblemCRMService
    {
        private IProblemCRMRepository _repository;
        public ProblemCRMService(IProblemCRMRepository repository)
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
        public async Task SaveProblemAsync(Problem problemDTO)
        {
            await this._repository.SaveAsync(problemDTO);
        }

        public async Task SaveProblemsAsync(IEnumerable<Problem> problemDTOs)
        {
            await this._repository.SaveRangeAsync(problemDTOs);
        }

        public bool DeleteProblem(Problem problem)
        {
            try
            {
                this._repository.DeleteProblem(problem.Id);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool DeleteProblem(int id)
        {
            try
            {
                this._repository.DeleteProblem(id);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
