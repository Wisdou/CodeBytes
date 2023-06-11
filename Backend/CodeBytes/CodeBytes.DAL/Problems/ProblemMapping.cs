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
        public static ProblemTag GetModelFromEntity(ProblemTagEntity tag)
        {
            return new ProblemTag()
            {
                Tag = tag.Tag,
            };
        }

        public static ProblemTagEntity GetEntityFromModel(ProblemTag tag)
        {
            return new ProblemTagEntity()
            {
                Tag = tag.Tag,
            };
        }

        public static Problem GetModelFromEntity(ProblemEntity problem)
        {
            if (problem == null)
            {
                return null;
            }

            return new Problem()
            {
                Title = problem.Title,
                Description = problem.Description,
                Difficulty = problem.Difficulty,
                Tags = problem.Tags.Select(x => GetModelFromEntity(x)).ToList(),
            };
        }

        public static ProblemEntity GetEntityFromModel(Problem problem)
        {
            if (problem == null)
            {
                return null;
            }

            return new ProblemEntity()
            {
                Title = problem.Title,
                Description = problem.Description,
                Difficulty = problem.Difficulty,
                Tags = problem.Tags.Select(x => GetEntityFromModel(x)).ToList(),
            };
        }
    }
}
