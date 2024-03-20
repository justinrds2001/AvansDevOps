using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public class TestReadyState : BacklogState
    {
        public override void ToTesting()
        {
            BacklogItem.BacklogState = new TestingState { BacklogItem = BacklogItem };
        }
    }
}
