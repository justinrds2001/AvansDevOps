using AvansDevOps.Observer;
using AvansDevOps.Observer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class Pipeline: Publisher
    {
        public List<IJob> Jobs { get; set; } = new();


        public void AddJob(IJob job)
        {
            Jobs.Add(job);
        }

        public bool Execute(bool passed = true)
        {
            bool success = true;
            foreach (IJob job in Jobs)
            {
                success = job.Execute(passed);
                if (!success)
                {
                    NotifySpecificParticipant<ScrumMaster>("The pipeline has failed!");
                    NotifySpecificParticipant<ProductOwner>("The pipeline has failed!");
                    break;
                }
            }
            return success;
        }
    }
}
