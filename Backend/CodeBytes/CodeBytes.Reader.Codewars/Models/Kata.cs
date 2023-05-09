using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.Reader.Codewars.Models
{
    public class Rank
    {
        private static Dictionary<int, string> _ranksValues = new Dictionary<int, string>()
        {
            {-8, "8 kyu" },
            {-7, "7 kyu" },
            {-6, "6 kyu" },
            {-5, "5 kyu" },
            {-4, "4 kyu" },
            {-3, "3 kyu" },
            {-2, "2 kyu" },
            {-1, "1 kyu" },
            {1, "1 dan" },
            {2, "2 dan" },
            {3, "3 dan" },
            {4, "4 dan" }
        };

        [JsonProperty("id")]
        public int? Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("color")]
        public string Color;

        public string GetRank
        {
            get
            {
                return this.Id == null ? "No rank" : _ranksValues[this.Id.Value];
            }
        }

        public Rank() { }

        public Rank(int? id, string name, string color)
        {
            this.Id = id;
            this.Name = name;
            this.Color = color;
        }
    }

    public class Kata
    {
        [JsonProperty("id")]
        public string ID;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("slug")]
        public string Slug;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("languages")]
        public List<string> AvailableLanguages;

        [JsonProperty("rank")]
        public Rank KataLevel;

        [JsonProperty("tags")]
        public List<string> Tags;

        public List<string> CompletedLanguages;
        public DateTime CompletedAt { get; set; }
        public Kata() { }
        public Kata(string id, string name, string slug, string description,
                    List<string> availableLanguages, Rank kataLevel, List<string> tags)
        {
            this.ID = id;
            this.Name = name;
            this.Slug = slug;
            this.AvailableLanguages = availableLanguages;
            this.KataLevel = kataLevel;
            this.Tags = tags;
            this.Description = description;
        }
    }
}
