using Octokit;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using GithubGraphql.GraphQL;
using GithubGraphql.Utils;
using System.Linq;

namespace GithubGraphql.Services
{
    public class GitHubService
    {
        private readonly GitHubClient _client;

        public GitHubService(string apiKey) => _client = new GitHubClient(new ProductHeaderValue("IssueQueryDemo"))
        {
            Credentials = new Credentials(apiKey)
        };

        public async IAsyncEnumerable<JToken> RunPagedQueryAsync(
            string queryText,
            string repoName)
        {
            var issueAndPRQuery = new GraphQLRequest
            {
                Query = queryText
            };

            issueAndPRQuery.Variables["repo_name"] = repoName;

            bool hasMorePages = true;
            var uri = new Uri("https://api.github.com/graphql");
            const string respType = "application/json";

            for (var pagesReturned = 0; hasMorePages && pagesReturned < 10; pagesReturned++)
            {
                var response = await _client.Connection.Post<string>(
                    uri,
                    issueAndPRQuery.ToJsonText(),
                    respType,
                    respType
                );

                var results = JObject.Parse(response.HttpResponse.Body.ToString());
                hasMorePages = (bool)QueryHelper.PageInfo(results)["hasPreviousPage"];
                issueAndPRQuery.Variables["start_cursor"] = QueryHelper.PageInfo(results)["startCursor"].ToString();

                foreach (JObject issue in QueryHelper.Issues(results)["nodes"].Cast<JObject>())
                {
                    yield return issue;
                }
            }
        }
    }
}
