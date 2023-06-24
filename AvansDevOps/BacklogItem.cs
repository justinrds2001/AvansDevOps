using AvansDevOps.BacklogState;
using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class BacklogItem
    {
        public Contributor? Contributor { get; set; }
        public List<Activity> Activities { get; set; }
        public string DefinitionOfDone { get; set; }
        public IBacklogState BacklogState { get; set; }
    }
}
