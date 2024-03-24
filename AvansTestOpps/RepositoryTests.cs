using AvansDevOps.BacklogState;
using AvansDevOps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansTestOpps
{
    public class RepositoryTests
    {
        [Fact]
        public void CanMakeARepositoryWithBranches()
        {
            // Arrange
            Repository repository = new();

            Branch mainBranch = new() { Name = "Main" };
            Branch devBranch = new() { Name = "Development" };

            // Act
            repository.Branches.Add(mainBranch);
            repository.Branches.Add(devBranch);

            // Assert
            Assert.True(repository.Branches.Count == 2);
        }

        [Fact]
        public void CanMakeACommitToABranch()
        {
            // Arrange Act
            Repository repository = new();

            Branch mainBranch = new() { Name = "Main" };
            Branch devBranch = new() { Name = "Development" };

            // Act
            repository.Branches.Add(mainBranch);
            repository.Branches.Add(devBranch);
            bool result = devBranch.Commit("Fixed conflicts");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanMakePullRequestOfABranch()
        {
            // Arrange Act
            Repository repository = new();

            Branch mainBranch = new() { Name = "Main" };
            Branch devBranch = new() { Name = "Development" };

            // Act
            repository.Branches.Add(mainBranch);
            repository.Branches.Add(devBranch);
            bool result = devBranch.MakePullRequest(mainBranch);

            // Assert
            Assert.True(result);
        }
    }
}
