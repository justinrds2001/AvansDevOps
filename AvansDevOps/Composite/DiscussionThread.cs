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
        public DiscussionThread(Participant commenter) : base(commenter)
        {
        }

        public List<DiscussionThreadComponent> DiscussionThreadComponents { get; set; } = new();
        public Forum Forum { get; set; } = new();

        public void Add(DiscussionThreadComponent discussionThreadComponent)
        {
            if (IsDiscussionClosed())
            {
                Console.WriteLine("Discussion is closed, can't add new replies.");
                return;
            }
            // Notify forum
            discussionThreadComponent.Parent = this;

            discussionThreadComponent.AssociatedBacklogItem = AssociatedBacklogItem;

            DiscussionThreadComponent topParent = SelectTopLevelParent(discussionThreadComponent);
            topParent.Notify("New reply to discussion! " + discussionThreadComponent.Title);

            DiscussionThreadComponents.Add(discussionThreadComponent);

            topParent.Subscribe(discussionThreadComponent.Commenter!);

        }

        public static DiscussionThreadComponent SelectTopLevelParent(DiscussionThreadComponent discussionThread)
        {
            if (discussionThread.Parent == null)
            {
                return discussionThread;
            }
            return SelectTopLevelParent(discussionThread.Parent);
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
