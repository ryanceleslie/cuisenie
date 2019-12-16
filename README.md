# MealPlanner

This app is meant to take a lot of the guess work when meal planning/prepping. To start, it saves the recipes we like and gives suggestions one what to eat for the week based on rating, last time we ate it, and other criteria.

```powershell
// these work if the connection string is added to the startup project and configured
Add-Migration -Name VariousUpdates -Context Infrastructure.Data.MealPlannerContext -Project Infrastructure -StartupProject API -OutputDir Data/Migrations
Update-Database -Migration VariousUpdates -Context Infrastructure.Data.MealPlannerContext -Project Infrastructure -StartupProject API
```

```powershell
// test these on future updates
dotnet ef migrations add <NAME> -c Infrastructure.Data.MealPlannerContext -p Infrastructure -s API -o Data/Migrations
dotnet ef database update <NAME> -c Infrastructure.Data.MealPlannerContext -p Infrastructure -s API
```