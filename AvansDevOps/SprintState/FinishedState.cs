using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintFactory;

namespace AvansDevOps.SprintState
{
    public class FinishedState : ISprintState
    {
        private readonly Sprint _sprint;

        public FinishedState(Sprint Sprint)
        {
            this._sprint = Sprint;
        }

        public void FinishSprint()
        {
            Console.WriteLine("The sprint is already finished!");
        }

        public void ReviewSprint(bool isApproved = false)
        {
            _sprint.UpdateSprintState(new CanceledState(_sprint));

            if (_sprint is ReleaseSprint releaseSprint && isApproved)
            {
                releaseSprint.CreateSprint();
            }
        }

        public void StartSprint()
        {
            Console.WriteLine("The print is already closed!");
        }
    }
}
