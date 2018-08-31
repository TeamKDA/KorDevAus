## Prerequisites
- [.NET Core SDK 2.1](https://www.microsoft.com/net/download/dotnet-core/2.1)

## Quick Start
```sh
cd src/KorDevAus
dotnet restore
dotnet dev-certs https --trust
dotnet run
```
Go to https://localhost:5001/ in your browser

## Tech stack used for this app
- ASP.NET CORE
- Backend
    - Azure
    - Azure Active Directory B2C
- Frontend
    - [LibMan](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/?view=aspnetcore-2.1) 
    - [Turbolinks](https://github.com/turbolinks/turbolinks)
    - [Stimulus](https://stimulusjs.org/)
    - jQuery, Bootstrap