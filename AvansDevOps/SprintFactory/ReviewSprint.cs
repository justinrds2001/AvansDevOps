using AvansDevOps.SprintState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ISprintFactory
{
    public class ReviewSprint : Sprint
    {
        public void CreateSprint()
        {
            SprintState = new CreatedState() {

            };
        }
    }
}