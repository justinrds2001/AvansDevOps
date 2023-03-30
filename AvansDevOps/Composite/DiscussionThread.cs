using AvansDevOps.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Composite
{
    public class DiscussionThread : DiscussionThreadComponent
    {
        public List<DiscussionThreadComponent> DiscussionThreadComponents { get; set; }

        public DiscussionThread()
        {
            DiscussionThreadComponents = new();
        }

        public void Add(DiscussionThreadComponent discussionThreadComponent)
        {
            DiscussionThreadComponents.Add(discussionThreadComponent);
        }

        // TODO: Remove maybe?

        override public void AcceptVisitor(IVisitor visitor)
        {
            visitor.VisitDiscussionThread(this);
        }
    }
}
