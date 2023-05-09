using CodeBytes.DTO.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.DAL.Problems
{
    public interface IProblemRepository
    {
        void Save(ProblemDTO entity);

        void SaveRange(IEnumerable<ProblemDTO> entities);

        List<ProblemDTO> GetAll();
        ProblemDTO Get(int id);
    }
}
