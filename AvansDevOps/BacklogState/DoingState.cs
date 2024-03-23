using AvansDevOps.Observer;
using AvansDevOps.Observer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public class DoingState : BacklogState
    {

        public override void ToTestReady()
        {
            if(BacklogItem.Sprint != null)
            {
                BacklogItem.Sprint.NotifySpecificParticipant<Tester>("Backlog item is ready for testing: " + BacklogItem.Title);
                BacklogItem.UpdateBacklogItemState(new TestReadyState() { BacklogItem = BacklogItem });
            }
        }
    }
}
