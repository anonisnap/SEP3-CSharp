Very nice setup:

1. Install tools
    - dotnet tool install -g dotnet-ef
    
2. Create a migration:
    - dotnet ef migrations add InitialCreate
    
3. Update to Database
    - dotnet ef database update
    
    

Extra:    
If more than one DBContext, do the following:
Add --context <dbName>
- Example
dotnet ef migrations add 4_updatedItemLocationDb --context SEP_DBContext
