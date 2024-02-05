using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ISprintFactory
{
    public class ReleaseISprintFactory : ISprintFactory
    {
        public Sprint CreateSprint()
        {
            return new ReleaseSprint { };
        }
    }
}
