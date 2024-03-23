using AvansDevOps.Observer;
using AvansDevOps.Observer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public class TestingState : BacklogState
    {
        public override void ToToDo()
        {
            BacklogItem.Sprint?.NotifySpecificParticipant<ScrumMaster>("Testing failed, moving back to ToDo: " + BacklogItem.Title);
            BacklogItem.UpdateBacklogItemState(new TodoState() { BacklogItem = BacklogItem });
        }

        public override void ToTested()
        {
            BacklogItem.UpdateBacklogItemState(new TestedState() { BacklogItem = BacklogItem });
        }
    }
}
