using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Observer
{
    public abstract class Participant : ISubsriber
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        void ISubsriber.Notify()
        {
            throw new NotImplementedException();
        }
    }
}
