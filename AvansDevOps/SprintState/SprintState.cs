using AvansDevOps.ISprintFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintState
{
    public abstract class SprintState
    {
        public Sprint Sprint { get; set; } = null!;

        virtual public void StartSprint()
        {
            throw new InvalidOperationException("You cannot start the sprint!");
        }

        virtual public void CancelSprint()
        {
            throw new InvalidOperationException("You cannot cancel the sprint!");
        }

        virtual public void FinishSprint()
        {
            throw new InvalidOperationException("You cannot finish the sprint!");
        }

        virtual public void CloseSprint()
        {
            throw new InvalidOperationException("You cannot close the sprint!");
        }   

    }
}
