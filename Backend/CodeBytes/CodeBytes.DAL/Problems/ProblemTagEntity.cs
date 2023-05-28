using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.DAL.Problems
{
    public class ProblemTagEntity
    {
        public int Id { get; set; }
        public string Tag { get; set; }

        public List<ProblemEntity> Problem { get; set; }
    }
}
