using CodeBytes.Domain.Model;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.DAL.Problems
{
    static class ProblemMapping
    {
        public static Problem GetModelFromEntity(ProblemEntity problem)
        {
            return new Problem()
            {
                Title = problem.Title,
                Description = problem.Description,
            };
        }

        public static ProblemEntity GetEntityFromModel(Problem problem)
        {
            return new ProblemEntity()
            {
                Title = problem.Title,
                Description = problem.Description,
            };
        }
    }
}
