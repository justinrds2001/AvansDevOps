using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public abstract class BacklogState
    {   
        public virtual void ToToDo(BacklogItem item)
        {
            Console.WriteLine("You cannot set the backlog to ToDo!");
        }
        public virtual void ToDoing(BacklogItem item)
        {
            Console.WriteLine("You cannot set the backlog to Doing!");
        }
        public virtual void ToTesting(BacklogItem item)
        {
            Console.WriteLine("You cannot set the backlog to Testing!");
        }
        public virtual void ToTested(BacklogItem item)
        {
            Console.WriteLine("You cannot set the backlog to Tested!");
        }
        public virtual void ToDone(BacklogItem item)
        {
            Console.WriteLine("You cannot set the backlog to Done!");
        }
        public virtual void ToTestReady(BacklogItem item)
        {
            Console.WriteLine("You cannot set the backlog to Test Ready!");
        }
    }
}
