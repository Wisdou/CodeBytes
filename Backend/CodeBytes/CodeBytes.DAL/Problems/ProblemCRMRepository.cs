using CodeBytes.DAL.Data;
using CodeBytes.Domain.Interfaces;
using CodeBytes.Domain.Model;
using Microsoft.EntityFrameworkCore;
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
            _context = context;
        }

        public void DeleteProblem(int id)
        {
            ProblemEntity problem = _context.Problems.First(x => x.ID == id);
            _context.Problems.Remove(problem);
            _context.SaveChanges();
        }

        public async Task DeleteProblemAsync(int id)
        {
            ProblemEntity problem = await _context.Problems.FirstAsync(x => x.ID == id);
            _context.Problems.Remove(problem);
            await _context.SaveChangesAsync();
        }

        public void DeleteProblems(int[] ids)
        {
            IEnumerable<ProblemEntity> problemsToDelete = _context.Problems.Where(x => ids.Contains(x.ID));
            _context.Problems.RemoveRange(problemsToDelete);
            _context.SaveChanges();
        }

        public async Task DeleteProblemsAsync(int[] ids)
        {
            IEnumerable<ProblemEntity> problemsToDelete = _context.Problems.Where(x => ids.Contains(x.ID));
            _context.Problems.RemoveRange(problemsToDelete);
            await _context.SaveChangesAsync();
        }

        public void Save(Problem model)
        {
            if (model == null)
            {
                return;
            }

            _context.Problems.Add(ProblemMapping.GetEntityFromModel(model));
            _context.SaveChanges();
        }

        public async Task SaveAsync(Problem model)
        {
            if (model == null)
            {
                return;
            }

            await _context.Problems.AddAsync(ProblemMapping.GetEntityFromModel(model));
            await _context.SaveChangesAsync();
        }

        public void SaveRange(IEnumerable<Problem> models)
        {
            if (models == null)
            {
                return;
            }

            IEnumerable<ProblemEntity> entitiesForSave = models.Select(problem => ProblemMapping.GetEntityFromModel(problem));
            _context.Problems.AddRange(entitiesForSave);
            _context.SaveChanges();
        }

        public async Task SaveRangeAsync(IEnumerable<Problem> models)
        {
            if (models == null)
            {
                return;
            }

            IEnumerable<ProblemEntity> entitiesForSave = models.Select(problem => ProblemMapping.GetEntityFromModel(problem));
            await _context.Problems.AddRangeAsync(entitiesForSave);
            await _context.SaveChangesAsync();
        }
    }
}
