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

        public static async Task<List<LeetcodeProblem>> GetFirstProblems(int cnt)
        {
            var leetcodeMainPageUrl = LEETCODE_PROBLEMS_URL;
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(leetcodeMainPageUrl);

            var rowSelector = "div[role=\"row\"]";
            var dataRows = document.QuerySelectorAll(rowSelector);

            List<LeetcodeProblem> result = new List<LeetcodeProblem>();
            return result;
        }

        public static async Task<string> GetProblemDescrption(string name)
        {
            var problemUrl = String.Format(LeetcodeReader.LEETCODE_PROBLEM_URL_PATTERN, name);

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(problemUrl);
            var dataDescrSelector = "div[data-track-load=\"qd_description_content\"]";
            var problemDataDescr = document.QuerySelector(dataDescrSelector);
            var descr = problemDataDescr.TextContent;

            return descr;
        }
    }
}
