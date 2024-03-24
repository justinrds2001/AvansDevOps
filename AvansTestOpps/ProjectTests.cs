using AvansDevOps.Pipeline;
using AvansDevOps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansTestOpps
{
    public class ProjectTests
    {
        [Fact]
        public void AddPipeline_Should_Add_Pipeline()
        {
            // Arrange
            var project = new Project();
            var pipeline = new Pipeline();

            // Act
            project.AddPipeline(pipeline);

            // Assert
            Assert.Contains(pipeline, project.Pipelines);
        }

        [Fact]
        public void Project_Initialization_Should_Have_Empty_Collections()
        {
            // Arrange & Act
            var project = new Project();

            // Assert
            Assert.Empty(project.Name);
            Assert.Empty(project.Backlog.BacklogItems);
            Assert.Empty(project.Pipelines);
            Assert.Empty(project.Sprints);
            Assert.Empty(project.Repositories);
            Assert.Empty(project.Participants);
        }
    }
}
