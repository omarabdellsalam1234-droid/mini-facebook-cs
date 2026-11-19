public abstract class Content
{
    private static int nextId = 1;
    public int Id { get; }
    public User Owner { get; }
    public string Text { get; private set; }
    public DateTime CreatedAt { get; }

    protected Content(User owner, string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Text cannot be empty");
        Id = nextId++;
        Owner = owner;
        Text = text;
        CreatedAt = DateTime.Now;
    }

    public virtual void Display()
    {
        Console.WriteLine($"{Owner.Name}: {Text}");
        Console.WriteLine($"created on: {CreatedAt:yyyy-MM-dd}");

    }
}