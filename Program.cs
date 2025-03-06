using System;
using System.Linq;
using GithubGraphql.Services;
using GithubGraphql.Models;

var key = Environment.GetEnvironmentVariable("GitHubKey") ?? throw new InvalidOperationException("Key not found");
var gitHubService = new GitHubService(key);

await foreach (var issue in gitHubService.RunPagedQueryAsync(PagedIssueQuery.Query, "github_graphql"))
{
    if (issue["labels"]["nodes"].Any(n => (string)n["name"] == "bug"))
    {
        Console.WriteLine(issue);
    }
}
