using AvansDevOps.ISprintFactory;
using AvansDevOps.Observer;
using AvansDevOps.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintFactory
{
    public static class SprintFactory
    {
        public static ReleaseSprint? CreateReleaseSprint(string name, DateTime startDate, DateTime endDate, List<Participant> participants, Pipeline.Pipeline pipeline)
        {

            if (pipeline.Jobs.Last().GetType() != typeof(DeployJob))
            {
                Console.WriteLine("Last job in pipeline should be a DeployJob");
                return null;
            }            
            ReleaseSprint sprint = new()
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Participants = participants
            };

            sprint.SetPipeline(pipeline);

            foreach (Participant participant in participants)
            {
                sprint.Subscribe(participant);
            }

            return sprint;
        }

        public static Sprint CreateReleaseSprint(string v, DateTime now1, DateTime now2, List<Participant> participants)
        {
            throw new NotImplementedException();
        }

        public static ReviewSprint CreateReviewSprint(string name, DateTime startDate, DateTime endDate, List<Participant> participants, Pipeline.Pipeline? pipeline = null)
        {

            ReviewSprint sprint = new()
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Participants = participants
            };

            if (pipeline != null)
            {
                sprint.SetPipeline(pipeline);
            }

            foreach (Participant participant in participants)
            {
                sprint.Subscribe(participant);
            }

            return sprint;
        }
    }
}
