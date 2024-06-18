# DemoPageRank

## Technologies
- ASP.NET Core 8
- Entity Framework Core 8 and EF InMemory
- CQRS & MediatR
- FluentValidation
- React

## Getting Started
### Prerequisites
- Visual Studio 2022 and Visual Studio Code
- .NET Core SDK 8.0
- Uses EF Core InMemory for the demo, so we don't need to install any database tools.

### Setups
#### Visual Studio
- Open DemoPageRank.sln file in DemoPageRank folder
- In Visual Studio, Build and Run the project as Https profile
#### Client app
- Go to DemoPageRank/src/demo-app folder
- run ```npm install```
- run ```npm run start```

### Port configuration
- API is configured to port https://localhost:7007 as HTTPS Profile in the file Properties/launchSettings.json 
- The React app is configured to run on port 3000 and calls the backend API on port 7007 in file .env.
