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
    private string _password="";

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
    public List<Request> ReceivedRequests { get; private set; } = new List<Request>();
    public List<Request> SentRequests { get; private set; } = new List<Request>();
    public List<Post> Posts { get; private set; } = new List<Post>();
    
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

    public void sendFreindRequest(User receiver)
    {   
        if(this==receiver || Friends.Contains(receiver))
            return;
        foreach (var r in SentRequests)
        {   //check if we already sent a friend request or not
            if(r.Receiver==receiver && r.Status == RequestStatus.Pending)
                return;
        }
        foreach (var s in receiver.SentRequests)
        {   
            //if receiver already sent a friend request to sender then the request is automatically accepted
            if(s.Receiver==this && s.Status == RequestStatus.Pending)
            {
                s.Accept();
                return;
            }
        }
        Request req = new Request(this,receiver);
        this.SentRequests.Add(req);
        receiver.ReceivedRequests.Add(req);

    }
  
    public void AddPost(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("post cannot be empty");
        Posts.Add(new Post(this, text));
    }

    public void AddComment(string text,Post post)
    {
        if(string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Comment cannot be empty");
        post.Comments.Add(new Comment(this,text,post));
    }
    public void AddReact(ReactType type, Post post)
    {
        post.Reacts.Add(new React(this, type, post));
    }
    

}