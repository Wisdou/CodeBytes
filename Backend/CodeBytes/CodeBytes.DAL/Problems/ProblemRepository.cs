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

            return ProblemMapping.GetModelFromEntity(problem);
        }

        public List<Problem> GetAll()
        {
            List<ProblemEntity> problems = new List<ProblemEntity>();

            problems = this._context.Problems.ToList();

            return problems.Select(problem => ProblemMapping.GetModelFromEntity(problem)).ToList();
        }

        public void Save(Problem model)
        {
            this._context.Problems.Add(ProblemMapping.GetEntityFromModel(model));
            this._context.SaveChanges();
        }

        public void SaveRange(IEnumerable<Problem> models)
        {
            this._context.Problems.AddRange(models.Select(problem => ProblemMapping.GetEntityFromModel(problem)));
            this._context.SaveChanges();
        }
    }
}
