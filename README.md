# Database Migration Strategy

Use [`EF Core CLI tool`](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

- Check `dotnet-ef` tool in `WebAPP/.config/dotnet-tools.json`.

# Initial DB Schema

```bash
$ dotnet ef database update
```

# Shorthand Script

Run `.WebApp/migration.sh`

Script have 3 step.

- 1. Restore Dotnet Dependencies of projects
- 2. Restore Dotnet Tool
- 3. Update Migration

# Reference

> MS Guide about migration
> https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
