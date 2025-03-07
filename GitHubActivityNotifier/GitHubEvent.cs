using System;
using System.Collections.Generic;

namespace GitHubEventNamespace
{
    public class GitHubEvent 
    {
        public string? Id {get; set;}
        public string? Type {get; set;}
        public DateTime? CreatedAt {get; set;}
        public GitHubRepo? Repo {get; set;}
        public GitHubPayload? Payload {get; set;}

    }

    public class GitHubRepo 
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
    }

    public class GitHubPayload
    {
        public string? Ref { get; set; }
        public List<GitHubCommit>? Commits { get; set; }
    }

    public class GitHubCommit
    {
        public string? Sha { get; set; }          // Coincide con "sha"
        public string? Message { get; set; }      // Coincide con "message"
        public GitHubAuthor? Author { get; set; }
    }

    public class GitHubAuthor
    {
        public string? Name { get; set; }         // Coincide con "name"
        public string? Email { get; set; }        // Coincide con "email"
    }
}