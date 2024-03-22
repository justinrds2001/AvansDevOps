using AvansDevOps.Observer;
using AvansDevOps.SprintState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ISprintFactory
{
    public abstract class Sprint : Publisher
    {
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SprintState.SprintState SprintState { get; set; } = null!;
        public void UpdateSprintState(SprintState.SprintState sprintState)
        {
            SprintState = sprintState;
        }
    }
}
