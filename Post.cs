public class Post:Content
{   
    
    public List<Comment> Comments { get; private set; } = new List<Comment>(); 
    public List<React> Reacts { get; private set; } = new List<React>(); 

    public Post(User author, string text):base(author,text){}

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"  {Reacts.Count} reacts, {Comments.Count} comments");
    }
    
    
}
