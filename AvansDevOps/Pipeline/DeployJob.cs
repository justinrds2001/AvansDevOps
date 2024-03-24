using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class DeployJob : IJob
    {
        public bool Execute(bool passed = true)
        {
            Console.WriteLine("Running Deploy job...");
            return passed;
        }
    }
}
