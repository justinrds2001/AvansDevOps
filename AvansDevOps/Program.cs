using AvansDevOps.Composite;
using AvansDevOps.Observer.Users;
using AvansDevOps.Observer;
using AvansDevOps.Visitor;

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


RunObserver();
RunCompositeVisitor();
Console.ReadLine();
