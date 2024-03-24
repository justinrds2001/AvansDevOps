using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.ISprintFactory;

namespace AvansDevOps.SprintState
{
    public class CreatedState : SprintState
    {
        override public void StartSprint(Sprint sprint)
        {
            sprint.AllowChanges = false;
            sprint.UpdateSprintState(new ActiveState());
        }
    }
}
