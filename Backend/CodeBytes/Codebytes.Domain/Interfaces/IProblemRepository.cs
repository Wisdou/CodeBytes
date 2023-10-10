using CodeBytes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.Domain.Interfaces
{
    public interface IProblemRepository
    {
        Problem Get(int id);
        Task<Problem> GetAsync(int id);
        IReadOnlyCollection<Problem> GetAll();
        Task<IReadOnlyCollection<Problem>> GetAllAsync();
        IReadOnlyCollection<Problem> Get(ProblemFilterParams filter);
        Task<IReadOnlyCollection<Problem>> GetAsync(ProblemFilterParams filter);
        int GetTotalCount();
        Task<int> GetTotalCountAsync();
        int GetTotalCount(ProblemFilterParams filter);
        Task<int> GetTotalCountAsync(ProblemFilterParams filter);
    }
}
