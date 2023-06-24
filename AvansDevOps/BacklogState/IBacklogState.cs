using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public interface IBacklogState
    {
        public void ChangeState(IBacklogState? state);
        public void AssignContributor(Contributor contributor);
        public void FinishTask();
    }
}
