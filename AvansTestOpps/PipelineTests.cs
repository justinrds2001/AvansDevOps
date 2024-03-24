using AvansDevOps.BacklogState;
using AvansDevOps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Pipeline;
using AvansDevOps.ISprintFactory;
using AvansDevOps.Observer.Users;
using AvansDevOps.Observer;
using AvansDevOps.SprintFactory;

namespace AvansTestOpps
{
    public class PipelineTests
    {
        private static Pipeline MakePipeline()
        {
            PackageJob packageJob = new();
            BuildJob buildJob = new();
            TestJob testJob = new();
            DeployJob deployJob = new();
            UtilityJob utilityJob = new();
            Pipeline pipeline = new();
            pipeline.AddJob(packageJob);
            pipeline.AddJob(buildJob);
            pipeline.AddJob(testJob);
            pipeline.AddJob(utilityJob);
            pipeline.AddJob(deployJob);
            return pipeline;
        }

        [Fact]
        public void ShouldBeAbleToMakePipelineWithJobs()
        {
            // Arrange Act
            Pipeline pipeline = MakePipeline();

            // Assert
            Assert.True(pipeline.Jobs.Count == 5);
        }

        [Fact]
        public void ShouldNotifyScrumMasterAndProductOwnerIfReleasePipelineIsSuccessful()
        {
            // Arrange
            Pipeline pipeline = MakePipeline();
            Tester tester = new() { Name = "John Doe" };
            Developer developer = new() { Name = "Steve" };
            ProductOwner owner = new() { Name = "Denzel" };
            ScrumMaster master = new() { Name = "Bryan" };
            List<Participant> participants = new()
            {
                tester,
                developer,
                owner,
                master,
            };
            Sprint sprint = SprintFactory.CreateReleaseSprint("Test", DateTime.Now, DateTime.Now, participants, pipeline)!;
            sprint.SprintState.StartSprint(sprint);
            sprint.SprintState.FinishSprint(sprint);
            bool result = pipeline.Execute();
            sprint.SprintState.CloseSprint(sprint);

            // Assert
            Assert.True(result);
            Assert.Equal(1, owner.MessagesReceived);
            Assert.Equal(1, master.MessagesReceived);
            Assert.Equal(0, tester.MessagesReceived);
        }

        [Fact]
        public void ShouldNotifyScrumMasterAndProductOwnerIfPipelineIsNotSuccessful()
        {
            // Arrange
            Pipeline pipeline = MakePipeline();
            Tester tester = new() { Name = "John Doe" };
            Developer developer = new() { Name = "Steve" };
            ProductOwner owner = new() { Name = "Denzel" };
            ScrumMaster master = new() { Name = "Bryan" };
            List<Participant> participants = new()
            {
                tester,
                developer,
                owner,
                master,
            };
            Sprint sprint = SprintFactory.CreateReleaseSprint("Test", DateTime.Now, DateTime.Now, participants, pipeline)!;
            sprint.SprintState.StartSprint(sprint);
            sprint.SprintState.FinishSprint(sprint);
            bool result = pipeline.Execute(false);
            sprint.SprintState.CancelSprint(sprint);

            // Assert
            Assert.False(result);
            Assert.Equal(1, owner.MessagesReceived);
            Assert.Equal(1, master.MessagesReceived);
            Assert.Equal(0, tester.MessagesReceived);
        }
    }
}
