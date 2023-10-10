using CodeBytes.DAL.Data;
using CodeBytes.Domain.Interfaces;
using CodeBytes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.DAL.Problems
{
    public class ProblemCRMRepository : IProblemCRMRepository
    {
        private CodeByteContext _context;

        public ProblemCRMRepository(CodeByteContext context)
        {
            this._context = context;
        }

        public void Save(Problem model)
        {
            if (model == null)
            {
                return;
            }

            this._context.Problems.Add(ProblemMapping.GetEntityFromModel(model));
            this._context.SaveChanges();
        }

        public async Task SaveAsync(Problem model)
        {
            if (model == null)
            {
                return;
            }

            await this._context.Problems.AddAsync(ProblemMapping.GetEntityFromModel(model));
            await this._context.SaveChangesAsync();
        }

        public void SaveRange(IEnumerable<Problem> models)
        {
            if (models == null)
            {
                return;
            }

            IEnumerable<ProblemEntity> entitiesForSave = models.Select(problem => ProblemMapping.GetEntityFromModel(problem));
            this._context.Problems.AddRange(entitiesForSave);
            this._context.SaveChanges();
        }

        public async Task SaveRangeAsync(IEnumerable<Problem> models)
        {
            if (models == null)
            {
                return;
            }

            IEnumerable<ProblemEntity> entitiesForSave = models.Select(problem => ProblemMapping.GetEntityFromModel(problem));
            await this._context.Problems.AddRangeAsync(entitiesForSave);
            await this._context.SaveChangesAsync();
        }
    }
}
