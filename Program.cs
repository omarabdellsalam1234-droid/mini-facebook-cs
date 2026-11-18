User a = new User("omar", "1234");
a.AddPost("hello world");
Post p = a.Posts[0];
a.AddComment("nice post", p);
a.AddReact(ReactType.Like, p);

List<Content> items = new List<Content> { p, p.Comments[0] };
foreach (Content c in items)
    c.Display();


p.Display();