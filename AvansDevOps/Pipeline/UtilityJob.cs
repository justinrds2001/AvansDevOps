using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class UtilityJob : IJob
    {
        public bool Execute(bool passed = true)
        {
            Console.WriteLine("Running Utility job...");
            return passed;
        }
    }
}
