public class React{
    
    

    private static int nextId = 1;
    public int Id { get;}
    public User Owner { get;}
    public ReactType Type {get; private set;} 
    public Post post { get;}

    public React(User owner,ReactType type,Post post)
    {   
        Owner=owner;
        this.post=post;
        Type=type;

        Id=nextId++;
        
    }

}