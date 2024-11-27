# Setting up the .NET ASP.NET Web API Application

## Prerequisites

Before you begin, ensure you have the following installed on your machine:

1. **.NET SDK** (version 8 or later) - Download and install from the official [.NET website](https://dotnet.microsoft.com/download).
2. **SQL Server** (or another compatible database provider) - Ensure that you have SQL Server (or another database) installed and running. Alternatively, you can use a local database like SQL Server Express or SQLite.
3. **Visual Studio** (or any IDE of your choice that supports .NET development, such as Visual Studio Code) - Download from the [Visual Studio website](https://visualstudio.microsoft.com/).

## Cloning the Repository

1. Clone the repository to your local machine using Git:
   ```bash
   git clone https://github.com/your-repo-name.git

2. Navigate to the project directory
   ```bash
   cd your-repo-name

## Setting Up the Database
1. AppSettings
   - inside your appsettings double check that the defaultConnection string is correct. By default it will be as follows:
       ```bash
      "ConnectionStrings": {
        "DefaultConnection": "Server=.\\SQLEXPRESS;Database=BookCommerce;Trusted_Connection=True;TrustServerCertificate=True;"
      }

## Running Migrations:
The next part is for if you want to try and see the database for testing. 
1. Open a terminal in your project directory and run the following :
    ```bash
    dotnet ef migrations add InitialCreate
This will create a migration file in the migrations folder. 
2. To apply the migration you have to run the following:
    ```bash
    dotnet ef database update
This should apply the migration onto your database with the test data.
