using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.ISprintFactory;

namespace AvansDevOps.SprintState
{
    public class ActiveState : SprintState
    {
        override public void FinishSprint()
        {
            Sprint.UpdateSprintState(new FinishedState() { Sprint = Sprint });
        }
    }
}
