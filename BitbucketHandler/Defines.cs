namespace BitbucketHandler
{
    using System.Collections.Generic;
    
    public class Label
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }

    public class User
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string Gravatar_URL { get; set; }
        public string Gravatar_Id { get; set; }
        public string URL { get; set; }
    }

    public class Milestone
    {
        public string Url { get; set; }
        public int Number { get; set; }
        public string State { get; set; }
    }

    public class PullRequest
    {
    }

    public class Issue
    {
        //public string Url { get; set; }
        //public string HTML_Url { get; set; }
        public int Number { get; set; }
        public string State { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public User User { get; set; }
        public List<Label> Labels { get; set; }
        public User Asignee { get; set; }
        public Milestone Milestone { get; set; }
        public int Comments { get; set; }
        public PullRequest Pull_Request { get; set; }
        public string Closed_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

    }
}