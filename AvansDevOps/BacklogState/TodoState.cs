using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public class TodoState : IBacklogState
    {
        public BacklogItem BacklogItem { get; set; } = null!;
        public void AssignContributor(Contributor contributor)
        {
            BacklogItem.Contributor = contributor;
        }

        public void ChangeState(IBacklogState? state)
        {
            if (state != null) BacklogItem.BacklogState = state;
            else BacklogItem.BacklogState = new DoingState
            {
                BacklogItem = BacklogItem
            };
        }

        public void FinishTask()
        {
            throw new NotImplementedException();
        }
    }
}
