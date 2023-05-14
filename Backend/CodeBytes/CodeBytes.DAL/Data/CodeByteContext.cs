using CodeBytes.DAL.Problems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.DAL.Data
{
    public class CodeByteContext: DbContext
    {

        public CodeByteContext()
        {
        }

        public CodeByteContext(DbContextOptions<CodeByteContext> options) : base(options)
        {
        }

        public DbSet<ProblemEntity> Problems { get; set; }
    }
}
