using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public class TestedState : IBacklogState
    {
        public BacklogItem BacklogItem { get; set; } = null!;
        public void AssignContributor(Contributor contributor)
        {
            Console.WriteLine("Cannot switch contributor outside the ToDo");
        }

        public void ChangeState(IBacklogState? state)
        {
            if (state != null) BacklogItem.BacklogState = state;
            else BacklogItem.BacklogState = new DoneState
            {
                BacklogItem = BacklogItem
            };
        }

        public void FinishTask()
        {
            throw new NotImplementedException();
        }
    }
}
