using CodeBytes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.Domain.Interfaces
{
    public interface IProblemService
    {
        public void SaveProblem(Problem problemDTO);

        public void SaveProblems(IEnumerable<Problem> problemDTOs);

        public Problem GetProblem(int id);

        public List<Problem> GetProblems();
    }
}
