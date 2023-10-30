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
            _repository = repository;
        }

        public void SaveProblem(Problem Problem)
        {
            _repository.Save(Problem); 
        }

        public void SaveProblems(IEnumerable<Problem> Problems)
        {
            _repository.SaveRange(Problems);
        }
        public async Task SaveProblemAsync(Problem problemDTO)
        {
            await _repository.SaveAsync(problemDTO);
        }

        public async Task SaveProblemsAsync(IEnumerable<Problem> problemDTOs)
        {
            await _repository.SaveRangeAsync(problemDTOs);
        }

        public bool DeleteProblem(Problem problem)
        {
            try
            {
                _repository.DeleteProblem(problem.Id);
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
                _repository.DeleteProblem(id);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteProblemAsync(int id)
        {
            try
            {
                await _repository.DeleteProblemAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool DeleteProblems(int[] ids)
        {
            try
            {
                _repository.DeleteProblems(ids);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteProblemsAsync(int[] ids)
        {
            try
            {
                await _repository.DeleteProblemsAsync(ids);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
