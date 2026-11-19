public class MiniFacebook{
    
    public Dictionary<string, User> Users = new Dictionary<string, User>();
    public List<Post> Posts {get; private set;} = new List<Post>();
    
    public User? signUp(string name,string password)
    {
        if (Users.ContainsKey(name))
            return null;   // name is taken
        User user = new User(name, password);
        Users.Add(name, user);
        return user;
        
    }

    public User? logIn(string name,string password)
    {   
        if (Users.ContainsKey(name) && Users[name].Password == password)
            return Users[name];

        return null;
    }
    public List<Post> GetFeed(User user)
    {
        return Posts
            .Where(p => p.Owner == user || user.Friends.Contains(p.Owner))
            .OrderByDescending(p => p.CreatedAt)
            .ToList();
    }

    public void DisplayFeed(User user)
    {
        foreach (var post in GetFeed(user))
            post.Display();
    }

    
    

}