using AvansDevOps.Observer;
using AvansDevOps.Observer.Users;
using AvansDevOps.Pipeline;
using AvansDevOps.SprintState;
using System;
using System.Collections.Generic;

namespace AvansDevOps.ISprintFactory
{
    public abstract class Sprint : Publisher
    {
        private string name = string.Empty;
        private DateTime startDate;
        private DateTime endDate;
        private Backlog backlog = new Backlog();
        private Pipeline.Pipeline? pipeline;
        private List<Participant> participants = new List<Participant>();
        private bool allowChanges = true;
        private readonly string errorMessage = "Changes are not allowed.";

        public string Name
        {
            get => name;
            set
            {
                if (!allowChanges)
                    Console.WriteLine(errorMessage);
                else
                    name = value;
            }
        }

        public DateTime StartDate
        {
            get => startDate;
            set
            {
                if (!allowChanges)
                    Console.WriteLine(errorMessage);
                else
                    startDate = value;
            }
        }

        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (!allowChanges)
                    Console.WriteLine(errorMessage);
                else
                    endDate = value;
            }
        }

        public Backlog Backlog
        {
            get => backlog;
            set
            {
                if (!allowChanges)
                    Console.WriteLine(errorMessage);
                else
                    backlog = value;
            }
        }

        public Pipeline.Pipeline? Pipeline
        {
            get => pipeline;
            set
            {
                if (!allowChanges)
                    Console.WriteLine(errorMessage);
                else
                    pipeline = value;
            }
        }

        public List<Participant> Participants
        {
            get => participants;
            set
            {
                if (!allowChanges)
                    Console.WriteLine(errorMessage);
                else
                    participants = value;
            }
        }

        public bool AllowChanges
        {
            get => allowChanges;
            set => allowChanges = value;
        }

        public SprintState.SprintState SprintState { get; set; } = new CreatedState();

        public void UpdateSprintState(SprintState.SprintState sprintState)
        {
            SprintState = sprintState;
        }

        public void AddBacklogItem(BacklogItem backlogItem)
        {
            if (!allowChanges)
                Console.WriteLine(errorMessage);
            else
            {
                backlogItem.Sprint = this;
                Backlog.BacklogItems.Add(backlogItem);
            }

        }

        public void SetPipeline(Pipeline.Pipeline pipeline)
        {
            if (!allowChanges)
                Console.WriteLine(errorMessage);
            else
            {
                var scrumMaster = Participants.Find(participant => participant.GetType() == typeof(ScrumMaster));
                var productOwner = Participants.Find(participant => participant.GetType() == typeof(ProductOwner));
                if (scrumMaster != null) pipeline.Subscribe(scrumMaster);
                if (productOwner != null) pipeline.Subscribe(productOwner);
                this.Pipeline = pipeline;
            }
        }

        public void ExecutePipeline()
        {
            if (Pipeline == null)
            {
                Console.WriteLine("No pipeline set");
                return;
            }
            Pipeline.Execute();
        }
    }
}
