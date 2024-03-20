using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public class TestingState : BacklogState
    {
        public override void ToToDo()
        {
            BacklogItem.BacklogState = new TodoState { BacklogItem = BacklogItem };
        }

        public override void ToTesting()
        {
            BacklogItem.BacklogState = new TestingState { BacklogItem = BacklogItem };
        }
    }
}
