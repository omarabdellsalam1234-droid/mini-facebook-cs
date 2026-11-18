public class MiniFacebook{
    public List<User> Users {get; private set;} = new List<User>();
    public List<Post> Posts {get; private set;} = new List<Post>();
    
    public void signUp(string name,string password)
    {
        User user = new User(name,password);
        Users.Add(user);
        
    }

    public User? logIn(string name,string password)
    {   
        
        foreach(User user in Users)
        {
            if(user.Name == name && user.Password == password)
                return user;
        }
        return null;
    }
    

}