# User Authentication System (.NET 8)

A simple backend API for user registration and login using **ASP.NET Core 8**, **Entity Framework Core**, **Identity**, and **JWT tokens**.

## 🔧 Tech Stack

- C# / .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- ASP.NET Identity
- JWT Bearer Authentication
- SQL Server (LocalDB)
- Swagger (Swashbuckle)

## 📦 Features

- ✅ Register a user with email and password
- ✅ Log in and receive a JWT token
- ✅ Protect endpoints with [Authorize] attribute
- 🧪 Swagger UI for testing APIs

## 📁 Project Structure

/Controllers
└── AuthController.cs
/Data
└── AppDbContext.cs
Program.cs
appsettings.json


## 🛠 Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/UserAuthSystem.git
   cd UserAuthSystem

2. **Add your connection string & JWT key to appsettings.json**

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=UserAuthDb;Trusted_Connection=True;"
},
"Jwt": {
  "Key": "THIS_IS_A_SECRET_KEY_SHOULD_BE_LONG"
}

3. **Install dependencies**

dotnet restore

4. **Run migrations**

dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update


5. **Run migrations**

dotnet run
