using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.ISprintFactory;

namespace AvansDevOps.SprintState
{
    public class FinishedState : SprintState
    {
        override public void CloseSprint()
        {
            Sprint.UpdateSprintState(new ClosedState());
        }

        override public void CancelSprint()
        {
            Sprint.UpdateSprintState(new CanceledState());
        }
    }
}
