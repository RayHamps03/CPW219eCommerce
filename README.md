# Ray's PC Components
This is a website made to learn and practice the fundamentals
of ASP.NET Core MVC (Model-View-Controller).

## Features
### Styling with [Bootstrap 5](https://getbootstrap.com/)
This application uses Bootstrap 5 automatically with ASP.NET Core, a web-development framework used to assist in creating fast, responsive websites.

### CRUD (Create, Retrieve, Update, Delete) functionality with Entity Framework Core
Entity Framework Core allows this application to work with a database to provide CRUD functionality to this application's entities.
<img width="400" height="250" alt="image" src="https://github.com/user-attachments/assets/7c0afbc4-3e3d-4369-850c-0242444546ee" />
> Image provided by [manubes](https://www.manubes.com/what-is-crud/)

### Login/Register
Session middleware provided by ASP.NET Core is used to allow sessions so that the login information by the current user is tracked.

### MVC Pattern
The MVC (Model-View-Controller) pattern is used to process data that is passed through the application in a way that:
- Models manage data and their rules
- The controller requests the needed data
- The view returns a response of said processed data in the UI

## Installation and How to Run
1) Clone or download this repository
2) Download .NET 10 SDK
3) Visual Studio 2026 recommended
4) Open in VS 2026
5) Under tools at the top, click 'NuGet Package Manager' > 'Package Manager Console' (Required for full app functionality)
<img width="522" height="412" alt="Screenshot 2026-03-13 174557" src="https://github.com/user-attachments/assets/849b2a80-54a9-4cb9-9ce9-532d53c15390" /> <br>
6) In the Package Manager Console, type the following: <br>
  `Update-Database`
7) Click run

## Technologies/Frameworks Used
- ASP.Net Core MVC with C#
- Entity Framework Core
- Bootstrap 5
- HTML/CSS/JS
