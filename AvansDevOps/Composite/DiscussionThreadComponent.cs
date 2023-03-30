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
        public string Content { get; set; }

        public abstract void AcceptVisitor(IVisitor visitor);
    }
}