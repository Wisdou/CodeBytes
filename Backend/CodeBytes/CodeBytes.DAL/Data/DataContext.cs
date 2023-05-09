using CodeBytes.DAL.Problems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.DAL.Data
{
    class DataContext: DbContext
    {
        const string CONNECTION_STRING = "Host=localhost;Port=5432;Database=CodeBytes;Username=postgres;Password=1234";

        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(DataContext.CONNECTION_STRING);
        }

        public DbSet<ProblemEntity> Problems { get; set; }
    }
}
