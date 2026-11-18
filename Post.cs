public class Post
{   
    private static int nextId = 1;
    public int Id { get;}
    public User Author { get;}
    public string Text { get; private set; }
    public DateTime CreatedAt { get;}
    public List<Comment> Comments { get; private set; } = new List<Comment>(); 
    public List<React> Reacts { get; private set; } = new List<React>(); 

    public Post(User author, string text){
        Id = nextId++;
        Author=author;
        Text=text;
        CreatedAt = DateTime.Now;
    }
    
    
}
