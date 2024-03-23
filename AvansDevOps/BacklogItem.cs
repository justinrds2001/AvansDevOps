using AvansDevOps.BacklogState;
using AvansDevOps.ISprintFactory;
using AvansDevOps.Observer;
using AvansDevOps.Observer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class BacklogItem
    {
        public string Title { get; set; } = string.Empty;
        public Contributor? Contributor { get; set; }
        public string DefinitionOfDone { get; set; } = string.Empty;
        public BacklogState.BacklogState BacklogState { get; set; } = null!;
        public Sprint? Sprint { get; set; }

        public void UpdateBacklogItemState(BacklogState.BacklogState backlogState)
        {
            BacklogState = backlogState;
        }
    }
}
