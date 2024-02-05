using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ISprintFactory
{
    public class ReviewISprintFactory : ISprintFactory
    {
        public Sprint CreateSprint()
        {
            return new ReviewSprint { };
        }
    }
}
