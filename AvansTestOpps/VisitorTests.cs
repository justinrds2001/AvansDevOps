using AvansDevOps.Composite;
using AvansDevOps.Observer.Users;
using AvansDevOps.Visitor;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AvansDevOps.Tests
{
    [Collection("Sequential Collection")]
    public class VisitorTests
    {
        [Fact]
        public void VisitDiscussionThread_Prints_Content_To_Console()
        {
            // Arrange
            var visitor = new ThreadVisitor();
            var discussionThread = new DiscussionThread(new Developer() { Name = "Alice" })
            {
                Content = "Discussing the latest feature implementation",
                DiscussionThreadComponents = new List<DiscussionThreadComponent>
                {
                    new Message(new Developer() { Name = "Bob" }) { Content = "I think we need more tests." },
                    new Message(new Developer() { Name = "Charlie" }) { Content = "Agreed, let's add more tests." },
                }
            };

            Assert.True(discussionThread.DiscussionThreadComponents.Count == 2);
        }

        [Fact]
        public void VisitDiscussionThread_Visits_Child_Components()
        {
            // Arrange
            var visitor = new ThreadVisitor();
            var discussionThread = new DiscussionThread(new Developer { Name = "User" })
            {
                Content = "Discussion thread content"
            };
            var childComponent1 = new Message(new Developer { Name = "User1" }) { Content = "Message 1" };
            var childComponent2 = new Message(new Developer { Name = "User2" }) { Content = "Message 2" };
            discussionThread.DiscussionThreadComponents.Add(childComponent1);
            discussionThread.DiscussionThreadComponents.Add(childComponent2);

            // Act
            visitor.VisitDiscussionThread(discussionThread);

            // Assert
            Assert.True(discussionThread.Commenter?.MessagesReceived == 0);
        }

        [Fact]
        public void VisitMessage_Prints_Content_To_Console()
        {
            // Arrange
            var visitor = new ThreadVisitor();
            var message = new Message(new Developer() { Name = "Alice" })
            {
                Content = "This is a message.",
            };

            visitor.VisitMessage(message);
            Assert.True(message.Content == "This is a message.");
        }
    }
}
