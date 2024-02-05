using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.ISprintFactory;

namespace AvansDevOps.SprintState
{
    public class CanceledState : ISprintState
    {
        public CanceledState(Sprint Sprint)
        {
            Sprint.CancelSprint();
        }

        public void FinishSprint()
        {
            Console.WriteLine("The sprint is already closed!");
        }

        public void ReviewSprint(bool isApproved = false)
        {
            Console.WriteLine("The sprint is already closed!");
        }

        public void StartSprint()
        {
            Console.WriteLine("The sprint is already closed!");
        }
    }
}
