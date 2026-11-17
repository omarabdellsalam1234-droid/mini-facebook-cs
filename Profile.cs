public class Profile
{
    public string Bio{get; private set;}
    public string Photo { get; private set; }
    public string location { get; private set; }
    public string work {get; private set;}

    public Profile(string bio, string photo, string location, string work)
    {
        Bio = bio;
        Photo = photo;
        Location = location;
        Work = work;
    }
    
    

}