using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.Domain.Model
{
    public class Problem
    {
        public enum ProblemDifficulty
        {
            Unknown = -1,
            Easy = 1,
            Medium,
            Hard
        }

        public int Id { get; set; }
        public string Title { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProblemDifficulty Difficulty { get; set; }
        public string Description { get; set; }
        public List<ProblemTag> Tags { get; set; }
    }
}
