using CodeBytes.DAL.Data;
using CodeBytes.Domain.Interfaces;
using CodeBytes.Domain.Model;
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
        private CodeByteContext _context;

        public ProblemRepository(CodeByteContext context)
        {
            this._context = context;
        }

        public Problem Get(int id)
        {
            ProblemEntity problem;

            problem = this._context.Problems.First(x => x.ID == id);

            return problem.Adapt<Problem>(ProblemMapping.EntityToDtoConfiguration);
        }

        public List<Problem> GetAll()
        {
            List<ProblemEntity> problems = new List<ProblemEntity>();

            problems = this._context.Problems.ToList();

            return problems.AsQueryable().ProjectToType<Problem>(ProblemMapping.EntityToDtoConfiguration).ToList();
        }

        public void Save(Problem entity)
        {
            this._context.Problems.Add(entity.Adapt<ProblemEntity>(ProblemMapping.DtoToEntityConfiguration));
            this._context.SaveChanges();
        }

        public void SaveRange(IEnumerable<Problem> entities)
        {
            this._context.Problems.AddRange(entities.AsQueryable().ProjectToType<ProblemEntity>(ProblemMapping.DtoToEntityConfiguration));
            this._context.SaveChanges();
        }
    }
}
