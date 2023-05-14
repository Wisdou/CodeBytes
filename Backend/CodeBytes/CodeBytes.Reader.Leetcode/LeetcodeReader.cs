using CodeBytes.Reader.Leetcode.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Parser;
using System.Linq;
using System.Collections.Generic;
using AngleSharp.Dom;

namespace CodeBytes.Reader.Leetcode
{
    public static class LeetcodeReader
    {
        private const string LEETCODE_URL = @"https://leetcode.com/";
        private const string LEETCODE_PROBLEMS_URL = LeetcodeReader.LEETCODE_URL + "problemset/all/";
        private const string LEETCODE_PROBLEM_URL_PATTERN = LeetcodeReader.LEETCODE_URL + "problems/{0}";

        public static async Task<List<LeetcodeProblem>> GetFirstProblems()
        {
            return new List<LeetcodeProblem>();
        }

        public static async Task<LeetcodeProblem> GetProblem(string name)
        {
            var problemUrl = String.Format(LeetcodeReader.LEETCODE_PROBLEM_URL_PATTERN, name);

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(problemUrl);
            var dataDescrSelector = "div[data-track-load=\"qd_description_content\"]";
            var problemDataDescr = document.QuerySelector(dataDescrSelector);
            var descr = problemDataDescr.TextContent;

            var dataNameSelector = "div .mr-2 .text-lg .font-medium .text-label-1";
            string problemDataName = document.QuerySelector(dataNameSelector).FirstChild.TextContent;

            var dataAcceptanceSelector = "div .text-label-1 .dark:text-dark-label-1 .text-sm .font-medium > span";
            string acceptanceRating = document.QuerySelector(dataAcceptanceSelector).FirstChild.TextContent;

            return new LeetcodeProblem()
            {
                Title = problemDataName,
                Description = descr,
                Acceptance = Convert.ToDecimal(acceptanceRating.Substring(0, acceptanceRating.Length - 1))
            };
        }
    }
}
