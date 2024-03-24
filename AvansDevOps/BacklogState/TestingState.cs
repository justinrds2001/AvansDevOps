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
        public override void ToToDo(BacklogItem item)
        {
            item.Sprint?.NotifySpecificParticipant<ScrumMaster>("Testing failed, moving back to ToDo: " + item.Title);
            item.UpdateBacklogItemState(new TodoState());
        }

        public override void ToTested(BacklogItem item)
        {
            item.UpdateBacklogItemState(new TestedState());
        }
    }
}
