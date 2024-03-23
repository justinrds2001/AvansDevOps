using AvansDevOps.Composite;
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

static ReviewSprint MakeSprint()
{
    var factory = new SprintFactory();
    List<Contributor> list = new()
    {
        new Tester() { Name = "Bob" },
        new ScrumMaster() { Name = "Henk-Jan" },
        new Tester() { Name = "Ruben" }
    };

    List<Participant> list2 = new()
    {
        new Tester() { Name = "Bob" },
        new ScrumMaster() { Name = "Henk-Jan" },
        new Tester() { Name = "Ruben" }
    };

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
        new TestJob()
    };

    Pipeline pipeline = new()
    {
        Jobs = jobs
    };

    ReviewSprint reviewSprint = factory.CreateSprint<ReviewSprint>("Review Sprint", new DateTime(), new DateTime(), pipeline, list2);
    foreach (var item in backlog.BacklogItems)
    {
        reviewSprint.AddBacklogItem(item);
    }
    return reviewSprint;
}

static void RunCompositeVisitor()
{
    ScrumMaster scrummaster = new() { Name = "Henk-Jan" };
    Developer developer = new() { Name = "Bob" };
    Tester tester = new() { Name = "Ruben" };

    DiscussionThread discussionThread = new DiscussionThread(scrummaster) { 
        Title = "Code comments",
        Content = "What is the deal with the unnecessary amount of commented code?",
    };

    DiscussionThread parentMessage = new(developer) { Content = "That was our intern!" };
    Message childMessage = new(scrummaster) { Content = "We... Don't have any interns..." };
    DiscussionThread anotherParentMessage = new(tester) { Content = "I think we should remove the commented code." };
    Message anotherChildMessage = new(scrummaster) { Content = "Bob should do that!" };

    discussionThread.Add(parentMessage);
    parentMessage.Add(childMessage);
    parentMessage.Add(anotherParentMessage);
    anotherParentMessage.Add(anotherChildMessage);

    Console.WriteLine("Discussion Thread Content:");

    ThreadVisitor visitor = new ThreadVisitor();
    discussionThread.AcceptVisitor(visitor);
}

static void RunObserver()
{
    // Create a Forum
    Forum forum = new Forum();

    // Create some participants
    Participant participant1 = new Developer() { Name = "Bob" };
    Participant participant2 = new ScrumMaster() { Name = "Henk-Jan" };
    Participant participant3 = new Tester() { Name = "Ruben" };

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
    ReviewSprint sprint = MakeSprint();
    // Creating a new backlog item
    var backlogItem = sprint.Backlog.BacklogItems[0];

    backlogItem.BacklogState = new TodoState { BacklogItem = backlogItem };

    // Test ToDo to Doing transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToDoing();
    Console.WriteLine($"Transitioning from ToDo to Doing: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test Doing to TestReady transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTestReady();
    Console.WriteLine($"Transitioning from Doing to TestReady: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test TestReady to Testing transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTesting();
    Console.WriteLine($"Transitioning from TestReady to Testing: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test Testing to Tested transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTested();
    Console.WriteLine($"Transitioning from Testing to Tested: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test Tested to Done transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToDone();
    Console.WriteLine($"Transitioning from Tested to Done: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test Done to TestReady transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTestReady();
    Console.WriteLine($"Transitioning from Done to TestReady: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    backlogItem.UpdateBacklogItemState(new TestReadyState() { BacklogItem = backlogItem });

    // Test TestReady to Testing transition again
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTesting();
    Console.WriteLine($"Transitioning from TestReady to Testing: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test Testing to ToDo transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToToDo();
    Console.WriteLine($"Transitioning from Testing to ToDo: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test ToDo to Doing transition again
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToDoing();
    Console.WriteLine($"Transitioning from ToDo to Doing: {backlogItem.BacklogState.GetType().Name}");

    Console.WriteLine();

    // Test Doing to TestReady transition again
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTestReady();
    Console.WriteLine($"Transitioning from Doing to TestReady: {backlogItem.BacklogState.GetType().Name}");
}

static void RunSprintState()
{
    var sprint = MakeSprint();

    sprint.UpdateSprintState(new CreatedState() { Sprint = sprint });

    // Test starting the sprint
    Console.WriteLine($"Current state: {sprint.SprintState.GetType().Name}");
    sprint.SprintState.StartSprint();
    Console.WriteLine($"Transitioning to Active: {sprint.SprintState.GetType().Name}");

    Console.WriteLine();

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
    ExportStrategy pdfStrategy = new PDF();
    ExportStrategy pngStrategy = new PNG();

    // Generating report using selected strategy
    pdfStrategy.GenerateReport(report);
    pngStrategy.GenerateReport(report);
}

//Console.WriteLine("Observer Pattern\n----------------");
//RunObserver();
//Console.WriteLine("\n_________________________________________________________________________________\n");
//Console.WriteLine("Composite and Visitor Patterns\n------------------------------");
//RunCompositeVisitor();
//Console.WriteLine("\n_________________________________________________________________________________\n");
//Console.WriteLine("Backlog State Pattern\n---------------------");
RunBacklogState();
//Console.WriteLine("\n_________________________________________________________________________________\n");
//Console.WriteLine("Sprint State Pattern\n--------------------");
//RunSprintState();
//Console.WriteLine("\n_________________________________________________________________________________\n");
//Console.WriteLine("Strategy Pattern\n----------------");
//RunReportStrategy();
