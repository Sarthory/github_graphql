using Newtonsoft.Json;
using System.Collections.Generic;

namespace GithubGraphql.GraphQL
{
    public class GraphQLRequest
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("variables")]
        public Dictionary<string, object> Variables { get; } = new();

        public string ToJsonText() => JsonConvert.SerializeObject(this);
    }
}
