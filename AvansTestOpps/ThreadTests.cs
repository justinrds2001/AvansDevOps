using AvansDevOps;
using AvansDevOps.BacklogState;
using AvansDevOps.Composite;
using AvansDevOps.Observer;
using AvansDevOps.Observer.Users;
using AvansDevOps.Visitor;
using Microsoft.VisualBasic;
using Moq;
using Message = AvansDevOps.Composite.Message;

namespace AvansTestOpps
{
    //User story 2: Als gebruiker wil een discussie kunnen starten bij een project
    public class ThreadTests
    {
        [Fact]
        public void User_Can_Open_A_Discussion_Thread()
        {
            // Arrange
            Developer developer = new() { Name = "Bobby" };
            BacklogItem backlogItem = new BacklogItem()
            {
                Title = "Implement composite pattern",
                BacklogState = new TodoState(),
            };

            DiscussionThread discussionThread = new DiscussionThread(developer)
            {
                Title = "Code comments",
                Content = "What is the deal with the unnecessary amount of commented code?",
                AssociatedBacklogItem = backlogItem,
            };

            // Assert
            Assert.Equal("Code comments", discussionThread.Title);
            Assert.Equal("What is the deal with the unnecessary amount of commented code?", discussionThread.Content);
            Assert.Same(developer, discussionThread.Commenter);
            Assert.Same(backlogItem, discussionThread.AssociatedBacklogItem);
        }

        [Fact]
        public void Adding_Reply_To_Closed_BacklogItem_Should_Return_Console_Message()
        {
            // Arrange
            var participant = new Developer();
            var backlogItem = new BacklogItem();
            backlogItem.UpdateBacklogItemState(new DoneState() { BacklogItem = backlogItem });
            var discussionThread = new DiscussionThread(participant);
            discussionThread.AssociatedBacklogItem = backlogItem;
            var reply = new Message(participant);

            // Act
            discussionThread.Add(reply);

            // Assert
            Assert.True(participant.MessagesReceived == 0);

        }

        [Fact]
        public void Adding_Reply_To_Open_BacklogItem_Should_Add_Message()
        {
            // Arrange
            Developer developer = new() { Name = "Bobby" };
            BacklogItem backlogItem = new BacklogItem()
            {
                Title = "Implement composite pattern",
                BacklogState = new TodoState(),
            };

            DiscussionThread discussionThread = new DiscussionThread(developer)
            {
                Title = "Code comments",
                Content = "What is the deal with the unnecessary amount of commented code?",
                AssociatedBacklogItem = backlogItem
            };

            DiscussionThread reply = new DiscussionThread(developer) { Content = "That was our intern!" };
            discussionThread.AssociatedBacklogItem = backlogItem;

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                discussionThread.Add(reply);

                // Assert
                Assert.True(developer.MessagesReceived == 1);
            }
        }

        [Fact]
        public void DiscussionThread_SelectTopLevelParent_WhenParentIsNull_ShouldReturnDiscussionThread()
        {
            // Arrange
            var discussionThread = new DiscussionThread(new Developer());

            // Act
            var result = DiscussionThread.SelectTopLevelParent(discussionThread);

            // Assert
            Assert.Same(discussionThread, result);
        }

        [Fact]
        public void DiscussionThread_SelectTopLevelParent_WhenParentIsNotNull_ShouldReturnTopLevelParent()
        {
            // Arrange
            var discussionThread = new DiscussionThread(new Developer());
            var childComponent = new Message(new Developer());
            childComponent.Parent = discussionThread;

            // Act
            var result = DiscussionThread.SelectTopLevelParent(childComponent);

            // Assert
            Assert.Same(discussionThread, result);
        }

        [Fact]
        public void Message_AcceptVisitor_ShouldVisitMessageAndChildComponents()
        {
            // Arrange
            var visitor = new Mock<IVisitor>();
            var message = new Message(new Developer());
            var childComponent1 = new Message(new Developer());
            var childComponent2 = new Message(new Developer());
            message.ChildComponents.Add(childComponent1);
            message.ChildComponents.Add(childComponent2);

            // Act
            message.AcceptVisitor(visitor.Object);

            // Assert
            visitor.Verify(v => v.VisitMessage(message), Times.Once);
            visitor.Verify(v => v.VisitMessage(childComponent1), Times.Once);
            visitor.Verify(v => v.VisitMessage(childComponent2), Times.Once);
        }

        [Fact]
        public void Adding_Reply_Should_Notify_All_Participants()
        {
            // Arrange
            Developer participant1 = new Developer() { Name = "Participant 1" };
            Developer participant2 = new Developer() { Name = "Participant 2" };
            Developer participant3 = new Developer() { Name = "Participant 3" };

            // Arrange
            Developer developer = new() { Name = "Bobby" };
            BacklogItem backlogItem = new BacklogItem()
            {
                Title = "Implement composite pattern",
                BacklogState = new TodoState(),
            };

            DiscussionThread discussionThread = new DiscussionThread(developer)
            {
                Title = "Code comments",
                Content = "What is the deal with the unnecessary amount of commented code?",
                AssociatedBacklogItem = backlogItem
            };

            discussionThread.AssociatedBacklogItem = backlogItem;

            discussionThread.Subscribe(participant1);
            discussionThread.Subscribe(participant2);
            discussionThread.Subscribe(participant3);

            var reply = new Message(participant2) { Content = "This is a reply." };

            // Act
            Assert.True(participant1.MessagesReceived == 0);
            Assert.True(participant2.MessagesReceived == 0);
            Assert.True(participant3.MessagesReceived == 0);
        }

    }
}