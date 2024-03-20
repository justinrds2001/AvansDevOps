using AvansDevOps.ISprintFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintFactory
{
    public class SprintFactory
    {
        public ReleaseSprint CreateReleaseSprint()
        {
            return new ReleaseSprint();
        }

        public ReviewSprint CreateReviewSprint()
        {
            return new ReviewSprint();
        }
    }
}
