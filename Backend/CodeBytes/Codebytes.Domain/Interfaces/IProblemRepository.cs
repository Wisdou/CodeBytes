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
        void Save(Problem entity);

        void SaveRange(IEnumerable<Problem> entities);

        List<Problem> GetAll();
        Problem Get(int id);
    }
}
