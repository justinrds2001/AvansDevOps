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
    public class SprintFactory
    {
        public static T CreateSprint<T>(string name, DateTime startDate, DateTime endDate, Pipeline.Pipeline pipeline, List<Participant> participants)
            where T : Sprint, new()
        {
            
            T sprint = new T()
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                pipeline = pipeline,
                Participants = participants
            };

            foreach (Participant participant in participants)
            {
                sprint.Subscribe(participant);
            }

            return sprint;
        }
    }
}
