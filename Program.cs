User a = new User("omar", "1234");
User b = new User("sara", "5678");

a.sendFreindRequest(b);
Console.WriteLine(b.ReceivedRequests.Count);  // should print 1

b.ReceivedRequests[0].Accept();
Console.WriteLine(a.Friends.Count);  // should print 1
Console.WriteLine(b.Friends.Count);  // should print 1

a.AddPost("hello world");
Console.WriteLine(a.Posts.Count);  // should print 1

MiniFacebook app = new MiniFacebook();
app.signUp("omar", "1234");
Console.WriteLine(app.logIn("omar", "1234") != null);   // True
Console.WriteLine(app.logIn("omar", "wrong") != null);  // False
Console.WriteLine(app.signUp("omar", "x") == null);   // True (duplicate)