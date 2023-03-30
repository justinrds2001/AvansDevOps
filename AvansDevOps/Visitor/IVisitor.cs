using AvansDevOps.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Visitor
{
    public interface IVisitor
    {
        public void VisitDiscussionThread(DiscussionThread discussionThread);
        public void VisitMessage(Message message);
    }
}