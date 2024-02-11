# WoueShop
WoueShop an E-Commerce website built with Asp.Net core 8 and blazor

## Database
For Database I will be using PostgreSQL with EF core 8, This project follows the Code-First approach to generate database schema.

## Getting Started
### Set up the environment
- Add these keys in the appsettings file inside of the Project named WoueShop (main project) as follows

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=WoueShopDb;User ID=postgres;Password=password;"
  },
  "AppSettings": {
    "BASE_ADDRESS": "https://localhost:7045/" 
  }
}
```

Change the values to your according if needed.

### Set up the Database
- This project requires a Database, When you have added the proper connection string in the appsettings file run the migration command from your terminal

```bash
dotnet ef database update -s WoueShop/WoueShop -p WoueShop.Data
```

With this the database schema will be generated and the application is ready to boot up.