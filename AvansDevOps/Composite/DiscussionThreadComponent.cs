using AvansDevOps.Observer;
using AvansDevOps.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Composite
{
    public abstract class DiscussionThreadComponent: Publisher
    {
        // content string property
        private string Content { get; set; }

        public abstract void AcceptVisitor(IVisitor visitor);
        public abstract void Replace(DiscussionThreadComponent oldDiscussionThreadComponent, DiscussionThreadComponent newDiscussionThreadComponent);
        public abstract void Remove(DiscussionThreadComponent discussionThreadComponent);

        public abstract string GetString();
    }
}