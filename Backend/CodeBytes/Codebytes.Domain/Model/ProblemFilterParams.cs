using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.Domain.Model
{
    public class Paging
    {
        public int Size { get; set; }
        public int Page { get; set; }

        public Paging() { }
    }
    public class ProblemFilterParams
    {
        public Paging Paging { get; set; }
        public string StartsWith { get; set; }

        public int[] Difficulties { get; set; }
        public ProblemFilterParams() { }
    }
}
