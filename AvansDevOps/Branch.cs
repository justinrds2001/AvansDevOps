using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class Branch
    {
        public string Name { get; set; } = string.Empty;
        public bool IsMain { get; set; } = false;
        public BacklogItem? Backlog { get; set; }
        public bool Commit(string name)
        {
            Console.WriteLine($"Pushing {name} to {Name} remote branch");
            return true;
        }
        public bool MakePullRequest(Branch branch)
        {
            Console.WriteLine($"Making pull request to merge {Name} into {branch.Name}");
            return true;
        }
    }
}
