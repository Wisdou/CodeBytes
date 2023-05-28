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
        public static TypeAdapterConfig KataMapsterConfiguration = new TypeAdapterConfig().NewConfig<Kata, Problem>().
                                                                       Map(src => src.Title, dest => dest.Name).
                                                                       Map(src => src.Description, dest => dest.Description).
                                                                       Map(src => src.Tags, dest => dest.Tags.Select(tag => new ProblemTag() { Tag = tag }).ToList()).
                                                                       Config;
    }
}
