public class MiniFacebook{
    
    private Dictionary<string, User> Users = new Dictionary<string, User>();
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
    

}