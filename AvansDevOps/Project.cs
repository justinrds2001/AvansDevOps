using AvansDevOps.ISprintFactory;
using AvansDevOps.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class Project
    {
        public string Name { get; set; } = string.Empty;
        public Backlog Backlog { get; set; } = new();
        public List<Pipeline.Pipeline> Pipelines { get; set; } = new();
        public List<Sprint> Sprints { get; set; } = new();
        public List<Repository> Repositories { get; set; } = new();
        public List<Participant> Participants { get; set; } = new();
        public void AddPipeline(Pipeline.Pipeline pipeline)
        {
            Pipelines.Add(pipeline);
        }
    }
}
