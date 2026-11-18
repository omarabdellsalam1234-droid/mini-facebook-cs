public class User
{
    private static int nextId = 1;
    public int Id { get; }
    private string _name="";

    public string Name
    {
        get { return _name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty");
            _name = value;
        }
    }
    public string _password="";

    public string Password 
    { 
        get{return _password;}

        private set
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Password cannot be empty");
            _password = value;
        }
    }
    public Profile Profile { get; private set; }
    public List<User> Friends { get; private set; } = new List<User>();
    public List<Request> Requests {get; private set;} = new List<Request>();

    
    public User(string name, string password)
    {
        Id = nextId++;
        Name = name;
        Password = password;
        Profile = new Profile();
    }

    public void editProfile(string newName, string newBio)
    {
        this.Profile.Bio=newBio;
        this.Name = newName;
    }

    public void post(string text){

        if(string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("post cannot be empty");
        Post post = new Post(this,text);   
    }

    public void addComment(string text, Post post){

        if(string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("comment cannot be empty");
        Comment Comment = new Comment(this,text,post);
    }

    public void addReact(ReactType type,Post post){

        React react = new React(this,type,post);
    }

    public void sendFreindRequest(User receiver)
    {
        new Request(this,receiver);
    }
    


    
    
}