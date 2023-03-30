using AvansDevOps.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Visitor
{
    public class ThreadVisitor : IVisitor
    {
        public void VisitDiscussionThread(DiscussionThread discussionThread)
        {
            Console.WriteLine(discussionThread.Content);
            foreach (var thread in discussionThread.DiscussionThreadComponents)
            {
                thread.AcceptVisitor(this);
            }
        }

        public void VisitMessage(Message message)
        {
            Console.WriteLine(message.ToString());
        }
    }
}
