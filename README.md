# Cuisinie

This app is meant to take a lot of the guess work when meal planning/prepping. To start, it saves the recipes we like and gives suggestions one what to eat for the week based on rating, last time we ate it, and other criteria.

### Making Code Migrations
This is for my own benefit when changing running code-first migrations

```powershell
# run these from Cuisinie folder, not project folder
dotnet ef migrations add <NAME> -c Infrastructure.Data.CuisinieContext -p Infrastructure -s API -o Data/Migrations
dotnet ef database update <NAME> -c Infrastructure.Data.CuisinieContext -p Infrastructure -s API
```