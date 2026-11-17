public class Post
{   
    public static nextId = 1;
    public int Id { get;}
    public User Author { get;}
    public string Text { get; private set; }
    public DateTime CreatedAt { get;}
    public List<Comment> Comments { get; private set; } new List<Comment>(); 
    public List<Like> Likes { get; private set; } = new List<Like>(); 

    public post(Author author, string text){
        Id = nextId++;
        Author=author;
        Text=text;
        CreatedAt = DateTime.now;
    }
}