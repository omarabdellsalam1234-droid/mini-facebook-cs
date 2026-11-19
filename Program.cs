
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
            Console.WriteLine("1. Create post\n2. Display Feed\n3. Send friend request\n4. View friend requests\n0. Log out");
            Console.Write("> ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Write your post: ");
                user.Posts.Add(new Post(user,Console.ReadLine()));
                Console.WriteLine("Posted.");
            }
            else if (choice == "2")
            {
                app.DisplayFeed(user);
            }
            else if (choice == "3")
            {
                Console.Write("Send to username: ");
                string target = Console.ReadLine();
                if (target != user.Name && app.Users.TryGetValue(target, out User other))
                {
                    user.sendFreindRequest(other);
                    Console.WriteLine("Request sent.");
                }
                else Console.WriteLine("User not found.");
            }
            else if (choice == "4")
            {
                if (user.ReceivedRequests.Count == 0) Console.WriteLine("No requests.");
                for (int i = 0; i < user.ReceivedRequests.Count; i++)
                    Console.WriteLine($"{i + 1}. {user.ReceivedRequests[i].Sender.Name}");

                if (user.ReceivedRequests.Count > 0)
                {
                    Console.Write("Number to accept (0 to skip): ");
                    if (int.TryParse(Console.ReadLine(), out int n) && n >= 1 && n <= user.ReceivedRequests.Count)
                    {
                        user.ReceivedRequests[n - 1].Accept();
                        Console.WriteLine("Accepted.");
                    }
                }
            }
            else if (choice == "0") return;
            else Console.WriteLine("Invalid choice.");
        }
    }
}
