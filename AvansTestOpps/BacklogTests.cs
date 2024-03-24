using AvansDevOps;
using AvansDevOps.BacklogState;
using AvansDevOps.Composite;
using AvansDevOps.ISprintFactory;
using AvansDevOps.Observer;
using AvansDevOps.Observer.Users;
using AvansDevOps.SprintFactory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansTestOpps
{
    public class BacklogTests
    {
        [Fact]
        public void ItemShouldStartAtToDo()
        {
            // Arrange Act
            BacklogItem item = new();

            // Assert
            Assert.True(item.BacklogState is TodoState);
        }

        [Fact]
        public void ItemShouldBeAbleToChangeStates()
        {
            // Arrange
            BacklogItem item = new();

            // Act
            item.BacklogState.ToDoing(item);
            item.BacklogState.ToTestReady(item);
            item.BacklogState.ToTesting(item);
            item.BacklogState.ToTested(item);
            item.BacklogState.ToDone(item);

            // Act
            Assert.True(item.BacklogState is DoneState);
        }

        [Fact]
        public void ItemShouldNotBeAbleToSkipStates()
        {
            // Arrange
            BacklogItem item = new();

            // Act
            item.BacklogState.ToDone(item);

            // Assert
            Assert.False(item.BacklogState is DoneState);
            Assert.True(item.BacklogState is TodoState);
        }

        [Fact]
        public void TestersShouldGetNotifiedIfItemIsTestReady()
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw);

            Tester tester = new() { Name = "John Doe" };
            Developer developer = new() { Name = "Steve" };
            BacklogItem item = new();
            List<Participant> participants = new();
            Sprint sprint = SprintFactory.CreateReviewSprint("Test", DateTime.Now, DateTime.Now, participants);
            sprint.AddBacklogItem(item);

            item.BacklogState.ToDoing(item);
            item.BacklogState.ToTestReady(item);

            // Assert
            Assert.Contains($"{tester.Name} received message: Backlog item is ready for testing", sw.ToString());
            Assert.DoesNotContain(developer.Name, sw.ToString());
        }
    }
}
