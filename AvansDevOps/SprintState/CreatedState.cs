using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintFactory;

namespace AvansDevOps.SprintState
{
    public class CreatedState : ISprintState
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

        public void ReviewSprint(bool approvedDeployement = false)
        {
            Console.WriteLine("Sprint has to be started first.");
        }

        public void StartSprint()
        {
            _sprint.UpdateSprintState(new ActiveState(this._sprint));
        }
    }
}
