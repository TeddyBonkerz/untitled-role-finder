# untitled-role-finder
To run locally on windows.
- Install .NET 8.0
- Install NodeJs to have access to npm and npx for MCP server.
- Run app with `dotnet run`

To set up user secrets.
- run `dotnet user-secrets init` if you have never run it before.
- run the command with appropriate keys
`dotnet user-secrets set "OpenAI:ApiKey" "API_KEY"`