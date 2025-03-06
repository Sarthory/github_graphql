## Task

Using Github's [GraphQL API](https://docs.github.com/en/graphql), query for issues in this repository containing the label "bug".

## Prerequisites

- Github account
- The latest .NET SDK/runtime (version 9 or later)

The .NET SDK/runtime comes with Visual Studio, but using the [.NET CLI](https://dotnet.microsoft.com/en-us/download) works fine too.

## Setup

Once all the prerequisites are satisfied, you'll need to perform the following setup steps.

1. Clone this repo
1. Create a [Github PAT](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-personal-access-token-classic) that is given the following permissions: `public_repo` and `repo:status`
1. Assign the value of the new PAT to the following environment variable: `GitHubKey=YOUR_ACCESS_TOKEN`. This environment variable must be accessible by the program
1. Run the program (`F5` in Visual Studio, or `dotnet run` using the CLI)

## Result

Running the program successfully should reveal in the console the result of the GraphQL query (1 issue).

## Fixed GraphQL query/response error
![image](https://github.com/user-attachments/assets/8ac07331-a4aa-42bf-8cf6-26e2f6ec2368)
