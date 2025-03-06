using Newtonsoft.Json.Linq;

namespace GithubGraphql.Utils
{
    public static class QueryHelper
    {
        public static JObject PageInfo(JObject result) => (JObject)Issues(result)["pageInfo"];

        public static JObject Issues(JObject result) => (JObject)result["data"]["repository"]["issues"];
    }
}
