public class Post:Content
{   
    
    public List<Comment> Comments { get; private set; } = new List<Comment>(); 
    public List<React> Reacts { get; private set; } = new List<React>(); 

    public Post(User author, string text):base(author,text){}


    public override void Display()
    {
        base.Display();
        var reactsByType = Reacts.GroupBy(x => x.Type).OrderBy(o => o.Count());

        foreach(var group in reactsByType)
        {
            Console.WriteLine($"->{group.Key}:{group.Count()}");
             
        }
        foreach(var c in Comments)
        {
            Console.WriteLine("\n\t");
            c.Display();
        }
    }
    
    
}
