# Cuisenie

This app is meant to take a lot of the guess work when meal planning/prepping. To start, it saves the recipes we like and gives suggestions one what to eat for the week based on rating, last time we ate it, and other criteria.

## Azure
This app is deployed using Azure DevOps CI/CD pipelines to multiple Azure App Services. It also utilized API Management tools for API access and leverages Azure Key Vault for app secrets like DB connection strings to an Azure SQL DB. For cost purposes, I won't be using APIm for personal use.

### Generating Code Migrations
This is for my own benefit when changing running code-first migrations

```powershell
# run these from Cuisenie/src folder, not project folder
dotnet ef migrations add <NAME> -c Infrastructure.Data.CuisenieContext -p Infrastructure -s API -o Data/Migrations
dotnet ef database update <NAME> -c Infrastructure.Data.CuisenieContext -p Infrastructure -s API
```