using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeBytes.Domain.Model
{
    public class Problem
    {
        private static Dictionary<int, string> DifficultyMap = new Dictionary<int, string>()
        {
            {1, "Easy" },
            {2, "Medium" },
            {3, "Hard" },
            {-1, "Unknown" }
        };

        [JsonPropertyName("difficulty")]
        public string GetDifficulty
        {
            get{
                return Problem.DifficultyMap[this.Difficulty];
            }
        }
        public int Id { get; set; }
        public string Title { get; set; }

        [JsonIgnore]
        public int Difficulty { get; set; }
        public string Description { get; set; }
        public List<ProblemTag> Tags { get; set; }
    }
}
