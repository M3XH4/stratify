# KPI Management System — Deployment Guide

This guide covers deployment for the Windows Forms client, ASP.NET Core Web API, and SQL Server database.

## 1) Database Deployment

### Where to deploy SQL Server
- Local office server with SQL Server
- Windows Server with SQL Server Express/Standard
- Azure SQL Database
- Somee / SmarterASP.NET (small projects)

### Create production database
1. Install SQL Server (or Azure SQL).
2. Create a new database: `KpiManagementDb`.
3. Create a SQL login or configure Windows authentication.

### Run EF Core migrations
Update `KPI.API/appsettings.json` with your SQL connection string.

```bash
# install EF tools if needed

dotnet tool install --global dotnet-ef

# add migration (first time)
dotnet ef migrations add InitialCreate -p KPI.Data -s KPI.API

# apply to database
dotnet ef database update -p KPI.Data -s KPI.API
```

### Connection strings
`KPI.API/appsettings.json`:

```
"ConnectionStrings": {
  "DefaultConnection": "Server=SERVER;Database=KpiManagementDb;User Id=USER;Password=PASSWORD;TrustServerCertificate=True;"
}
```

Use environment variables in production when possible.

### Backup/restore
- SQL Server Management Studio → `Backup Database`
- Restore via SSMS → `Restore Database`

## 2) API Deployment (ASP.NET Core)

### Recommended hosting
- IIS on Windows Server
- Azure App Service
- SmarterASP.NET / Somee
- Windows VPS

### Publish API
```bash
dotnet publish KPI.API -c Release -o .\publish\api
```

### Configure `appsettings.json`
- Update `DefaultConnection`
- Update `EmailSettings`
- Update `AdminUser`

### Secure API
- Enable HTTPS (certificate)
- Restrict firewall to 443
- Enable JWT auth for production

### Test API
- `GET /api/roles`
- `POST /api/auth/login`

## 3) Windows Forms Deployment

### Publish WinForms
```bash
dotnet publish KPI.WinForms -c Release -r win-x64 --self-contained true -o .\publish\winforms
```

### Update API base URL
Edit `KPI.WinForms/Program.cs`:
```
new ApiClient("https://your-api-domain")
```

### Installer options
- ClickOnce
- MSIX
- Inno Setup
- Advanced Installer

### User installation
- Distribute installer or ClickOnce URL
- Ensure firewall allows outbound HTTPS to the API

## 4) Recommended Deployment Setup

**WinForms App (clients)** → **Web API** → **SQL Server**

Reasons:
- Centralized security
- Easier updates
- Audit and logging
- Database not exposed to clients

## 5) Production Configuration Checklist
- Environment variables for secrets
- API base URL for clients
- SQL connection string
- CORS if cross-domain
- HTTPS enabled
- JWT auth enabled
- Logging enabled
- Backup strategy (daily/weekly)

## 6) Step-by-Step Flow
1. Build DB schema (EF migration)
2. Deploy SQL Server database
3. Publish and deploy API
4. Test API endpoints
5. Configure WinForms API URL
6. Publish installer
7. Install on client PCs

## 7) Final Deliverables
- Published API folder
- SQL database backup or migrations
- WinForms installer
- Configuration guide
- Admin credentials
- User manual
- Deployment documentation
