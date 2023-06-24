using AvansDevOps.SprintFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class Project
    {
        public string Name { get; set; }
        public List<BacklogItem> BacklogItems { get; set; } = new();
        public List<Pipeline> Pipelines { get; set; } = new();
        public List<Sprint> Sprints { get; set; } = new();
    }
}
