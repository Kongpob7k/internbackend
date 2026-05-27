# Repair Request API

This is a .NET 8 Web API for managing repair tickets.

## Prerequisites

Before you start, make sure you have the following installed on your machine:
1. **[.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)**
2. **SQL Server Express LocalDB** (Usually installed with Visual Studio's "ASP.NET and web development" workload).

## Step-by-Step Setup Guide

### 1. Clone the Repository
Clone the code to your local machine and navigate into the project folder:
```bash
git clone <your-repository-url>
cd internapi
```

### 2. Install Entity Framework Core CLI (Optional but recommended)
To generate the database using the command line, you need the EF Core tools installed globally. Run this command:
```bash
dotnet tool install --global dotnet-ef
```

### 3. Set Up the Database
The project uses Entity Framework Core with a SQL Server LocalDB. The database doesn't exist on your machine yet, so you need to generate it.

**Option A: Using the Command Line (Terminal / PowerShell)**
Run this command in the folder where the `RepairRequestApi.csproj` file is located:
```bash
dotnet ef database update
```

**Option B: Using Visual Studio**
1. Open the `.sln` file in Visual Studio.
2. Go to **Tools** > **NuGet Package Manager** > **Package Manager Console**.
3. Type the following command and hit Enter:
   ```powershell
   Update-Database
   ```

*This command reads the `appsettings.json` file, connects to your LocalDB, and creates the `RepairRequestDb` database with all the necessary tables.*

### 4. Run the Application

**Using Command Line:**
```bash
dotnet run
```
*Note: You do not need to run a separate "install" command like `npm install`. The `dotnet run` command will automatically restore (download) the required NuGet packages and build the project before starting it.*

**Using Visual Studio:**
Press the **Play (Start)** button or **F5** at the top.

### 5. Test with Swagger
Once the app is running, open your browser and go to the Swagger UI:
- **http://localhost:5217/swagger** (or the port specified in your terminal/launch settings).

From the Swagger UI, you can:
1. Use `POST /api/Auth/register` to create a new user.
2. Use `POST /api/Auth/login` to get a JWT token.
3. Click the **Authorize** button at the top of Swagger, paste the token directly (no "Bearer " prefix needed), and test the protected endpoints!

## Configuration Note
For this development setup, the `Jwt:Key` and Database `DefaultConnection` string are hardcoded in the `appsettings.json` file. You do not need to configure any external environment variables or secrets to get the project running locally.
