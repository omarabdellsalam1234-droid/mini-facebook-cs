public class React{
    
    public enum TYPE{Like,Love,Angry}

    private static nextId = 1;
    public int Id { get;}
    public User Owner { get;}
    public TYPE Type {get; private set;} 
    public Post post { get;}

    public React(User owner,TYPE type,Post post)
    {   
        Owner=owner;
        Post=post;
        Type=type;

        Id=nextId++;
        
    }

}