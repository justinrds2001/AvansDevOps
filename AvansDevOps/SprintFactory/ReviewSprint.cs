using AvansDevOps.SprintState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintFactory
{
    public class ReviewSprint : Sprint
    {
        public ISprintState SprintState { get; set; }

        public void CreateSprint()
        {
            SprintState = new CreatedState() {

            };
        }
    }
}
