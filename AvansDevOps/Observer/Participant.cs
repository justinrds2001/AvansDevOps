using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Observer
{
    public class Participant: ISubsriber
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Participant(string name, string email)
        {
            Name = name;
            Email = email;
        }

        void ISubsriber.Notify()
        {
            throw new NotImplementedException();
        }
    }
}