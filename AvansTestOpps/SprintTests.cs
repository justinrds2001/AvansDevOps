using System;
using System.Collections.Generic;
using AvansDevOps.ISprintFactory;
using AvansDevOps.Observer;
using AvansDevOps.Observer.Users;
using AvansDevOps.Pipeline;
using AvansDevOps.SprintFactory;
using AvansDevOps.SprintState;
using Xunit;

namespace AvansDevOps.Tests
{
    public class SprintTests
    {
        static ReleaseSprint MakeReleaseSprint()
        {
            List<Contributor> list = new()
            {
                new Tester() { Name = "Bob" },
                new ScrumMaster() { Name = "Henk-Jan" },
                new Tester() { Name = "Ruben" }
            };

            List<Participant> list2 = new()
            {
                new ProductOwner() { Name = "Johannes Vermeer" }
            };

            list2.AddRange(list);

            Backlog backlog = new()
            {
                BacklogItems = new List<BacklogItem>()
                {
                    new BacklogItem
                    {
                        Title = "Implement feature X",
                        Contributor = list[0],
                        DefinitionOfDone = "Feature X is implemented",
                    },
                    new BacklogItem
                    {
                        Title = "Implement feature Y",
                        Contributor = list[1],
                        DefinitionOfDone = "Feature Y is implemented",
                    },
                    new BacklogItem
                    {
                        Title = "Implement feature Z",
                        Contributor = list[2],
                        DefinitionOfDone = "Feature Z is implemented",
                    }
                }
            };
            List<IJob> jobs = new()
            {
                new AnalyseJob(),
                new PackageJob(),
                new TestJob(),
                new BuildJob(),
                new DeployJob()
            };

            Pipeline.Pipeline pipeline = new()
            {
                Jobs = jobs
            };

            ReleaseSprint releaseSprint = SprintFactory.SprintFactory.CreateReleaseSprint("Release Sprint", new DateTime(2024, 3, 23, 16, 23, 42, DateTimeKind.Utc), new DateTime(2024, 4, 23, 16, 23, 42, DateTimeKind.Utc), list2, pipeline)!;
            foreach (var item in backlog.BacklogItems)
            {
                releaseSprint.AddBacklogItem(item);
            }
            releaseSprint.SetPipeline(pipeline);
            return releaseSprint;
        }

        static ReviewSprint MakeReviewSprint()
        {
            List<Contributor> list = new()
            {
                new Tester() { Name = "Bob" },
                new ScrumMaster() { Name = "Henk-Jan" },
                new Tester() { Name = "Ruben" }
            };

            List<Participant> list2 = new()
            {
                new ProductOwner() { Name = "Johannes Vermeer" }
            };

            list2.AddRange(list);

            Backlog backlog = new()
            {
                BacklogItems = new List<BacklogItem>()
                {
                    new BacklogItem
                    {
                        Title = "Implement feature X",
                        Contributor = list[0],
                        DefinitionOfDone = "Feature X is implemented",
                    },
                    new BacklogItem
                    {
                        Title = "Implement feature Y",
                        Contributor = list[1],
                        DefinitionOfDone = "Feature Y is implemented",
                    },
                    new BacklogItem
                    {
                        Title = "Implement feature Z",
                        Contributor = list[2],
                        DefinitionOfDone = "Feature Z is implemented",
                    }
                }
            };
            List<IJob> jobs = new()
            {
                new AnalyseJob(),
                new PackageJob(),
                new TestJob(),
                new BuildJob(),
                new DeployJob()
            };

            Pipeline.Pipeline pipeline = new()
            {
                Jobs = jobs
            };

            ReviewSprint reviewSprint = SprintFactory.SprintFactory.CreateReviewSprint("Review Sprint", new DateTime(2024, 3, 23, 16, 23, 42, DateTimeKind.Utc), new DateTime(2024, 4, 23, 16, 23, 42, DateTimeKind.Utc), list2, pipeline)!;
            foreach (var item in backlog.BacklogItems)
            {
                reviewSprint.AddBacklogItem(item);
            }
            reviewSprint.SetPipeline(pipeline);
            return reviewSprint;
        }

        [Fact]
        public void ReleaseFactory_Should_Create_ReleaseSprint()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();

            // Act

            // Assert
            Assert.NotNull(sprint);
        }

        [Fact]
        public void ReviewFactory_Should_Create_ReviewSprint()
        {
            // Arrange
            ReviewSprint sprint = MakeReviewSprint();

            // Act

            // Assert
            Assert.NotNull(sprint);
        }

