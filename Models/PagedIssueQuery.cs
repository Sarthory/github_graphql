namespace GithubGraphql.Models
{
  public static class PagedIssueQuery
  {
    public const string Query = @"
        query ($repo_name: String!,  $start_cursor:String) {
          repository(owner: ""ahape"", name: $repo_name) {
            issues(last: 50, before: $start_cursor) {
              pageInfo {
                hasPreviousPage
                startCursor
              }
              nodes {
                labels(last: 50) {        
                  nodes{
                    name
                    description
                    issues(last: 50){
                      nodes{
                        author{
                          login                          
                        }
                        bodyText
                        createdAt
                        authorAssociation
                        title
                      }
                    }
                  }
                }
                title
                number
                createdAt
              }
            }
          }
        }";
  }
}
