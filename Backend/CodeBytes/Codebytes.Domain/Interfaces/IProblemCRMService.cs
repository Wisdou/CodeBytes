using CodeBytes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.Domain.Interfaces
{
    public interface IProblemCRMService
    {
        public void SaveProblem(Problem problemDTO);
        public void SaveProblems(IEnumerable<Problem> problemDTOs);
        public Task SaveProblemAsync(Problem problemDTO);
        public Task SaveProblemsAsync(IEnumerable<Problem> problemDTOs);
        bool DeleteProblem(int id);
        Task<bool> DeleteProblemAsync(int id);
        bool DeleteProblems(int[] ids);
        Task<bool> DeleteProblemsAsync(int[] ids);
    }
}
