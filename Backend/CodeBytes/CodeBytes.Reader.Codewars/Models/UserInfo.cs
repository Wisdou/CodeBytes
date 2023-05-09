using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.Reader.Codewars.Models
{
    public class CompletedKata
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("completedLanguages")]
        public List<string> CompletedLanguages;

        [JsonProperty("completedAt")]
        public DateTime CompletedAt { get; set; }
        public CompletedKata() { }
    }

    public class UserInfo
    {
        [JsonProperty("totalPages")]
        public int TotalPages;

        [JsonProperty("totalItems")]
        public int TotalItems;

        [JsonProperty("data")]
        public List<CompletedKata> Katas;

        public UserInfo() { }
    }
}
