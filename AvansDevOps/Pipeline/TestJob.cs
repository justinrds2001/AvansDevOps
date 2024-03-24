using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class TestJob : IJob
    {
        public bool Execute(bool passed = true)
        {
            Console.WriteLine("Running Test job...");
            return passed;
        }
    }
}
