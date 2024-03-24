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
        override public void CloseSprint()
        {
            if (Sprint is ReleaseSprint)
            {
                Sprint.NotifySpecificParticipant<ScrumMaster>("New release has been sucessful.");
                Sprint.NotifySpecificParticipant<ProductOwner>("New release has been sucessful.");
                Sprint.ExecutePipeline();
            }

            Sprint.UpdateSprintState(new ClosedState() { Sprint = Sprint });
        }

        override public void CancelSprint()
        {

            Sprint.UpdateSprintState(new CanceledState() { Sprint = Sprint });
        }
    }
}
