using AvansDevOps.Composite;
using AvansDevOps.Observer.Users;
using AvansDevOps.Visitor;
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

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                visitor.VisitDiscussionThread(discussionThread);

                // Assert
                var expectedOutput = "Alice: Discussing the latest feature implementation" + Environment.NewLine +
                                     "Bob: I think we need more tests." + Environment.NewLine +
                                     "Charlie: Agreed, let's add more tests." + Environment.NewLine;
                Assert.Equal(expectedOutput, sw.ToString());
            }
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

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                visitor.VisitMessage(message);

                // Assert
                Assert.Equal("Alice: This is a message." + Environment.NewLine, sw.ToString());
            }
        }
    }
}
