using AvansDevOps.Observer;
using AvansDevOps.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Composite
{
    public abstract class DiscussionThreadComponent
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        

        public abstract void AcceptVisitor(IVisitor visitor);
        public abstract void ReplaceChild(DiscussionThreadComponent oldLeave, DiscussionThreadComponent newNode);
        public abstract void Remove(DiscussionThreadComponent discussionThreadComponent);
        public abstract void Add(DiscussionThreadComponent discussionThreadComponent);
        public abstract string GetString();
    }
}