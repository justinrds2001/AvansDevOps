using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public class DoingState : IBacklogState
    {
        public BacklogItem BacklogItem { get; set; } = null!;

        public void AssignContributor(Contributor contributor)
        {
            throw new NotImplementedException();
        }

        public void ChangeState(IBacklogState? state)
        {
            // Notify testers if state is changing from doing to test ready
            if (state is TestReadyState || state is null)
            {
                Console.WriteLine("Notifying testers...");
            }

            if (state != null)
                BacklogItem.BacklogState = state;
            else
                BacklogItem.BacklogState = new TestReadyState { BacklogItem = BacklogItem };
        }

        public void FinishTask()
        {
            throw new NotImplementedException();
        }
    }
}
