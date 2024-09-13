# 1. Migration
- Open Nuget Manage Console 

## Add migration
```EF
Add-Migration mirationName -Project BusinessObject -StartupProject VemsApi
```

## Run migration
```EF
Update-database -Project BusinessObject -StartupProject VemsApi
```