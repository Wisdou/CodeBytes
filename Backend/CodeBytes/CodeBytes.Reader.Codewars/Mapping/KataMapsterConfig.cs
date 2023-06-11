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
        private static Dictionary<int, int> Dict = new Dictionary<int, int>()
        {
            {-8, 1},
            {-7, 1},
            {-6, 2},
            {-5, 2},
            {-4, 2},
            {-3, 3},
            {-2, 3},
            {-1, 3},
            {1, 3},
            {2, 3},
            {3, 3},
            {4, 3},
            {0, -1}
        };

        public static TypeAdapterConfig KataMapsterConfiguration = new TypeAdapterConfig().NewConfig<Kata, Problem>().
                                                                       Map(src => src.Title, dest => dest.Name).
                                                                       Map(src => src.Description, dest => dest.Description).
                                                                       Map(src => src.Difficulty, dest => KataMapsterConfig.Dict[dest.KataLevel.Id ?? 0]).
                                                                       Map(src => src.Tags, dest => dest.Tags.Select(tag => new ProblemTag() { Tag = tag }).ToList()).
                                                                       Config;
    }
}
