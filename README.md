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

## How to contribute
- General rule
    1. Assign a [issue](https://github.com/TeamKDA/KorDevAus/issues) to you
    2. Create a featured branch from the master branch
    3. Show your magic
    4. Send a Pull Request!!
- CSS
    - We use [BEM naming methodology](https://css-tricks.com/bem-101/)
    - Please also read the [maintainable css guide](https://maintainablecss.com/) 
    - SASS? We want to use SASS! But It should be integrated with ASP.NET CORE Project in a simple manner. We want to hear your idea.
- JavaScript
    - TODO
- Controller
    - TODO
- Model
    - TODO