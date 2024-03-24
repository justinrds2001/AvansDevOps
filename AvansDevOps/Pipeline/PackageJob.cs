using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class PackageJob : IJob
    {
        public bool Execute(bool passed = true)
        {
            Console.WriteLine("Running Package job...");
            return passed;
        }
    }
}
