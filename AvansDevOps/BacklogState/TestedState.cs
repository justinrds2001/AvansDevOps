using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public class TestedState : BacklogState
    {
        public override void ToDone()
        {
            BacklogItem.BacklogState = new DoneState { BacklogItem = BacklogItem };

        }
        public override void ToTestReady()
        {
            // Notify developers
            Console.WriteLine("Notifying developers...");
            BacklogItem.BacklogState = new TestReadyState { BacklogItem = BacklogItem };
        }
    }
}
