using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Observer
{
    public class Developer : Contributor
    {
        public Developer(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public override void Notify()
        {
            Console.WriteLine($"Developer {this.Name} has been notified of a new sprint.");
        }
    }
}
