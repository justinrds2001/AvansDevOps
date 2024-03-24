using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Observer
{
    public abstract class Participant : ISubscriber
    {
        public string Name { get; set; } = string.Empty;
        public int MessagesReceived { get; set; } = 0;

        public void Update(string message)
        {
            MessagesReceived++;
            Console.WriteLine($"{Name} received message: {message}");
        }
    }
}
