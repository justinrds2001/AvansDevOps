using AvansDevOps.Composite;
using AvansDevOps.Observer.Users;
using AvansDevOps.Observer;
using AvansDevOps.Visitor;
using AvansDevOps.BacklogState;
using AvansDevOps;

static void RunCompositeVisitor()
{
    DiscussionThread discussionThread = new DiscussionThread();

    Message parentMessage = new Message { Content = "Parent message content" };
    Message childMessage = new Message { Content = "Child message content" };

    Console.WriteLine(parentMessage.GetType());

    // Add child message to parent message
    parentMessage.Add(childMessage);

    // Since we've added a child message to another message, the parent message should now become a thread
    discussionThread.Add(parentMessage);
    Console.WriteLine(parentMessage.GetType());

    // Visit the discussion thread to print its content
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
    // Creating a new backlog item
    var backlogItem = new BacklogItem
    {
        Title = "Implement feature X",
        BacklogState = new TodoState()
    };

    // Test ToDo to Doing transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToDoing();
    Console.WriteLine($"Transitioning from ToDo to Doing: {backlogItem.BacklogState.GetType().Name}");

    // Test Doing to TestReady transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTestReady();
    Console.WriteLine($"Transitioning from Doing to TestReady: {backlogItem.BacklogState.GetType().Name}");

    // Test TestReady to Testing transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTesting();
    Console.WriteLine($"Transitioning from TestReady to Testing: {backlogItem.BacklogState.GetType().Name}");

    // Test Testing to Tested transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTested();
    Console.WriteLine($"Transitioning from Testing to Tested: {backlogItem.BacklogState.GetType().Name}");

    // Test Tested to Done transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToDone();
    Console.WriteLine($"Transitioning from Tested to Done: {backlogItem.BacklogState.GetType().Name}");

    // Test Done to TestReady transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTestReady();
    Console.WriteLine($"Transitioning from Done to TestReady: {backlogItem.BacklogState.GetType().Name}");

    // Test TestReady to Testing transition again
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTesting();
    Console.WriteLine($"Transitioning from TestReady to Testing: {backlogItem.BacklogState.GetType().Name}");

    // Test Testing to ToDo transition
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToToDo();
    Console.WriteLine($"Transitioning from Testing to ToDo: {backlogItem.BacklogState.GetType().Name}");

    // Test ToDo to Doing transition again
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToDoing();
    Console.WriteLine($"Transitioning from ToDo to Doing: {backlogItem.BacklogState.GetType().Name}");

    // Test Doing to TestReady transition again
    Console.WriteLine($"Current state: {backlogItem.BacklogState.GetType().Name}");
    backlogItem.BacklogState.ToTestReady();
    Console.WriteLine($"Transitioning from Doing to TestReady: {backlogItem.BacklogState.GetType().Name}");

    Console.ReadLine();
}


//RunObserver();
//RunCompositeVisitor();
RunBacklogState();
Console.ReadLine();
