﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBytes.Domain.Model
{
    public class Problem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ProblemTag> Tags { get; set; }
    }
}
