﻿using AvansDevOps.Composite;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AvansDevOps.Observer
{
    public class Forum : Publisher
    {
        public List<DiscussionThread> Threads { get; set; } = new();
    }
}