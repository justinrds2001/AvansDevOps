﻿using AvansDevOps.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Composite
{
    public class DiscussionThread : DiscussionThreadComponent
    {
        public List<DiscussionThreadComponent> DiscussionThreadComponents { get; set; } = new List<DiscussionThreadComponent>();


        override public void Add(DiscussionThreadComponent discussionThreadComponent)
        {
            DiscussionThreadComponents.Add(discussionThreadComponent);
        }

        override public void Remove(DiscussionThreadComponent discussionThreadComponent)
        {
            DiscussionThreadComponents.Remove(discussionThreadComponent);
        }
        
        override public void ReplaceChild(DiscussionThreadComponent oldLeave, DiscussionThreadComponent newNode)
        {
            Remove(oldLeave);
            Add(newNode);
        }


        override public void AcceptVisitor(IVisitor visitor)
        {
            visitor.VisitDiscussionThread(this);
        }

        override public string GetString()
        {
            return string.Join("\n\t", DiscussionThreadComponents.Select(x => x.ToString()).ToList());
        }
    }
}
