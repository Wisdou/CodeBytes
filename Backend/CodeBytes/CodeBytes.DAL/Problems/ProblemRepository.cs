﻿using CodeBytes.DAL.Data;
using CodeBytes.Domain.Interfaces;
using CodeBytes.Domain.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            ProblemEntity problem = this._context.Problems.Include(x => x.Tags).AsNoTracking().FirstOrDefault(x => x.ID == id);

            return ProblemMapping.GetModelFromEntity(problem);
        }

        public IReadOnlyCollection<Problem> Get(ProblemFilterParams filter)
        {
            int skipAmount = filter.Paging.Page * filter.Paging.Size;
            int takeAmount = filter.Paging.Size;

            IQueryable<ProblemEntity> filteredTasks = this._context.Problems;
            if (filter.StartsWith != null && filter.StartsWith != String.Empty)
            {
                filteredTasks = filteredTasks.Where(x => x.Title.StartsWith(filter.StartsWith));
            }

            if (filter.Difficulties != null && filter.Difficulties.Length > 0)
            {
                filteredTasks = filteredTasks.Where(x => filter.Difficulties.Contains(x.Difficulty));
            }

            List<Problem> problems = filteredTasks.Include(x => x.Tags).AsNoTracking().
                Skip(skipAmount).Take(takeAmount).Select(problem => ProblemMapping.GetModelFromEntity(problem)).
                ToList();

            if (filter.DescriptionSize > 0)
            {
                problems.ForEach(x => x.Description = x.Description.Substring(0, filter.DescriptionSize));
            }

            return problems.AsReadOnly();
        }
        public async Task<IReadOnlyCollection<Problem>> GetAsync(ProblemFilterParams filter)
        {
            int skipAmount = filter.Paging.Page * filter.Paging.Size;
            int takeAmount = filter.Paging.Size;

            IQueryable<ProblemEntity> filteredTasks = this._context.Problems;
            if (filter.StartsWith != null && filter.StartsWith != String.Empty)
            {
                filteredTasks = filteredTasks.Where(x => x.Title.StartsWith(filter.StartsWith));
            }

            if (filter.Difficulties != null && filter.Difficulties.Length > 0)
            {
                filteredTasks = filteredTasks.Where(x => filter.Difficulties.Contains(x.Difficulty));
            }

            List<Problem> problems = await filteredTasks.Include(x => x.Tags).AsNoTracking().
                Skip(skipAmount).Take(takeAmount).Select(problem => ProblemMapping.GetModelFromEntity(problem)).
                ToListAsync();

            if (filter.DescriptionSize > 0)
            {
                problems.ForEach(x => x.Description = x.Description.Substring(0, filter.DescriptionSize));
            }

            return problems.AsReadOnly();
        }


        public IReadOnlyCollection<Problem> GetAll()
        {
            List<ProblemEntity> problems = this._context.Problems.Include(x => x.Tags).AsNoTracking().ToList();

            return problems.Select(problem => ProblemMapping.GetModelFromEntity(problem)).ToList().AsReadOnly();
        }

        public async Task<IReadOnlyCollection<Problem>> GetAllAsync()
        {
            List<ProblemEntity> problems = await this._context.Problems.Include(x => x.Tags).AsNoTracking().ToListAsync();

            return problems.Select(problem => ProblemMapping.GetModelFromEntity(problem)).ToList().AsReadOnly();
        }

        public async Task<Problem> GetAsync(int id)
        {
            ProblemEntity problem = await this._context.Problems.Include(x => x.Tags).AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
            return ProblemMapping.GetModelFromEntity(problem);
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

        public int GetTotalCount()
        {
            return this._context.Problems.Count();
        }

        public async Task<int> GetTotalCountAsync()
        {
            int result = await this._context.Problems.CountAsync();
            return result;
        }

        public int GetTotalCount(ProblemFilterParams filter)
        {
            IQueryable<ProblemEntity> filteredTasks = this._context.Problems;
            if (filter.StartsWith != null && filter.StartsWith != String.Empty)
            {
                filteredTasks = filteredTasks.Where(x => x.Title.StartsWith(filter.StartsWith));
            }

            if (filter.Difficulties != null && filter.Difficulties.Length > 0)
            {
                filteredTasks = filteredTasks.Where(x => filter.Difficulties.Contains(x.Difficulty));
            }

            int result = filteredTasks.Count();
            return result;
        }

        public async Task<int> GetTotalCountAsync(ProblemFilterParams filter)
        {
            IQueryable<ProblemEntity> filteredTasks = this._context.Problems;
            if (filter.StartsWith != null && filter.StartsWith != String.Empty)
            {
                filteredTasks = filteredTasks.Where(x => x.Title.StartsWith(filter.StartsWith));
            }

            if (filter.Difficulties != null && filter.Difficulties.Length > 0)
            {
                filteredTasks = filteredTasks.Where(x => filter.Difficulties.Contains(x.Difficulty));
            }

            int result = await filteredTasks.CountAsync();
            return result;
        }
    }
}
