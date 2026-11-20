
class Program
{
    static MiniFacebook app = new MiniFacebook();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Sign Up\n2. Log in\n0. Exit");
            Console.Write("> ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {   
                Console.Write("Username: ");
                string name = Console.ReadLine();
                Console.Write("Password: ");
                string pass = Console.ReadLine();

                User? user = app.signUp(name, pass);
                if (user == null) Console.WriteLine("Username taken.");
                else
                {
                    Console.WriteLine("Registered.");
                    UserMenu(user);
                }
            }
            else if (choice == "2")
            {
                Console.Write("Username: ");
                string name = Console.ReadLine();
                Console.Write("Password: ");
                string pass = Console.ReadLine();

                User user = app.logIn(name, pass);
                if (user == null) Console.WriteLine("Wrong username or password.");
                else UserMenu(user);
            }
            else if (choice == "0") break;
            else Console.WriteLine("Invalid choice.");
        }
    }

    static void UserMenu(User user)
    {
        while (true)
        {
            Console.WriteLine($"\nLogged in as {user.Name}");
            Console.WriteLine("1. Create post\n2. Display Feed\n3. Send friend request\n4. View Pending friend requests\n0. Log out");
            Console.Write("> ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Write your post: ");

                string text = Console.ReadLine();
                try
                {   
                    Post p = new Post(user,text);
                    user.Posts.Add(p);
                    app.Posts.Add(p);
                    Console.WriteLine("Posted.");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (choice == "2")
            {
                app.DisplayFeed(user);
                Console.Write("Choose Post to comment or react (type id): ");
                if(int.TryParse(Console.ReadLine(),out int postId))
                {
                    Post post = app.Posts.Find(x => x.Id == postId);
                    if(post != null)
                        PostMenu(app,user,post);
                    else
                        Console.WriteLine("Post not found.");
                }
                else
                {
                     Console.WriteLine("Please enter a number.");
                }

                
            }
            else if (choice == "3")
            {
                Console.Write("Send to username: ");
                string target = Console.ReadLine();
                try
                {
                    if (app.Users.TryGetValue(target, out User other))
                    {
                        user.sendFreindRequest(other);
                        Console.WriteLine("Request sent.");
                    }
                    else Console.WriteLine("User not found.");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (choice == "4")
            {
                if (user.ReceivedRequests.Count == 0) Console.WriteLine("No requests.");
                user.DisplayPendingRequests();

            }
            else if (choice == "0") return;
            else Console.WriteLine("Invalid choice.");
        }
    }
    static void PostMenu(MiniFacebook app, User user, Post post)
    {
        while (true)
        {
            Console.WriteLine("1. Comment  2. React  3. Back");
            Console.Write("> ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Comment: ");
                try
                {
                    user.AddComment(Console.ReadLine(),post);
                    Console.WriteLine("Comment added.");
                }
                catch (ArgumentException e) { Console.WriteLine(e.Message); }
            }
            else if (choice == "2")
            {
                Console.Write("Reaction type(Like, Love, Angry): ");
                string input = Console.ReadLine()!;

                if (Enum.TryParse<ReactType>(input, ignoreCase: true, out var type)
                    && Enum.IsDefined(type))
                {
                    user.AddReact(type,post);
                    Console.WriteLine("Reacted.");
                }
                else
                {
                    Console.WriteLine("Unknown reaction.");
                }
            }
            else if (choice == "3") return;
            else Console.WriteLine("Invalid choice.");
        }
    }
}
