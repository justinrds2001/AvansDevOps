using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Observer
{
    public abstract class Participant : ISubscriber
    {
        public String Name { get; set; }

        public void Update(string message)
        {
            Console.WriteLine($"{Name} received message: {message}");
        }
    }
}
