using CodeBytes.Domain.Model;
using CodeBytes.Reader.Codewars.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.Reader.Codewars.Mapping
{
    public static class KataMapsterConfig
    {
        private static Dictionary<int, Problem.ProblemDifficulty> Dict = new Dictionary<int, Problem.ProblemDifficulty>()
        {
            {-8, Problem.ProblemDifficulty.Easy},
            {-7, Problem.ProblemDifficulty.Easy},
            {-6, Problem.ProblemDifficulty.Medium},
            {-5, Problem.ProblemDifficulty.Medium},
            {-4, Problem.ProblemDifficulty.Medium},
            {-3, Problem.ProblemDifficulty.Hard},
            {-2, Problem.ProblemDifficulty.Hard},
            {-1, Problem.ProblemDifficulty.Hard},
            {1, Problem.ProblemDifficulty.Hard},
            {2, Problem.ProblemDifficulty.Hard},
            {3, Problem.ProblemDifficulty.Hard},
            {4, Problem.ProblemDifficulty.Hard},
            {0, Problem.ProblemDifficulty.Unknown}
        };

        public static TypeAdapterConfig KataMapsterConfiguration = new TypeAdapterConfig().NewConfig<Kata, Problem>().
                                                                       Map(src => src.Title, dest => dest.Name).
                                                                       Map(src => src.Description, dest => dest.Description).
                                                                       Map(src => src.Difficulty, dest => KataMapsterConfig.Dict[dest.KataLevel.Id ?? 0]).
                                                                       Map(src => src.Tags, dest => dest.Tags.Select(tag => new ProblemTag() { Tag = tag }).ToList()).
                                                                       Config;
    }
}
