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
        public static TypeAdapterConfig EntityToDtoConfiguration = new TypeAdapterConfig().
                                                                       NewConfig<ProblemEntity, Problem>().
                                                                       Map(src => src.Title, dest => dest.Title).
                                                                       Map(src => src.Description, dest => dest.Description).
                                                                       Config;

        public static TypeAdapterConfig DtoToEntityConfiguration = new TypeAdapterConfig().
                                                                       NewConfig<Problem, ProblemEntity>().
                                                                       Map(src => src.Title, dest => dest.Title).
                                                                       Map(src => src.Description, dest => dest.Description).
                                                                       Config;
    }
}
