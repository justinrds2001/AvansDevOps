using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintFactory;

namespace AvansDevOps.SprintState
{
    public class ActiveState : ISprintState
    {
        private readonly Sprint _sprint;

        public ActiveState(Sprint Sprint)
        {
            this._sprint = Sprint;
        }

        public void FinishSprint()
        {
            _sprint.UpdateSprintState(new FinishedState(_sprint));

        }

        public void ReviewSprint(bool isApproved = false)
        {
            Console.WriteLine("Sprint is not finished yet...");
        }

        public void StartSprint()
        {
            Console.WriteLine("Sprint is already started...");
        }
    }
}
