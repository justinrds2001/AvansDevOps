using AvansDevOps.Observer;
using AvansDevOps.Pipeline;
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
        public Backlog Backlog { get; set; } = new();
        public List<IJob> Jobs { get; set; } = new();
        public SprintState.SprintState SprintState { get; set; } = null!;
        public void UpdateSprintState(SprintState.SprintState sprintState)
        {
            SprintState = sprintState;
        }
    }
}
