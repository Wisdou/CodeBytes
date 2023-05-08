using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeBytes.Reader.Codewars;
using Newtonsoft.Json;
using System.IO;

namespace CodeBytes.API
{
    public class Program
    {
        private const string PATH_TO_FILE = @"C:\Users\Daniel\OneDrive\Рабочий стол\Solutions.txt";

        public static void Main(string[] args)
        {
            var list = CodeWarsReader.GetProblemsPerUser("andersk").Result;
            File.WriteAllText(PATH_TO_FILE, JsonConvert.SerializeObject(list));
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
