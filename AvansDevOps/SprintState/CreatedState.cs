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
        private readonly Sprint _sprint;

        public CreatedState(Sprint Sprint)
        {
            this._sprint = Sprint;
        }

        public void FinishSprint()
        {
            Console.WriteLine("Sprint has to be started first.");
        }

        public void ReviewSprint(bool isApproved = false)
        {
            Console.WriteLine("Sprint has to be started first.");
        }

        override public void StartSprint()
        {
            _sprint.UpdateSprintState(new ActiveState());
        }
    }
}
