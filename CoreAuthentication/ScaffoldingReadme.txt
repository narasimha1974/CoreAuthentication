Support for ASP.NET Core Identity was added to your project
- The code for adding Identity to your project was generated under Areas/Identity.

Configuration of the Identity related services can be found in the Areas/Identity/IdentityHostingStartup.cs file.


The generated UI requires support for static files. To add static files to your app:
1. Call app.UseStaticFiles() from your Configure method

To use ASP.NET Core Identity you also need to enable authentication. To authentication to your app:
1. Call app.UseAuthentication() from your Configure method (after static files)

The generated UI requires MVC. To add MVC to your app:
1. Call services.AddMvc() from your ConfigureServices method
2. Call app.UseMvc() from your Configure method (after authentication)

Apps that use ASP.NET Core Identity should also use HTTPS. To enable HTTPS see https://go.microsoft.com/fwlink/?linkid=848054.



https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell
Example that scaffolds only selected tables and creates the context in a separate folder with a specified name:
Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables "Blog","Post" -ContextDir Context -Context BlogContext

Scaffold-DbContext "Server=DESKTOP-NB093L1\SQLEXPRESS;Database=aspnet-CoreAuthentication-BE4FE1DC-1288-4515-9E4A-1B6F524F8DF7;user Id=vista;Password=star;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir EntityModels -Tables "BrideOrGroom" -ContextDir Context -Context BrideOrGroom -Force