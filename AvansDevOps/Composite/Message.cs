using AvansDevOps.Composite;
using AvansDevOps.Observer;
using AvansDevOps.Visitor;

namespace AvansDevOps.Composite
{
    public class Message : DiscussionThreadComponent
    {
        public Message(Participant commenter) : base(commenter)
        {

        }

        public List<DiscussionThreadComponent> ChildComponents { get; set; } = new List<DiscussionThreadComponent>();

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
    }
}