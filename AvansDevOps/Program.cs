﻿using AvansDevOps.Composite;
using AvansDevOps.Observer.Users;
using AvansDevOps.Observer;
using AvansDevOps.Visitor;
using AvansDevOps.BacklogState;
using AvansDevOps;
using AvansDevOps.ISprintFactory;
using AvansDevOps.SprintState;
using AvansDevOps.SprintFactory;
using AvansDevOps.ReportStrategy;
using AvansDevOps.Pipeline;

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

    Pipeline pipeline = new()
    {
        Jobs = jobs
    };

    ReleaseSprint releaseSprint = SprintFactory.CreateReleaseSprint("Review Sprint", new DateTime(2024, 3, 23, 16, 23, 42, DateTimeKind.Utc), new DateTime(2024, 4, 23, 16, 23, 42, DateTimeKind.Utc), list2, pipeline);
    foreach (var item in backlog.BacklogItems)
    {
        releaseSprint.AddBacklogItem(item);
    }
    releaseSprint.SetPipeline(pipeline);
    return releaseSprint;
}

static void RunCompositeVisitor()
{
    ScrumMaster scrummaster = new() { Name = "Ende Rest" };
    Developer developer = new() { Name = "Bobby" };
    Tester tester = new() { Name = "Ernst" };
    BacklogItem backlogItem = new BacklogItem()
    {
        Title = "Implement composite pattern",
        BacklogState = new TodoState(),
    };

    DiscussionThread discussionThread = new DiscussionThread(scrummaster) {
        Title = "Code comments",
        Content = "What is the deal with the unnecessary amount of commented code?",
        AssociatedBacklogItem = backlogItem
    };

    DiscussionThread parentMessage = new(developer) { Content = "That was our intern!" };
    Message childMessage = new(scrummaster) { Content = "We... Don't have any interns..." };
    DiscussionThread anotherParentMessage = new(tester) { Content = "I think we should remove the commented code." };
    Message anotherChildMessage = new(scrummaster) { Content = "Bob should do that!" };

    discussionThread.Add(parentMessage);
    parentMessage.Add(childMessage);
    parentMessage.Add(anotherParentMessage);
    anotherParentMessage.Add(anotherChildMessage);

    backlogItem.BacklogState = new DoneState();
    Message anotherChildMessage2 = new(developer) { Content = "I will do that!" };
    anotherParentMessage.Add(anotherChildMessage2);

    Console.WriteLine("Discussion Thread Content:");

    ThreadVisitor visitor = new ThreadVisitor();
    discussionThread.AcceptVisitor(visitor);
}

static void RunObserver()
{
    // Create a Forum
    Forum forum = new Forum();

    // Create some participants
    Participant participant1 = new Developer() { Name = "Bassie" };
    Participant participant2 = new ScrumMaster() { Name = "Adriaan" };
    Participant participant3 = new Tester() { Name = "Enzo" };

    // Subscribe participants to the forum
    forum.Subscribe(participant1);
    forum.Subscribe(participant2);
    forum.Subscribe(participant3);

    // Publish a message
    forum.Notify("Meeting starts at 10:00 AM");

    // Unsubscribe a participant
    forum.Unsubscribe(participant2);

    // Publish another message
    forum.Notify("We should get a new Scrum Master!");
}

static void RunBacklogState(){
    ReleaseSprint sprint = MakeReleaseSprint();
    // Creating a new backlog item
    var backlogItem = sprint.Backlog.BacklogItems[0];
    // Test To-Do to Doing transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToDoing(backlogItem);
    Console.WriteLine($"Transitioning from ToDo to Doing: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test Doing to TestReady transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTestReady(backlogItem);
    Console.WriteLine($"Transitioning from Doing to TestReady: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test TestReady to Testing transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTesting(backlogItem);
    Console.WriteLine($"Transitioning from TestReady to Testing: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test Testing to Tested transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTested(backlogItem);
    Console.WriteLine($"Transitioning from Testing to Tested: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test Tested to Done transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToDone(backlogItem);
    Console.WriteLine($"Transitioning from Tested to Done: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test Done to TestReady transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTestReady(backlogItem);
    Console.WriteLine($"Transitioning from Done to TestReady: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    backlogItem.UpdateBacklogItemState(new TestReadyState());

    // Test TestReady to Testing transition again
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTesting(backlogItem);
    Console.WriteLine($"Transitioning from TestReady to Testing: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test Testing to To-Do transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToToDo(backlogItem);
    Console.WriteLine($"Transitioning from Testing to ToDo: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test To-Do to Doing transition again
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToDoing(backlogItem);
    Console.WriteLine($"Transitioning from ToDo to Doing: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test Doing to TestReady transition again
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTestReady(backlogItem);
    Console.WriteLine($"Transitioning from Doing to TestReady: {backlogItem.BacklogState.GetType().Name}");
}

static void RunSprintState()
{
    var sprint = MakeReleaseSprint();

    sprint.UpdateSprintState(new CreatedState() { Sprint = sprint });

    // Test starting the sprint
    Console.WriteLine($"Current state: {sprint.SprintState.GetType().Name}");
    sprint.SprintState.StartSprint();
    Console.WriteLine($"Transitioning to Active: {sprint.SprintState.GetType().Name}");

    Console.WriteLine();

    sprint.AddBacklogItem(new BacklogItem() { Title = "Implement feature X" });

    // Test finishing the sprint
    Console.WriteLine($"Current state: {sprint.SprintState.GetType().Name}");
    sprint.SprintState.FinishSprint();
    Console.WriteLine($"Transitioning to Finished: {sprint.SprintState.GetType().Name}");

    Console.WriteLine();

    // Test closing the sprint
    Console.WriteLine($"Current state: {sprint.SprintState.GetType().Name}");
    sprint.SprintState.CancelSprint();
    Console.WriteLine($"Transitioning to Canceled: {sprint.SprintState.GetType().Name}");

    sprint.UpdateSprintState(new ActiveState() { Sprint = sprint });
    Console.WriteLine("\nTransitioning back to active...\n");

    Console.WriteLine($"Current state: {sprint.SprintState.GetType().Name}");
    sprint.SprintState.FinishSprint();
    Console.WriteLine($"Transitioning to Finished: {sprint.SprintState.GetType().Name}");

    Console.WriteLine();

    // Test closing the sprint
    Console.WriteLine($"Current state: {sprint.SprintState.GetType().Name}");
    sprint.SprintState.CloseSprint();
    Console.WriteLine($"Transitioning to Closed: {sprint.SprintState.GetType().Name}");

}

static void RunReportStrategy()
{
    var report = new Report()
    {
        Footer = "This is the report footer",
        Content = "This is the report content",
        Header = "This is the report header"
    };

    // Choosing export strategy (PDF or PNG)
    IExportStrategy pdfStrategy = new Pdf();
    IExportStrategy pngStrategy = new Png();

    // Generating report using selected strategy
    pdfStrategy.GenerateReport(report);
    pngStrategy.GenerateReport(report);
}

string divider = "\n_________________________________________________________________________________\n";

Console.WriteLine("Observer Pattern\n----------------");
RunObserver();
Console.WriteLine();
Console.WriteLine("Composite and Visitor Patterns\n------------------------------");
RunCompositeVisitor();
Console.WriteLine(divider);
Console.WriteLine("Backlog State Pattern\n---------------------");
RunBacklogState();
Console.WriteLine(divider);
Console.WriteLine("Sprint State Pattern\n--------------------");
RunSprintState();
Console.WriteLine(divider);
Console.WriteLine("Strategy Pattern\n----------------");
RunReportStrategy();
