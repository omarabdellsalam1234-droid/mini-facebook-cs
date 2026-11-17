public class MiniFacebook{
    public List<User> Users {get; private set;} = new List<User>();
    public List<post> Posts {get; private set;} = new List<post>();
    
    public boolean signUp(string name,string password)
    {
        User user = new User(name,password);
        Users.Add(user);
    }

    public User logIn(string name,string password)
    {
        foreach(User user in Users)
        {
            if(!user.Name.CompareTo(name)&&!user.Password.CompareTo(password))
                return user;
        }
    }
    

}