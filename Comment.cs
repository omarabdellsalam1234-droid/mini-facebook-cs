public class Comment{

    private static nextId = 1;
    public int Id { get;}
    public User Author { get;}
    public string Text { get; private set; }
    public DateTime CreatedAt { get;}
    public Post post { get;}

    public Comment(User author,string text,Post post)
    {   
        Author=author;
        Text=text;
        Post=post;

        Id=nextId++;
        CreatedAt = DateTime.Now;
    }

}