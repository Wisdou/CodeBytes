using CodeBytes.DAL.Data;
using CodeBytes.Domain.Interfaces;
using CodeBytes.Domain.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;
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
            ProblemEntity problem = this._context.Problems.AsNoTracking().First(x => x.ID == id);

            return ProblemMapping.GetModelFromEntity(problem);
        }

        public IReadOnlyCollection<Problem> GetAll()
        {
            List<ProblemEntity> problems = this._context.Problems.AsNoTracking().ToList();

            return problems.Select(problem => ProblemMapping.GetModelFromEntity(problem)).ToList().AsReadOnly();
        }

        public async Task<IReadOnlyCollection<Problem>> GetAllAsync()
        {
            List<ProblemEntity> problems = await this._context.Problems.AsNoTracking().ToListAsync();

            return problems.Select(problem => ProblemMapping.GetModelFromEntity(problem)).ToList().AsReadOnly();
        }

        public async Task<Problem> GetAsync(int id)
        {
            ProblemEntity problem = await this._context.Problems.FindAsync(new int[] { id });
            return ProblemMapping.GetModelFromEntity(problem);
        }

        public void Save(Problem model)
        {
            this._context.Problems.Add(ProblemMapping.GetEntityFromModel(model));
            this._context.SaveChanges();
        }

        public async Task SaveAsync(Problem entity)
        {
            await this._context.Problems.AddAsync(ProblemMapping.GetEntityFromModel(entity));
            await this._context.SaveChangesAsync();
        }

        public void SaveRange(IEnumerable<Problem> models)
        {
            IEnumerable<ProblemEntity> entitiesForSave = models.Select(problem => ProblemMapping.GetEntityFromModel(problem));
            this._context.Problems.AddRange(entitiesForSave);
            this._context.SaveChanges();
        }

        public async Task SaveRangeAsync(IEnumerable<Problem> models)
        {
            IEnumerable<ProblemEntity> entitiesForSave = models.Select(problem => ProblemMapping.GetEntityFromModel(problem));
            await this._context.Problems.AddRangeAsync(entitiesForSave);
            await this._context.SaveChangesAsync();
        }
    }
}
