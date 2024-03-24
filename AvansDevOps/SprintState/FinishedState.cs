using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.ISprintFactory;
using AvansDevOps.Observer.Users;

namespace AvansDevOps.SprintState
{
    public class FinishedState : SprintState
    {
        override public void CloseSprint(Sprint sprint)
        {
            if (sprint is ReleaseSprint)
            {
                sprint.NotifySpecificParticipant<ScrumMaster>("New release has been sucessful.");
                sprint.NotifySpecificParticipant<ProductOwner>("New release has been sucessful.");
                sprint.ExecutePipeline();
            }

            sprint.UpdateSprintState(new ClosedState());
        }

        override public void CancelSprint(Sprint sprint)
        {

            sprint.UpdateSprintState(new CanceledState());
        }
    }
}
