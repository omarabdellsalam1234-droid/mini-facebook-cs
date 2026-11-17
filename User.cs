public class User
{
    public string Id { get; }
    public string Name { get; private set; }
    public string Password { get; private set; }
    // public Profile Profile { get; }
    public List<User> Friends { get; private set; } = new List<User>();

    
    public User(string id, string name, string password)
    {
        Id = id;
        Name = name;
        Password = password;
    }
    
}