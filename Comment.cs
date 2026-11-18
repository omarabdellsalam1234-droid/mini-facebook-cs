public class Comment:Content{

    
    public Post post { get;}

    public Comment(User author,string text,Post post):base(author,text)
    {   
        this.post=post;
    }
    public override void Display()
    {
        Console.Write("  > ");
        base.Display();
    }

}