﻿using AvansDevOps.Observer;
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

        public bool Execute()
        {
            bool success = true;
            foreach (IJob job in Jobs)
            {
                success = job.Execute();
                if (!success)
                {
                    Notify("Pipeline failed");
                    break;
                }
            }
            return success;
        }
    }
}