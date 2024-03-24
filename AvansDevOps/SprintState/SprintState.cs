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
        virtual public void StartSprint(Sprint sprint)
        {
            Console.WriteLine("You cannot start the sprint!");
        }

        virtual public void CancelSprint(Sprint sprint)
        {
            Console.WriteLine("You cannot cancel the sprint!");
        }

        virtual public void FinishSprint(Sprint sprint)
        {
            Console.WriteLine("You cannot finish the sprint!");
        }

        virtual public void CloseSprint(Sprint sprint)
        {
            Console.WriteLine("You cannot close the sprint!");
        }   

    }
}
