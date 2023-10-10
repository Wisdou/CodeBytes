using CodeBytes.Domain.Interfaces;
using CodeBytes.Reader.Codewars;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.DAL.Seeder
{
    public static class DataSeeder
    {
        public static async Task FillUsers(IProblemCRMRepository repository)
        {
            var list = await CodeWarsReader.GetProblemsPerUser("andersk");
            repository.SaveRange(list);
        }
    }
}
