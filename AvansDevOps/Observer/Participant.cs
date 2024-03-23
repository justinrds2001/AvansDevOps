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

        public void Update(string message)
        {
            Console.WriteLine($"{Name} received message: {message}");
        }
    }
}
