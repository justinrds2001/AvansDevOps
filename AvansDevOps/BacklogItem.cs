using AvansDevOps.BacklogState;
using AvansDevOps.Observer;
using AvansDevOps.Observer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class BacklogItem : Publisher
    {
        public Contributor? Contributor { get; set; }
        public List<Activity> Activities { get; set; } = new List<Activity>();
        public string DefinitionOfDone { get; set; } = string.Empty;
        public BacklogState.BacklogState BacklogState { get; set; } = null!;
    }
}
