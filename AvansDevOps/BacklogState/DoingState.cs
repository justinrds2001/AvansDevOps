using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogState
{
    public class DoingState : BacklogState
    {

        public override void ToTestReady()
        {
            // Notify testers
            Console.WriteLine("Notifying testers...");
           BacklogItem.BacklogState = new TestReadyState { BacklogItem = BacklogItem };
        }
    }
}
