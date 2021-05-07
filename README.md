

First set src/Infrastructure as default project in Package Manager Console 

Add-migration InitialApp -OutputDir Data/Migrations -Context Infrastructure.Data.AppDbContext -StartupProject Web
remove-migration -context AppDbContext
update-database -context AppDbContext


Add-migration InitialIdentity -OutputDir Identity/Migrations -Context Infrastructure.Identity.AppIdentityDbContext -StartupProject Web
update-database -context Infrastructure.Identity.AppIdentityDbContext

# Creating AntiForgeryToken
https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-5.0#javascript
