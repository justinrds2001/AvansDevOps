using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public class DoneState : IBacklogState
    {
        public BacklogItem BacklogItem { get; set; }
        public void AssignContributor(Contributor contributor)
        {
            Console.WriteLine("Cannot switch contributor outside the ToDo");
        }

        public void ChangeState(IBacklogState? state)
        {
            throw new NotImplementedException();
        }

        public void FinishTask()
        {
            throw new NotImplementedException();
        }
    }
}
