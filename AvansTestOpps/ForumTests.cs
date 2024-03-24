using AvansDevOps.Composite;
using AvansDevOps.Observer;
using AvansDevOps.Observer.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansTestOpps
{
    public class ForumTests
    {
        [Fact]
        public void AddThread_Should_Add_Thread_And_Notify_Subscribers()
        {
            // Arrange
            var forum = new Forum();
            var subscriber1 = new Mock<ISubscriber>();
            var subscriber2 = new Mock<ISubscriber>();
            var thread = new DiscussionThread(new Developer());

            forum.Subscribe(subscriber1.Object);
            forum.Subscribe(subscriber2.Object);

            // Act
            forum.AddThread(thread);

            // Assert
            subscriber1.Verify(s => s.Update("New discussion has started! " + thread.Title), Times.Once);
            subscriber2.Verify(s => s.Update("New discussion has started! " + thread.Title), Times.Once);
            Assert.Contains(thread, forum.Threads);
        }
    }
}
