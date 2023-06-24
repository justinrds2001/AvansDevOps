using AvansDevOps.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Composite
{
    public class Message : DiscussionThreadComponent
    {
        override public void AcceptVisitor(IVisitor visitor)
        {
            visitor.VisitMessage(this);
        }

        public override string GetString()
        {
            throw new NotImplementedException();
        }

        public override void Remove(DiscussionThreadComponent discussionThreadComponent)
        {
            throw new NotImplementedException();
        }

        public override void Replace(DiscussionThreadComponent oldDiscussionThreadComponent, DiscussionThreadComponent newDiscussionThreadComponent)
        {
            throw new NotImplementedException();
        }
    }
}
