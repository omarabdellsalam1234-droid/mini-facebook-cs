public class Request{

    private static nextId = 1;
    public int Id { get;}

    public enum STATUS {Pending,Accepted,Denied}
    public User Sender { get;}
    public User Receiver { get;}
    public STATUS Status {get; private set;}
    public DateTime CreatedAt { get;}

    public Request(User sender,User receiver, STATUS status)
    {   
        Status=status;
        Sender = sender;
        Receiver = receiver;

        Id=nextId++;
        CreatedAt = DateTime.Now;
    }

}