        [Fact]
        public void AddBacklogItem_Should_Allow_Changes_By_Adding_BacklogItem()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();
            BacklogItem backlogItem = new()
            {
                Title = "Implement feature A",
                Contributor = new Tester() { Name = "Bob" },
                DefinitionOfDone = "Feature A is implemented",
            };

            // Act
            sprint.AddBacklogItem(backlogItem);

            // Assert
            Assert.Contains(backlogItem, sprint.Backlog.BacklogItems);
        }

        [Fact]
        public void AddBacklogItem_Should_Not_Allow_Changes_By_Adding_BacklogItem()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();
            sprint.UpdateSprintState(new SprintState.ActiveState());
            sprint.AllowChanges = false;
            BacklogItem backlogItem = new()
            {
                Title = "Implement feature B",
                Contributor = new Tester() { Name = "Bob" },
                DefinitionOfDone = "Feature B is implemented",
            };

            // Act
            sprint.AddBacklogItem(backlogItem);

            // Assert
            Assert.DoesNotContain(backlogItem, sprint.Backlog.BacklogItems);
        }

        [Fact]
        public void StartSprint_From_CreatedState_Should_Go_To_ActiveState()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();

            // Act
            sprint.SprintState.StartSprint(sprint);

            // Assert
            Assert.IsType<ActiveState>(sprint.SprintState);
        }

        [Fact]
        public void FinishSprint_From_ActiveState_Should_Go_To_FinishedState()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();
            sprint.SprintState = new ActiveState();

            // Act
            sprint.SprintState.FinishSprint(sprint);

            // Assert
            Assert.IsType<FinishedState>(sprint.SprintState);
        }

        [Fact]
        public void CancelSprint_From_FinishedState_Should_Go_To_CanceledState()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();
            sprint.SprintState = new FinishedState();

            // Act
            sprint.SprintState.CancelSprint(sprint);

            // Assert
            Assert.IsType<CanceledState>(sprint.SprintState);
        }

        [Fact]
        public void CloseSprint_From_FinishedState_Should_Go_To_ClosedState()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();
            sprint.SprintState = new FinishedState();

            // Act
            sprint.SprintState.CloseSprint(sprint);

            // Assert
            Assert.IsType<ClosedState>(sprint.SprintState);
        }

        [Fact]
        public void CloseSprint_From_FinishedState_Should_Notify_Participants()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();
            sprint.SprintState = new FinishedState();

            // Act
            sprint.SprintState.CloseSprint(sprint);

            // Assert
            Assert.True(sprint.Participants.Count > 0);
        }

        [Fact]
        public void CloseSprint_From_FinishedState_Should_Execute_Pipeline()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();
            sprint.SprintState = new FinishedState();

            // Act
            sprint.SprintState.CloseSprint(sprint);

            // Assert
            Assert.True(sprint.Pipeline!.Jobs.Count > 0);
        }

        [Fact]
        public void Pipeline_Should_Execute_When_Release_Sprint_Is_Set_To_CloseState()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();
            sprint.SprintState = new FinishedState();

            // Act
            sprint.SprintState.CloseSprint(sprint);

            // Assert
            Assert.True(sprint.Participants[0].MessagesReceived > 0);
        }

        [Fact]
        public void CancelSprint_From_CreatedState_Should_Not_Switch_State()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();

            // Act
            sprint.SprintState.CancelSprint(sprint);

            // Assert
            Assert.IsType<CreatedState>(sprint.SprintState);
        }

        [Fact]
        public void CloseSprint_From_CreatedState_Should_Not_Switch_State()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();

            // Act
            sprint.SprintState.CloseSprint(sprint);

            // Assert
            Assert.IsType<CreatedState>(sprint.SprintState);
        }

        [Fact]
        public void FinishSprint_From_CreatedState_Should_Not_Switch_State()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();

            // Act
            sprint.SprintState.FinishSprint(sprint);

            // Assert
            Assert.IsType<CreatedState>(sprint.SprintState);
        }

        [Fact]
        public void StartSprint_From_FinishedState_Should_Not_Switch_State()
        {
            // Arrange
            ReleaseSprint sprint = MakeReleaseSprint();
            sprint.SprintState = new FinishedState();

            // Act
            sprint.SprintState.StartSprint(sprint);

            // Assert
            Assert.IsType<FinishedState>(sprint.SprintState);
        }
    }
}
