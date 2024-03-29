﻿using CodeBytes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.Domain.Interfaces
{
    public interface IProblemCRMRepository
    {
        void Save(Problem entity);
        Task SaveAsync(Problem entity);
        void SaveRange(IEnumerable<Problem> entities);
        Task SaveRangeAsync(IEnumerable<Problem> entities);
        void DeleteProblem(int id);
        Task DeleteProblemAsync(int id);
        void DeleteProblems(int[] ids);
        Task DeleteProblemsAsync(int[] ids);
    }
}
