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
        public BacklogItem BacklogItem { get; set; } = null!;
        public virtual void ToToDo()
        {
            Console.WriteLine("You cannot set the backlog to ToDo!");
        }
        public virtual void ToDoing()
        {
            Console.WriteLine("You cannot set the backlog to Doing!");
        }
        public virtual void ToTesting()
        {
            Console.WriteLine("You cannot set the backlog to Testing!");
        }
        public virtual void ToTested()
        {
            Console.WriteLine("You cannot set the backlog to Tested!");
        }
        public virtual void ToDone()
        {
            Console.WriteLine("You cannot set the backlog to Done!");
        }
        public virtual void ToTestReady()
        {
            Console.WriteLine("You cannot set the backlog to Test Ready!");
        }
    }
}
