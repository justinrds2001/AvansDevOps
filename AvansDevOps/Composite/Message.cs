using AvansDevOps.Composite;
using AvansDevOps.Visitor;

namespace AvansDevOps.Composite
{
    public class Message : DiscussionThreadComponent
    {
        public List<DiscussionThreadComponent> ChildComponents { get; set; } = new List<DiscussionThreadComponent>();
        private DiscussionThreadComponent? parent;

        public override void AcceptVisitor(IVisitor visitor)
        {
            visitor.VisitMessage(this);
            foreach (var component in ChildComponents)
            {
                component.AcceptVisitor(visitor);
            }
        }

        public override string GetString()
        {
            // Return the content of this message followed by the content of child messages
            return $"{Content}\n\t{string.Join("\n\t", ChildComponents)}";
        }

        public override void Add(DiscussionThreadComponent discussionThreadComponent)
        {
            // If the parent exists and it's not already a thread
            if (parent != null && !(parent is DiscussionThread))
            {
                DiscussionThread newThread = new DiscussionThread();
                newThread.Add(this); // Move this message to the new thread
                parent.ReplaceChild(this, newThread); // Replace this message with the new thread
                parent = newThread; // Update parent reference
            }

            DiscussionThreadComponent thread = new DiscussionThread();
            thread.Add(discussionThreadComponent);
            ChildComponents.Add(thread); // Add the new thread as a child component
            parent = thread; // Update parent reference
        }

        public override void Remove(DiscussionThreadComponent discussionThreadComponent)
        {
            ChildComponents.Remove(discussionThreadComponent);
        }

        public override void ReplaceChild(DiscussionThreadComponent oldLeave, DiscussionThreadComponent newNode)
        {
            int index = ChildComponents.IndexOf(oldLeave);
            if (index != -1)
            {
                ChildComponents[index] = newNode;
                newNode.Add(oldLeave); // Move oldLeave to the new node
            }
        }
    }
}