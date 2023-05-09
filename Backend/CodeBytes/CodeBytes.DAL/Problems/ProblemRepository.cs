using CodeBytes.DAL.Data;
using CodeBytes.DTO.Problems;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.DAL.Problems
{
    public class ProblemRepository : IProblemRepository
    {
        public ProblemDTO Get(int id)
        {
            ProblemEntity problem;

            using (var context = new DataContext())
            {
                problem = context.Problems.First(x => x.ID == id);
            }

            return problem.Adapt<ProblemDTO>(ProblemMapping.EntityToDtoConfiguration);
        }

        public List<ProblemDTO> GetAll()
        {
            List<ProblemEntity> problems = new List<ProblemEntity>();

            using (var context = new DataContext())
            {
                problems = context.Problems.ToList();
            }

            return problems.AsQueryable().ProjectToType<ProblemDTO>(ProblemMapping.EntityToDtoConfiguration).ToList();
        }

        public void Save(ProblemDTO entity)
        {
            using (var context = new DataContext())
            {
                context.Problems.Add(entity.Adapt<ProblemEntity>(ProblemMapping.DtoToEntityConfiguration));
                context.SaveChanges();
            }
        }

        public void SaveRange(IEnumerable<ProblemDTO> entities)
        {
            using (var context = new DataContext())
            {
                context.Problems.AddRange(entities.AsQueryable().ProjectToType<ProblemEntity>(ProblemMapping.DtoToEntityConfiguration));
                context.SaveChanges();
            }
        }
    }
}
