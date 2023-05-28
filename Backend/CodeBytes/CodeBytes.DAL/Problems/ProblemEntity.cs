using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.DAL.Problems
{
    public class ProblemEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ProblemTagEntity> Tags { get; set; }
    }
}
