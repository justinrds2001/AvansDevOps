using AvansDevOps.Observer;
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
        public List<DiscussionThreadComponent> DiscussionThreadComponents { get; set; } = new();
        public Forum Forum { get; set; } = new();


        public void Add(DiscussionThreadComponent discussionThreadComponent)
        {
            // Notify forum
            Forum.Notify("New reply to discussion! " + discussionThreadComponent.Title);
            DiscussionThreadComponents.Add(discussionThreadComponent);
        }

        public void Remove(DiscussionThreadComponent discussionThreadComponent)
        {
            DiscussionThreadComponents.Remove(discussionThreadComponent);
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
