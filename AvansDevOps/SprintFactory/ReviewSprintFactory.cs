using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintFactory
{
    public class ReviewSprintFactory : SprintFactory
    {
        public Sprint CreateSprint()
        {
            return new ReviewSprint
            {

            };
        }
    }
}
