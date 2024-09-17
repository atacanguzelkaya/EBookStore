# Ebook Store

This project is an online bookstore built using ASP.NET Core and MVC. It follows clean code techniques adhering to SOLID principles, utilizing the Repository and Service Patterns. The Individual Account system is integrated for user management, and MSSQL is used as the database. The interface is built with Bootstrap and Jquery, while data handling is done using EntityFrameworkCore and Automapper.

## Features

- Developed with ASP.NET Core MVC
- Clean code structure following SOLID principles
- Implementation of Repository and Service Patterns
- Data management with MSSQL
- Data handling using Entity Framework Core
- Data mapping with Automapper
- User-friendly interface with Jquery and Bootstrap
- Individual Account system for user management

## Technologies Used

- **ASP.NET Core 8**
- **MVC**
- **Entity Framework Core**
- **Automapper**
- **MSSQL**
- **JQuery**
- **Bootstrap**
- **Repository Pattern**
- **Service Pattern**
- **Individual Account Authentication**

## Live Demo

[Check out the live version of the project](https://ebookstore-atacanguzelkaya.somee.com/)

## Installation

1. Clone this repository:
   ```bash
   git clone https://github.com/username/ebookstore.git
   ```

2. Set up your MSSQL server and modify the connection string in the `appsettings.json` file.

3. Install the required dependencies:
   ```bash
   dotnet restore
   ```

4. Apply migrations to create the database:
   ```bash
   dotnet ef database update
   ```

5. Run the project:
   ```bash
   dotnet run
   ```
