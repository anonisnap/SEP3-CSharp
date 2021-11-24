Very nice setup:

1. Install tools
    - dotnet tool install -g dotnet-ef
    
2. Create a migration:
    - dotnet ef migrations add InitialCreate
    
3. Update to Database
    - dotnet ef database update