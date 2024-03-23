using AvansDevOps.Observer;
using AvansDevOps.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Composite
{
    public abstract class DiscussionThreadComponent : Publisher
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DiscussionThreadComponent? Parent { get; set; }
        public Participant? Commenter { get; set; }

        protected DiscussionThreadComponent(Participant commenter)
        {
            Commenter = commenter;
            Subscribe(Commenter);
        }

        public abstract void AcceptVisitor(IVisitor visitor);
        public abstract string GetString();
    }
}