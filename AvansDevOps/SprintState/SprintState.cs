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
            Console.WriteLine("You cannot start the sprint!");
        }

        virtual public void CancelSprint()
        {
            Console.WriteLine("You cannot cancel the sprint!");
        }

        virtual public void FinishSprint()
        {
            Console.WriteLine("You cannot finish the sprint!");
        }

        virtual public void CloseSprint()
        {
            Console.WriteLine("You cannot close the sprint!");
        }   

    }
}
