using AvansDevOps.Observer;
using AvansDevOps.Observer.Users;
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
        public Pipeline.Pipeline pipeline { get; set; } = new();
        public List<Participant> Participants { get; set; } = new();

        public SprintState.SprintState SprintState { get; set; } = null!;
        public void UpdateSprintState(SprintState.SprintState sprintState)
        {
            SprintState = sprintState;
        }

        public void AddBacklogItem(BacklogItem backlogItem)
        {
            backlogItem.Sprint = this;
            Backlog.BacklogItems.Add(backlogItem);
        }

        public void SetPipeline(Pipeline.Pipeline pipeline)
        {
            var scrumMaster = Participants.Find(participant => participant.GetType() == typeof(ScrumMaster));
            if (scrumMaster != null)
            {
                pipeline.Subscribe(scrumMaster);
            }
            this.pipeline = pipeline;
        }

        public void ExecutePipeline()
        {
            pipeline.Execute();
        }
    }
}
