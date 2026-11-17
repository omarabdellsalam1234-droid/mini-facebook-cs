public class MiniFacebook{
    public List<User> Users {get; private set;} = new List<User>();
    public List<post> Posts {get; private set;} = new List<post>();
    
    public boolean signUp(string name,string password)
    {
        User user = new User(name,password);
        Users.Add(user);
        //add to database
    }

    public User logIn(string name,string password)
    {   
        //m4 3aref law fe 7ga to5os el database hena wala la2
        foreach(User user in Users)
        {
            if(!user.Name.CompareTo(name)&&!user.Password.CompareTo(password))
                return user;
        }
    }
    

}