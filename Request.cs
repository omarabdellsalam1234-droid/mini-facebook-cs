public class Request{

    private static int nextId = 1;
    public int Id { get;}

    
    public User Sender { get;}
    public User Receiver { get;}
    public DateTime CreatedAt { get;}

    public RequestStatus Status { get; private set; }

    public Request(User sender, User receiver)
    {
        Status = RequestStatus.Pending;
        Sender = sender;
        Receiver = receiver;
        Id = nextId++;
        CreatedAt = DateTime.Now;

    }

    
    public void Accept()
    {
        if (Status != RequestStatus.Pending) return;
        Status = RequestStatus.Accepted;
        Sender.Friends.Add(Receiver);
        Receiver.Friends.Add(Sender);
    }
    public void Reject()
    {
        if (Status != RequestStatus.Pending) return;
        Status = RequestStatus.Reject;
    }

}