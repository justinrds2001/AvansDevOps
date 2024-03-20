using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public class TodoState : BacklogState
    {
        public override void ToDoing()
        {
            BacklogItem.BacklogState = new DoingState { BacklogItem = BacklogItem };
        }
    }
}
