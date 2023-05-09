using CodeBytes.Reader.Codewars.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CodeBytes.DTO.Problems;
using System.Linq;
using Mapster;
using CodeBytes.Reader.Codewars.Mapping;

namespace CodeBytes.Reader.Codewars
{
    public static class CodeWarsReader
    {
        private static HttpClient Client { get; } = new HttpClient();

        private const string GETKATABYIDURL = @"https://www.codewars.com/api/v1/code-challenges/{0}";
        private const string GETKATAPERUSER = @"https://www.codewars.com/api/v1/users/{0}/code-challenges/completed?page={1}";
        public async static Task<Kata> GetKataById(string kataID)
        {
            string url = String.Format(GETKATABYIDURL, kataID);
            string response = await Client.GetStringAsync(url);
            Kata kata = JsonConvert.DeserializeObject<Kata>(response);
            return kata;
        }

        public async static Task<List<Kata>> GetKatasPerUser(string usedId)
        {
            string url = String.Format(GETKATAPERUSER, usedId, 0);
            string response = await Client.GetStringAsync(url);
            UserInfo katasPage = JsonConvert.DeserializeObject<UserInfo>(response);
            List<Kata> result = new List<Kata>();
            for (int i = 0; i < katasPage.TotalPages; i++)
            {
                string pageUrl = String.Format(GETKATAPERUSER, usedId, i);
                string newResponse = await Client.GetStringAsync(pageUrl);
                UserInfo newKataPage = JsonConvert.DeserializeObject<UserInfo>(newResponse);

                foreach (var completedKata in newKataPage.Katas)
                {
                    var newKata = await GetKataById(completedKata.Id);
                    newKata.CompletedLanguages = completedKata.CompletedLanguages;
                    newKata.CompletedAt = completedKata.CompletedAt;
                    result.Add(newKata);
                }
            }
            return result;
        }

        public async static Task<List<ProblemDTO>> GetProblemsPerUser(string usedId)
        {
            var result = await GetKatasPerUser(usedId);
            return result.AsQueryable().ProjectToType<ProblemDTO>(KataMapsterConfig.KataMapsterConfiguration).ToList();
        }
    }
}
