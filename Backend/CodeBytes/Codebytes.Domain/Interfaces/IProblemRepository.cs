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
        void Save(Problem entity);
        Task SaveAsync(Problem entity);
        void SaveRange(IEnumerable<Problem> entities);
        Task SaveRangeAsync(IEnumerable<Problem> entities);
        IReadOnlyCollection<Problem> GetAll();
        Task<IReadOnlyCollection<Problem>> GetAllAsync();
        IReadOnlyCollection<Problem> Get(ProblemFilterParams filter);
        Task<IReadOnlyCollection<Problem>> GetAsync(ProblemFilterParams filter);
        int GetTotalCount();
        Task<int> GetTotalCountAsync();
    }
}
