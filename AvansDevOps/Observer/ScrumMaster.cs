using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Observer
{
    public class ScrumMaster : Contributor
    {
        public ScrumMaster(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public void Notify()
        {
            Console.WriteLine("Scrum master {0} has been notified.", this.Name);
        }
    }
}
