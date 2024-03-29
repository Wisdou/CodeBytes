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
        private const double MIN_SIMILARITY = 0.5;

        private CodeByteContext _context;

        public ProblemRepository(CodeByteContext context)
        {
            _context = context;
        }

        public Problem Get(int id)
        {
            ProblemEntity problem = _context.Problems.Include(x => x.Tags).AsNoTracking().FirstOrDefault(x => x.ID == id);

            return ProblemMapping.GetModelFromEntity(problem);
        }

        public IReadOnlyCollection<Problem> Get(ProblemFilterParams filter)
        {
            int skipAmount = filter.Paging.Page * filter.Paging.Size;
            int takeAmount = filter.Paging.Size;

            var problemsSet = _context.Problems;
            IQueryable<ProblemEntity> filteredTasks;
            if (filter.StartsWith != null && filter.StartsWith != String.Empty)
            {
                filteredTasks = problemsSet.FromSqlInterpolated($"SELECT * FROM public.\"Problems\" WHERE SIMILARITY(SUBSTRING(\"Title\", 1, {filter.StartsWith.Length}), {filter.StartsWith}) > {ProblemRepository.MIN_SIMILARITY}");
            }
            else
            {
                filteredTasks = problemsSet;
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

            var problemsSet = _context.Problems;
            IQueryable<ProblemEntity> filteredTasks;
            if (filter.StartsWith != null && filter.StartsWith != String.Empty)
            {
                filteredTasks = problemsSet.FromSqlInterpolated($"SELECT * FROM public.\"Problems\" WHERE SIMILARITY(SUBSTRING(\"Title\", 1, {filter.StartsWith.Length}), {filter.StartsWith}) > {ProblemRepository.MIN_SIMILARITY}");
            }
            else
            {
                filteredTasks = problemsSet;
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
            List<ProblemEntity> problems = _context.Problems.Include(x => x.Tags).AsNoTracking().ToList();

            return problems.Select(problem => ProblemMapping.GetModelFromEntity(problem)).ToList().AsReadOnly();
        }

        public async Task<IReadOnlyCollection<Problem>> GetAllAsync()
        {
            List<ProblemEntity> problems = await _context.Problems.Include(x => x.Tags).AsNoTracking().ToListAsync();

            return problems.Select(problem => ProblemMapping.GetModelFromEntity(problem)).ToList().AsReadOnly();
        }

        public async Task<Problem> GetAsync(int id)
        {
            ProblemEntity problem = await _context.Problems.Include(x => x.Tags).AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
            return ProblemMapping.GetModelFromEntity(problem);
        }

        public int GetTotalCount()
        {
            return _context.Problems.Count();
        }

        public async Task<int> GetTotalCountAsync()
        {
            int result = await _context.Problems.CountAsync();
            return result;
        }

        public int GetTotalCount(ProblemFilterParams filter)
        {
            IQueryable<ProblemEntity> filteredTasks = _context.Problems;
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
            IQueryable<ProblemEntity> filteredTasks = _context.Problems;
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