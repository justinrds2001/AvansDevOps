﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class BuildJob : IJob
    {
        public bool Execute(bool passed = true)
        {
            Console.WriteLine("Running Build job...");
            return passed;
        }
    }
}
